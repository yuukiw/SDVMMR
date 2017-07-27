using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gtk;

namespace SDVMMR
{
	public class ModListManagment
	{
		public ModListManagment()
		{

		}

		internal static List<ModInfo> LoadList(ListStore ModStore)
		{
			JsonHandler j = new JsonHandler();
			List<ModInfo> LoadedMods = j.loadModList(ModStore);
			return LoadedMods;
		}

		internal static void SaveList(List<ModInfo> LoadedMods)
		{
			JsonHandler j = new JsonHandler();
			j.saveModInfoList(LoadedMods);
		}

		internal static void addMod(string path, List<ModInfo> mods, Gtk.ListStore ModStore, SDVMMSettings setting)
		{
			try
			{
				JsonHandler json = new JsonHandler();
				ModManifest Manifest = json.readFromModManifest(Path.Combine(path, "manifest.json"));
				//TODO check if unique id is valid or if its a xnb mod
				string uId = Manifest.UniqueID;
				string version = String.Concat(Manifest.Version.MajorVersion, ".", Manifest.Version.MinorVersion, ".", Manifest.Version.PatchVersion);
				ModInfo newMod = new ModInfo(Manifest.Name, Manifest.Author, version, path, uId, Manifest.MinimumApiVersion, Manifest.Description, Manifest.EntryDll, true, false/*isX*/, "OrgXP");


				ModInfo modLookingFor = mods.Find(x => x.UniqueID == uId);
				if (modLookingFor != null)
				{
					var mod = mods.Where(d => d.Version != version).FirstOrDefault();
					if (mod != null) 
					{ 
						mod.Version = version; 
					}
				}
				else
				{
					mods.Add(newMod);
					addToTree(newMod, ModStore);
				}
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "error");
				msg.Show();
			}
			try
			{
				string destFolder = System.IO.Path.Combine(setting.GameFolder, "Mods", Path.GetFileName(path));
				var source = new DirectoryInfo(path);
				var destination = new DirectoryInfo(destFolder);
				source.MoveMod(destination);
				//Directory.Delete(path, true);
			}
			catch (Exception ex)
			{
				SDVMMR.Message msg = new Message(ex.ToString(), "Error");
				msg.Show();
			}
			SaveList(mods);
		}

		internal static void addToTree(ModInfo Mod, ListStore ModStore)
		{
			ModStore.AppendValues(Mod.IsActive.ToString(), Mod.Name, Mod.Author, Mod.Version, Mod.Description);
		}


	}
}
