using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Windows.Forms;
using SDVMMR.JSON_Dummies;

namespace SDVMMR
{
	public static class FileHandler
	{
        internal static bool dMode = false;
        public static bool IsDebugRelease
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
        



        private static readonly string dataDirectory = DirectoryOperations.getFolder("AppData");

		public static SDVMMSettings LoadSettings()
		{
			string Path = System.IO.Path.Combine(dataDirectory, "SDVMM", "SDVMM.json");

            if (dMode)
                Console.Write("Checking if SDVMM.json exist...");
            // TODO Set proper initial values for settings
            if (!File.Exists(Path))
            {
                if (dMode)
                    Console.Write("it doesnt exist, loading default...");
                return CreateDefaultSettings();
            }
            if (dMode)
                Console.Write("it does exist loading it now...");
            StreamReader read = new StreamReader(Path);
			string JsonData = read.ReadToEnd();
			read.Close();

			var loadedSettings = JsonConvert.DeserializeObject<SDVMMSettings>(JsonData);

			// always check for SMAPI version
			if (loadedSettings == null | loadedSettings.SmapiVersion == "C:\\")
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
            try
            {
                if (!File.Exists(Path))
                    return null;

                string JsonData = File.ReadAllText(Path);
                return JsonConvert.DeserializeObject<ModManifest>(JsonData);
            }
            catch(Exception ex)
            {
                return LoadOldModManifest(Path);
            }
		}

        private static ModManifest LoadOldModManifest(string Path)
        {
            try
            {
                if (!File.Exists(Path))
                    return null;

                string JsonData = File.ReadAllText(Path);
                ModManifestOld oldData  = JsonConvert.DeserializeObject<ModManifestOld>(JsonData);
                ModManifest newData = new ModManifest();
                newData.Author = oldData.Author;
                newData.Author = oldData.Description;
                newData.EntryDll = oldData.EntryDll;
                newData.MinimumApiVersion = oldData.MinimumApiVersion;
                newData.Name = oldData.Name;    
                newData.Version = String.Join(".", oldData.Version.MajorVersion, oldData.Version.MinorVersion, oldData.Version.PatchVersion);
                return newData;             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }



        public static ALLManifest LoadALLManifest(string Path)
        {
            try
            {
                if (!File.Exists(Path))
                    return null;

                string JsonData = File.ReadAllText(Path);
                return JsonConvert.DeserializeObject<ALLManifest>(JsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
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
			catch (Exception ex)
			{
                if(!dMode)
				MessageBox.Show("Couldn`t load the Translation. Defaulting to English", "Translation Error");
                if (dMode)       
                MessageBox.Show(ex.ToString());
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
            if (!System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json")))
            {
                System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json"));
            }
            string path = Path.Combine(dataDirectory, "SDVMM", "SDVMM.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(settings));
		}

		public static void SaveModList(List<ModInfo> Mods)
		{

            // Write to JSON
            if (!System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json")))
            {
                System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "Mods.json"));
            }
            string path = Path.Combine(dataDirectory, "SDVMM", "Mods.json");
			File.WriteAllText(path, JsonConvert.SerializeObject(Mods));
		}

		public static List<ModInfo> LoadModList()
		{
            try
            {
                string modListPath = Path.Combine(dataDirectory, "SDVMM", "Mods.json");

                if (!File.Exists(modListPath))
                {
                    return new List<ModInfo>();
                }

                string JsonData = File.ReadAllText(modListPath);

                return JsonConvert.DeserializeObject<List<ModInfo>>(JsonData) ?? new List<ModInfo>();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }
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

			//find out which OS SDVMM is running on and based on guess the paths
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{

				DriveInfo[] allDrives = DriveInfo.GetDrives();
				foreach (DriveInfo d in allDrives)
				{
					//check if the drive is a HDD
					if (d.DriveType == DriveType.Fixed)
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

				}
			}
			if (Environment.OSVersion.Platform == PlatformID.MacOSX)
			{
				if (System.IO.Directory.Exists(Path.Combine(userpath, "Library", "Application Support", "Steam")))
				{
					settings.SteamFolder = Path.Combine(userpath, "Library", "Application Support", "Steam");
				}
				defaultSPath = Path.Combine(userpath, "Library", "Application Support", "Steam", "steamapps", "common", "Stardew Valley", "Contents", "MacOS");
				defaultGogPath = Path.Combine("Applications", "Stardew Valley.app", "Contents", "MacOS");
			}
			OperatingSystem os = Environment.OSVersion;
	
			if (Environment.OSVersion.Platform == PlatformID.Unix)
			{
				if (IsRunningOnMac())
				{
					if (System.IO.Directory.Exists(Path.Combine(userpath, "Library", "Application Support", "Steam")))
					{
						settings.SteamFolder = Path.Combine(userpath, "Library", "Application Support", "Steam");
					}
					defaultSPath = Path.Combine(userpath, "Library", "Application Support", "Steam", "steamapps", "common", "Stardew Valley", "Contents", "MacOS");
					defaultGogPath = Path.Combine("Applications", "Stardew Valley.app", "Contents", "MacOS");
				}
				else
				{


					if (System.IO.Directory.Exists(Path.Combine(userpath, ".local", "share", "Steam")))
					{
						settings.SteamFolder = Path.Combine(userpath, ".local", "share", "Steam");
					}

					defaultGogPath = Path.Combine(userpath, "Games", "Stardew Valley", "game");
					defaultSPath = Path.Combine(userpath, ".steam", "steam", "steamapps", "common", "Stardew Valley");
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

				}
			}
			settings.SmapiVersion = getSMAPIVersion(settings.GameFolder);
			settings.Language = null;
			FileHandler.SaveSettings(settings);
			return settings;
		}

		//From Managed.Windows.Forms/XplatUI
		[System.Runtime.InteropServices.DllImport("libc")]
		static extern int uname(IntPtr buf);

		static bool IsRunningOnMac()
		{
			IntPtr buf = IntPtr.Zero;
			try
			{
				
				buf = System.Runtime.InteropServices.Marshal.AllocHGlobal(8192);
				// This is a hacktastic way of getting sysname from uname ()
				if (uname(buf) == 0)
				{
					string os = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(buf);
					if (os == "Darwin")
						return true;
				}
			}
			catch
			{
			}
			finally
			{
				if (buf != IntPtr.Zero)
					System.Runtime.InteropServices.Marshal.FreeHGlobal(buf);
			}
			return false;
		}

	}
}
