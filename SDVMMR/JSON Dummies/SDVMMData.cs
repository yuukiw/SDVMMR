using System;
using System.Collections.Generic;

namespace SDVMMR
{

	public class SDVMMData
	{
		public SDVMMSettings Settings { get; set; }
		public List<ModInfo> ModInfo { get; set; }
	}

	public class SDVMMSettings
	{
		public SDVMMSettings(string SV, bool SisInst, string sFolder, string gFolder, bool gVersion, bool ow, string filePath)
		{
			SmapiVersion = SV;
			SmapiIsinstalled = SisInst;
			SteamFolder = sFolder;
			GameFolder = gFolder;
			GoGVersion = gVersion;
			overWrite = ow;
		}

		public string SmapiVersion { get; set; }
		public bool SmapiIsinstalled { get; set; }
		public string SteamFolder { get; set; }
		public string GameFolder { get; set; }
		public bool GoGVersion { get; set; }
		public bool overWrite { get; set; }
	}

public class ModInfo
	{
	public ModInfo(string name, string author, string version, string filePath, string uid, string MiniApiVersion, string Desc, string entry,bool IsA, bool IsX, string OrgXP)
		{
			Name = name;
			Author = author;
			Version = version;
			UniqueID = uid;
			MinimumApiVersion = MiniApiVersion;
			Description = Desc;
			EntryDll = entry;
			IsActive = IsA;
			IsXnb = IsX;
			OrgXnbPath = OrgXP;
		}


		public string Name { get; set; }
		public string Author { get; set; }
		public string Version { get; set; }
		public string UniqueID { get; set; }
		public string MinimumApiVersion { get; set; }
		public string Description { get; set; }
		public string EntryDll { get; set;}
		public bool IsActive { get; set; }
		public bool IsXnb { get; set; }
		public string OrgXnbPath { get; set; }
	}
}