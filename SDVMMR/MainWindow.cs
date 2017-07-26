using System;
using Gtk;
using System.Collections.Generic;
using System.IO;

public partial class MainWindow : Gtk.Window
{
	internal List<SDVMMR.ModInfo> Mods = new List<SDVMMR.ModInfo>();
	internal Gtk.ListStore ModStore = new Gtk.ListStore(typeof(string), typeof(string),typeof(string),typeof(string));

	//  TODO Set GOOD default values for settings
	internal SDVMMR.SDVMMSettings SDVMMSettings = new SDVMMR.SDVMMSettings("", false, "", "", false, false, "");

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		this.Mods = SDVMMR.ModListManagment.LoadList(ModStore);
		//TODO parse mods into treeview
		Build();
		// Createing  columns
		Gtk.TreeViewColumn CBColumn = new Gtk.TreeViewColumn();
		CBColumn.Title = "Active";

		Gtk.CellRendererText CBCell = new Gtk.CellRendererText();
        CBColumn.PackStart(CBCell, true);

		Gtk.TreeViewColumn NameColumn = new Gtk.TreeViewColumn();
		NameColumn.Title = "Name";

		Gtk.CellRendererText ModsNameCell = new Gtk.CellRendererText();
		NameColumn.PackStart(ModsNameCell, true);

		Gtk.TreeViewColumn AuthorColumn = new Gtk.TreeViewColumn();
		AuthorColumn.Title = "Author";

		Gtk.CellRendererText AuthorCell = new Gtk.CellRendererText();
		AuthorColumn.PackStart(AuthorCell, true);

		Gtk.TreeViewColumn VersionColumn = new Gtk.TreeViewColumn();
		VersionColumn.Title = "Version";

		Gtk.CellRendererText VersionCell = new Gtk.CellRendererText();
		VersionColumn.PackStart(VersionCell, true);

		// Add the columns to the TreeView
		activeMods.AppendColumn(CBColumn);
		activeMods.AppendColumn(NameColumn);
		activeMods.AppendColumn(AuthorColumn);
		activeMods.AppendColumn(VersionColumn);

		NameColumn.AddAttribute(ModsNameCell, "text", 1);
		AuthorColumn.AddAttribute(AuthorCell, "text", 2);
		VersionColumn.AddAttribute(VersionCell, "text",3);

		// the column checkbox is created
		Gtk.CellRendererToggle valueCb = new CellRendererToggle();
		CBColumn.PackStart(valueCb, true);




		activeMods.Model = ModStore;
		//SDVMMR.ModListManagment.addToTree(SDVMMR.JsonHandler.readFromMod(System.IO.Path.Combine(SDVMMR.DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json")), ModStore);
	}




	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		SDVMMR.ModListManagment.SaveList(Mods);
		Application.Quit();
		a.RetVal = true;
	}

	public void MethodWithLogic(Gdk.Key key)
	{
		Boolean smapiisInstalled = true;
		if (key == Gdk.Key.Alt_R || key == Gdk.Key.Alt_L)
		{
			if (smapiisInstalled == true)
			{
				if (Play_SDV.StockId == "SIcon")
				{
					Play_SDV.StockId = "SDVIcon";
					Play_SDV.ShortLabel = "Play SDV";
				}
				else
				{
					Play_SDV.StockId = "SIcon";
					Play_SDV.ShortLabel = "Start SMAPI";
				}
			}
		}

	}

	protected void OnPlaySDVActivated(object sender, EventArgs e)
	{

	}
	protected void OnOpenSettingsActivated(object sender, EventArgs e)
	{
		SDVMMR.Setting Swin = new SDVMMR.Setting(SDVMMSettings, Mods);
		Swin.Show();
	}

	protected void OnAddModActivated(object sender, EventArgs e)
	{
		Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
				   "Choose the file to open",
				   this,
				   FileChooserAction.Open,
				   "Cancel", ResponseType.Cancel,
				   "Open", ResponseType.Accept);

		if (filechooser.Run() == (int)ResponseType.Accept)
		{
			System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);
			var folder = System.IO.Path.GetDirectoryName(filechooser.Filename);
			file.Close();
			if (System.IO.File.Exists(System.IO.Path.Combine(folder, "manifest.json")))
			{
				SDVMMR.ModListManagment.addMod(folder, this.Mods, this.ModStore);
				filechooser.Destroy();
			}
			else
			{
				SDVMMR.Message msg = new SDVMMR.Message("Please Choose the correct Folder.", "Wrong Folder");
				msg.Show();
				filechooser.Destroy();
			}
		}
	}



}
