using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Gtk;

namespace SDVMMR
{
	internal static class recSearchForXNB
	{
		internal static List<ModInfo> Mods = FileHandler.LoadModList();
		internal static SDVMMSettings Settings;
		internal static ListStore ModStore;
		internal static string spath = "";
		internal static string mod = "";
		internal static string checkValue = "";
		internal static string recXNB(string SourcePath, string search, SDVMMSettings settings, ListStore modStore, string filepath, string mode,string CheckValue)
		{
			Settings = settings;
			ModStore = modStore;
			spath = filepath;
			mod = mode;
			checkValue = CheckValue;
			var x = Directory.GetFiles(SourcePath, search, SearchOption.AllDirectories).ToList();

			return x.Count == 1 ? System.IO.Path.GetFullPath(x[0]) : checkFile(x.ToArray());
		}

		internal static string checkFile(string[] array)
		{
			if (checkValue == null)
			{
				checkValue = shaCheck.GetHashCode(array[0], new MD5CryptoServiceProvider());
			}
			for (int i = 1; i < array.Length; i++)
			{
				if (checkValue != shaCheck.GetHashCode(array[i], new MD5CryptoServiceProvider()))
				{
					return "";
				}
			}
			for (int x = 0; x < array.Length; x++)
			{
				if (mod == "add")
				{
					ModManager mm = new ModManager(Settings, ModStore);
					mm.addMod(spath, true, array[x]);
				}
				else
				{
					ModManager mm = new ModManager(Settings, ModStore);
					mm.removeMod(array[x]);
					File.Copy(array[x].Replace(Path.Combine(MainWindow.SDVMMSettings.GameFolder, "Content"), Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Backup")),array[x]);
				}

			}
			return null;
		}



	}
}
