using System;

using System.IO;
using Gtk;
using System.Collections.Generic;
using Pango;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace SDVMMR
{


	public partial class Setting : Gtk.Window
	{
		SDVMMSettings settings;

		internal static string lang;
		public Setting(SDVMMSettings settings) :
				base(Gtk.WindowType.Toplevel)
		{
			
			this.settings = settings;
			this.Build();
			lang = settings.Language;
			GeneralSettings.Text = MainWindow.Translation.SettingsCategoryName1;
			ModSettings.Text = MainWindow.Translation.SettingsCategoryName2;
			SteamSettings.Text = MainWindow.Translation.SettingsCategoryName3;
			SteamFolderLabel.Text = MainWindow.Translation.SettingsSteamFolder;
			GameFolderLabel.Text = MainWindow.Translation.SettingsGameFolder;
			GogLabel.Text = MainWindow.Translation.isGOG;
			Save.Label = MainWindow.Translation.SaveSettings;
			GogCBtn.Label = MainWindow.Translation.GOGChangeBtn;
			overwriteButton.Label = MainWindow.Translation.overWriteGameFiles;
			SetVDF.Label = MainWindow.Translation.SettingsSetLaunchOptions;
			LanguageLabel.Text = MainWindow.Translation.Language;
			if (MainWindow.SDVMMSettings.overWrite == true)
				overwriteButton.Active = true;

			SteamFolderBox.Text = settings.SteamFolder;
			GameFolderBox.Text = settings.GameFolder;
			if (Environment.OSVersion.Platform != PlatformID.Win32NT)
				SetVDF.Hide();

			var x = Directory.GetFiles(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations"), "*.json", SearchOption.TopDirectoryOnly).ToList();

			ListStore store = new ListStore(typeof(string));

			foreach (String name in x)
			{
				store.AppendValues(System.IO.Path.GetFileNameWithoutExtension(name));
			}
			LanguageBox.Model = store;
			LanguageBox.Active = 0;

			int help = 0;
			while (LanguageBox.ActiveText != lang)
			{
				if (lang == null)
					break;
				help++;
				LanguageBox.Active = help;
			}
			if (MainWindow.SDVMMSettings.Language == null)
			this.KeepAbove = true;

		}

		protected void OnSteamFolderTNClicked(object sender, EventArgs e)
		{
			string folder = "";
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
					   MainWindow.Translation.FCTitle,
					   this,
					   FileChooserAction.Open,
				MainWindow.Translation.FCcancel, ResponseType.Cancel,
					   MainWindow.Translation.FCopen, ResponseType.Accept);

			if (filechooser.Run() == (int)ResponseType.Accept)
			{
				System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);
				folder = System.IO.Path.GetDirectoryName(filechooser.Filename);
				file.Close();
				if (System.IO.File.Exists(System.IO.Path.Combine(folder, "Steam.dll")))
				{
					SteamFolderBox.Text = folder;
					filechooser.Destroy();
				}
				else
				{
					SDVMMR.Message msg = new Message(MainWindow.Translation.SettingsPathsnotSet, MainWindow.Translation.SettingsPathsnotSetTitle);
					msg.Show();
					filechooser.Destroy();
				}
			}

		}

		protected void OnGameFolderBtnClicked(object sender, EventArgs e)
		{
			string folder = "";
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
					   MainWindow.Translation.FCTitle,
					   this,
					   FileChooserAction.Open,
				MainWindow.Translation.FCcancel, ResponseType.Cancel,
					   MainWindow.Translation.FCopen, ResponseType.Accept);

			if (filechooser.Run() == (int)ResponseType.Accept)
			{
				System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);
				folder = System.IO.Path.GetDirectoryName(filechooser.Filename);
				file.Close();
				if (System.IO.File.Exists(System.IO.Path.Combine(folder, "Stardew Valley.exe")))
				{
					GameFolderBox.Text = folder;
				}
				else
				{
					SDVMMR.Message msg = new Message(MainWindow.Translation.SettingsPathsnotSet, MainWindow.Translation.SettingsPathsnotSetTitle);
					msg.Show();
				}
			}
		}

		protected void OnGogCBtnClicked(object sender, EventArgs e)
		{
			if (GogBox.Text == "False")
				GogBox.Text = "True";
			else
				GogBox.Text = "False";
		}

		protected void OnSaveClicked(object sender, EventArgs e)
		{
			if (SteamFolderBox.Text != "" & GameFolderBox.Text != "")
			{
				bool isGOG = (GogBox.Text == "True");
				bool overwrite = overwriteButton.Active;
				settings.Language = LanguageBox.ActiveText;
				settings.GameFolder = GameFolderBox.Text;
				settings.SteamFolder = SteamFolderBox.Text;
				settings.GoGVersion = isGOG;
				settings.overWrite = overwrite;

				FileHandler.SaveSettings(this.settings);
				if (lang != settings.Language)
				{
					DialogResult dialogResult = MessageBox.Show(MainWindow.Translation.LanguageChanged,MainWindow.Translation.LanguageChangedTitle, MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes)
					{
						Environment.Exit(0);
					}
				}
				this.Destroy();
			}
			else
			{
				SDVMMR.Message msg = new Message(MainWindow.Translation.ValuesNotFound, "Error");
				msg.Show();
			}
		}


		protected void OnSetVDFClicked(object sender, EventArgs e)
		{



			WriteToVDF.EditVDF(settings);
		}
	}
}
