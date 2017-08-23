using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SDVMMR
{
    static class Program
    {
        internal static  bool dMode = false;

        public static bool IsDebugRelease
        {
            get
            {
#if DEBUG
            return true;
#else
                return false;
#endif
            }
        }


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            dMode = IsDebugRelease;
            
            try
            {
                if(dMode)
                Console.Write("Starting up...");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (dMode)
                    Console.Write("setting up enviorment...");
                SetupEnvironment();
                if (dMode)
                    Console.Write("done, trying to open MainWindow now");

                Application.Run(new MainWindow());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void SetupEnvironment()
        {
            if (dMode)
                Console.Write("looking for Config of old version if windows...");

            //first of we check if the old non mono version of SDVMM was used
            //if so migrate the ini to the new system
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini")))
                {
                    if (!System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM")))
                    {
                        System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM"));
                    }
                    string path = Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json");

                    string language = "en";
                    string oldPath = Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini");
                    string GFolder = iniParsing.INI_ReadValueFromFile("General", "GameFolder", "C:\\", oldPath);
                    string SFolder = iniParsing.INI_ReadValueFromFile("General", "SteamFolder", "C:\\", oldPath);
                    string GoGV = iniParsing.INI_ReadValueFromFile("General", "SteamFolder", "C:\\", oldPath);
                    string SVersion = iniParsing.INI_ReadValueFromFile("SMAPI Details", "Version", "C:\\", oldPath);
                    bool isGOG = (GoGV == "1");
                    if (!System.IO.File.Exists(path))
                    {
                        DirectoryOperations.CreateFile(path);
                    }

                    var settings = new SDVMMSettings(language, SVersion, GFolder, SFolder, isGOG, false);

                    FileHandler.SaveSettings(settings);
                    System.IO.File.Delete(Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini"));
                }
            }
        }
    }
}
