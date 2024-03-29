﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Pathoschild.Http;
using Pathoschild.Http.Client;

namespace SDVMMR
{

	internal static class UpdateHandler
	{
        //public static readonly HttpClient client = new HttpClient();
       

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
                    string text = "0";
                    try
                    {
                        if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip")))
                        {
                            System.IO.File.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip"));
                        }
                        text = "1";
                        WC.Headers.Add("user-agent", "SDVMM/Version: 1.0");
                        WC.DownloadFile(url, Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip"));
                        text = "2";
                        if (System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
                        {
                            Directory.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"), true);
                        }
                        text = "3";
                        if (!System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
                        {
                            System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
                        }
                        text = "4";
                        zipHandling.extractZip(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Smapi.zip"), Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
                        var x = Directory.GetDirectories(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
                        string path = "";
                        text = "5";
                        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        {
                            path = Path.Combine(x[0], "internal", "Windows");
                        }
                        else
                        {
                            text = "6";
                            path = Path.Combine(x[0], "internal", "Mono");
                        }
                        text = "7";
                        var source = new DirectoryInfo(System.IO.Path.GetFullPath(path));
                        var destination = new DirectoryInfo(gameFolder);
                        source.MoveMod(destination);
                        MainWindow.SDVMMSettings.SmapiVersion = version;
                        FileHandler.SaveSettings(MainWindow.SDVMMSettings);
                    }
                    catch {
                        MessageBox.Show(text);
                    }
				}
			}
		}

		public static void DownloadXNBLoader(string url, MainWindow mf)
		{
			//todo download and put into mods folder http://community.playstarbound.com/resources/xnb-loader.4506/download?version=20562
			using (WebClient WC = new WebClient())
			{
				if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip")))
				{
					System.IO.File.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip"));
				}
				WC.Headers.Add("user-agent", "SDVMM/Version: 1.0");
				WC.DownloadFile(url, Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip"));
				if (System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
				{
					Directory.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"), true);
				}
				if (!System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
				{
					System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
				}
				zipHandling.extractZip(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xl.zip"), Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
				ModManager mm = new ModManager(MainWindow.SDVMMSettings,mf);
				mm.addMod(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked", "XnbLoader", "XnbLoader.dll"), false, "");
                mm.addMod(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked", "!EntoaroxFramework", "EntoaroxFramework.dll"), false, "");


            }
		}




        internal static async Task<IDictionary<string, ModInfoModel>> CheckModUpdate(string[] modKeys, MainWindow mf)
        {
            using (IClient client = new FluentClient("https://api.smapi.io/v2.0/"))
            {
                return await client
                   .PostAsync("mods", new ModSearchModel(modKeys))
                   .As<IDictionary<string, ModInfoModel>>();
            }
        }
    }    

   
}
