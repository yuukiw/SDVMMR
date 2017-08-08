using System;
using System.IO;
using Gameloop;
using Newtonsoft.Json;
using System.Runtime;
using Microsoft.CSharp;
using Gameloop.Vdf;
using System.Linq;
using System.Diagnostics;

namespace SDVMMR
{
	public class WriteToVDF
	{
		internal static dynamic raw;
		internal static VObject game;
		internal static string path;

		internal static void EditVDF(SDVMMSettings Settings)
		{
			try
			{



				var files = Directory.GetFiles(Path.Combine(Settings.SteamFolder, "userdata"), "localconfig.vdf", SearchOption.AllDirectories).ToArray();

				// find game settings

				int i = 0;
				for (i = 0; i < files.Length; i++)
				{
					// read file
					var fileText = File.ReadAllText(files[i]);
					if (fileText == null)
						continue;
					VdfSerializerSettings ste = new VdfSerializerSettings();
					ste.UsesEscapeSequences = true;

					raw = VdfConvert.Deserialize(fileText, ste);
					VObject data = (VObject)raw.UserLocalConfigStore.Software.Valve.Steam.Apps;

					if (data.ContainsKey("413150"))
					{
						game = (VObject)raw.UserLocalConfigStore.Software.Valve.Steam.Apps["413150"];
						break;
					}

				}

				// check fail conditions
				if (game == null)
				{
					Message msg = new Message(MainWindow.Translation.SDVInstalled, "error");
					return;
				}
				if (game.ContainsKey("LaunchOptions"))
				{
					Message msg = new Message(MainWindow.Translation.LaunchOptionExist, "error");
					return;
				}
				if (File.Exists(Path.Combine(files[i], "localconfig-sdvmm.vdf.bak")))
				{
					Message msg = new Message(MainWindow.Translation.LaunchOptionApplied, "error");
					return;
				}
								// kill steam
				foreach (var process in Process.GetProcessesByName("Steam"))
				{
					process.Kill();

				}


				// apply launch options
				if (!File.Exists(Path.Combine(Path.GetDirectoryName(files[i]), "localconfig-sdvmm.vdf.bak")))
					File.Copy(files[i], Path.Combine(Path.GetDirectoryName(files[i]), "localconfig-sdvmm.vdf.bak"));
				//VValue launchOptions = new VValue(@String.Join(""," ","\\\"",MainWindow.SDVMMSettings.GameFolder.Replace("\\","\\\\"),"\\\\" ,"StardewModdingAPI.exe","\\\" ", "%command%"));

string path = Path.Combine(MainWindow.SDVMMSettings.GameFolder, "StardewModdingAPI.exe").Replace(@"\", @"\\");
VValue launchOptions = new VValue($" \\\"{path}\\\" %command%");

				game.Add("LaunchOptions",launchOptions);
				File.WriteAllText(files[i], raw.ToString());
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "error");
			}



		}
	}
}
