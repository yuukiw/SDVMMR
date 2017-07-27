using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gtk;
using Newtonsoft.Json;

namespace SDVMMR {
	public static class FileHandler {

		private static readonly string dataDirectory = DirectoryOperations.getFolder("AppData");

		public static SDVMMSettings LoadSettings() {
			string Path = System.IO.Path.Combine(dataDirectory, "SDVMM", "SDVMM.json");
			SDVMMSettings defaultSettings = new SDVMMSettings("", false, "", "", false, false, "");

			// TODO Set proper initial values for settings
			if (!File.Exists(Path))
				return defaultSettings;

			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<SDVMMSettings>(JsonData) ?? defaultSettings;
		}

		internal static ModInfo LoadModInfo(string Path) {

			if (!File.Exists(Path))
				return null;


			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<ModInfo>(JsonData);
		}

		public static GitHub LoadFromGit(string Path) {
			if (!File.Exists(Path))
				return null;

			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<GitHub>(JsonData);
		}

		public static ModManifest LoadModManifest(string Path) {
			if (!File.Exists(Path))
				return null;

			string JsonData = File.ReadAllText(Path);
			return JsonConvert.DeserializeObject<ModManifest>(JsonData);
		}



		public static void SaveSettings(SDVMMSettings settings) {
			//TODO path
			string path = Path.Combine(dataDirectory, "SDVMM", "SDVMM.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(settings));
		}



		public static void SaveModList(List<ModInfo> Mods) {

			// Write to JSON

			string path = Path.Combine(dataDirectory, "SDVMM", "Mods.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(Mods));
		}

		public static List<ModInfo> LoadModList() {

			string modListPath = Path.Combine(dataDirectory, "SDVMM", "Mods.json");

			if (!File.Exists(modListPath)) {
				return new List<ModInfo>();
			}

			string JsonData = File.ReadAllText(modListPath);

			return JsonConvert.DeserializeObject<List<ModInfo>>(JsonData) ?? new List<ModInfo>();
		}
	}
}
