using System;
using System.Diagnostics;

namespace SDVMMR
{
	public partial class OpenFolder : Gtk.Dialog
	{
		public OpenFolder()
		{
			this.Build();
			openGameFolder.Label = MainWindow.Translation.OpenGameDir;
			openSDVMMFolder.Label = MainWindow.Translation.OpenSDVMMDir;
			openAppDataFolder.Label = MainWindow.Translation.OpenAppdata;
		}

		protected void OnOpenAppDataFolderClicked(object sender, EventArgs e)
		{
			Process.Start(System.IO.Path.Combine(DirectoryOperations.getFolder("AppData"),"SDVMM"));
		}

		protected void OnOpenGameFolderClicked(object sender, EventArgs e)
		{
			Process.Start(MainWindow.SDVMMSettings.GameFolder);	
		}

		protected void OnOpenSDVMMFolderClicked(object sender, EventArgs e)
		{
			Process.Start(DirectoryOperations.getFolder("ExeFolder"));
		}

		protected void OnButtonOkClicked(object sender, EventArgs e)
		{
			this.Destroy();
		}
	}
}
