using System;
using System.IO;
using Gameloop;
using Newtonsoft.Json;
using System.Runtime;
using Microsoft.CSharp;

namespace SDVMMR
{
	public class WriteToVDF
	{
		internal void EditVDF()
		{

			try
			{
				string VDFData = File.ReadAllText(@"H:\\Program Files (x86)\\Steam\\userdata\\43615642\\config\\localconfig.vdf");
				/*	dynamic test = Gameloop.Vdf.VdfConvert.Deserialize(VDFData);
					dynamic x = test.Software.Valve.Steam.apps.'413150'.LaunchOptions;
			  */
				dynamic prop = Gameloop.Vdf.VdfConvert.Deserialize(VDFData);
				int x = 0;
				foreach (dynamic data in prop.Value["Software"].Children())
				{
					x++;
				}
					//Console.WriteLine(data.Value["Broadcast"]);
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "error");
			}


		}
	}
}
