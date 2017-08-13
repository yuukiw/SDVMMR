using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVMMR
{
    public partial class Setting : Form
    {
        internal SDVMMSettings settings;
        internal static string lang;

        public Setting(SDVMMSettings Settings)
        {
            this.settings = Settings;
            InitializeComponent();
            lang = settings.Language;
            GeneralSettings.Text = MainWindow.Translation.SettingsCategoryName1;
            ModSettings.Text = MainWindow.Translation.SettingsCategoryName2;
            SteamSettings.Text = MainWindow.Translation.SettingsCategoryName3;
            SteamFolder.Text = MainWindow.Translation.SettingsSteamFolder;
            GameFolder.Text = MainWindow.Translation.SettingsGameFolder;
            IsGOG.Text = MainWindow.Translation.isGOG;
            Save.Text = MainWindow.Translation.SaveSettings;
            isGogBtn.Text = MainWindow.Translation.GOGChangeBtn;
            IsGOGBox.Text = settings.GoGVersion.ToString();
            overwriteButton.Text = MainWindow.Translation.overWriteGameFiles;
            SetVDF.Text = MainWindow.Translation.SettingsSetLaunchOptions;
            LanguageLabel.Text = MainWindow.Translation.Language;
            LanguageBox.DropDownStyle = ComboBoxStyle.DropDownList;
            if (MainWindow.SDVMMSettings.overWrite == true)
                overwriteButton.Checked = true;

            SteamFolderBox.Text = settings.SteamFolder;
            GameFolderBox.Text = settings.GameFolder;
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                SetVDF.Hide();

            var x = Directory.GetFiles(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations"), "*.json", SearchOption.TopDirectoryOnly).ToList();

            foreach (String y in x)
            {
                LanguageBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(y));
            }

            if (lang != null)
                LanguageBox.SelectedIndex = LanguageBox.FindStringExact(lang);
            else
                LanguageBox.SelectedIndex = LanguageBox.FindStringExact("en");

            if (settings.overWrite == true)
                overwriteButton.CheckState = CheckState.Checked;

            if (MainWindow.SDVMMSettings.Language == null)
                this.TopMost = true;

        }



        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SteamFolderBox.Text != "" & GameFolderBox.Text != "")
            {
                bool isGOG = Boolean.Parse(IsGOGBox.Text);
                bool overwrite = overwriteButton.CheckState == CheckState.Checked ? true : false;
                settings.Language = LanguageBox.Text;
                settings.GameFolder = GameFolderBox.Text;
                settings.SteamFolder = SteamFolderBox.Text;
                settings.GoGVersion = isGOG;
                settings.overWrite = overwrite;

                FileHandler.SaveSettings(this.settings);
                if (lang != settings.Language)
                {
                    DialogResult dialogResult = MessageBox.Show(MainWindow.Translation.LanguageChanged, MainWindow.Translation.LanguageChangedTitle, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }

            }
            else
            {
                MessageBox.Show(MainWindow.Translation.ValuesNotFound, "Error");
            }
        }

        private void SteamFolderBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SetVDF_Click(object sender, EventArgs e)
        {
            WriteToVDF.EditVDF(settings);
        }

        private void isGogBtn_Click(object sender, EventArgs e)
        {
            if (IsGOGBox.Text == "False")
                IsGOGBox.Text = "True";
            else
                IsGOGBox.Text = "False";
        }
    }
}
