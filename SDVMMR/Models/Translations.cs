using System;
using Newtonsoft.Json.Linq;

namespace SDVMMR
{
	public class Translations
	{
		//MainWindow UI Toolbar
		public string LaunchSDV { get; set; }
		public string LaunchSMAPI { get; set; }
		public string AddMod { get; set; }
		public string openFolder { get; set; }
		public string Settings { get; set; }
		public string About { get; set; }
		public string Yes { get; set; }
		public string No { get; set; }
		//MainWindow Treeview
		public string TreeViewTitle { get; set; }
		public string Active { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string Version { get; set; }
		public string Description { get; set; }
        //Mod Actions
        public string delModDepError { get; set; }
        public string changeStateDepError { get; set; }
        //Settings
        public string SettingsCategoryName1 { get; set; }
		public string SettingsSteamFolder { get; set; }
		public string SettingsGameFolder { get; set; }
		public string isGOG { get; set; }
		public string GOGChangeBtn { get; set; }
		public string Language { get; set; }
		public string LanguageChanged { get; set; }
		public string LanguageChangedTitle { get; set; }
		public string SettingsCategoryName2 { get; set; }
		public string overWriteGameFiles { get; set; }
		public string SettingsCategoryName3 { get; set; }
		public string SettingsSetLaunchOptions { get; set; }
		public string SaveSettings { get; set; }
		public string SettingsPathsnotSet { get; set; }
		public string SettingsPathsnotSetTitle { get; set; }
		//Messages
		public string LaunchOptionExist { get; set; }
		public string LaunchOptionApplied { get; set; }
		public string SDVInstalled { get; set; }
		public string SMAPIUpdateFound { get; set; }
		public string SDVMMUpdateFound { get; set; }
		public string UpdateTitle { get; set; }
		public string ValuesNotFound { get; set; }
		//FileChooser
		public string FCMods { get; set; }
		public string FCTitle { get; set; }
		public string FCXNBTitle { get; set;}
		public string FCopen { get; set; }
		public string FCcancel { get; set; }
		//OpenFolder
		public string OpenAppdata { get; set; }
		public string OpenSDVMMDir { get; set; }
		public string OpenGameDir { get; set; }
		//About
		public string ChangeLog { get; set; }
		public string CurrentVersion { get; set; }
		public string Translator { get; set; }
		public string TranslatorName { get; set; }
		public string credits { get; set; }
		public string Website { get; set; }
		public string BuyMeACoffe { get; set; }
		//Updating
		public string UpdateDone { get; set; }
		public string Close { get; set; }

	}
}
