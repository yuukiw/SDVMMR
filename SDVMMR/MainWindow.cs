using System;
using Gtk;
using System.Collections.Generic;
using System.IO;
using SDVMMR;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;

public partial class MainWindow : Gtk.Window
{

	internal ModManager ModManager;
	private List<ModInfo> Mods => ModManager.Mods;

	ListStore ModStore => activeMods.Model as ListStore;

	internal static SDVMMSettings SDVMMSettings;

	internal string SDVMMVersion = "1.0";

	internal static Translations Translation;

	internal static string key = "";

	internal static string selectedItemName;
	internal static string selectedItemAuthor;
	internal static string selectedItemState;
	internal static string selectedUID;
	internal static bool itemChanged = false;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{

		SDVMMSettings = FileHandler.LoadSettings();


		if (SDVMMSettings.Language == null)
		{
			key = "en";
			Translation = FileHandler.LoadTranslations("en", new Translations());
			var x = Directory.GetFiles(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations"), "*.json", SearchOption.TopDirectoryOnly).ToList();
			if (x.Count == 2)
			{
				if (System.IO.Path.GetFileNameWithoutExtension(x[0]) != "en")
				{
					key = System.IO.Path.GetFileNameWithoutExtension(x[0]);
					FileHandler.LoadTranslations(key, Translation);

				}
				else
				{
					key = System.IO.Path.GetFileNameWithoutExtension(x[1]);
					FileHandler.LoadTranslations(key, MainWindow.Translation);

				}
			}
			if (x.Count > 2)
			{
				//todo
				key = null;
				Setting Swin = new Setting(SDVMMSettings);
				Swin.Show();
			}
		}
		else
		{
			key = SDVMMSettings.Language;
			Translation = FileHandler.LoadTranslations(key, new Translations());
		}

		SetupWindow();

		this.ModManager = new ModManager(SDVMMSettings, activeMods.Model as ListStore);


		string Sv = SDVMMSettings.SmapiVersion;
		string XnBVersion = "";
		foreach (ModInfo Mod in Mods)
			if (Mod.Name == "XNBLoader") XnBVersion = Mod.Version;


		Updates.CheckForUpdates(Sv, SDVMMVersion, XnBVersion, SDVMMSettings.GameFolder);


		RefreshTreeView();



		//SDVMMR.ModListManagment.addToTree(SDVMMR.JsonHandler.readFromMod(System.IO.Path.Combine(SDVMMR.DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json")), ModStore);
	}

	private void SetupWindow()
	{
		Build();
		//this.Title = "SDVMM 1.0";
		SDVVersion.Text = SDVMMVersion;
		SMAPIVersion.Text = SDVMMSettings.SmapiVersion;
		// Createing  columns
		Gtk.TreeViewColumn CBColumn = new Gtk.TreeViewColumn();
		CBColumn.Title = MainWindow.Translation.Active;

		Gtk.CellRendererText CBCell = new Gtk.CellRendererText();
		CBColumn.PackStart(CBCell, true);

		Gtk.TreeViewColumn NameColumn = new Gtk.TreeViewColumn();
		NameColumn.Title = Translation.Name;

		Gtk.CellRendererText ModsNameCell = new Gtk.CellRendererText();
		NameColumn.PackStart(ModsNameCell, true);

		Gtk.TreeViewColumn AuthorColumn = new Gtk.TreeViewColumn();
		AuthorColumn.Title = Translation.Author;

		Gtk.CellRendererText AuthorCell = new Gtk.CellRendererText();
		AuthorColumn.PackStart(AuthorCell, true);

		Gtk.TreeViewColumn VersionColumn = new Gtk.TreeViewColumn();
		VersionColumn.Title = Translation.Version;

		Gtk.CellRendererText VersionCell = new Gtk.CellRendererText();
		VersionColumn.PackStart(VersionCell, true);

		Gtk.TreeViewColumn DescColumn = new Gtk.TreeViewColumn();
		DescColumn.Title = Translation.Description;


		Gtk.CellRendererText DescCell = new Gtk.CellRendererText();
		DescColumn.PackStart(DescCell, true);

		Gtk.TreeViewColumn UIDColumn = new Gtk.TreeViewColumn();
		UIDColumn.Title = "";
		UIDColumn.Visible = false;


		Gtk.CellRendererText UIDCell = new Gtk.CellRendererText();
		UIDColumn.PackStart(UIDCell, true);



		// Add the columns to the TreeView
		activeMods.AppendColumn(CBColumn);
		activeMods.AppendColumn(NameColumn);
		activeMods.AppendColumn(AuthorColumn);
		activeMods.AppendColumn(VersionColumn);
		activeMods.AppendColumn(DescColumn);
		activeMods.AppendColumn(UIDColumn);

		activeMods.Model = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
		// the column checkbox is created
		Gtk.CellRendererText valueCb = new CellRendererText();
		CBColumn.PackStart(valueCb, true);

		CBColumn.AddAttribute(valueCb, "text", 0);
		NameColumn.AddAttribute(ModsNameCell, "text", 1);
		AuthorColumn.AddAttribute(AuthorCell, "text", 2);
		VersionColumn.AddAttribute(VersionCell, "text", 3);
		DescColumn.AddAttribute(DescCell, "text", 5);

		activeMods.Selection.Changed += (sender, e) =>
{

	Gtk.TreeIter selected;
	if (activeMods.Selection.GetSelected(out selected))
	{
		selectedItemName = ModStore.GetValue(selected, 1).ToString();
		selectedItemAuthor = ModStore.GetValue(selected, 2).ToString();
		selectedItemState = ModStore.GetValue(selected, 0).ToString();
		selectedUID = ModStore.GetValue(selected, 4).ToString();

		itemChanged = true;

	}
};
		Gtk.TreeIter iter;
		if (ModStore.GetIterFirst(out iter))
			activeMods.Selection.SelectIter(iter);

		activeMods.ButtonPressEvent += new ButtonPressEventHandler(onAMButtonPressed);
	}

	internal void RefreshTreeView()
	{
		ModStore.Clear();

		foreach (ModInfo Mod in Mods)
		{
			ModStore.AppendValues(Mod.IsActive.ToString(), Mod.Name, Mod.Author, Mod.Version, Mod.UniqueID);

		}
	}

	protected override bool OnDeleteEvent(Gdk.Event evnt)
	{
		base.OnDeleteEvent(evnt);
		FileHandler.SaveModList(Mods);
		Application.Quit();
		return true;
	}

	public bool exit()
	{
		FileHandler.SaveModList(Mods);
		Application.Quit();
		return true;
	}

	public void MethodWithLogic(Gdk.Key key)
	{
		Boolean smapiisInstalled = SDVMMSettings.SmapiIsinstalled;
		if (key == Gdk.Key.Alt_R || key == Gdk.Key.Alt_L)
		{
			if (smapiisInstalled == true)
			{
				if (Play_SDV.StockId == "SIcon")
				{
					Play_SDV.StockId = "SDVIcon";
					Play_SDV.ShortLabel = Translation.LaunchSDV;
				}
				else
				{
					Play_SDV.StockId = "SIcon";
					Play_SDV.ShortLabel = Translation.LaunchSMAPI;
				}
			}
		}

	}

	protected void OnPlaySDVActivated(object sender, EventArgs e)
	{

	}

	protected void OnOpenSettingsActivated(object sender, EventArgs e)
	{
		Setting Swin = new Setting(SDVMMSettings);
		Swin.Show();
	}

	protected void OnAddModActivated(object sender, EventArgs e)
	{
		Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
				   Translation.FCTitle,
				   this,
				   FileChooserAction.Open,
Translation.FCcancel, ResponseType.Cancel,
Translation.FCopen, ResponseType.Accept);
		filechooser.SelectMultiple = true;
		FileFilter filter = new FileFilter();
		filter.Name = Translation.FCMods;
		filter.AddPattern("*.dll");
		filter.AddPattern("*.xnb");
		filter.AddPattern("*.zip");
		filechooser.Filter = filter;
		if (filechooser.Run() == (int)ResponseType.Accept)
		{

			var folder = filechooser.Filename;
			ModManager.addMod(folder, false, "");
			RefreshTreeView();


			filechooser.Destroy();
		}

	}

	[GLib.ConnectBefore]
	protected void onAMButtonPressed(object o, ButtonPressEventArgs args)
	{
		if (args.Event.Button == 3)    // Right button click
		{

			if (selectedItemName != null & itemChanged == true)
			{
				itemChanged = false;

				Menu m = new Menu();
				string text = String.Join("", "Delete ", selectedItemName);
				MenuItem deleteItem = new MenuItem(text);
				deleteItem.ButtonPressEvent += new ButtonPressEventHandler(OnDeleteItemButtonPressed);
				m.Add(deleteItem);
				var mod = Mods.Where(x => x.UniqueID == selectedUID).FirstOrDefault();
				bool isX = mod.IsXnb;
				if (isX == false)
				{
					if (selectedItemState == "True")
					{
						text = String.Join("", "Deactivate ", selectedItemName);
					}
					else
					{
						text = String.Join("", "Activate ", selectedItemName);
					}
					MenuItem changeState = new MenuItem(text);
					changeState.ButtonPressEvent += new ButtonPressEventHandler(OnchangeStateButtonPressed);
					m.Add(changeState);


					MenuItem OpenFolder = new MenuItem("openFolder");
					OpenFolder.ButtonPressEvent += new ButtonPressEventHandler(OnOpenFolderButtonPressed);
					m.Add(OpenFolder);
				}

				m.ShowAll();
				m.Popup();
			}
		}
	}



	protected void OnDeleteItemButtonPressed(object sender, ButtonPressEventArgs e)
	{
		var itemToRemove = Mods.SingleOrDefault(r => r.UniqueID == selectedUID);
		if (itemToRemove.IsXnb == false)
		{

			if (itemToRemove.IsActive == true)
			{
				var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", selectedItemName.Replace(" ", "")));
				source.Delete();
			}
			else
			{
				var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", selectedItemName.Replace(" ", "")));
				source.Delete();
			}
		}
		else
		{
			if (SDVMMSettings.overWrite == false)
			{
				string name = string.Join(".", itemToRemove.Name, "xnb");
				recSearchForXNB.recXNB(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "XNBLoader", "content"), name, SDVMMSettings, ModStore, "", "remove", null);
			}
			else { 
            string name = string.Join(".", itemToRemove.Name, "xnb");
			string path = recSearchForXNB.recXNB(System.IO.Path.Combine(SDVMMSettings.GameFolder,"Content"), name, SDVMMSettings, ModStore, "", "remove",itemToRemove.UniqueID);
				if (path != null)
				{
					File.Delete(path);
					File.Copy(itemToRemove.OrgXnbPath, path);
				}
					    

			}
		}
		if (itemToRemove != null)
			Mods.Remove(itemToRemove);
		RefreshTreeView();
	}

	protected void OnchangeStateButtonPressed(object sender, ButtonPressEventArgs e)
	{
		try
		{
			if (!System.IO.Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods")))
			{
				System.IO.Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods"));
			}
			if (selectedItemState == "True")
			{

				var mod = Mods.Where(x => x.UniqueID == selectedUID).FirstOrDefault();
				mod.IsActive = false;
				bool isX = mod.IsXnb;
				//check
				if (isX == false)
				{
					if (!Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods")))
						Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods"));
					string destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", selectedItemName.Replace(" ", ""));
					var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", selectedItemName.Replace(" ", "")));
					var destination = new DirectoryInfo(destFolder);
					source.MoveMod(destination);
					source.Delete(true);
				}
				else
				{
					

				}


				FileHandler.SaveModList(Mods);

				RefreshTreeView();
			}
			else
			{
				var mod = Mods.Where(x => x.UniqueID == selectedUID).FirstOrDefault();
				mod.IsActive = true;
				bool isX = mod.IsXnb;
				if (isX == false)
				{
					string destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", selectedItemName.Replace(" ", ""));
					var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", selectedItemName.Replace(" ", "")));
					var destination = new DirectoryInfo(destFolder);
					source.MoveMod(destination);
					source.Delete(true);
				}
				else
				{

				}
				FileHandler.SaveModList(Mods);

				RefreshTreeView();
			}
		}
		catch (Exception ex)
		{
			Message msg = new Message(ex.Message, "error");
			msg.Show();
		}	}

	protected void OnOpenFolderButtonPressed(object sender, ButtonPressEventArgs e)
	{
		try
		{

			string source = "";
			if (selectedItemState == "True")
			{
				source = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", selectedItemName);
			}
			else
			{
				source = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", selectedItemName);
			}
			Process.Start(source);
		}
		catch (Exception ex)
		{
			Message msg = new Message(ex.Message, "error");
			msg.Show();
		}	}

}
