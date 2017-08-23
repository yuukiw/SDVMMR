using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;

namespace SDVMMR
{
    public partial class Browser : Form
    {
        List<Uri> HistoryStack;
        int HistoryStack_Index;
        bool fromHistory;
        MainWindow Mf = null;
        SDVMMSettings settings = null;
        internal string bHome;
        internal string file;

        public Browser(string url, MainWindow mf, SDVMMSettings set)
        {


            try
            {
                Mf = mf;
                settings = set;
                bHome = url;
                string URL = url;
                HistoryStack = new List<Uri>();
                HistoryStack_Index = 0;
                fromHistory = false;
                InitializeComponent();                
                var app_dir = Path.GetDirectoryName(Application.ExecutablePath);
                Gecko.Xpcom.Initialize(Path.Combine("Firefox"));
                webBrowser1.Navigate(URL);
                //webBrowser1.ScriptErrorsSuppressed = true;

                UpdateNavButtons();
                }catch(Exception  ex)
            {
                MessageBox.Show((ex.ToString()));
            }
            }


        private void webBrowser1_Navigating(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {
            if (!fromHistory)
            {
                if (HistoryStack_Index < HistoryStack.Count)
                {
                    HistoryStack.RemoveRange(HistoryStack_Index, HistoryStack.Count - HistoryStack_Index);
                }
                HistoryStack.Add(e.Uri);
                HistoryStack_Index++;
                UpdateNavButtons();
            }
            fromHistory = false;
            
            if (e.Uri.Segments[e.Uri.Segments.Length - 1].EndsWith(".zip")|| e.Uri.Segments[e.Uri.Segments.Length - 1].EndsWith(".rar"))
            {
                file = "Mod.zip";

                if (e.Uri.Segments[e.Uri.Segments.Length - 1].EndsWith(".rar"))
                {
                    file = "Mod.rar";
                }
                var url = e.Uri;
                e.Cancel = true;
                using (WebClient WC = new WebClient())
                {
                    try
                    {
                        if (System.IO.File.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), file)))
                        {
                            System.IO.File.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), file));
                        }

                        WC.Headers.Add("user-agent", "SDVMM/Version: 1.0");
                        WC.DownloadFileAsync(url, Path.Combine(DirectoryOperations.getFolder("ExeFolder"), file));
                        WC.DownloadFileCompleted += new AsyncCompletedEventHandler(WC_DownloadFileCompleted);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
            {
                Directory.Delete(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"), true);
            }

            if (!System.IO.Directory.Exists(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked")))
            {
                System.IO.Directory.CreateDirectory(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "unpacked"));
            }

            Mf.ManualRaise = false;
            ModManager mm = new ModManager(settings,Mf);
            mm.addMod(Path.Combine(DirectoryOperations.getFolder("ExeFolder"), file), false, "");
            Mf.RefreshListView();
            Mf.ManualRaise = false;
        }

        private void back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            if (HistoryStack_Index > 1)
            {
                HistoryStack_Index--;
                fromHistory = true;
               // webBrowser1.Navigate(HistoryStack[HistoryStack_Index - 1]);
                UpdateNavButtons();
            }
        }

        private void forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            if (HistoryStack_Index < HistoryStack.Count)
            {
                HistoryStack_Index++;
                fromHistory = true;
               // webBrowser1.Navigate(HistoryStack[HistoryStack_Index - 1]);
                UpdateNavButtons();
            }
        }

        private void UpdateNavButtons()
        {
            back.Enabled = HistoryStack_Index > 1;
            forward.Enabled = HistoryStack_Index < HistoryStack.Count;
        }

        private void home_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(bHome);
        }

    }


}
