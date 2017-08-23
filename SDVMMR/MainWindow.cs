using SDVMMR.JSON_Dummies;
using SDVMMR.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVMMR
{
    public partial class MainWindow : Form
    {

        internal bool ManualRaise = true;
        internal static SDVMMSettings SDVMMSettings = null;

        internal ModManager ModManager = null;
        private List<ModInfo> ListOfMods => ModManager.Mods;

        internal string SDVMMVersion = "1.0";

        internal static Translations Translation = null;
        internal static string key = "";

        internal static string selectedItemName = "";
        internal static string selectedItemAuthor = "";
        internal static string selectedItemState = "";
        internal static string selectedUID = "";
        internal static bool itemChanged = false;

        internal string dpath;

        internal static bool dMode = false;



        public MainWindow()
        {
            try
            {
                if (dMode)
                    Console.Write("building components...");
                InitializeComponent();
                if (dMode)
                    Console.Write("done, setting up window...");
                initWindow();
                SdvvmrV.Text = String.Join("", "SDVMM Version: ", SDVMMVersion);
                SDVV.Text = String.Join("", "SMAPI Version: ", SDVMMSettings.SmapiVersion);
                donate.Text = Translation.BuyMeACoffe;
                addMod.Text = Translation.AddMod;
                About.Text = Translation.About;
                OpenSDV.Text = Translation.OpenGameDir;
                OpenAPPData.Text = Translation.OpenAppdata;
                OpenSDVMM.Text = Translation.OpenSDVMMDir;
                Settings.Text = Translation.Settings;

                SMAPIUpdate.Text = "Smapi update found!";
                LinkLabel.Link link = new LinkLabel.Link();
                link.LinkData = "http://www.google.com";
                SMAPIUpdate.Links.Add(link);



                initListView();
                checkForMods();
                RefreshListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        private void initWindow()
        {
            try
            {

                if (dMode)
                    Console.Write("loading settings...");

                SDVMMSettings = FileHandler.LoadSettings();
                if (dMode)
                    Console.Write("settings loaded...");

                string XLversion = "";
                Mode.DropDownStyle = ComboBoxStyle.DropDownList;
                Mode.Items.Add("Details");
                Mode.Items.Add("Large Icons");
                Mode.Items.Add("Small Icons");
                Mode.Items.Add("List");
                Mode.Items.Add("Tile");
                Mode.Text = "Details";


                if (dMode)
                    Console.Write("checking for updates...");

                Updates.CheckForUpdates(SDVMMSettings.SmapiVersion, SDVMMVersion, XLversion, SDVMMSettings.GameFolder, this);

                if (!File.Exists(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations", "en.json")))
                {
                    using (WebClient WC = new WebClient())
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "lang.zip")))
                        {
                            System.IO.File.Delete(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "lang.zip"));
                        }
                        WC.Headers.Add("user-agent", "SDVMM/Version: 1.0");
                        WC.DownloadFile("https://drive.google.com/uc?export=download&id=0B94u0_R6vixWaGtXWVBDOVViaEk", System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "lang.zip"));
                        if (System.IO.Directory.Exists(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
                        {
                            Directory.Delete(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"), true);
                        }
                        if (!System.IO.Directory.Exists(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
                        }
                        zipHandling.extractZip(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "lang.zip"), System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder")));

                    }
                }

                if (SDVMMSettings.Language == null)
                {
                    key = "en";
                    Translation = FileHandler.LoadTranslations("en", new Translations());
                    var x = Directory.GetFiles(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations"), "*.json", SearchOption.TopDirectoryOnly).ToList();
                    if (x.Count == 2)
                    {
                        if (System.IO.Path.GetFileNameWithoutExtension(x[0]) != "en")
                        {
                            key = System.IO.Path.GetFileNameWithoutExtension(x[0]);
                            FileHandler.LoadTranslations(key, Translation);

                        }
                        else
                        {
                            key = System.IO.Path.GetFileNameWithoutExtension(x[1]);
                            FileHandler.LoadTranslations(key, Translation);

                        }
                    }
                    if (x.Count > 2)
                    {
                        string ci = CultureInfo.CurrentUICulture.ToString();
                        string[] SystemLanguage = ci.Split('-');
                        string path = System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations", String.Join(".", SystemLanguage[0], "json"));
                        if (x.Contains(path))
                        {
                            SDVMMSettings.Language = SystemLanguage[0];
                            FileHandler.SaveSettings(SDVMMSettings);
                            key = SDVMMSettings.Language;
                            Translation = FileHandler.LoadTranslations(key, new Translations());
                        }
                        else
                        {
                            key = null;
                            //Setting Swin = new Setting(SDVMMSettings);
                            // Swin.Show();
                        }
                    }
                }
                else
                {
                    key = SDVMMSettings.Language;
                    Translation = FileHandler.LoadTranslations(key, new Translations());
                }
                launchSMAPIItem.Checked = true;
                Launch.Text = launchSMAPIItem.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void initListView()
        {
            // Show CheckBoxes in the ListView.
            this.activeMods.CheckBoxes = true;

            //Set the column headers and populate the columns.
            activeMods.HeaderStyle = ColumnHeaderStyle.Clickable;

            activeMods.Columns.Add("Name", 150, HorizontalAlignment.Left);
            activeMods.Columns.Add("Author", 150, HorizontalAlignment.Left);
            activeMods.Columns.Add("Version", 50, HorizontalAlignment.Left);
            activeMods.Columns.Add("Desciption", 500, HorizontalAlignment.Left);
            activeMods.Columns.Add("uid", 0, HorizontalAlignment.Left);
            activeMods.Columns.Add("isa", 0, HorizontalAlignment.Left);
            activeMods.Columns.Add("isx", 0, HorizontalAlignment.Left);
            //activeMods.Columns["uid"]. = false;
            activeMods.View = View.Details;
            activeMods.ItemCheck += new ItemCheckEventHandler(activeMods_ItemCheck);
            activeMods.ColumnClick += new ColumnClickEventHandler(ColumnClick);
            this.search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            search.Text = "search...";


        }

        private void ColumnClick(object o, ColumnClickEventArgs e)
        {
            this.activeMods.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        class ListViewItemComparer : IComparer
        {
            private int col = 0;

            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }



        internal void checkForMods()
        {

            string filepath = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods");

            if (!Directory.Exists(filepath))
            {

            }
            else
            {
                DirectoryInfo d = new DirectoryInfo(filepath);

                foreach (var file in d.GetFiles("manifest.json", SearchOption.AllDirectories))
                {
                    ModInfo modLookingFor = null;
                    ModInfo newMod = null;
                    if (file.FullName.Contains("AdvancedLocationLoader") & file.FullName.Contains("locations"))
                    {
                        ALLManifest Manifest = FileHandler.LoadALLManifest(file.FullName);
                        string uId = String.Join(Manifest.About.ModName, Manifest.About.Author);
                        string version = Manifest.About.Version;
                        newMod = new ModInfo(Manifest.About.ModName, Manifest.About.Author, version, System.IO.Path.GetDirectoryName(file.FullName), uId, "", Manifest.About.Description, "", true, false/*isX*/, "OrgXP", true);
                        modLookingFor = ListOfMods.Find(x => x.UniqueID == uId);
                    }
                    else
                    {
                        ModManifest Manifest = FileHandler.LoadModManifest(file.FullName);
                        string uId = Manifest.UniqueID;
                        string version = String.Concat(Manifest.Version.MajorVersion, ".", Manifest.Version.MinorVersion, ".", Manifest.Version.PatchVersion);
                        newMod = new ModInfo(Manifest.Name, Manifest.Author, version, System.IO.Path.GetDirectoryName(file.FullName), uId, Manifest.MinimumApiVersion, Manifest.Description, Manifest.EntryDll, true, false/*isX*/, "OrgXP", false);
                        modLookingFor = ListOfMods.Find(x => x.UniqueID == uId);
                    }
                    if (modLookingFor == null)
                        ListOfMods.Add(newMod);
                }
                if (!Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods")))
                    Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods"));

                filepath = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods");
                d = new DirectoryInfo(filepath);

                foreach (var file in d.GetFiles("manifest.json", SearchOption.AllDirectories))
                {
                    ModManifest Manifest = FileHandler.LoadModManifest(file.FullName);
                    string uId = Manifest.UniqueID;
                    string version = String.Concat(Manifest.Version.MajorVersion, ".", Manifest.Version.MinorVersion, ".", Manifest.Version.PatchVersion);
                    ModInfo newMod = new ModInfo(Manifest.Name, Manifest.Author, version, System.IO.Path.GetDirectoryName(file.FullName), uId, Manifest.MinimumApiVersion, Manifest.Description, Manifest.EntryDll, false, false/*isX*/, "OrgXP", false);


                    ModInfo modLookingFor = ListOfMods.Find(x => x.UniqueID == uId);
                    if (modLookingFor == null)
                        ListOfMods.Add(newMod);

                }

                if (Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivatedMods")))
                {
                    filepath = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivatedMods");
                    d = new DirectoryInfo(filepath);

                    foreach (var file in d.GetFiles("manifest.json", SearchOption.AllDirectories))
                    {
                        ModManifest Manifest = FileHandler.LoadModManifest(file.FullName);
                        string uId = Manifest.UniqueID;
                        string version = String.Concat(Manifest.Version.MajorVersion, ".", Manifest.Version.MinorVersion, ".", Manifest.Version.PatchVersion);
                        ModInfo newMod = new ModInfo(Manifest.Name, Manifest.Author, version, System.IO.Path.GetDirectoryName(file.FullName), uId, Manifest.MinimumApiVersion, Manifest.Description, Manifest.EntryDll, false, false/*isX*/, "OrgXP", false);


                        ModInfo modLookingFor = ListOfMods.Find(x => x.UniqueID == uId);
                        if (modLookingFor == null)
                        {
                            ListOfMods.Add(newMod);
                            var source = new DirectoryInfo(System.IO.Path.GetDirectoryName(file.FullName));
                            var destination = new DirectoryInfo(file.FullName.Replace(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivatedMods"), System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods")));
                            source.MoveMod(destination);
                        }
                    }
                }
                if (Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters")))
                {
                    var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters"));
                    foreach (var Dir in dirList.GetDirectories().ToArray())
                    {
                        string uId = "CustomCritters-" + Dir.Name;
                        string version = "1.0";
                        ModInfo newMod = new ModInfo(Dir.Name, "CustomCritter", version, System.IO.Path.GetDirectoryName(Dir.FullName), uId, "", "", "", true, false/*isX*/, "OrgXP", false);


                        ModInfo modLookingFor = ListOfMods.Find(x => x.UniqueID == uId);
                        if (modLookingFor == null)
                        {
                            ListOfMods.Add(newMod);
                        }
                    }
                }
                if (Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters")))
                {
                    var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent"));
                    foreach (var Dir in dirList.GetDirectories().ToArray())
                    {
                        string uId = "CustomFarming-" + Dir.Name;
                        string version = "1.0";
                        ModInfo newMod = new ModInfo(Dir.Name, "CustomFarming", version, System.IO.Path.GetDirectoryName(Dir.FullName), uId, "", "", "", true, false/*isX*/, "OrgXP", false);


                        ModInfo modLookingFor = ListOfMods.Find(x => x.UniqueID == uId);
                        if (modLookingFor == null)
                        {
                            ListOfMods.Add(newMod);
                        }
                    }
                }
            }
            FileHandler.SaveModList(ListOfMods);
            RefreshListView();
        }

        internal void RefreshListView()
        {
            activeMods.Items.Clear();


            foreach (ModInfo Mod in ListOfMods)
            {
                ManualRaise = false;

                ModManager mm = new ModManager(SDVMMSettings, this);
                mm.addToTree(Mod, this);

            }
        }


        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                ManualRaise = false;
                activeMods.Items.Clear();
                string text = search.Text;
                ModManager mm = new ModManager(SDVMMSettings, this);
                //defining the parameter
                string Author = "Author: ";
                string UID = "uID: ";
                /*string isAcitve = "-Active";
                string isnotActive = "-notActive";
                string isXNB = "-isXnb";
                string isALL = "-isALL:";
                string depends = "depends:";*/




                foreach (ModInfo Mod in ListOfMods.ToArray())
                {
                    if (text.Contains(Author))
                    {
                        text = text.Replace(Author, "");
                        //text = text,Remove(sourceString.IndexOf(removeString), removeString.Length);

                        if (Mod.Author.Contains(text, StringComparison.OrdinalIgnoreCase))
                        {
                            mm.addToTree(Mod, this);
                        }

                    }
                    if (text.Contains(UID))
                    {
                        text.Replace(UID, "");
                        if (Mod.UniqueID == UID)
                        {
                            mm.addToTree(Mod, this);
                        }
                    }
                    else
                    {
                        if (Mod.Name.Contains(text, StringComparison.OrdinalIgnoreCase) & Mod.Description.Contains(text, StringComparison.OrdinalIgnoreCase))
                        {
                            mm.addToTree(Mod, this);
                        }
                    }
                }
                if (activeMods.Items.Count == 0)
                {
                    MessageBox.Show("No result, reseting search.");
                    search.Text = "search...";
                    RefreshListView();
                }
                ManualRaise = true;
            }
        }

        public void addToList(ListViewItem Item)
        {
            activeMods.Items.Add(Item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManualRaise = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void activeMods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addMod_ButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog filechooser = new OpenFileDialog();
            filechooser.Filter = "All suported Files|*.dll;*.zip;*.xnb;`*.json|SMAPI|*.dll|XNB|*.xnb|zip|*.zip|Json|*.json";
            filechooser.Title = Translation.FCMods;
            filechooser.Multiselect = true;
            if (filechooser.ShowDialog() == System.Windows.Forms.DialogResult.OK)

            {
                ManualRaise = false;
                foreach (string File in filechooser.FileNames)
                {
                    var folder = File;
                    ModManager mm = new ModManager(SDVMMSettings, this);
                    mm.addMod(folder, false, "");
                    RefreshListView();
                }
                /*             var folder = filechooser.FileName;
                             ModManager mm = new ModManager(SDVMMSettings, this);
                             mm.addMod(folder, false, "");
                             RefreshListView();*/
                ManualRaise = true;
            }
        }


        private void addMod_Click(object sender, EventArgs e)
        {

        }


        private void activeMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ManualRaise)
            {
                ManualRaise = false;
                bool dependingMods = false;
                int index = e.Index;
                item = activeMods.Items[index];
                var subitem = item.SubItems;
                string uID = subitem[4].Text;
                var itemToChange = ListOfMods.Where(x => x.UniqueID == uID).FirstOrDefault();
                if (itemToChange.IsXnb)
                { }
                else
                {
                    if (uID == "Entoarox.AdvancedLocationLoader" & itemToChange.IsActive)
                    {
                        string msg = Translation.changeStateDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;

                        foreach (ModInfo mod in ListOfMods.Where(x => x.IsALL == true))
                        {
                            dependingMods = true;
                            msg += mod.Name + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                            if (activeMods.Items[index].Checked == false)
                                activeMods.Items[index].Checked = true;
                            RefreshListView();
                        }
                    }
                    if (uID == "spacechase0.CustomCritters" & itemToChange.IsActive)
                    {
                        var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters"));
                        string msg = Translation.changeStateDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;
                        foreach (var dir in dirList.GetDirectories().ToArray())
                        {
                            dependingMods = true;
                            msg += Path.GetFileName(dir.FullName) + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                            if (activeMods.Items[index].Checked == false)
                                activeMods.Items[index].Checked = true;
                            RefreshListView();
                        }
                    }
                    if (uID == "Platonymous.CustomFarming" & itemToChange.IsActive)
                    {
                        var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent"));
                        string msg = Translation.changeStateDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;
                        foreach (var dir in dirList.GetDirectories().ToArray())
                        {
                            dependingMods = true;
                            msg += Path.GetFileName(dir.FullName) + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                            if (activeMods.Items[index].Checked == false)
                                activeMods.Items[index].Checked = true;
                            RefreshListView();
                        }
                    }
                    // future check for depedendcies in smapi 2.0 will be done here
                    //foreach (ModInfo mod in ListOfMods.Where(x => x.Dependencies.UniqueId == uID & x => x.Dependencies.isRequired))
                    //{
                    //    dependingMods = true;
                    //    msg += mod.Name + System.Environment.NewLine;
                    //}
                    if (!dependingMods)
                    {
                        if (!System.IO.Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods")))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods"));
                        }
                        if (e.CurrentValue == CheckState.Checked)
                        {
                            string destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", itemToChange.EntryDll.Replace(".dll", ""));
                            var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", itemToChange.EntryDll.Replace(".dll", "")));
                            if (itemToChange.EntryDll == "EntoaroxFramework.dll")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "!EntoaroxFramework");
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "!EntoaroxFramework"));
                            }
                            if (itemToChange.Author == "CustomCritter")
                            {
                                if (!Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent")))
                                    Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomCritters", "Critters"));
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomCritters", "Critters", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters", itemToChange.Name));
                            }
                            if (itemToChange.Author == "CustomFarming")
                            {
                                if (!Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent")))
                                    Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent"));
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent", itemToChange.Name));
                            }
                            if (itemToChange.IsALL)
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", ""));
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", "")));
                            }
                            var destination = new DirectoryInfo(destFolder);
                            source.MoveMod(destination);
                            itemToChange.IsActive = false;
                            if (source.Exists)
                                source.Delete(true);
                            item.Checked = true;
                        }
                        else
                        {
                            string destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", itemToChange.EntryDll.Replace(".dll", ""));
                            var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", itemToChange.EntryDll.Replace(".dll", "")));
                            if (itemToChange.EntryDll == "EntoaroxFramework.dll")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "!EntoaroxFramework");
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "!EntoaroxFramework"));
                            }
                            if (itemToChange.Author == "CustomCritter")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomCritters", "Critters", itemToChange.Name));
                            }
                            if (itemToChange.Author == "CustomFarming")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent", itemToChange.Name));
                            }
                            if (itemToChange.IsALL)
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", ""));
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", "")));
                            }

                            var destination = new DirectoryInfo(destFolder);
                            source.MoveMod(destination);
                            itemToChange.IsActive = true;
                            if (source.Exists)
                                source.Delete(true);
                            item.Checked = true;
                        }
                        FileHandler.SaveModList(ListOfMods);
                        //RefreshListView();
                    }
                    ManualRaise = true;
                }
            }

        }

        private ListViewItem item = null;

        private void activeMods_MouseDown(object sender, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Right)    // Right button click
            {
                ContextMenu m = new ContextMenu();
                item = activeMods.GetItemAt(args.X, args.Y);
                if (item == null)
                { }
                else
                {
                    var subitem = item.SubItems;
                    string uID = subitem[4].Text;
                    bool isX = Boolean.Parse(subitem[6].Text);
                    string text = String.Join("", "Delete ", item.Text);
                    MenuItem deleteItem = new MenuItem(text);
                    deleteItem.Click += new EventHandler(delete_Click);
                    m.MenuItems.Add(deleteItem);
                    var mod = ListOfMods.Where(x => x.UniqueID == uID).FirstOrDefault();
                    if (isX == false)
                    {
                        if (mod.IsActive)
                        {
                            text = String.Join("", "Deactivate ", item.Text);
                        }
                        else
                        {
                            text = String.Join("", "Activate ", item.Text);
                        }
                        MenuItem changeState = new MenuItem(text);
                        changeState.Click += new EventHandler(change_Click);
                        m.MenuItems.Add(changeState);


                        MenuItem OpenFolder = new MenuItem("openFolder");
                        OpenFolder.Click += new EventHandler(openFolderItem_Click);
                        m.MenuItems.Add(OpenFolder);
                    }

                    activeMods.ContextMenu = m;
                    m.Show(activeMods, new System.Drawing.Point(args.X, args.Y));
                }
            }
        }

        private void openFolderItem_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                var subitem = item.SubItems;
                string uID = subitem[4].Text;
                var itemFound = ListOfMods.Where(x => x.UniqueID == uID).FirstOrDefault();
                string folder = itemFound.IsActive ? "Mods" : "deactivated Mods";
                if (uID != "Entoarox.EntoaroxFramework")
                {
                    if (itemFound.Author == "CustomCritter")
                    {
                        Process.Start(Path.Combine(SDVMMSettings.GameFolder, folder, "CustomCritters", "Critters", itemFound.Name));
                    }
                    if (itemFound.Author == "CustomFarming")
                    {
                        Process.Start(Path.Combine(SDVMMSettings.GameFolder, folder, "CustomFarming", "CustomContent", itemFound.Name));
                    }
                    else
                        Process.Start(Path.Combine(SDVMMSettings.GameFolder, folder, itemFound.EntryDll.Replace(".dll", "")));
                }
                else
                {

                    Process.Start(Path.Combine(SDVMMSettings.GameFolder, folder, String.Join("", "!", itemFound.EntryDll.Replace(".dll", ""))));
                }
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                bool dependingMods = false;
                var subitem = item.SubItems;
                string uID = subitem[4].Text;
                var itemToChange = ListOfMods.Where(x => x.UniqueID == uID).FirstOrDefault();
                if (itemToChange.IsXnb)
                { }
                else
                {
                    if (!System.IO.Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods")))
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods"));
                    }
                    if (uID == "Entoarox.AdvancedLocationLoader" & itemToChange.IsActive)
                    {
                        //string msg = $"Cant change the state of {item.Text} due it being required by:" + System.Environment.NewLine;
                        string msg = Translation.changeStateDepError.Replace("{item.Text}",item.Text) + Environment.NewLine;
                        foreach (ModInfo mod in ListOfMods.Where(x => x.IsALL == true))
                        {
                            dependingMods = true;
                            msg += mod.Name + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                            RefreshListView();
                            ManualRaise = true;
                            return;
                        }
                    }
                    if (uID == "spacechase0.CustomCritters" & itemToChange.IsActive)
                    {
                        var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters"));
                        //string msg = $"Cant change the state of {item.Text} due it being required by:" + System.Environment.NewLine;
                        string msg = Translation.changeStateDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;
                        foreach (var dir in dirList.GetDirectories().ToArray())
                        {
                            dependingMods = true;
                            msg += Path.GetFileName(dir.FullName) + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                        }
                    }
                    if (uID == "Platonymous.CustomFarming" & itemToChange.IsActive)
                    {
                        var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent"));
                        //string msg = $"Cant change the state of {item.Text} due it being required by:" + System.Environment.NewLine;
                        string msg = Translation.changeStateDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;
                        foreach (var dir in dirList.GetDirectories().ToArray())
                        {
                            dependingMods = true;
                            msg += Path.GetFileName(dir.FullName) + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                        }
                    }
                    // future check for depedendcies in smapi 2.0 will be done here
                    //foreach (ModInfo mod in ListOfMods.Where(x => x.Dependencies.UniqueId == uID & x => x.Dependencies.isRequired))
                    //{
                    //    dependingMods = true;
                    //    msg += mod.Name + System.Environment.NewLine;
                    //}

                    if (!dependingMods)
                    {
                        if (itemToChange.IsActive)
                        {
                            string destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", itemToChange.EntryDll.Replace(".dll", ""));
                            var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", itemToChange.EntryDll.Replace(".dll", "")));
                            if (itemToChange.EntryDll == "EntoaroxFramework.dll")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "!EntoaroxFramework");
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "!EntoaroxFramework"));
                            }
                            if (itemToChange.Author == "CustomCritter")
                            {
                                if (!Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent")))
                                    Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomCritters", "Critters"));
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomCritters", "Critters", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters", itemToChange.Name));
                            }
                            if (itemToChange.Author == "CustomFarming")
                            {
                                if (!Directory.Exists(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent")))
                                    Directory.CreateDirectory(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent"));
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent", itemToChange.Name));
                            }
                            if (itemToChange.IsALL)
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", ""));
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", "")));
                            }
                            var destination = new DirectoryInfo(destFolder);
                            source.MoveMod(destination);
                            itemToChange.IsActive = false;
                            if (source.Exists)
                                source.Delete(true);

                        }
                        else
                        {



                            string destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", itemToChange.EntryDll.Replace(".dll", ""));
                            var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", itemToChange.EntryDll.Replace(".dll", "")));
                            if (itemToChange.EntryDll == "EntoaroxFramework.dll")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "!EntoaroxFramework");
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "!EntoaroxFramework"));
                            }
                            if (itemToChange.Author == "CustomCritter")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomCritters", "Critters", itemToChange.Name));
                            }
                            if (itemToChange.Author == "CustomFarming")
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent", itemToChange.Name);
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent", itemToChange.Name));
                            }
                            if (itemToChange.IsALL)
                            {
                                destFolder = System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", ""));
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "AdvancedLocationLoader", "locations", itemToChange.Name.Replace(" ", "")));
                            }
                            var destination = new DirectoryInfo(destFolder);
                            source.MoveMod(destination);
                            source.Delete(true);
                            itemToChange.IsActive = true;
                            if (source.Exists)
                                source.Delete(true);

                        }
                        FileHandler.SaveModList(ListOfMods);
                        RefreshListView();
                    }
                    ManualRaise = true;
                }
            }
        }

        void delete_Click(object sender, EventArgs e)
        {
            bool dependingMods = false;
            if (item != null)
            {
                var subitem = item.SubItems;
                string uID = subitem[4].Text;
                var itemToRemove = ListOfMods.Where(x => x.UniqueID == uID).FirstOrDefault();
                if (itemToRemove.IsXnb == false)
                {
                    if (uID == "Entoarox.AdvancedLocationLoader")
                    {
                        //string msg = $"Cant delete {item.Text} due it being required by:" + System.Environment.NewLine;
                        string msg = Translation.delModDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;
                        foreach (ModInfo mod in ListOfMods.Where(x => x.IsALL == true))
                        {
                            dependingMods = true;
                            msg += mod.Name + System.Environment.NewLine;
                        }
                        if (dependingMods)
                            MessageBox.Show(msg);
                    }
                    if (uID == "spacechase0.CustomCritters")
                    {
                        var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters"));
                        //string msg = $"Cant delete {item.Text} due it being required by:" + System.Environment.NewLine;
                        string msg = Translation.delModDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;
                        foreach (var dir in dirList.GetDirectories().ToArray())
                        {
                            dependingMods = true;
                            msg += Path.GetFileName(dir.FullName) + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                        }
                    }
                    if (uID == "Platonymous.CustomFarming")
                    {
                        var dirList = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent"));
                        //string msg = $"Cant delete {item.Text} due it being required by:" + System.Environment.NewLine;
                        string msg = Translation.delModDepError.Replace("{item.Text}", item.Text) + Environment.NewLine;
                        foreach (var dir in dirList.GetDirectories().ToArray())
                        {
                            dependingMods = true;
                            msg += Path.GetFileName(dir.FullName) + System.Environment.NewLine;
                        }
                        if (dependingMods)
                        {
                            MessageBox.Show(msg);
                        }
                    }
                    // future check for depedendcies in smapi 2.0 will be done here
                    //foreach (ModInfo mod in ListOfMods.Where(x => x.Dependencies.UniqueId == uID & x => x.Dependencies.isRequired))
                    //{
                    //    dependingMods = true;
                    //    msg += mod.Name + System.Environment.NewLine;
                    //}

                    if (!dependingMods)
                    {
                        if (itemToRemove.IsActive == true)
                        {
                            var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", itemToRemove.EntryDll.Replace(".dll", "")));
                            if (itemToRemove.Author == "CustomCritter")
                            {
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomCritters", "Critters", itemToRemove.Name));
                            }
                            if (itemToRemove.Author == "CustomFarming")
                            {
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "CustomFarming", "CustomContent", itemToRemove.Name));
                            }
                            source.Delete(true);
                        }
                        else
                        {
                            var source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", itemToRemove.EntryDll.Replace(".dll", "")));
                            if (itemToRemove.Author == "CustomCritters")
                            {
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomCritters", "Critters", itemToRemove.Name));
                            }
                            if (itemToRemove.Author == "CustomFarming")
                            {
                                source = new DirectoryInfo(System.IO.Path.Combine(SDVMMSettings.GameFolder, "deactivated Mods", "CustomFarming", "CustomContent", itemToRemove.Name));
                            }
                            source.Delete(true);
                        }
                    }

                }
                else
                {
                    if (SDVMMSettings.overWrite == false)
                    {
                        string name = string.Join(".", itemToRemove.Name, "xnb");
                        recSearchForXNB.recXNB(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Mods", "XNBLoader", "content"), name, SDVMMSettings, this, "", "remove", null);
                    }
                    else
                    {
                        string name = string.Join(".", itemToRemove.Name, "xnb");
                        string path = recSearchForXNB.recXNB(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Content"), name, SDVMMSettings, this, "", "remove", itemToRemove.UniqueID);
                        if (path != null)
                        {
                            File.Delete(path);
                            File.Copy(itemToRemove.OrgXnbPath, path);
                        }


                    }
                }
                if (itemToRemove != null & !dependingMods)
                    ListOfMods.Remove(itemToRemove);
                RefreshListView();
                FileHandler.SaveModList(ListOfMods);
            }

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var myForm = new Setting(SDVMMSettings);
            myForm.Show();
        }

        private void launchSDVMMItem_Click(object sender, EventArgs e)
        {
            if (ManualRaise)
            {
                ManualRaise = false;
                if (launchSMAPIItem.CheckState == CheckState.Checked)
                    launchSMAPIItem.CheckState = CheckState.Unchecked;
                Launch.Text = launchSDVItem.Text;
                Image myImage = Resources.SDV;
                Launch.Image = myImage;
                ManualRaise = true;
                Launch.PerformButtonClick();
            }
        }

        private void launchSMAPIItem_Click(object sender, EventArgs e)
        {
            if (ManualRaise)
            {
                ManualRaise = false;
                if (launchSDVItem.CheckState == CheckState.Checked)
                    launchSDVItem.CheckState = CheckState.Unchecked;
                Image myImage = Resources.SMAPI;
                Launch.Image = myImage;
                Launch.Text = launchSMAPIItem.Text;
                ManualRaise = true;
                Launch.PerformButtonClick();
            }
        }

        private void Launch_ButtonClick(object sender, EventArgs e)
        {
            if (Launch.Text == launchSDVItem.Text)
            {
                if (SDVMMSettings.SteamFolder != DirectoryOperations.getFolder("AppData"))
                {
                    var x = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        Process.Start(System.IO.Path.Combine(SDVMMSettings.SteamFolder, "Steam.exe"), "-applaunch 413150");
                    else
                        Process.Start("mono", System.IO.Path.Combine(SDVMMSettings.GameFolder, "Stardew Valley.exe"));
                }
                else
                {
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        Process.Start(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Stardew Valley.exe"));
                    else
                        Process.Start(System.IO.Path.Combine(SDVMMSettings.GameFolder, "Stardew Valley"));
                }
            }
            else
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    Process.Start(System.IO.Path.Combine(SDVMMSettings.GameFolder, "StardewModdingAPI.exe"));
                else
                {

                    var x = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
                    string path = String.Join("", SDVMMSettings.GameFolder, System.IO.Path.DirectorySeparatorChar.ToString(), "StardewModdingAPI");
                    Process.Start(path);
                    Task.Delay(2000);
                    foreach (var process in Process.GetProcessesByName("StardewModdingAPI.bin.x86"))
                    {
                        //process.Kill();
                        MessageBox.Show("hi");
                    }
                    foreach (var process in Process.GetProcessesByName("StardewModdingAPI.bin.x86_64"))
                    {

                        MessageBox.Show("hi2");
                    }
                }
            }
        }


        internal static bool tile = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (activeMods.View == View.Details)
                activeMods.View = View.LargeIcon;
            else
            {
                if (activeMods.View == View.LargeIcon)
                    activeMods.View = View.SmallIcon;
                else
                {
                    if (activeMods.View == View.SmallIcon)
                        activeMods.View = View.List;
                    else
                    {
                        if (activeMods.View == View.List)
                        {
                            tile = true;
                            activeMods.CheckBoxes = false;
                            activeMods.View = View.Tile;
                            RefreshListView();
                        }
                        else
                        {
                            tile = false;
                            activeMods.View = View.Details;
                            activeMods.CheckBoxes = true;
                            RefreshListView();
                        }
                    }
                }

            }
        }

        private void betterSplitButton1_Click(object sender, EventArgs e)
        {

        }

        private void OpenSDV_ButtonClick(object sender, EventArgs e)
        {
            Process.Start(SDVMMSettings.GameFolder);
        }

        private void OpenSDVMM_Click(object sender, EventArgs e)
        {
            Process.Start(DirectoryOperations.getFolder("ExeFolder"));
        }

        private void OpenAPPData_Click(object sender, EventArgs e)
        {
            Process.Start(DirectoryOperations.getFolder("AppData"));
        }

        private void donate_Click(object sender, EventArgs e)
        {
            Process.Start("https://ko-fi.com/A130310B");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Mode.Text)
            {
                case "Details": tile = false; activeMods.View = View.Details; activeMods.CheckBoxes = true; RefreshListView(); break;
                case "Large Icons": tile = false; activeMods.View = View.LargeIcon; activeMods.CheckBoxes = true; RefreshListView(); break;
                case "Small Icons": tile = false; activeMods.View = View.SmallIcon; activeMods.CheckBoxes = true; RefreshListView(); break;
                case "List": tile = false; activeMods.View = View.List; activeMods.CheckBoxes = true; RefreshListView(); break;
                case "Tile": tile = true; activeMods.TileSize = new Size(200, 100); activeMods.CheckBoxes = false; activeMods.View = View.Tile; RefreshListView(); break;
                default: tile = false; activeMods.View = View.Details; activeMods.CheckBoxes = true; RefreshListView(); break;
            }

        }

        private void SMAPIUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.google.com");
        }

        private void SMAPIUpdate_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.google.com");
        }

        private void downloadModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManualRaise = false;
            //Xpcom.Initialize(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "xulrunner"));
            Browser Wb = new Browser("http://www.nexusmods.com/stardewvalley/mods/searchresults/?src_cat=1", this, SDVMMSettings);
            Wb.Show();
            ManualRaise = false;
        }


    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }

}
