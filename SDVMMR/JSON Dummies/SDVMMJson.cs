using System;
namespace SDVMMR
{
	public class SDVMMJson
	{
		public SDVMMJsonInfo Info { get; set; }
		public SDVMMJsonMods[] Mods { get; set; }
	}

	public class SDVMMJsonInfo
	{
		public string SmapiVersion { get; set; }
		public bool SmapiIsinstalled { get; set; }
		public string SteamFolder { get; set; }
		public string GameFolder { get; set; }
		public bool GoGVersion { get; set; }
	}

	public class SDVMMJsonMods
	{
		public string Name { get; set; }
		public string Author { get; set; }
		public string Version { get; set; }
        public string UniqueID { get; set; }
		public string MinimumApiVersion { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public bool IsXnb { get; set; }
		public string OrgXnbPath { get; set; }
	}
}
