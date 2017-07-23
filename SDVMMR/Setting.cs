using System;
using System.IO;
using Gtk;
using System.Collections.Generic;

namespace SDVMMR
{
	public partial class Setting : Gtk.Window
	{
		List<ModInfo> Mods;
		SDVMMSettings settings;

		public Setting(SDVMMSettings settings, List<ModInfo> mods) :
				base(Gtk.WindowType.Toplevel)
		{
			this.Mods = mods;
			this.settings = settings;
			this.Build();


		}

		protected void OnSteamFolderTNClicked(object sender, EventArgs e)
		{
			string folder = "";
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
					   "Choose the file to open",
					   this,
					   FileChooserAction.Open,
					   "Cancel", ResponseType.Cancel,
					   "Open", ResponseType.Accept);

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
					SDVMMR.Message msg = new Message("Please Choose the correct Folder.", "Wrong Folder");
					msg.Show();
					filechooser.Destroy();
				}
			}

		}

		protected void OnGameFolderBtnClicked(object sender, EventArgs e)
		{
			string folder = "";
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
					   "Choose the file to open",
					   this,
					   FileChooserAction.Open,
					   "Cancel", ResponseType.Cancel,
					   "Open", ResponseType.Accept);

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
					SDVMMR.Message msg = new Message("Please Choose the correct Folder.", "Wrong Folder");
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

		protected void OnOverWriteBtnClicked(object sender, EventArgs e)
		{
			if (overWriteLabel.Text == "won't be overwritten")
				overWriteLabel.Text = "will be overwritten";
			else
				overWriteLabel.Text = "won't be overwritten";
		}

		protected void OnSaveClicked(object sender, EventArgs e)
		{
			if (SteamFolderBox.Text != "" & GameFolderBox.Text != "")
			{
				string path = System.IO.Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json");
				bool help = false;
				if (GogBox.Text == "True")
					help = true;
				bool help2 = false;
				if (overWriteLabel.Text == "will be overwritten")
					help2 = true;
				JsonHandler json = new JsonHandler();
				var Info = json.readFromInfo(path);
				//  This createss a new one each time its run. instead change settings object and pass it to `writeToInfo`

				//json.writeToInfo("", true, SteamFolderBox.Text, GameFolderBox.Text, help, help2,path );
				settings.SmapiIsinstalled = true;
				// more settings
				json.writeToInfo(this.settings);
			}
			else
			{
				SDVMMR.Message msg = new Message("not all Values are set.", "Error");
				msg.Show();
			}
		}
	}
}
