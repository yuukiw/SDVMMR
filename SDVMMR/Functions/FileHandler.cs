using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using Newtonsoft.Json;


namespace SDVMMR
{
	public static class FileHandler
	{

		private static readonly string dataDirectory = DirectoryOperations.getFolder("AppData");

		public static SDVMMSettings LoadSettings()
		{
			string Path = System.IO.Path.Combine(dataDirectory, "SDVMM", "SDVMM.json");

			// TODO Set proper initial values for settings
			if (!File.Exists(Path))
				return CreateDefaultSettings();


			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();

			var loadedSettings = JsonConvert.DeserializeObject<SDVMMSettings>(JsonData);

			// always check for SMAPI version
			if (loadedSettings == null)
				loadedSettings.SmapiVersion = getSMAPIVersion(loadedSettings.GameFolder);

			return loadedSettings ?? CreateDefaultSettings();
		}

		internal static ModInfo LoadModInfo(string Path)
		{

			if (!File.Exists(Path))
				return null;

			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<ModInfo>(JsonData);
		}

		/*public static GitHub.GitRelease LoadFromGit(string Path) {
			if (!File.Exists(Path))
				return null;

			StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();
			return JsonConvert.DeserializeObject<GitHub.GitRelease>(JsonData);
		}*/

		public static ModManifest LoadModManifest(string Path)
		{
			if (!File.Exists(Path))
				return null;

			string JsonData = File.ReadAllText(Path);
			return JsonConvert.DeserializeObject<ModManifest>(JsonData);
		}

		internal static Translations LoadTranslations(string key, Translations obj)
		{
			try
			{
				string path = Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations", $"{key}.json");
				if (!File.Exists(path))
					return obj;

				string text = File.ReadAllText(path);
				JsonConvert.PopulateObject(text, obj);
				return obj;
			}
			catch (Exception)
			{
				Message msg = new Message("Couldn`t load the Translation. Defaulting to English", "Translation Error");
				string path = Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations", "en.json");
				if (!File.Exists(path))
					return obj;

				string text = File.ReadAllText(path);
				JsonConvert.PopulateObject(text, obj);
				return obj;
			}
		}


		public static void SaveSettings(SDVMMSettings settings)
		{

			string path = Path.Combine(dataDirectory, "SDVMM", "SDVMM.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(settings));
		}

		public static void SaveModList(List<ModInfo> Mods)
		{

			// Write to JSON

			string path = Path.Combine(dataDirectory, "SDVMM", "Mods.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(Mods));
		}

		public static List<ModInfo> LoadModList()
		{

			string modListPath = Path.Combine(dataDirectory, "SDVMM", "Mods.json");

			if (!File.Exists(modListPath))
			{
				return new List<ModInfo>();
			}

			string JsonData = File.ReadAllText(modListPath);

			return JsonConvert.DeserializeObject<List<ModInfo>>(JsonData) ?? new List<ModInfo>();
		}

		internal static string getSMAPIVersion(string gameFolder)
		{
			if (System.IO.File.Exists(System.IO.Path.Combine(gameFolder, "StardewModdingAPI.exe")))
			{
				System.Diagnostics.FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(System.IO.Path.Combine(gameFolder, "StardewModdingAPI.exe"));
				string Version = string.Join(".", myFileVersionInfo.FileVersion.Split('.').Take(3));
				return Version;
			}
			else
				return "";
		}

		private static SDVMMSettings CreateDefaultSettings()
		{
			var settings = new SDVMMSettings("", "", "", "", false, false);
			string defaultSPath = "";
			string defaultGogPath = "";
			string userpath = DirectoryOperations.getFolder("User");
			//search for attached drives

			// TODO Find Steam Path. Only does game path

			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach (DriveInfo d in allDrives)
			{
				//check if the drive is a HDD
				if (d.DriveType == DriveType.Fixed)
				{
					//find out which OS SDVMM is running on and based on guess the paths
					if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					{
						if (System.IO.File.Exists(Path.Combine(d.Name, "Program Files (x86)", "Steam", "Steam.exe")))
						{
							settings.SteamFolder = Path.Combine(d.Name, "Program Files (x86)", "Steam");
						}
						defaultSPath = Path.Combine(d.Name, "Program Files (x86)", "Steam", "steamapps", "common", "Stardew Valley");
						defaultGogPath = Path.Combine(d.Name, "Program Files (x86)", "GalaxyClient", "Games", "Stardew Valley");
						//if the registry entries exist take them instead.
						if (Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\GOG.com\\Games\\1453375253", "Path", null) != null)
						{
							defaultGogPath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\GOG.com\\Games\\1453375253", "Path", null).ToString();
						}
						if (Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 413150", "InstallLocation", null) != null)
						{
							defaultSPath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 413150", "InstallLocation", null).ToString();
						}
					}
					if (Environment.OSVersion.Platform == PlatformID.MacOSX)
					{
						if (System.IO.File.Exists(Path.Combine(userpath, "Library", "Application Support", "Steam", "Steam.exe")))
						{
							settings.SteamFolder = Path.Combine(userpath, "Library", "Application Support", "Steam");
						}
						defaultSPath = Path.Combine(userpath, "Library", "Application Support", "Steam", "steamapps", "common", "Stardew Valley", "Contents", "MacOS");
						defaultGogPath = Path.Combine("Applications", "Stardew Valley.app", "Contents", "MacOS");
					}
					if (Environment.OSVersion.Platform == PlatformID.Unix)
					{
						if (System.IO.File.Exists(Path.Combine(userpath, ".local", "share", "Steam", "Steam.exe")))
						{
							settings.SteamFolder = Path.Combine(userpath, ".local", "share", "Steam");
						}

						defaultGogPath = Path.Combine(userpath, "Games", "Stardew Valley", "game");
						defaultSPath = Path.Combine(userpath, ".local", "share", "Steam", "steamapps", "common", "Stardew Valley");
					}
				}
				if (System.IO.Directory.Exists(defaultSPath) || System.IO.Directory.Exists(defaultGogPath))
				{
					if (System.IO.Directory.Exists(defaultSPath))
					{
						settings.GameFolder = defaultSPath;
					}
					else
					{
						settings.GameFolder = defaultGogPath;
						settings.SteamFolder = DirectoryOperations.getFolder("AppData");
						settings.GoGVersion = true;
					}
					break;
				}
			}
			settings.SmapiVersion = getSMAPIVersion(settings.GameFolder);
			settings.Language = null;
			FileHandler.SaveSettings(settings);
			return settings;
		}
	}
}
