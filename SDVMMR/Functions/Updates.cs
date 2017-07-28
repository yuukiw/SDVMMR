using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using Newtonsoft.Json;

namespace SDVMMR
{
	internal class Updates
	{
		internal static string SDVMMVersion = "";
		internal static string SMAPIVersion = "";
		internal static string downloadUrl = "";
		public static void CheckForUpdates(string smapiVersion, string sdvmmVersion,string mVersion)
		{
			System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors)  => true;
			if (checkForConection() == true)
			{
				SMAPIVersion = smapiVersion;
				SDVMMVersion = sdvmmVersion;
				//CheckSDVMM();
				CheckSmapi();
				CheckXNBLoader(mVersion);
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
				UpdateHandler.DownloadSMAPI(downloadUrl);
			}
			catch(Exception ex)
			{
				Message msg = new Message(ex.ToString(), "Error");
			}
		}

		public static void CheckSmapi()
		{
			try
			{
				GitRelease release = GetLatestRelease("Pathoschild/SMAPI");
				downloadUrl = (release.TagName != SMAPIVersion)
				   ? release.Downloads.OrderByDescending(p => p.Created).FirstOrDefault(p => !p.Name.Contains("developers"))?.DownloadUrl
				   : null;
				UpdateHandler.DownloadSMAPI(downloadUrl);
			}
			catch(Exception ex)
			{
				Message msg = new Message(ex.ToString(), "Error");
			}
		}

		public static void CheckXNBLoader(string mVersion)
		{
			try
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
			}
		}
	}
}
