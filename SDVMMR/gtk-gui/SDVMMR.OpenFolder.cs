
// This file has been generated by the GUI designer. Do not modify.
namespace SDVMMR
{
	public partial class OpenFolder
	{
		private global::Gtk.VBox vbox3;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Button openAppDataFolder;

		private global::Gtk.Button openGameFolder;

		private global::Gtk.Button openSDVMMFolder;

		private global::Gtk.Button buttonOk;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SDVMMR.OpenFolder
			this.Name = "SDVMMR.OpenFolder";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Resizable = false;
			this.AllowGrow = false;
			// Internal child SDVMMR.OpenFolder.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.openAppDataFolder = new global::Gtk.Button();
			this.openAppDataFolder.CanFocus = true;
			this.openAppDataFolder.Name = "openAppDataFolder";
			this.openAppDataFolder.UseUnderline = true;
			this.openAppDataFolder.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
			this.vbox4.Add(this.openAppDataFolder);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.openAppDataFolder]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.openGameFolder = new global::Gtk.Button();
			this.openGameFolder.CanFocus = true;
			this.openGameFolder.Name = "openGameFolder";
			this.openGameFolder.UseUnderline = true;
			this.openGameFolder.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
			this.vbox4.Add(this.openGameFolder);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.openGameFolder]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.openSDVMMFolder = new global::Gtk.Button();
			this.openSDVMMFolder.CanFocus = true;
			this.openSDVMMFolder.Name = "openSDVMMFolder";
			this.openSDVMMFolder.UseUnderline = true;
			this.openSDVMMFolder.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
			this.vbox4.Add(this.openSDVMMFolder);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.openSDVMMFolder]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox3.Add(this.vbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.vbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			w1.Add(this.vbox3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(w1[this.vbox3]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Internal child SDVMMR.OpenFolder.ActionArea
			global::Gtk.HButtonBox w7 = this.ActionArea;
			w7.Name = "dialog1_ActionArea";
			w7.Spacing = 10;
			w7.BorderWidth = ((uint)(5));
			w7.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget(this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w7[this.buttonOk]));
			w8.Expand = false;
			w8.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 201;
			this.Show();
			this.openAppDataFolder.Clicked += new global::System.EventHandler(this.OnOpenAppDataFolderClicked);
			this.openGameFolder.Clicked += new global::System.EventHandler(this.OnOpenGameFolderClicked);
			this.openSDVMMFolder.Clicked += new global::System.EventHandler(this.OnOpenSDVMMFolderClicked);
			this.buttonOk.Clicked += new global::System.EventHandler(this.OnButtonOkClicked);
		}
	}
}
