using System;
using System.Collections.Generic;

namespace SDVMMR
{
	public class ModListManagment
	{
		public ModListManagment()
		{

		}

		internal static List<ModInfo> LoadList()
		{
			JsonHandler j = new JsonHandler();
			List<ModInfo> LoadedMods = j.loadModList();
			return LoadedMods;
		}

		internal static void SaveList(List<ModInfo> LoadedMods)
		{
			JsonHandler j = new JsonHandler();
			j.saveModInfoList(LoadedMods);
		}

		internal static void addMod(string path, List<ModInfo> mods)
		{
            //TODO Parse Manifest
			ModInfo newMod = new ModInfo("hi", "notme", "1.0", "", "keine", "0.0", "this is a test", true, false, "");
			try
			{
				mods.Add(newMod);
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "error");
				msg.Show();
			}
			SaveList(mods);
		}
	}
}
