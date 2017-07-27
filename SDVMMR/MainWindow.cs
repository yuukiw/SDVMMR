﻿using System;
using Gtk;
using System.Collections.Generic;
using System.IO;
using SDVMMR;

public partial class MainWindow : Gtk.Window {

	internal ModManager ModManager;
	private List<ModInfo> Mods => ModManager.Mods;

	ListStore ModStore => activeMods.Model as ListStore;

	internal SDVMMSettings SDVMMSettings;

	internal string SDVMMVersion = "1.0";

	public MainWindow() : base(Gtk.WindowType.Toplevel) {

		this.SDVMMSettings = FileHandler.LoadSettings();

		string Sv = SDVMMSettings.SmapiVersion;
		string XnBVersion = "";
		foreach (ModInfo Mod in Mods) 
			if (Mod.Name == "XNBLoader") XnBVersion = Mod.Version;	

		Updates.CheckForUpdates(Sv,SDVMMVersion,XnBVersion);

		SetupWindow();

		this.ModManager = new ModManager(SDVMMSettings, activeMods.Model as ListStore);

		RefreshTreeView();

		//SDVMMR.ModListManagment.addToTree(SDVMMR.JsonHandler.readFromMod(System.IO.Path.Combine(SDVMMR.DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json")), ModStore);
	}

	private void SetupWindow() {
		Build();
		//this.Title = "SDVMM 1.0";
		SDVVersion.Text = SDVMMVersion;
		SMAPIVersion.Text = SDVMMSettings.SmapiVersion;
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

		Gtk.TreeViewColumn DescColumn = new Gtk.TreeViewColumn();
		DescColumn.Title = "Description";


		Gtk.CellRendererText DescCell = new Gtk.CellRendererText();
		DescColumn.PackStart(DescCell, true);

		// Add the columns to the TreeView
		activeMods.AppendColumn(CBColumn);
		activeMods.AppendColumn(NameColumn);
		activeMods.AppendColumn(AuthorColumn);
		activeMods.AppendColumn(VersionColumn);
		activeMods.AppendColumn(DescColumn);

		activeMods.Model = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));

		NameColumn.AddAttribute(ModsNameCell, "text", 1);
		AuthorColumn.AddAttribute(AuthorCell, "text", 2);
		VersionColumn.AddAttribute(VersionCell, "text", 3);
		DescColumn.AddAttribute(DescCell, "text", 4);

		// the column checkbox is created
		Gtk.CellRendererToggle valueCb = new CellRendererToggle();
		CBColumn.PackStart(valueCb, true);

	}

	internal void RefreshTreeView() {
		ModStore.Clear();
		foreach (ModInfo Mod in Mods) {
			ModStore.AppendValues(Mod.IsActive.ToString(), Mod.Name, Mod.Author, Mod.Version);
		}
	}

	protected override bool OnDeleteEvent(Gdk.Event evnt) {
		base.OnDeleteEvent(evnt);
		FileHandler.SaveModList(Mods);
		Application.Quit();
		return true;
	}

	public void MethodWithLogic(Gdk.Key key) {
		Boolean smapiisInstalled = SDVMMSettings.SmapiIsinstalled;
		if (key == Gdk.Key.Alt_R || key == Gdk.Key.Alt_L) {
			if (smapiisInstalled == true) {
				if (Play_SDV.StockId == "SIcon") {
					Play_SDV.StockId = "SDVIcon";
					Play_SDV.ShortLabel = "Play SDV";
				} else {
					Play_SDV.StockId = "SIcon";
					Play_SDV.ShortLabel = "Start SMAPI";
				}
			}
		}

	}

	protected void OnPlaySDVActivated(object sender, EventArgs e) {

	}

	protected void OnOpenSettingsActivated(object sender, EventArgs e) {
		Setting Swin = new Setting(SDVMMSettings, Mods);
		Swin.Show();
	}

	protected void OnAddModActivated(object sender, EventArgs e) {
		Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
				   "Choose the file to open",
				   this,
				   FileChooserAction.Open,
				   "Cancel", ResponseType.Cancel,
				   "Open", ResponseType.Accept);

		if (filechooser.Run() == (int)ResponseType.Accept) {

			var folder = System.IO.Path.GetDirectoryName(filechooser.Filename);
			if (File.Exists(System.IO.Path.Combine(folder, "manifest.json"))) {

				ModManager.addMod(folder);
				RefreshTreeView();

			} else {
				Message msg = new Message("Please Choose the correct Folder.", "Wrong Folder");
				msg.Show();
				RefreshTreeView();
			}

			filechooser.Destroy();
		}

	}

}
