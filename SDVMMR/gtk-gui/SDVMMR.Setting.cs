
// This file has been generated by the GUI designer. Do not modify.
namespace SDVMMR
{
	public partial class Setting
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Label label1;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label SteamFolderLabel;

		private global::Gtk.Entry SteamFolderBox;

		private global::Gtk.Button SteamFolderTN;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label GameFolderLabel;

		private global::Gtk.Entry GameFolderBox;

		private global::Gtk.Button GameFolderBtn;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label GogLabel;

		private global::Gtk.Entry GogBox;

		private global::Gtk.Button GogCBtn;

		private global::Gtk.HSeparator hseparator2;

		private global::Gtk.Label label6;

		private global::Gtk.HSeparator hseparator3;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label OverWrite;

		private global::Gtk.Label overWriteLabel;

		private global::Gtk.Button OverWriteBtn;

		private global::Gtk.HBox hbox7;

		private global::Gtk.HSeparator hseparator4;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Button Save;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SDVMMR.Setting
			this.Name = "SDVMMR.Setting";
			this.Title = global::Mono.Unix.Catalog.GetString("Setting");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(5));
			this.Resizable = false;
			this.AllowGrow = false;
			// Container child SDVMMR.Setting.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("<b>General Settings</b>");
			this.label1.UseMarkup = true;
			this.vbox2.Add(this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.vbox2.Add(this.hseparator1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hseparator1]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.SteamFolderLabel = new global::Gtk.Label();
			this.SteamFolderLabel.WidthRequest = 80;
			this.SteamFolderLabel.Name = "SteamFolderLabel";
			this.SteamFolderLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Steam folder");
			this.hbox2.Add(this.SteamFolderLabel);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.SteamFolderLabel]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.SteamFolderBox = new global::Gtk.Entry();
			this.SteamFolderBox.CanFocus = true;
			this.SteamFolderBox.Name = "SteamFolderBox";
			this.SteamFolderBox.IsEditable = true;
			this.SteamFolderBox.InvisibleChar = '●';
			this.hbox2.Add(this.SteamFolderBox);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.SteamFolderBox]));
			w4.Position = 1;
			// Container child hbox2.Gtk.Box+BoxChild
			this.SteamFolderTN = new global::Gtk.Button();
			this.SteamFolderTN.WidthRequest = 60;
			this.SteamFolderTN.CanFocus = true;
			this.SteamFolderTN.Name = "SteamFolderTN";
			this.SteamFolderTN.UseUnderline = true;
			global::Gtk.Image w5 = new global::Gtk.Image();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-directory", global::Gtk.IconSize.Menu);
			this.SteamFolderTN.Image = w5;
			this.hbox2.Add(this.SteamFolderTN);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.SteamFolderTN]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			w6.Padding = ((uint)(5));
			this.vbox2.Add(this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.GameFolderLabel = new global::Gtk.Label();
			this.GameFolderLabel.WidthRequest = 80;
			this.GameFolderLabel.Name = "GameFolderLabel";
			this.GameFolderLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Game folder");
			this.hbox3.Add(this.GameFolderLabel);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.GameFolderLabel]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.GameFolderBox = new global::Gtk.Entry();
			this.GameFolderBox.CanFocus = true;
			this.GameFolderBox.Name = "GameFolderBox";
			this.GameFolderBox.IsEditable = true;
			this.GameFolderBox.InvisibleChar = '●';
			this.hbox3.Add(this.GameFolderBox);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.GameFolderBox]));
			w9.Position = 1;
			// Container child hbox3.Gtk.Box+BoxChild
			this.GameFolderBtn = new global::Gtk.Button();
			this.GameFolderBtn.WidthRequest = 60;
			this.GameFolderBtn.CanFocus = true;
			this.GameFolderBtn.Name = "GameFolderBtn";
			this.GameFolderBtn.UseUnderline = true;
			global::Gtk.Image w10 = new global::Gtk.Image();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-directory", global::Gtk.IconSize.Menu);
			this.GameFolderBtn.Image = w10;
			this.hbox3.Add(this.GameFolderBtn);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.GameFolderBtn]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			w11.Padding = ((uint)(5));
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.GogLabel = new global::Gtk.Label();
			this.GogLabel.WidthRequest = 80;
			this.GogLabel.Name = "GogLabel";
			this.GogLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Is GOG");
			this.hbox4.Add(this.GogLabel);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.GogLabel]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.GogBox = new global::Gtk.Entry();
			this.GogBox.CanFocus = true;
			this.GogBox.Name = "GogBox";
			this.GogBox.Text = global::Mono.Unix.Catalog.GetString("False");
			this.GogBox.IsEditable = true;
			this.GogBox.InvisibleChar = '●';
			this.hbox4.Add(this.GogBox);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.GogBox]));
			w14.Position = 1;
			// Container child hbox4.Gtk.Box+BoxChild
			this.GogCBtn = new global::Gtk.Button();
			this.GogCBtn.WidthRequest = 60;
			this.GogCBtn.CanFocus = true;
			this.GogCBtn.Name = "GogCBtn";
			this.GogCBtn.UseUnderline = true;
			this.GogCBtn.Label = global::Mono.Unix.Catalog.GetString("change");
			this.hbox4.Add(this.GogCBtn);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.GogCBtn]));
			w15.Position = 2;
			w15.Expand = false;
			w15.Fill = false;
			w15.Padding = ((uint)(5));
			this.vbox2.Add(this.hbox4);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
			w16.Position = 4;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator2 = new global::Gtk.HSeparator();
			this.hseparator2.Name = "hseparator2";
			this.vbox2.Add(this.hseparator2);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hseparator2]));
			w17.Position = 5;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Mod Settings</b>");
			this.label6.UseMarkup = true;
			this.vbox2.Add(this.label6);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label6]));
			w18.Position = 6;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator3 = new global::Gtk.HSeparator();
			this.hseparator3.Name = "hseparator3";
			this.vbox2.Add(this.hseparator3);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hseparator3]));
			w19.Position = 7;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.OverWrite = new global::Gtk.Label();
			this.OverWrite.WidthRequest = 80;
			this.OverWrite.Name = "OverWrite";
			this.OverWrite.LabelProp = global::Mono.Unix.Catalog.GetString("Game files");
			this.hbox6.Add(this.OverWrite);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.OverWrite]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.overWriteLabel = new global::Gtk.Label();
			this.overWriteLabel.WidthRequest = 0;
			this.overWriteLabel.Name = "overWriteLabel";
			this.overWriteLabel.LabelProp = global::Mono.Unix.Catalog.GetString("won\'t be overwritten");
			this.overWriteLabel.Justify = ((global::Gtk.Justification)(3));
			this.hbox6.Add(this.overWriteLabel);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.overWriteLabel]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			w21.Padding = ((uint)(5));
			// Container child hbox6.Gtk.Box+BoxChild
			this.OverWriteBtn = new global::Gtk.Button();
			this.OverWriteBtn.WidthRequest = 60;
			this.OverWriteBtn.CanFocus = true;
			this.OverWriteBtn.Name = "OverWriteBtn";
			this.OverWriteBtn.UseUnderline = true;
			this.OverWriteBtn.Label = global::Mono.Unix.Catalog.GetString("Change");
			this.hbox6.Add(this.OverWriteBtn);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.OverWriteBtn]));
			w22.PackType = ((global::Gtk.PackType)(1));
			w22.Position = 2;
			w22.Expand = false;
			w22.Fill = false;
			w22.Padding = ((uint)(5));
			this.vbox2.Add(this.hbox6);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox6]));
			w23.Position = 8;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			this.vbox2.Add(this.hbox7);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox7]));
			w24.Position = 9;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator4 = new global::Gtk.HSeparator();
			this.hseparator4.Name = "hseparator4";
			this.vbox2.Add(this.hseparator4);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hseparator4]));
			w25.Position = 10;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.Save = new global::Gtk.Button();
			this.Save.WidthRequest = 60;
			this.Save.CanFocus = true;
			this.Save.Name = "Save";
			this.Save.UseUnderline = true;
			this.Save.Label = global::Mono.Unix.Catalog.GetString("Save");
			this.hbox5.Add(this.Save);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.Save]));
			w26.PackType = ((global::Gtk.PackType)(1));
			w26.Position = 2;
			w26.Expand = false;
			w26.Fill = false;
			w26.Padding = ((uint)(5));
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w27.Position = 11;
			w27.Expand = false;
			w27.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 840;
			this.DefaultHeight = 464;
			this.Show();
			this.SteamFolderTN.Clicked += new global::System.EventHandler(this.OnSteamFolderTNClicked);
			this.GameFolderBtn.Clicked += new global::System.EventHandler(this.OnGameFolderBtnClicked);
			this.GogCBtn.Clicked += new global::System.EventHandler(this.OnGogCBtnClicked);
			this.OverWriteBtn.Clicked += new global::System.EventHandler(this.OnOverWriteBtnClicked);
			this.Save.Clicked += new global::System.EventHandler(this.OnSaveClicked);
		}
	}
}