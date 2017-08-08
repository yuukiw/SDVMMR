using System;
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
	}
}
