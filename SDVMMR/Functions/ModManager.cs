using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gtk;

namespace SDVMMR
{
	public class ModManager
	{

		internal List<ModInfo> Mods = FileHandler.LoadModList();

		private ListStore ModStore;

		private SDVMMSettings Settings;

		public ModManager(SDVMMSettings settings, ListStore modStore)
		{
			this.ModStore = modStore;
			this.Settings = settings;
		}

		internal void addMod(string path)
		{
			try
			{
				if (System.IO.Path.GetFileName(path).Contains(".xnb"))
				{
					string destPath = recSearchForXNB.recXNB(System.IO.Path.Combine(Settings.GameFolder, "Content"), System.IO.Path.GetFileName(path));
					if (destPath != "" & Settings.overWrite == false)
					{
						string orgpath = destPath;
						destPath = destPath.Replace(Settings.GameFolder, Path.Combine(Settings.GameFolder, "Mods", "XNBLoader", "something"));
						//todo move to the xnb version of the folder

						//Directory.Delete(System.IO.Path.GetFullPath(path), true);
						ModInfo newMod = new ModInfo(
							name: System.IO.Path.GetFileNameWithoutExtension(path),
							author: "Unknown",
							version: "0.0",
							filePath: destPath,
							uid: orgpath,
							MiniApiVersion: "0.0",
							Desc: "",
							entry: "",
							IsA: true,
							IsX: true,
							OrgXP: orgpath);
						
						Mods.Add(newMod);
					}
					if (destPath != "" & Settings.overWrite == true)
					{
						string destFolder = System.IO.Path.Combine(Settings.GameFolder, "Mods", Path.GetFileName(path));
						string orgpath = destPath;
						var source = new DirectoryInfo(System.IO.Path.GetFullPath(path));
						var destination = new DirectoryInfo(destPath);
						source.MoveMod(destination);
						//Directory.Delete(System.IO.Path.GetFullPath(path), true);

						ModInfo newMod = new ModInfo(
						name: System.IO.Path.GetFileNameWithoutExtension(path),
						author: "Unknown",
						version: "0.0",
						filePath: destPath,
						uid: orgpath,
						MiniApiVersion: "0.0",
						Desc: "",
						entry: "",
						IsA: true,
						IsX: true,
						OrgXP: orgpath);
						Mods.Add(newMod);
					}
					else
					{
						//todo ask user
					}
				}
				else
				{
					path = System.IO.Path.GetDirectoryName(path);
					ModManifest Manifest = FileHandler.LoadModManifest(Path.Combine(path, "manifest.json"));
					string uId = Manifest.UniqueID;
					string version = String.Concat(Manifest.Version.MajorVersion, ".", Manifest.Version.MinorVersion, ".", Manifest.Version.PatchVersion);
					ModInfo newMod = new ModInfo(Manifest.Name, Manifest.Author, version, path, uId, Manifest.MinimumApiVersion, Manifest.Description, Manifest.EntryDll, true, false/*isX*/, "OrgXP");


					ModInfo modLookingFor = Mods.Find(x => x.UniqueID == uId);
					if (modLookingFor != null)
					{
						var mod = Mods.Where(d => d.Version != version).FirstOrDefault();
						if (mod != null)
						{
							mod.Version = version;
						}
					}
					else
					{
						Mods.Add(newMod);
						addToTree(newMod);
					}
					string destFolder = System.IO.Path.Combine(Settings.GameFolder, "Mods", Path.GetFileName(path));
					var source = new DirectoryInfo(System.IO.Path.GetFullPath(path));
					var destination = new DirectoryInfo(destFolder);
					source.MoveMod(destination);
					//Directory.Delete(System.IO.Path.GetFullPath(path), true);
				}
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "error");
				msg.Show();
			}
			FileHandler.SaveModList(Mods);
		}

		internal void addToTree(ModInfo Mod)
		{
			ModStore.AppendValues(Mod.IsActive.ToString(), Mod.Name, Mod.Author, Mod.Version, Mod.Description);
		}


	}
}
