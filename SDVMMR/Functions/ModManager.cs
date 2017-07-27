using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gtk;

namespace SDVMMR {
	public class ModManager {

		internal List<ModInfo> Mods = FileHandler.LoadModList();

		private ListStore ModStore;

		private SDVMMSettings Settings;

		public ModManager(SDVMMSettings settings, ListStore modStore) {
			this.ModStore = modStore;
			this.Settings = settings;
		}

		internal void addMod(string path) {
			try {
				ModManifest Manifest = FileHandler.LoadModManifest(Path.Combine(path, "manifest.json"));
				//TODO check if unique id is valid or if its a xnb mod
				string uId = Manifest.UniqueID;
				string version = String.Concat(Manifest.Version.MajorVersion, ".", Manifest.Version.MinorVersion, ".", Manifest.Version.PatchVersion);
				ModInfo newMod = new ModInfo(Manifest.Name, Manifest.Author, version, path, uId, Manifest.MinimumApiVersion, Manifest.Description, Manifest.EntryDll, true, false/*isX*/, "OrgXP");


				ModInfo modLookingFor = Mods.Find(x => x.UniqueID == uId);
				if (modLookingFor != null) {
					var mod = Mods.Where(d => d.Version != version).FirstOrDefault();
					if (mod != null) {
						mod.Version = version;
					}
				} else {
					Mods.Add(newMod);
					addToTree(newMod);
				}
			} catch (Exception ex) {
				Message msg = new Message(ex.ToString(), "error");
				msg.Show();
			}
			try {
				string destFolder = System.IO.Path.Combine(Settings.GameFolder, "Mods", Path.GetFileName(path));
				var source = new DirectoryInfo(path);
				var destination = new DirectoryInfo(destFolder);
				source.MoveMod(destination);
				//Directory.Delete(path, true);
			} catch (Exception ex) {
				SDVMMR.Message msg = new Message(ex.ToString(), "Error");
				msg.Show();
			}
			FileHandler.SaveModList(Mods);
		}

		internal void addToTree(ModInfo Mod) {
			ModStore.AppendValues(Mod.IsActive.ToString(), Mod.Name, Mod.Author, Mod.Version, Mod.Description);
		}


	}
}
