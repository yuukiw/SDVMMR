using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

		internal void addMod(string path, bool skipRec, string recdestPath)
		{
			try
			{
				if ((System.IO.Path.GetFileName(path).Contains(".zip")))
				{
					string oldPath = path;
					if (!Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped")))
					{
						System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped"));
					}
					zipHandling.extractZip(path, Path.Combine(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped")));
					var x = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).ToList();
					if (x.Count > 0)
					{
						path = x[0];
					}
					if (oldPath == path)
					{
						x = Directory.GetFiles(path, "*.xnb", SearchOption.AllDirectories).ToList();
						if (x.Count > 0)
						{
							path = x[0];
						}
					}
				}

				if (System.IO.Path.GetFileName(path).Contains(".xnb"))
				{
					string destPath = "";
					string orgpath = "";
					if (skipRec == false)
					{
						destPath = recSearchForXNB.recXNB(System.IO.Path.Combine(Settings.GameFolder, "Content"), System.IO.Path.GetFileName(path), Settings, ModStore, path, "add", null);
						orgpath = destPath;
					}
					else
					{
						destPath = recdestPath;
						orgpath = path;
					}

					if (destPath != "" & Settings.overWrite == false & destPath != null)
					{
						string bpath = destPath;
						destPath = destPath.Replace(Path.Combine(Settings.GameFolder, "Content"), Path.Combine(Settings.GameFolder, "Mods", "XNBLoader", "content"));
						if (File.Exists(destPath))
							File.Delete(destPath);


						if (skipRec == true)
							File.Copy(orgpath, destPath);
						else
							File.Move(orgpath, destPath);

						//Directory.Delete(System.IO.Path.GetFullPath(path), true);
						ModInfo newMod = new ModInfo(
						name: System.IO.Path.GetFileNameWithoutExtension(path),
						author: "Unknown",
						version: "0.0",
						filePath: destPath,
						uid: shaCheck.GetHashCode(orgpath, new MD5CryptoServiceProvider()),
						MiniApiVersion: "0.0",
						Desc: "-",
						entry: "-",
						IsA: true,
						IsX: true,
						OrgXP: orgpath);
						ModInfo modLookingFor = Mods.Find(x => x.UniqueID == newMod.UniqueID);
						if (modLookingFor == null)
						{
							Mods.Add(newMod);
							addToTree(newMod);
							FileHandler.SaveModList(Mods);
						}

					}
					if (destPath != "" & Settings.overWrite == true & destPath != null)
					{
                      if (!Directory.Exists(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Backup")))
						{
							Directory.CreateDirectory(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Backup"));
						}
						if (!File.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Backup", "Minigames")))
						{
							var folder = new DirectoryInfo(Path.Combine(MainWindow.SDVMMSettings.GameFolder, "content")).EnumerateDirectories("*.*", SearchOption.AllDirectories);
							var folderarray = folder.ToArray();
							for (int i = 0; i < folderarray.Length; i++)
							{
								string dir = Path.Combine(folderarray[i].FullName.Replace(Path.Combine(MainWindow.SDVMMSettings.GameFolder,"content"),Path.Combine(DirectoryOperations.getFolder("ExeFolder"),"Backup")));
								Directory.CreateDirectory(dir);
							}
						}

						var backupFolder = destPath.Replace(Path.Combine(MainWindow.SDVMMSettings.GameFolder, "Content"), Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Backup"));
						if (!File.Exists(backupFolder))
						{
							File.Copy(destPath, backupFolder.ToString());
						}
						orgpath = destPath;
						if (skipRec == true)
							File.Copy(path, destPath, true);
						else
							File.Move(path, destPath);
						//Directory.Delete(System.IO.Path.GetFullPath(path), true);

						ModInfo newMod = new ModInfo(
						name: System.IO.Path.GetFileNameWithoutExtension(path),
						author: "Unknown",
						version: "0.0",
						filePath: destPath,
						uid: shaCheck.GetHashCode(orgpath, new MD5CryptoServiceProvider()),
						MiniApiVersion: "0.0",
						Desc: "-",
						entry: "-",
						IsA: true,
						IsX: true,
						OrgXP: orgpath);
						ModInfo modLookingFor = Mods.Find(x => x.UniqueID == newMod.UniqueID);
						if (modLookingFor == null)
						{
							Mods.Add(newMod);
							addToTree(newMod);
							FileHandler.SaveModList(Mods);
						}
					}
					else
					{
						if (destPath != null & skipRec == false)
						{
							string folder = "";
							Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog(
									   MainWindow.Translation.FCTitle,
									   null,
									   FileChooserAction.Open,
									   MainWindow.Translation.FCcancel, ResponseType.Cancel,
									   MainWindow.Translation.FCopen, ResponseType.Accept);

							filechooser.SelectMultiple = false;
							FileFilter filter = new FileFilter();
							filter.Name = MainWindow.Translation.FCXNBTitle;
							filter.AddPattern("*.xnb"); ;
							filechooser.Filter = filter;
							if (filechooser.Run() == (int)ResponseType.Accept)
							{
								folder = filechooser.Filename;
								addMod(folder, false, "");
								filechooser.Destroy();
							}
						}
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
					FileHandler.SaveModList(Mods);
					//Directory.Delete(System.IO.Path.GetFullPath(path), true);
				}
			}
			catch (Exception ex)
			{
				Message msg = new Message(ex.ToString(), "error");
				msg.Show();
			}
			Mods = FileHandler.LoadModList();
		}

		internal void removeMod(string path)
		{
			File.Delete(path);
		}

		internal void addToTree(ModInfo Mod)
		{
			ModStore.AppendValues(Mod.IsActive.ToString(), Mod.Name, Mod.Author, Mod.Version, Mod.Description);
		}


	}
}
