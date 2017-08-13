using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVMMR
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetupEnvironment();
            Application.Run(new MainWindow());
        }

        internal static void SetupEnvironment()
        {
            if (!System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM")))
            {
                System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM"));
            }
            string path = Path.Combine(DirectoryOperations.getFolder("AppData"), "SDVMM", "SDVMM.json");
            //first of we check if the old non mono version of SDVMM was used
            //if so migrate the ini to the new system
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("OldAppData"), "SDVMM.ini")))
                {

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
