using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gtk;
using Newtonsoft.Json;

namespace SDVMMR
{
	public class JsonHandler
	{

		public SDVMMSettings readFromInfo()
		{
			string Path = System.IO.Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json");
			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<SDVMMSettings>(JsonData);
		}

		internal static ModInfo readFromMod(string Path)
		{

			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<ModInfo>(JsonData);
		}

		public GitHub readFromGit(string Path)
		{
			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<GitHub>(JsonData);
		}

		public ModManifest readFromModManifest(string Path)
		{
			string JsonData = File.ReadAllText(Path);
			return JsonConvert.DeserializeObject<ModManifest>(JsonData);
		}



		public void writeToInfo(SDVMMSettings settings)
		{
			//TODO path
			string path = Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(settings));
		}



		public void writeToMods(List<ModInfo> Mods)
		{

			// Write to JSON

			string path = Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(Mods));
		}

		public List<ModInfo> loadModList(ListStore ModStore)
		{
			if (!File.Exists(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json")))
			{
				var dir = System.IO.Path.GetDirectoryName(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json"));
				var file = File.Create(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json"));
				file.Close();
			}
			string JsonData = File.ReadAllText(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json"));


			return JsonData != null
				? (JsonConvert.DeserializeObject<List<ModInfo>>(JsonData) ?? new List<ModInfo>())
				 : new List<ModInfo>();
		}


		public void saveModInfoList(List<ModInfo> list)
		{
			File.WriteAllText(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json"), JsonConvert.SerializeObject(list));
		}
	}
}
