using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SDVMMR
{
	public class ModManager
	{

		internal static List<ModInfo> Mods = FileHandler.LoadModList();

        private MainWindow mf;

		private SDVMMSettings Settings;

		public ModManager(SDVMMSettings settings, MainWindow nMainForm )
        {
            mf = nMainForm;
			this.Settings = settings;          
		}



        internal void addMod(string path, bool skipRec, string recdestPath)
		{
			try
			{
				if ((System.IO.Path.GetFileName(path).Contains(".zip")))
				{
					string oldPath = path;
                    if (Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped")))
                    {
                        System.IO.Directory.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped"),true);
                    }
                    if (!Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped")))
					{
						System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped"));
					}
					zipHandling.extractZip(path, Path.Combine(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped")));
					var x = Directory.GetFiles(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped"), "*.dll", SearchOption.AllDirectories).ToList();
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
						destPath = recSearchForXNB.recXNB(System.IO.Path.Combine(Settings.GameFolder, "Content"), System.IO.Path.GetFileName(path), Settings, mf, path, "add", null);
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
							addToTree(newMod,mf);
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
							addToTree(newMod,mf);
							FileHandler.SaveModList(Mods);
						}
					}
					else
					{
						if (destPath != null & skipRec == false)
						{
							string folder = "";

                            OpenFileDialog filechooser = new OpenFileDialog();
                            filechooser.Filter = String.Join("",MainWindow.Translation.FCXNBTitle ,"|*.xnb");
                            filechooser.Title = MainWindow.Translation.FCTitle;
                            if (filechooser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
							{
                                folder = filechooser.FileName;
								addMod(folder, false, "");								
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
						addToTree(newMod,mf);
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
                MessageBox.Show(ex.ToString(), "error");
			}
			Mods = FileHandler.LoadModList();
		}

		internal void removeMod(string path)
		{
			File.Delete(path);
		}

		internal void addToTree(ModInfo Mod, MainWindow mf)
		{
            ListViewItem item = new ListViewItem(Mod.Name, -2);
            item.SubItems.Add(Mod.Author);
            item.SubItems.Add(Mod.Version);
            item.SubItems.Add(Mod.Description);
            item.SubItems.Add(Mod.UniqueID);
            item.SubItems.Add(Mod.IsActive.ToString());
            item.SubItems.Add(Mod.IsXnb.ToString());
           
            if (MainWindow.tile)
            {
                if (Mod.IsActive == false)
                    item.BackColor = System.Drawing.Color.Gray;

                else
                    item.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                if (Mod.IsActive == false)
                    item.Checked = false;

                else
                    item.Checked = true;
            }

            mf.addToList(item);
            

        }


	}
}
