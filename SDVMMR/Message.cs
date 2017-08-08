using System;
namespace SDVMMR {
	public partial class Message : Gtk.Dialog {
		public event EventHandler WindowShouldClosed;

		public Message(string Message, string title) {
			this.Build();
			this.Title = title;
			this.msgBox2.Buffer.Text = Message;
			this.msgBox2.WrapMode = Gtk.WrapMode.Word;

			buttonOk.Pressed += ButtonOk_Pressed;
		}

		protected override bool OnDeleteEvent(Gdk.Event evnt) {
			WindowShouldClosed.Invoke(this, null);
			return base.OnDeleteEvent(evnt);
		}

		void ButtonOk_Pressed(object sender, EventArgs e) {
			this.Destroy();
		}


	}
}
