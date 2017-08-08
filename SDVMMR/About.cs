using System;
using System.Collections.Generic;
using System.Drawing;

namespace SDVMMR
{
	public partial class About : Gtk.Window
	{
		internal Translations Translations;
		public About(Translations translation) :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.Translations = translation;
			Website.Text = translation.Website;
			WebsiteLink.Text = "google.gol";
			Translator.Text =translation.Translator;
			TranslatorName.Text = translation.TranslatorName;
			Version.Text = translation.Version;
			VersionNumber.Text = "1.0";
			FrameCredits.Text = translation.credits;
			FrameChangelog.Text = translation.ChangeLog;

		}
	}
}
