using System;
using System.IO;
using Gameloop;
using Newtonsoft.Json;

namespace SDVMMR
{
	public class WriteToVDF
	{
		internal void EditVDF()
		{

			string VDFData = File.ReadAllText(@"C:\\Program Files (x86)\\Steam\\userdata\\43615642\config\\localconfig.vdf");
			var test = Gameloop.Vdf.VdfConvert.Deserialize(VDFData);

		}
	}
}
