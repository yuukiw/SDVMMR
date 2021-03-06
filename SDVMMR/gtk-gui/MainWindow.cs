
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action Action;

	private global::Gtk.Action Play_SDV;

	private global::Gtk.Action add_Mod;

	private global::Gtk.Action applyAction1;

	private global::Gtk.Action open_Folder;

	private global::Gtk.Action goDownAction;

	private global::Gtk.Action dialogInfoAction;

	private global::Gtk.Action open_about;

	private global::Gtk.Action open_Settings;

	private global::Gtk.Action Action1;

	private global::Gtk.Action support;

	private global::Gtk.VBox vbox1;

	private global::Gtk.VBox vbox2;

	private global::Gtk.Image Header;

	private global::Gtk.Toolbar toolbar1;

	private global::Gtk.HButtonBox hbuttonbox3;

	private global::Gtk.Table table1;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView activeMods;

	private global::Gtk.Label label7;

	private global::Gtk.VBox vbox3;

	private global::Gtk.HBox hbox5;

	private global::Gtk.Label SDV_Version;

	private global::Gtk.Label SDVVersion;

	private global::Gtk.VSeparator vseparator1;

	private global::Gtk.Label SMAPI_Version;

	private global::Gtk.Label SMAPIVersion;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.Action = new global::Gtk.Action("Action", null, null, null);
		w1.Add(this.Action, null);
		this.Play_SDV = new global::Gtk.Action("Play_SDV", global::Mono.Unix.Catalog.GetString("Play SDV"), null, "SDVIcon");
		this.Play_SDV.HideIfEmpty = false;
		this.Play_SDV.IsImportant = true;
		this.Play_SDV.ShortLabel = global::Mono.Unix.Catalog.GetString("Play SDV");
		w1.Add(this.Play_SDV, null);
		this.add_Mod = new global::Gtk.Action("add_Mod", global::Mono.Unix.Catalog.GetString("add_Mod"), null, "gtk-add");
		this.add_Mod.ShortLabel = global::Mono.Unix.Catalog.GetString("add Mod");
		w1.Add(this.add_Mod, null);
		this.applyAction1 = new global::Gtk.Action("applyAction1", null, null, "gtk-apply");
		w1.Add(this.applyAction1, null);
		this.open_Folder = new global::Gtk.Action("open_Folder", null, null, "gtk-directory");
		this.open_Folder.ShortLabel = global::Mono.Unix.Catalog.GetString("open Folder");
		w1.Add(this.open_Folder, null);
		this.goDownAction = new global::Gtk.Action("goDownAction", null, null, "gtk-go-down");
		w1.Add(this.goDownAction, null);
		this.dialogInfoAction = new global::Gtk.Action("dialogInfoAction", null, null, "gtk-dialog-info");
		w1.Add(this.dialogInfoAction, null);
		this.open_about = new global::Gtk.Action("open_about", null, null, "gtk-dialog-info");
		this.open_about.ShortLabel = global::Mono.Unix.Catalog.GetString("About");
		w1.Add(this.open_about, null);
		this.open_Settings = new global::Gtk.Action("open_Settings", null, null, "gtk-preferences");
		this.open_Settings.ShortLabel = global::Mono.Unix.Catalog.GetString("Settings");
		w1.Add(this.open_Settings, null);
		this.Action1 = new global::Gtk.Action("Action1", null, null, null);
		w1.Add(this.Action1, null);
		this.support = new global::Gtk.Action("support", null, null, "gtk-about");
		w1.Add(this.support, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(5));
		this.DefaultWidth = 959;
		this.DefaultHeight = 600;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.VBox();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.Header = new global::Gtk.Image();
		this.Header.Name = "Header";
		this.Header.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("SDVMMR.SDVM.png");
		this.vbox2.Add(this.Header);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.Header]));
		w2.Position = 0;
		// Container child vbox2.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString(@"<ui><toolbar name='toolbar1'><toolitem name='Play_SDV' action='Play_SDV'/><separator/><toolitem name='add_Mod' action='add_Mod'/><toolitem name='open_Folder' action='open_Folder'/><toolitem name='open_Settings' action='open_Settings'/><separator/><toolitem name='open_about' action='open_about'/><toolitem name='support' action='support'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.vbox2.Add(this.toolbar1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.toolbar1]));
		w3.Position = 1;
		w3.Expand = false;
		this.vbox1.Add(this.vbox2);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbuttonbox3 = new global::Gtk.HButtonBox();
		this.hbuttonbox3.Name = "hbuttonbox3";
		this.vbox1.Add(this.hbuttonbox3);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox3]));
		w5.Position = 1;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(1)), false);
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		// Container child table1.Gtk.Table+TableChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.activeMods = new global::Gtk.TreeView();
		this.activeMods.CanFocus = true;
		this.activeMods.Name = "activeMods";
		this.GtkScrolledWindow.Add(this.activeMods);
		this.table1.Add(this.GtkScrolledWindow);
		global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow]));
		w7.TopAttach = ((uint)(1));
		w7.BottomAttach = ((uint)(2));
		// Container child table1.Gtk.Table+TableChild
		this.label7 = new global::Gtk.Label();
		this.label7.Name = "label7";
		this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Mods");
		this.table1.Add(this.label7);
		global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.label7]));
		w8.XOptions = ((global::Gtk.AttachOptions)(4));
		w8.YOptions = ((global::Gtk.AttachOptions)(4));
		this.vbox1.Add(this.table1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.table1]));
		w9.Position = 2;
		// Container child vbox1.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox5 = new global::Gtk.HBox();
		this.hbox5.Name = "hbox5";
		this.hbox5.Spacing = 6;
		// Container child hbox5.Gtk.Box+BoxChild
		this.SDV_Version = new global::Gtk.Label();
		this.SDV_Version.Name = "SDV_Version";
		this.SDV_Version.LabelProp = global::Mono.Unix.Catalog.GetString("SDV Version:");
		this.hbox5.Add(this.SDV_Version);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.SDV_Version]));
		w10.Position = 0;
		w10.Expand = false;
		w10.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.SDVVersion = new global::Gtk.Label();
		this.SDVVersion.Name = "SDVVersion";
		this.SDVVersion.LabelProp = global::Mono.Unix.Catalog.GetString("0.0.0");
		this.hbox5.Add(this.SDVVersion);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.SDVVersion]));
		w11.Position = 1;
		w11.Expand = false;
		w11.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.vseparator1 = new global::Gtk.VSeparator();
		this.vseparator1.Name = "vseparator1";
		this.hbox5.Add(this.vseparator1);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.vseparator1]));
		w12.Position = 2;
		w12.Expand = false;
		w12.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.SMAPI_Version = new global::Gtk.Label();
		this.SMAPI_Version.Name = "SMAPI_Version";
		this.SMAPI_Version.LabelProp = global::Mono.Unix.Catalog.GetString("SMAPI Version:");
		this.hbox5.Add(this.SMAPI_Version);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.SMAPI_Version]));
		w13.Position = 3;
		w13.Expand = false;
		w13.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.SMAPIVersion = new global::Gtk.Label();
		this.SMAPIVersion.Name = "SMAPIVersion";
		this.SMAPIVersion.LabelProp = global::Mono.Unix.Catalog.GetString("0.0.0");
		this.hbox5.Add(this.SMAPIVersion);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.SMAPIVersion]));
		w14.Position = 4;
		w14.Expand = false;
		w14.Fill = false;
		this.vbox3.Add(this.hbox5);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox5]));
		w15.Position = 0;
		w15.Expand = false;
		w15.Fill = false;
		this.vbox1.Add(this.vbox3);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox3]));
		w16.Position = 3;
		w16.Expand = false;
		w16.Fill = false;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.Show();
		this.Play_SDV.Activated += new global::System.EventHandler(this.OnPlaySDVActivated);
		this.add_Mod.Activated += new global::System.EventHandler(this.OnAddModActivated);
		this.open_Folder.Activated += new global::System.EventHandler(this.OnOpenFolderActivated);
		this.open_about.Activated += new global::System.EventHandler(this.OnOpenAboutActivated);
		this.open_Settings.Activated += new global::System.EventHandler(this.OnOpenSettingsActivated);
		this.support.Activated += new global::System.EventHandler(this.OnSupportActivated);
	}
}
