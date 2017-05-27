using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;
using TibiaTools.Core.DTO.WebSiteDTO;
using TibiaTools.Core.Exceptions;
using TibiaTools.Core.Services.Contracts;

namespace TibiaTools.Application.Forms.PlayersDeaths
{
    public partial class LastPlayersDeaths : Form
    {
        private readonly IWebSiteRequestService _requestService;

        public LastPlayersDeaths(IWebSiteRequestService requestService)
        {
            characters = new List<CharacterDTO>();
            _requestService = requestService;

            InitializeComponent();
            LoadTexts();
            ManageEvents();
            ManageWorlds();
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void LoadTexts()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            this.labelHowItWorks.Text = resources.GetString("HowItWorks");
            this.labelSelectWorld.Text = resources.GetString("SelectWorld");
            this.tableDeath.EmptyListMsg = resources.GetString("SelectWorldAndStart");
            this.ButtonSearch.Text = resources.GetString("Search");
            this.Text = resources.GetString("LastPlayersDeaths");
        }

        private void ManageWorlds()
        {
            try
            {
                object[] worlds = _requestService
                    .GetAllWorlds()
                    .Select(x => new { Text = x, Value = x })
                    .ToArray();

                this.comboBoxWorlds.DataSource = worlds;
                this.comboBoxWorlds.SelectedIndex = 0;
            }
            catch
            {
                var resources = new SingleAssemblyResourceManager(typeof(Language));
                MessageBox.Show(resources.GetString("UnableToConnectInternet"));
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));
            selectedWorld = (comboBoxWorlds.SelectedItem as dynamic).Value.ToString();

            if (String.IsNullOrEmpty(selectedWorld)) return;

            try
            {
                tableDeath.DataSource = null;
                ButtonSearch.Text = resources.GetString("Loading");
                this.tableDeath.EmptyListMsg = resources.GetString("Loading");
                ButtonSearch.Enabled = false;

                var t = new Thread(GetCharacterDeaths) { IsBackground = true };
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(resources.GetString("UnableToConnectInternet"));

                ButtonSearch.Enabled = true;
                ButtonSearch.Text = resources.GetString("Search");
                this.tableDeath.EmptyListMsg = resources.GetString("SelectWorldAndStart");
            }
        }

        private DataTable DataTableDeathCharacters(int lastHours = 3)
        {
            var table = new DataTable("tableDeath");
            table.Columns.Add("Player");
            table.Columns.Add("Voc");
            table.Columns.Add("Date");
            table.Columns.Add("Message");

            foreach (var character in characters.Where(x => x.Deaths != null))
            {
                foreach (var death in character.Deaths.Where(y => DateTime.Now < y.Date.AddHours(lastHours)))
                {
                    table.Rows.Add(
                        character.Name,
                        Regex.Replace(character.Vocation.ToString(), "([A-Z])", " $1", RegexOptions.Compiled).Trim(),
                        death.Date,
                        death.Message);
                }
            }

            return table;
        }

        private void GetCharacterDeaths()
        {
            var updateCounterDelegate = new MethodInvoker(UpdateCount);

            lock (stateLock)
            {
                numPlayersOnline = 0;
                numPlayerCount = 0;
            }
            Invoke(updateCounterDelegate);

            lock (stateLock)
            {
                try
                {
                    characters = _requestService.GetOnlineCharacters(selectedWorld).ToList();
                }
                catch (OfflineWorldException ex)
                {
                    var resources = new SingleAssemblyResourceManager(typeof(Language));
                    MessageBox.Show(resources.GetString("SelectedWorldIsOffline"));

                    Invoke(new MethodInvoker(Finish));
                    return;
                }

                numPlayersOnline = characters.Count;
            }

            // I tested a parallel for. Does not worth.
            for (var i = 0; i < characters.Count; i++)
            {
                lock (stateLock)
                {
                    var charName = characters[i].Name;
                    do
                    {
                        characters[i] = _requestService.GetCharacterInformation(charName);
                    }
                    while (String.IsNullOrEmpty(characters[i].Name));
                    numPlayerCount++;
                }

                Invoke(updateCounterDelegate);
            }

            Invoke(new MethodInvoker(Finish));
        }

        private void UpdateCount()
        {
            lock (stateLock)
            {
                if (numPlayerCount != 0)
                    progressBar.Value = (int)(((double)numPlayerCount * 100d) / (double)numPlayersOnline);
            }
        }

        private void Finish()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));
            tableDeath.DataSource = DataTableDeathCharacters();
            ButtonSearch.Enabled = true;
            ButtonSearch.Text = resources.GetString("Search");
            this.tableDeath.EmptyListMsg = resources.GetString("SelectWorldAndStart");
            progressBar.Value = 100;
        }

        List<CharacterDTO> characters;
        string selectedWorld;
        readonly object stateLock = new object();
        int numPlayersOnline;
        int numPlayerCount;
    }
}
