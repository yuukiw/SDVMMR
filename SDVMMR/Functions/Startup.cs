using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;


namespace SDVMMR
{
	public class Startup
	{
		public Startup(SDVMMSettings settings, List<ModInfo> mods)
		{
			string path = Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json");
			//first of we check if the old non mono version of SDVMM was used
			//if so migrate the ini to the new system
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini")))
				{
					JsonHandler json = new JsonHandler();
					string oldPath = Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini");
					string GFolder = iniParsing.INI_ReadValueFromFile("General", "GameFolder", "C:\\", oldPath);
					string SFolder = iniParsing.INI_ReadValueFromFile("General", "SteamFolder", "C:\\", oldPath);
					string GoGV = iniParsing.INI_ReadValueFromFile("General", "SteamFolder", "C:\\", oldPath);
					string SVersion = iniParsing.INI_ReadValueFromFile("SMAPI Details", "Version", "C:\\", oldPath);
					bool help = false;
					if (GoGV == "1")
						help = true;
					if (!System.IO.File.Exists(path))
					{
						DirectoryOperations.createAppData(path);
					}
					//json.writeToInfo(SVersion, true, SFolder, GFolder, help, false, path);
					settings.GameFolder = GFolder;
					settings.GoGVersion = help;
					settings.SmapiVersion = SVersion;
					settings.SmapiIsinstalled = true;
					settings.SteamFolder = SFolder;
					json.writeToInfo(settings);
					//System.IO.Directory.Delete(Path.Combine(DirectoryOperations.getFolder("OldAppData")), true);
				}
			}
			if (!System.IO.File.Exists(path) || new System.IO.FileInfo(path).Length == 0)
			{
				if (!System.IO.File.Exists(path))
				{
					DirectoryOperations.createAppData(path);
				}
				string defaultSPath = "";
				string defaultGogPath = "";
				string userpath = DirectoryOperations.getFolder("User");
				//search for attached drives

				DriveInfo[] allDrives = DriveInfo.GetDrives();
				foreach (DriveInfo d in allDrives)
				{
					//check if the drive is a HDD
					if (d.DriveType == DriveType.Fixed)
					{
						//find out which OS SDVMM is running on and based on guess the paths
						if (Environment.OSVersion.Platform == PlatformID.Win32NT)
						{
							defaultSPath = Path.Combine(d.Name, "Program Files (x86)", "Steam", "steamapps", "common", "Games", "Stardew Valley");
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
							defaultSPath = Path.Combine(userpath, "Library", "Application Support", "Steam", "steamapps", "common", "Stardew Valley", "Contents", "MacOS");
							defaultGogPath = Path.Combine("Applications", "Stardew Valley.app", "Contents", "MacOS");
						}
						if (Environment.OSVersion.Platform == PlatformID.Unix)
						{
							defaultGogPath = Path.Combine(userpath, "Games", "Stardew Valley", "game");
							defaultSPath = Path.Combine(userpath, ".local", "share", "Steam", "steamapps", "common", "Stardew Valley");
						}
					}
					if (System.IO.Directory.Exists(defaultSPath) || System.IO.Directory.Exists(defaultGogPath))
					{
						break;
					}
				}
				//no luck finding them?
				if (!System.IO.Directory.Exists(defaultSPath) & !System.IO.Directory.Exists(defaultGogPath))
				{
					//then let us ask the user.
					Setting swin = new Setting(settings, mods);
					swin.Show();
				}



			}


		}
	}
}

