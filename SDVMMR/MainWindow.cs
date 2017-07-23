using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow : Gtk.Window
{
	internal List<SDVMMR.ModInfo> Mods = new List<SDVMMR.ModInfo>();

	//  TODO Set GOOD default values for settings
	internal SDVMMR.SDVMMSettings SDVMMSettings = new SDVMMR.SDVMMSettings("", false,  "", "", false, false, "" );

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
		if (key == Gdk.Key.Alt_R || key == Gdk.Key.Alt_L) 
		{
			if(smapiisInstalled == true)
			{ 
				if (Play_SDV.StockId == "SIcon")
				{
					Play_SDV.StockId = "SDVIcon";
					Play_SDV.ShortLabel = "Play SDV";
				}
				else
				{
					Play_SDV.StockId = "SIcon";
					Play_SDV.ShortLabel = "Start SMAPI";
				}			
			}
		}

	}

	protected void OnPlaySDVActivated(object sender, EventArgs e)
	{
		SDVMMR.Message Msg = new SDVMMR.Message("hi","this is a test");
		Msg.Show();
	}
protected void OnOpenSettingsActivated(object sender, EventArgs e)
{
		SDVMMR.Setting Swin =new SDVMMR.Setting(SDVMMSettings, Mods);
	   Swin.Show();
}



}
