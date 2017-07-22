using System;
namespace SDVMMR
{
	public partial class Setting : Gtk.Window
	{
		public Setting() :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
	}
}
