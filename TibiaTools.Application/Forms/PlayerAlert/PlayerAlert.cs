using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;
using TibiaTools.Core.DTO.WebSiteDTO;
using TibiaTools.Core.Exceptions;
using TibiaTools.Core.Services.Contracts;
using TibiaTools.Domain.Enums;
using TibiaTools.Core.Extensions;
using TibiaTools.Application.Helpers.Contracts;

namespace TibiaTools.Application.Forms.PlayerAlert
{
    public partial class PlayerAlert : Form
    {
        private readonly IFormOpener _formOpener;
        private readonly ITimerHelper _timerHelper;
        private readonly IWebSiteRequestService _requestService;
        private List<CharacterDTO> _charactersOnTableOld;
        private List<CharacterDTO> _charactersOnTable;
        private List<CharacterDTO> _charactersToRemove; // need it to remotion be safe between threads

        private Thread addCharacterThread;
        private Thread updateTableThread;

        public PlayerAlert(IFormOpener formOpener,
            ITimerHelper timerHelper,
            IWebSiteRequestService requestService)
        {
            _charactersOnTable = new List<CharacterDTO>();
            _charactersToRemove = new List<CharacterDTO>();
            _formOpener = formOpener;
            _timerHelper = timerHelper;
            _requestService = requestService;

            InitializeComponent();
            LoadTexts();
            ManageEvents();
            ManageTableRefresh();
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void ManageTableRefresh()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));
            this.buttonAddPlayer.Enabled = false;
            this.buttonAddPlayer.Text = resources.GetString("Loading");
            this.tablePlayers.EmptyListMsg = resources.GetString("Loading");

            _timerHelper.TimerEvent += (timer, state) => TableRefreshTimer();
            _timerHelper.Start(20000, true);
        }

        private void LoadTexts()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            this.labelHowItWorks.Text = resources.GetString("HowItWorksLastDeaths");
            this.labelInsertPlayerName.Text = resources.GetString("InsertPlayerName");
            this.tablePlayers.EmptyListMsg = resources.GetString("EmptyList");
            this.buttonAddPlayer.Text = resources.GetString("AddPlayer");
            this.colPlayerName.Text = resources.GetString("Player");
            this.colLevel.Text = resources.GetString("Level");
            this.colWorld.Text = resources.GetString("World");
            this.colPlayerVocation.Text = resources.GetString("Voc");
            this.colIsOnline.Text = resources.GetString("Online");
            this.colLastOnlineDate.Text = resources.GetString("LastLogin");
            this.colRemovePlayer.Text = resources.GetString("RemovePlayer");
            this.Text = resources.GetString("PlayerAlert");
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            if (String.IsNullOrEmpty(this.textBoxPlayerName.Text))
                return;

            if (_charactersOnTable.Any(x => x.Name.ToLower() == this.textBoxPlayerName.Text.ToLower()))
            {
                if (_charactersToRemove.Any(x => x.Name.ToLower() == this.textBoxPlayerName.Text.ToLower()))
                {
                    _charactersToRemove.RemoveAll(x => x.Name.ToLower() == this.textBoxPlayerName.Text.ToLower());
                }
                else
                {
                    MessageBox.Show(resources.GetString("CharacterIsAlreadyInTable"));
                    return;
                }
            }

            try
            {
                this.buttonAddPlayer.Enabled = false;
                this.buttonAddPlayer.Text = resources.GetString("Loading");

                addCharacterThread = new Thread(InsertCharacterOnTable) { IsBackground = true };
                addCharacterThread.Start();
            }
            catch (InvalidCharacterException)
            {
                MessageBox.Show(resources.GetString("InvalidCharacterName"));

                this.buttonAddPlayer.Enabled = true;
                this.buttonAddPlayer.Text = resources.GetString("AddPlayer");
            }
        }

        #region AddCharacterThread

        readonly object stateLock = new object();
        private void InsertCharacterOnTable()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));
            lock (stateLock)
            {
                // does not allow add a character on table when refresh list
                while (updateTableThread != null && 
                    updateTableThread.ThreadState != ThreadState.Stopped && 
                    updateTableThread.ThreadState != ThreadState.Unstarted)
                {
                    Thread.Sleep(1000);
                }

                var character = default(CharacterDTO);

                if (_charactersOnTable.All(x => x.Name.ToLower().Trim() != this.textBoxPlayerName.Text.ToLower().Trim()))
                {
                    try
                    {
                        character = _requestService.GetCharacterInformation(this.textBoxPlayerName.Text);
                        character.IsOnline = _requestService.GetOnlineCharacters(character.World).Any(x => x.Name.ToLower() == character.Name.ToLower());

                        _charactersOnTable.Add(character);
                    }
                    catch (OfflineWorldException)
                    {
                        character.IsOnline = false;

                        _charactersOnTable.Add(character);
                    }
                    catch (InvalidCharacterException)
                    {
                        var message = resources.GetString("InvalidCharacterName");
                        MessageBox.Show(message);
                    }
                    catch (Exception)
                    {
                        var message = resources.GetString("UnableToConnectTibiaWebsite");
                        MessageBox.Show(message);
                    }
                }
            }

            Invoke(new MethodInvoker(InsertCharacterOnTableFinish));
        }

        private void InsertCharacterOnTableFinish()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));
            tablePlayers.DataSource = UpdatePlayerTable();
            buttonAddPlayer.Enabled = true;
            buttonAddPlayer.Text = resources.GetString("AddPlayer");
        }

        #endregion

        #region TableRefreshThread

        private void TableRefreshTimer()
        {
            if ((updateTableThread == null || 
                updateTableThread.ThreadState == ThreadState.Stopped || 
                updateTableThread.ThreadState == ThreadState.Unstarted) //run only one time per timer
                &&
                (addCharacterThread == null || 
                addCharacterThread.ThreadState == ThreadState.Stopped || 
                addCharacterThread.ThreadState == ThreadState.Unstarted)) // does not run with add character thread
            {
                updateTableThread = new Thread(TableRefresh) { IsBackground = true };
                updateTableThread.Start();
            }
        }

        private bool TableRefreshFirstTime = true;
        private void TableRefresh()
        {
            if (TableRefreshFirstTime)
            {
                var playersOnVip = UserSettings.RecoverVipList();

                if (playersOnVip != null && playersOnVip.Any())
                {
                    lock (stateLock)
                    {
                        foreach (var player in playersOnVip)
                        {
                            var character = default(CharacterDTO);
                            try
                            {
                                character = _requestService.GetCharacterInformation(player);
                                character.IsOnline = _requestService.GetOnlineCharacters(character.World).Any(x => x.Name.ToLower() == character.Name.ToLower());
                            }
                            catch (OfflineWorldException)
                            {
                                character.IsOnline = false;
                            }
                            catch
                            {
                                continue;
                            }

                            _charactersOnTable.Add(character);
                        }
                    }
                }

                _charactersOnTableOld = _charactersOnTable.DeepClone();
                TableRefreshFirstTime = false;
            }
            else
            {
                _charactersOnTableOld = _charactersOnTable.DeepClone();

                lock (stateLock)
                {
                    for (var i = 0; i < _charactersOnTable.Count; i++)
                    {
                        try
                        {
                            _charactersOnTable[i].IsOnline = _requestService.GetOnlineCharacters(_charactersOnTable[i].World).Any(x => x.Name.ToLower() == _charactersOnTable[i].Name.ToLower());
                        }
                        catch (OfflineWorldException)
                        {
                            _charactersOnTable[i].IsOnline = false;
                        }
                    }
                }
            }

            if (this == null || this.IsDisposed)
            {
                _timerHelper.Stop();
                updateTableThread.Abort();
                return;
            }

            Invoke(new MethodInvoker(TableRefreshFinish));
        }

        private void TableRefreshFinish()
        {
            // update players value on table
            tablePlayers.DataSource = UpdatePlayerTable();

            // alert user if a player online status changed
            foreach(var updatedCharacter in _charactersOnTable)
            {
                if (_charactersOnTableOld.Single(x => x.Name == updatedCharacter.Name).IsOnline != updatedCharacter.IsOnline)
                {
                    var playerDetectedForm = _formOpener.GetModelessForm<PlayerDetected>();
                    playerDetectedForm.InitializeForm(updatedCharacter);
                }
            }

            var resources = new SingleAssemblyResourceManager(typeof(Language));
            this.buttonAddPlayer.Enabled = true;
            this.buttonAddPlayer.Text = resources.GetString("AddPlayer");
            this.tablePlayers.EmptyListMsg = resources.GetString("EmptyList");
        }

        #endregion

        #region Helpers

        private DataTable UpdatePlayerTable()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            var table = new DataTable("TablePlayers");
            table.Columns.Add("Player");
            table.Columns.Add("Level");
            table.Columns.Add("World");
            table.Columns.Add("Voc");
            table.Columns.Add("IsOnline");
            table.Columns.Add("LastOnlineDate");
            table.Columns.Add("RemovePlayer");

            // remove undesired players
            if (_charactersToRemove.Any())
            {
                foreach (var characterToRemove in _charactersToRemove)
                {
                    _charactersOnTable.RemoveAll(x => x.Name == characterToRemove.Name);
                    _charactersOnTableOld.RemoveAll(x => x.Name == characterToRemove.Name);
                }

                _charactersToRemove = new List<CharacterDTO>();
            }
            
            // update table
            foreach (var character in _charactersOnTable)
            {
                if (character.IsOnline)
                {
                    table.Rows.Add(
                        character.Name,
                        character.Level,
                        character.World,
                        character.Vocation.GetVocationName(),
                        resources.GetString("Online"),
                        resources.GetString("Now"),
                        resources.GetString("Remove"));
                }
                else
                {
                    table.Rows.Add(
                        character.Name,
                        character.Level,
                        character.World,
                        character.Vocation.GetVocationName(),
                        resources.GetString("Offline"),
                        character.LastLogin,
                        resources.GetString("Remove"));
                }
            }

            UserSettings.RememberVipList(_charactersOnTable.Select(x => x.Name));

            return table;
        }

        #endregion
    }
}
