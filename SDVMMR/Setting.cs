using System;
namespace SDVMMR
{
	public partial class Setting : Gtk.Window
	{
		public Setting() :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();

		}

		protected void OnSteamFolderTNClicked(object sender, EventArgs e)
		{
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
				"Choose Path",
				this,
				Gtk.FileChooserAction.Open,
				"cancel",
				Gtk.ResponseType.Cancel,
				"Apply",
				Gtk.ResponseType.Apply);

			if (filechooser.Run() == (int)Gtk.ResponseType.Accept)
			{
				string file = filechooser.Uri;
			}
			filechooser.Destroy();


		}
	}
}
