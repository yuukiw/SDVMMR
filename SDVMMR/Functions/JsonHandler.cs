using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SDVMMR
{
	public class JsonHandler
	{
		string result = "";

		public string readFromJson(string Path)
		{
			return result;
		}



		public void writeToJSON(string SV, bool SisInst, string sFolder, string gFolder, bool gVersion, string filePath)
		{

			var results = new SDVMMJsonInfo
			{
				SmapiVersion = SV,
				SmapiIsinstalled = SisInst,
				SteamFolder = sFolder,
				GameFolder = gFolder,
				GoGVersion = gVersion
			};

			File.WriteAllText(filePath, JsonConvert.SerializeObject(results));
		}

		public void writeToJSON(string name, string author, string version, string filePath, string uid, string MiniApiVersion, string Desc, bool IsA, bool IsX, string OrgXP)
		{
			var results = new SDVMMJsonMods
			{
				Name = name,
				Author = author,
				Version = version,
				UniqueID = uid,
				MinimumApiVersion = MiniApiVersion,
				Description = Desc,
				IsActive = IsA,
				IsXnb = IsX,
				OrgXnbPath = OrgXP
			};

			File.WriteAllText(filePath, JsonConvert.SerializeObject(results));
		}
	}
}
