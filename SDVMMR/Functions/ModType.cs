using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVMMR.Functions
{
    public partial class ModType : Form
    {


        MainWindow MainWindow;
        public ModType( MainWindow Mf)
        {
            InitializeComponent();
            this.MainWindow = Mf;
            type.Items.Add("Custom Critters");
            type.Items.Add("Custom Farming");
            type.Items.Add("I don`t know");
            type.Text = "I dont know";
        }

        private void ok_Click(object sender, EventArgs e)
        {
            switch(type.Text)
            {
                case "Custom Critters": MainWindow.dpath = Path.Combine(MainWindow.SDVMMSettings.GameFolder,"Mods", "CustomCritters","Critters"); break;
                case "Custom Farming": MainWindow.dpath = Path.Combine(MainWindow.SDVMMSettings.GameFolder, "Mods", "CustomFarming" ,"CustomContent"); break;
                default : MessageBox.Show("Please check the mod instructions"); MainWindow.dpath = null; break;
            }
            this.Close();
        }
    }
}
