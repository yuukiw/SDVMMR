using System;
using System.IO;
using Gameloop;
using Newtonsoft.Json;
using System.Runtime;
using Microsoft.CSharp;
using Gameloop.Vdf;
using System.Linq;

namespace SDVMMR
{
	public class WriteToVDF
	{

		internal static void EditVDF(SDVMMSettings Settings)
		{

			try
			{
				var x = Directory.GetFiles(Path.Combine(Settings.SteamFolder, "userdata"), "localconfig.vdf", SearchOption.AllDirectories).ToList();
				int i = 0;
				if (x.Count > 1)
				{
					bool exist = false;

					while (exist == false)
					{
						string cached = File.ReadAllText(x[i]);

						VdfSerializerSettings ste = new VdfSerializerSettings();
						ste.UsesEscapeSequences = true;

						dynamic test1 = VdfConvert.Deserialize(cached, ste);
						VObject game1 = (VObject)test1.UserLocalConfigStore.Software.Valve.Steam.apps;
						if (game1.ContainsKey("413150"))
						{
							exist = true;
						}
						if (x.Count <= i)
						{
							i = 999;
						}
						else
						{
							i++;
						}
					}
				}
				if (i != 999)
				{
					if (File.Exists(Path.Combine(x[i], "localconfig-sdvmm.vdf.bak")))
					{
						Message msg = new Message("LaunchOptions allready seem to have been applied", "error");
					}
					else
					{
						i--;

						System.IO.File.Copy(x[i], Path.Combine(Path.GetDirectoryName(x[i]), "localconfig-sdvmm.vdf.bak"));

						string cachedThing = File.ReadAllText(x[i]);

						VdfSerializerSettings st = new VdfSerializerSettings();
						st.UsesEscapeSequences = true;

						dynamic test = VdfConvert.Deserialize(cachedThing, st);
						VObject game = (VObject)test.UserLocalConfigStore.Software.Valve.Steam.apps["413150"];
						if (game.ContainsKey("LaunchOptions"))
						{
							Message msg = new Message("Launchoption already seems to exist", "error");
						}
						else
						{
							VValue LaunchOptions = new VValue(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "StardewModdingAPI.exe %command%"));
							game.Add("LaunchOptions", LaunchOptions);
							File.WriteAllText(x[i], test.ToString());
						}
					}
				}
				else
				{
					Message msg = new Message("are you sure SDV is correctly installed?", "error");
				}

			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "error");
			}


		}
	}
}
