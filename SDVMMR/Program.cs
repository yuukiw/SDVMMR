using System;
using Gtk;
using System.IO;

namespace SDVMMR
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();
			var main = new MainWindow(); 

				try
				{

					SetupEnvironment();
				MainWindow.SDVMMSettings = FileHandler.LoadSettings();


					main.Present();

					Application.Run();

				}
				catch (Exception ex)
				{

					// close main window to prevent further damage
					if (main != null)
						main.Destroy();

					Console.Write(ex);

					// Alert User
					ErrorAlert alert = new ErrorAlert(ex.ToString(), "Error")
					{
						DefaultWidth = 100,
						DefaultHeight = 100
					};

					alert.WindowShouldClosed += (sender, e) =>
					{
						Application.Quit();
					};
					alert.Present();
					Application.Run();

				}
		}

		internal static void SetupEnvironment()
		{
			string path = Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json");
			//first of we check if the old non mono version of SDVMM was used
			//if so migrate the ini to the new system
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini")))
				{

					string language = "en";
					string oldPath = Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini");
					string GFolder = iniParsing.INI_ReadValueFromFile("General", "GameFolder", "C:\\", oldPath);
					string SFolder = iniParsing.INI_ReadValueFromFile("General", "SteamFolder", "C:\\", oldPath);
					string GoGV = iniParsing.INI_ReadValueFromFile("General", "SteamFolder", "C:\\", oldPath);
					string SVersion = iniParsing.INI_ReadValueFromFile("SMAPI Details", "Version", "C:\\", oldPath);
					bool isGOG = (GoGV == "1");
					if (!System.IO.File.Exists(path))
					{
						DirectoryOperations.CreateFile(path);
					}

					var settings = new SDVMMSettings(language, SVersion, GFolder, SFolder, isGOG, false);

					FileHandler.SaveSettings(settings);
					System.IO.File.Delete(Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini"));
				}
			}
		}
	}
}
