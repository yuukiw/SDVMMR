using System;
using System.IO;
using System.Linq;
using Gtk;

namespace SDVMMR
{
	public partial class ChooseLanguage : Gtk.Dialog
	{
		internal static string lang;
		public ChooseLanguage()
		{
			
			var x = Directory.GetFiles(System.IO.Path.Combine(DirectoryOperations.getFolder("ExeFolder"), "Translations"), "*.json", SearchOption.TopDirectoryOnly).ToList();

			this.Build();
			ListStore store = new ListStore(typeof(string));

			foreach (String name in x)
			{
				store.AppendValues(System.IO.Path.GetFileNameWithoutExtension(name));
			}
			combobox1.Model = store;
		}

		protected void OnButtonOkClicked(object sender, EventArgs e)
		{
			if (combobox1.ActiveText != null)
			MainWindow.key = combobox1.ActiveText;
			
		}
	}
}
