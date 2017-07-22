using System;
using Gtk;
using Glade;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

	}



	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	public void MethodWithLogic(Gdk.Key key)
	{
		Boolean smapiisInstalled = true;
		if (key == Gdk.Key.Control_R) 
		{
			if(smapiisInstalled == true)
			{ 
				if (Play_SDV.StockId == "SDVMMR.SMAPI_mascot.png")
				{
					Play_SDV.StockId = "SDVMMR.White_Chicken.png";
					Play_SDV.ShortLabel = "Play SDV";
				}
				else
				{
					Play_SDV.StockId = "SDVMMR.SMAPI_mascot.png";
					Play_SDV.ShortLabel = "Start SMAPI";
				}			
			}
		}

	}


}
