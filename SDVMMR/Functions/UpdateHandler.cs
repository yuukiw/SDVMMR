using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;
using Gtk;
using Newtonsoft.Json;

namespace SDVMMR
{

	internal static class UpdateHandler
	{
		public static void DownloadSDVMM(string url)
		{
				DialogResult dialogResult = MessageBox.Show(MainWindow.Translation.SDVMMUpdateFound, MainWindow.Translation.UpdateTitle, MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					ProcessStartInfo startInfo = new ProcessStartInfo()
					{
						FileName = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SDVMM Updater.exe")),
						Arguments = url,
						UseShellExecute = true,
						WindowStyle = ProcessWindowStyle.Normal
					};
					Process.Start(startInfo);
					Environment.Exit(0);
				}
		}

		public static void DownloadSMAPI(string url, string gameFolder, string version)
		{
			DialogResult dialogResult = MessageBox.Show(MainWindow.Translation.SMAPIUpdateFound, MainWindow.Translation.UpdateTitle, MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				using (WebClient WC = new WebClient())
				{
					if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip")))
					{
						System.IO.File.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip"));
					}
					WC.Headers.Add("user-agent", "SDVMM/Version: 1.0");
					WC.DownloadFile(url, Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip"));
					if (System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
					{
						Directory.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"), true);
					}
					if (!System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
					{
						System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
					}
					zipHandling.extractZip(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip"), Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
					var x = Directory.GetDirectories(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
					string path = "";
					if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					{
						path = Path.Combine(x[0], "internal", "Windows");
					}
					else
					{
						path = Path.Combine(x[0], "internal", "Mono");
					}
					var source = new DirectoryInfo(System.IO.Path.GetFullPath(path));
					var destination = new DirectoryInfo(gameFolder);
					source.MoveMod(destination);
					MainWindow.SDVMMSettings.SmapiVersion = version;
					FileHandler.SaveSettings(MainWindow.SDVMMSettings);
				}
			}
		}

		public static void DownloadXNBLoader(string url, ListStore Mods)
		{
			//todo download and put into mods folder http://community.playstarbound.com/resources/xnb-loader.4506/download?version=20562
			using (WebClient WC = new WebClient())
			{
				if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip")))
				{
					System.IO.File.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip"));
				}
				WC.Headers.Add("user-agent", "SDVMM/Version: 1.0");
				WC.DownloadFile("https://drive.google.com/uc?export=download&id=0B94u0_R6vixWc3lkZm5RbF9sXzQ", Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip"));
				if (System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
				{
					Directory.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"), true);
				}
				if (!System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
				{
					System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
				}
				zipHandling.extractZip(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip"), Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
				ModManager mm = new ModManager(MainWindow.SDVMMSettings, Mods);
				mm.addMod(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked", "XnbLoader", "XnbLoader.dll"), false, "");


			}
		}

	}

}
