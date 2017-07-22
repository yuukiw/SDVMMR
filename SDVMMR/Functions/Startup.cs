using System;

namespace SDVMMR
{
	public class Startup
	{
		public Startup()
		{
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				if (System.IO.File.Exists(""))
				{
					JsonHandler json = new JsonHandler();
					json.writeToJson("", iniParsing.INI_ReadValueFromFile("", "", "", ""), "");
				}
			}
		}
	}
}

