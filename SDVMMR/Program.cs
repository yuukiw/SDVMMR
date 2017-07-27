using System;
using Gtk;
using Glade;

namespace SDVMMR {
	class MainClass {
		public static void Main(string[] args) {
			MainWindow main = null;

			try {
				Application.Init();
				main = new MainWindow();
				//Startup start = new Startup(win.SDVMMSettings, win.Mods);

				main.Show();
				Application.Run();
			} catch (Exception ex) {

				// close main window to prevent further damage
				if (main != null)
					main.Destroy();

				Console.Write(ex);

				// Alert User
				ErrorAlert alert = new ErrorAlert(ex.ToString(), "Error") {
					DefaultWidth = 100,
					DefaultHeight = 100
				};

				alert.WindowShouldClosed += (sender, e) => {
					Application.Quit();
				};

				Application.Run();
				alert.Present();
			}

		}
	}
}
