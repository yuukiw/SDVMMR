using System;
using Gtk;
using Glade;

namespace SDVMMR {
	class MainClass {
		public static void Main(string[] args) {
			try {
				Application.Init();
				MainWindow win = new MainWindow();
				//Startup start = new Startup(win.SDVMMSettings, win.Mods);
				win.Show();
				Application.Run();
			} catch (Exception ex) {
				Console.Write(ex.ToString());
				Message msg = new SDVMMR.Message(ex.ToString(), "error");
				msg.Show();
			}

		}
	}
}
