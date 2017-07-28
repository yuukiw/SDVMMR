using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SDVMMR
{
	
	internal static class UpdateHandler
	{
		
		public static void DownloadSDVMM(string url)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo()
			{
				FileName = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SDVMM Updater.exe")),
				Arguments = url,
				UseShellExecute = true,
				WindowStyle = ProcessWindowStyle.Normal
			};
			Process.Start(startInfo);
		}

		public static void DownloadSMAPI(string url)
		{
			Message msg = new Message(url, "hi");
		}

		public static void DownloadXNBLoader(string url)
		{

		}

	}

}
