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

namespace TibiaTools.Application.Forms.PlayerAlert
{
    public partial class PlayerAlert : Form
    {
        private readonly IWebSiteRequestService _requestService;
        private List<CharacterDTO> _charactersOnTable;

        private Thread addCharacterThread;
        private Thread updateTableThread;
        private System.Threading.Timer updateTableTimer;

        public PlayerAlert(IWebSiteRequestService requestService)
        {
            _charactersOnTable = new List<CharacterDTO>();
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
            updateTableTimer = new System.Threading.Timer(TableRefreshTimer, null, 0, 30000);
        }

        private void LoadTexts()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            this.labelHowItWorks.Text = resources.GetString("HowItWorksLastDeaths");
            this.labelInsertPlayerName.Text = resources.GetString("InsertPlayerName");
            this.buttonAddPlayer.Text = resources.GetString("AddPlayer");
            this.Text = resources.GetString("PlayerAlert");
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            if (String.IsNullOrEmpty(this.textBoxPlayerName.Text))
                return;

            if (_charactersOnTable.Any(x => x.Name.ToLower().Trim() == this.textBoxPlayerName.Text.ToLower().Trim()))
            {
                MessageBox.Show(resources.GetString("CharacterIsAlreadyInTable"));
                return;
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

                this.buttonAddPlayer.Enabled = false;
                this.buttonAddPlayer.Text = resources.GetString("AddPlayer");
            }
            catch (Exception)
            {
                MessageBox.Show(resources.GetString("UnableToConnectTibiaWebsite"));

                this.buttonAddPlayer.Enabled = false;
                this.buttonAddPlayer.Text = resources.GetString("AddPlayer");
            }
        }

        #region AddCharacterThread

        readonly object stateLock = new object();
        private void InsertCharacterOnTable()
        {
            lock (stateLock)
            {
                // does not allow add a character on table when refresh list
                while (updateTableThread.ThreadState != ThreadState.Stopped && updateTableThread.ThreadState != ThreadState.Unstarted)
                {
                    Thread.Sleep(1000);
                }

                var character = default(CharacterDTO);

                try
                {
                    character = _requestService.GetCharacterInformation(this.textBoxPlayerName.Text);
                    character.IsOnline = _requestService.GetOnlineCharacters(character.World).Any(x => x.Name.ToLower().Trim() == character.Name.ToLower().Trim());
                }
                catch (OfflineWorldException)
                {
                    character.IsOnline = false;
                }

                _charactersOnTable.Add(character);
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

        private void TableRefreshTimer(object stat)
        {
            if (updateTableThread == null || updateTableThread.ThreadState == ThreadState.Stopped || updateTableThread.ThreadState == ThreadState.Unstarted)
            {
                updateTableThread = new Thread(TableRefresh) { IsBackground = true };
                updateTableThread.Start();
            }
        }

        private void TableRefresh()
        {
            lock (stateLock)
            {
                for (var i = 0; i < _charactersOnTable.Count; i++)
                {
                    try
                    {
                        _charactersOnTable[i].IsOnline = _requestService.GetOnlineCharacters(_charactersOnTable[i].World).Any(x => x.Name.ToLower().Trim() == _charactersOnTable[i].Name.ToLower().Trim());
                    }
                    catch (OfflineWorldException)
                    {
                        _charactersOnTable[i].IsOnline = false;
                    }
                }

                UpdatePlayerTable();
            }
        }

        #endregion

        #region Helpers

        private DataTable UpdatePlayerTable()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            var table = new DataTable("TablePlayers");
            table.Columns.Add("Player");
            table.Columns.Add("World");
            table.Columns.Add("Voc");
            table.Columns.Add("IsOnline");
            table.Columns.Add("LastOnlineDate");
            table.Columns.Add("RemovePlayer");

            foreach (var character in _charactersOnTable)
            {
                if (character.IsOnline)
                {
                    table.Rows.Add(
                        character.Name,
                        character.World,
                        character.Vocation.GetVocationName(),
                        "Online",
                        resources.GetString("Now"),
                        "todo");
                }
                else
                {
                    table.Rows.Add(
                        character.Name,
                        character.World,
                        character.Vocation.GetVocationName(),
                        "Offline",
                        character.LastLogin,
                        "todo");
                }
            }

            return table;
        }

        #endregion
    }
}
