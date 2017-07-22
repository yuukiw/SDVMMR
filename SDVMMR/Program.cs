using System;
using Gtk;

namespace SDVMMR
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();		
			MainWindow win = new MainWindow();
			win.KeyPressEvent += (sender, e) =>
			{
				win.MethodWithLogic(e.Event.Key);
			};

			Startup start = new Startup();
			win.Show();
			Application.Run();
		}
	}
}
