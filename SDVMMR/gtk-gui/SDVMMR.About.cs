
// This file has been generated by the GUI designer. Do not modify.
namespace SDVMMR
{
	public partial class About
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.VBox vbox7;

		private global::Gtk.Label Website;

		private global::Gtk.Label Translator;

		private global::Gtk.Label Version;

		private global::Gtk.VBox vbox6;

		private global::Gtk.Label WebsiteLink;

		private global::Gtk.Label TranslatorName;

		private global::Gtk.Label VersionNumber;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView ChangelogTV;

		private global::Gtk.Label FrameChangelog;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Frame frame2;

		private global::Gtk.Alignment GtkAlignment1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gtk.TextView CreditsTV;

		private global::Gtk.Label FrameCredits;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SDVMMR.About
			this.Name = "SDVMMR.About";
			this.Title = global::Mono.Unix.Catalog.GetString("About");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(5));
			// Container child SDVMMR.About.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.Website = new global::Gtk.Label();
			this.Website.WidthRequest = 80;
			this.Website.Name = "Website";
			this.Website.LabelProp = global::Mono.Unix.Catalog.GetString("label10");
			this.vbox7.Add(this.Website);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.Website]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.Translator = new global::Gtk.Label();
			this.Translator.WidthRequest = 80;
			this.Translator.Name = "Translator";
			this.Translator.LabelProp = global::Mono.Unix.Catalog.GetString("label12");
			this.vbox7.Add(this.Translator);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.Translator]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.Version = new global::Gtk.Label();
			this.Version.WidthRequest = 80;
			this.Version.Name = "Version";
			this.Version.LabelProp = global::Mono.Unix.Catalog.GetString("label14");
			this.vbox7.Add(this.Version);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.Version]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.hbox2.Add(this.vbox7);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox7]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox6 = new global::Gtk.VBox();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.WebsiteLink = new global::Gtk.Label();
			this.WebsiteLink.WidthRequest = 80;
			this.WebsiteLink.Name = "WebsiteLink";
			this.WebsiteLink.LabelProp = global::Mono.Unix.Catalog.GetString("label11");
			this.vbox6.Add(this.WebsiteLink);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.WebsiteLink]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.TranslatorName = new global::Gtk.Label();
			this.TranslatorName.WidthRequest = 80;
			this.TranslatorName.Name = "TranslatorName";
			this.TranslatorName.LabelProp = global::Mono.Unix.Catalog.GetString("label13");
			this.vbox6.Add(this.TranslatorName);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.TranslatorName]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.VersionNumber = new global::Gtk.Label();
			this.VersionNumber.WidthRequest = 80;
			this.VersionNumber.Name = "VersionNumber";
			this.VersionNumber.LabelProp = global::Mono.Unix.Catalog.GetString("label15");
			this.vbox6.Add(this.VersionNumber);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.VersionNumber]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			this.hbox2.Add(this.vbox6);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox6]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.hbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.hbox2]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ChangelogTV = new global::Gtk.TextView();
			this.ChangelogTV.CanFocus = true;
			this.ChangelogTV.Name = "ChangelogTV";
			this.GtkScrolledWindow.Add(this.ChangelogTV);
			this.GtkAlignment.Add(this.GtkScrolledWindow);
			this.frame1.Add(this.GtkAlignment);
			this.FrameChangelog = new global::Gtk.Label();
			this.FrameChangelog.Name = "FrameChangelog";
			this.FrameChangelog.LabelProp = global::Mono.Unix.Catalog.GetString("<b>GtkFrame</b>");
			this.FrameChangelog.UseMarkup = true;
			this.frame1.LabelWidget = this.FrameChangelog;
			this.vbox3.Add(this.frame1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.frame1]));
			w14.Position = 0;
			this.vbox2.Add(this.vbox3);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox3]));
			w15.Position = 1;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(12));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.CreditsTV = new global::Gtk.TextView();
			this.CreditsTV.CanFocus = true;
			this.CreditsTV.Name = "CreditsTV";
			this.GtkScrolledWindow1.Add(this.CreditsTV);
			this.GtkAlignment1.Add(this.GtkScrolledWindow1);
			this.frame2.Add(this.GtkAlignment1);
			this.FrameCredits = new global::Gtk.Label();
			this.FrameCredits.Name = "FrameCredits";
			this.FrameCredits.LabelProp = global::Mono.Unix.Catalog.GetString("<b>GtkFrame</b>");
			this.FrameCredits.UseMarkup = true;
			this.frame2.LabelWidget = this.FrameCredits;
			this.vbox4.Add(this.frame2);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.frame2]));
			w19.Position = 0;
			this.vbox2.Add(this.vbox4);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox4]));
			w20.Position = 2;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 719;
			this.DefaultHeight = 497;
			this.Show();
		}
	}
}
