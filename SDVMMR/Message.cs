using System;
namespace SDVMMR
{

	public partial class Message : Gtk.Dialog
	{


		public Message(string Message, string title)
		{
			this.Build();
			this.Title = title;
			this.msgBox.Buffer.Text = Message;
		}

		protected void OnButtonOkActivated(object sender, EventArgs e)
		{

		}

		protected void OnButtonOkClicked(object sender, EventArgs e)
		{
            this.Destroy();
		}
	}
}
