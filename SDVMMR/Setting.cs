using System;
using System.IO;
using Gtk;
using System.Collections.Generic;

namespace SDVMMR {
	public partial class Setting : Gtk.Window {
		List<ModInfo> Mods;
		SDVMMSettings settings;

		public Setting(SDVMMSettings settings, List<ModInfo> mods) :
				base(Gtk.WindowType.Toplevel) {
			this.Mods = mods;
			this.settings = settings;
			this.Build();


		}

		protected void OnSteamFolderTNClicked(object sender, EventArgs e) {
			string folder = "";
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
					   "Choose the file to open",
					   this,
					   FileChooserAction.Open,
					   "Cancel", ResponseType.Cancel,
					   "Open", ResponseType.Accept);

			if (filechooser.Run() == (int)ResponseType.Accept) {
				System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);
				folder = System.IO.Path.GetDirectoryName(filechooser.Filename);
				file.Close();
				if (System.IO.File.Exists(System.IO.Path.Combine(folder, "Steam.dll"))) {
					SteamFolderBox.Text = folder;
					filechooser.Destroy();
				} else {
					SDVMMR.Message msg = new Message("Please Choose the correct Folder.", "Wrong Folder");
					msg.Show();
					filechooser.Destroy();
				}
			}

		}

		protected void OnGameFolderBtnClicked(object sender, EventArgs e) {
			string folder = "";
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
					   "Choose the file to open",
					   this,
					   FileChooserAction.Open,
					   "Cancel", ResponseType.Cancel,
					   "Open", ResponseType.Accept);

			if (filechooser.Run() == (int)ResponseType.Accept) {
				System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);
				folder = System.IO.Path.GetDirectoryName(filechooser.Filename);
				file.Close();
				if (System.IO.File.Exists(System.IO.Path.Combine(folder, "Stardew Valley.exe"))) {
					GameFolderBox.Text = folder;
				} else {
					SDVMMR.Message msg = new Message("Please Choose the correct Folder.", "Wrong Folder");
					msg.Show();
				}
			}
		}

		protected void OnGogCBtnClicked(object sender, EventArgs e) {
			if (GogBox.Text == "False")
				GogBox.Text = "True";
			else
				GogBox.Text = "False";
		}

		protected void OnSaveClicked(object sender, EventArgs e) {
			if (SteamFolderBox.Text != "" & GameFolderBox.Text != "") {
				bool isGOG = (GogBox.Text == "True");
				bool overwrite = overwriteButton.Active;

				settings.GameFolder = GameFolderBox.Text;
				settings.SteamFolder = SteamFolderBox.Text;
				settings.GoGVersion = isGOG;
				settings.overWrite = overwrite;

				FileHandler.SaveSettings(this.settings);
			} else {
				SDVMMR.Message msg = new Message("not all Values are set.", "Error");
				msg.Show();
			}
		}
	}
}
