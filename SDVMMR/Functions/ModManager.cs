using SDVMMR.Functions;
using SDVMMR.JSON_Dummies;
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


        public ModManager(SDVMMSettings settings, MainWindow nMainForm)
        {
            mf = nMainForm;
            this.Settings = settings;
        }



        internal void addMod(string path, bool skipRec, string recdestPath)
        {
            try
            {
                string destFolder = "";
                if ((System.IO.Path.GetFileName(path).Contains(".zip")|| System.IO.Path.GetFileName(path).Contains(".7z") || System.IO.Path.GetFileName(path).Contains(".rar")))
                {
                    string oldPath = path;
                    if (Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped")))
                    {
                        System.IO.Directory.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped"), true);
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
                    if (x.Count == 0)
                        x = Directory.GetFiles(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped"), "*.json", SearchOption.AllDirectories).ToList();
                    if (x.Count > 0)
                    {
                        path = x[0];
                    }
                    if (oldPath == path)
                    {
                        x = Directory.GetFiles(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unzipped"), "*.xnb", SearchOption.AllDirectories).ToList();
                        if (x.Count > 0)
                        {
                            foreach(String s in x)
                            {
                                addMod(s, false, "");
                            }
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
                        OrgXP: orgpath,
                        IsAll: false);
                        ModInfo modLookingFor = Mods.Find(x => x.UniqueID == newMod.UniqueID);
                        if (modLookingFor == null)
                        {
                            Mods.Add(newMod);
                            addToTree(newMod, mf);
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
                                string dir = Path.Combine(folderarray[i].FullName.Replace(Path.Combine(MainWindow.SDVMMSettings.GameFolder, "content"), Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Backup")));
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
                        OrgXP: orgpath,
                        IsAll: false);
                        ModInfo modLookingFor = Mods.Find(x => x.UniqueID == newMod.UniqueID);
                        if (modLookingFor == null)
                        {
                            Mods.Add(newMod);
                            addToTree(newMod, mf);
                            FileHandler.SaveModList(Mods);
                        }
                    }
                    else
                    {
                        if (destPath != null & skipRec == false)
                        {
                            string folder = "";

                            OpenFileDialog filechooser = new OpenFileDialog();
                            filechooser.Filter = String.Join("", MainWindow.Translation.FCXNBTitle, "|*.xnb");
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
                    string pathwo = System.IO.Path.GetDirectoryName(path);
                    string mpath = Path.Combine(pathwo, "manifest.json");
                    ModInfo modLookingFor = null;
                    ModInfo newMod = null;
                    dynamic Manifest;
                    Manifest = FileHandler.LoadModManifest(mpath);
                    string uId = "";
                    string version = "";
                    if (Manifest == null || Manifest.Name == null)
                    {
                        Manifest = FileHandler.LoadALLManifest(mpath);
                        try
                        {
                            uId = String.Join(Manifest.About.ModName, Manifest.About.Author);
                            version = Manifest.About.Version;
                            newMod = new ModInfo(Manifest.About.ModName, Manifest.About.Author, version, System.IO.Path.GetDirectoryName(path), uId, "", Manifest.About.Description, "", true, false/*isX*/, "OrgXP", true);
                        }
                        catch (Exception)
                        {
                            ModType mt = new ModType(mf);
                            mt.ShowDialog(mf);
                            if (mf.dpath != null)
                            {
                                string dirPath = Path.GetDirectoryName(path);
                                var dirName = new DirectoryInfo(dirPath).Name;
                                destFolder = Path.Combine(mf.dpath , dirName);
                                if (destFolder.Contains("CustomFarming"))
                                {
                                    if(!Directory.Exists(Path.Combine(Settings.GameFolder,"Mods", "CustomFarming")))
                                    {
                                        MessageBox.Show("Custom Farming doesnt seem to be installed. Please install it first");
                                        return;
                                    }
                                    uId = String.Join("", "CustomFarming-", dirName);
                                    version = "1.0";
                                    newMod = new ModInfo(dirName, "CustomFarming","1.0", System.IO.Path.GetDirectoryName(path), String.Join("","CustomFarming-",Path.GetFileNameWithoutExtension(path)), "", "", Path.GetFileNameWithoutExtension(path), true, false/*isX*/, "OrgXP", false);
                                }
                                else
                                {
                                    if (!Directory.Exists(Path.Combine(Settings.GameFolder, "Mods", "CustomCritters")))
                                    {
                                        MessageBox.Show("Custom Critters doesnt seem to be installed. Please install it first");
                                        return;
                                    }
                                    uId = String.Join("", "CustomCritter-", dirName);
                                    version = "1.0";
                                    newMod = new ModInfo(dirName, "CustomCritter", "1.0", System.IO.Path.GetDirectoryName(path), String.Join("", "CustomCritter-", Path.GetFileNameWithoutExtension(path)), "", "", Path.GetFileNameWithoutExtension(path), true, false/*isX*/, "OrgXP", false);
                                }
                            }

                        }
                    }
                    else
                    {

                        uId = Manifest.UniqueID;
                        version = String.Concat(Manifest.Version.MajorVersion, ".", Manifest.Version.MinorVersion, ".", Manifest.Version.PatchVersion);
                        newMod = new ModInfo(Manifest.Name, Manifest.Author, version, System.IO.Path.GetDirectoryName(path), uId, Manifest.MinimumApiVersion, Manifest.Description, Manifest.EntryDll, true, false/*isX*/, "OrgXP", false);
                    }
                    modLookingFor = Mods.Find(x => x.UniqueID == uId);
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
                        addToTree(newMod, mf);
                    }
                    DirectoryInfo source = new DirectoryInfo(System.IO.Path.GetDirectoryName(path));
                    if (newMod.IsALL)
                    {
                        string dirPath = Path.GetDirectoryName(path);
                        var dirName = new DirectoryInfo(dirPath).Name;
                        destFolder = System.IO.Path.Combine(Settings.GameFolder, "Mods", "AdvancedLocationLoader", "locations", dirName);
                    }
                    else
                    {
                        if (newMod.EntryDll == "EntoaroxFramework.dll")
                        {
                            destFolder = System.IO.Path.Combine(Settings.GameFolder, "Mods", "!EntoaroxFramework");
                        }
                        else
                        {
                            if(destFolder == "")
                            destFolder = System.IO.Path.Combine(Settings.GameFolder, "Mods", Path.GetFileNameWithoutExtension(path));
                        }
                    }
                    var destination = new DirectoryInfo(destFolder);
                    source.MoveMod(destination);
                    FileHandler.SaveModList(Mods);
                    //Directory.Delete(System.IO.Path.GetFullPath(path), true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
