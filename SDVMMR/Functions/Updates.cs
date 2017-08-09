using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using Gtk;
using Newtonsoft.Json;

namespace SDVMMR
{
	internal class Updates
	{
		internal static string SDVMMVersion = "";
		internal static string SMAPIVersion = "";
		internal static string downloadUrl = "";
		internal static ListStore ModStore;
		public static void CheckForUpdates(string smapiVersion, string sdvmmVersion, string mVersion, string gameFolder,ListStore Mods)
		{
			ModStore = Mods;
			System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
			if (checkForConection() == true)
			{
				SMAPIVersion = smapiVersion;
				SDVMMVersion = sdvmmVersion;
				//CheckSDVMM();
				CheckSmapi(gameFolder);
				CheckXNBLoader(mVersion, gameFolder);
			}
			//TODO check for updates	
		}

		private static bool checkForConection()
		{

			try
			{
				using (var client = new WebClient())
				using (var stream = client.OpenRead("http://www.google.com"))
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

		internal static GitRelease GetLatestRelease(string repo)
		{
			// build requests
			HttpWebRequest request = WebRequest.CreateHttp($"https://api.github.com/repos/{repo}/releases/latest");
			request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.Revalidate);
			request.UserAgent = $"SDVMM/{SDVMMVersion}";

			// fetch data
			using (WebResponse response = request.GetResponseAsync().Result)
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream))
			{
				string responseText = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<GitRelease>(responseText);
			}
		}



		public static void CheckSDVMM()
		{
			try
			{
				GitRelease release = GetLatestRelease("yuukiw/SDVMMR");
				downloadUrl = (release.TagName != SDVMMVersion)
				   ? release.Downloads.OrderByDescending(p => p.Created).FirstOrDefault(p => !p.Name.Contains("developers"))?.DownloadUrl
				   : null;
				UpdateHandler.DownloadSDVMM(downloadUrl);
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "Error");
			}
		}

		public static void CheckSmapi(string gameFolder)
		{
			try
			{
				GitRelease release = GetLatestRelease("Pathoschild/SMAPI");
				downloadUrl = (release.TagName != SMAPIVersion)
				   ? release.Downloads.OrderByDescending(p => p.Created).FirstOrDefault(p => !p.Name.Contains("developers"))?.DownloadUrl
				   : null;
				if (downloadUrl != null)
					UpdateHandler.DownloadSMAPI(downloadUrl, gameFolder, release.TagName);
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "Error");
			}
		}

		public static void CheckXNBLoader(string mVersion, string path)
		{
			if (!File.Exists(Path.Combine(path, "Mods", "XnbLoader", "XnbLoader.dll")))
			{
				UpdateHandler.DownloadXNBLoader("http://community.playstarbound.com/resources/xnb-loader.4506/download?version=20562",ModStore);

			}
			}

			/*	try
				{
					string Version = "";
					if (Version == "")
						Version = "0.0";

					GitRelease release = GetLatestRelease("Pathoschild/SMAPI");
					downloadUrl = (release.TagName != Version)
					   ? release.Downloads.OrderByDescending(p => p.Created).FirstOrDefault(p => !p.Name.Contains("developers"))?.DownloadUrl
					   : null;
					if(downloadUrl != null) 
						UpdateHandler.DownloadSMAPI(downloadUrl);
				}
				catch(Exception ex)
				{
					Message msg = new Message(ex.ToString(), "Error");
				}*/
		}

}
