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

		public SDVMMSettings readFromInfo(string Path)
		{
			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<SDVMMSettings>(JsonData);
		}

		public ModInfo readFromMod(string Path)
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
			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
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
			// TODO path
			string path = Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(Mods));
		}

		List<ModInfo> loadModList()
		{
			StreamReader read = new StreamReader(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json"));
			string JsonData = read.ReadToEnd();
			read.Close();

			return JsonConvert.DeserializeObject<List<ModInfo>>(JsonData);
		}


		void saveModInfoList(List<ModInfo> list)
		{
			File.WriteAllText(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json"), JsonConvert.SerializeObject(list));
		}
}
}
