using System;
namespace SDVMMR {
	public partial class ErrorAlert : Gtk.Window {
		public event EventHandler WindowShouldClosed;

		public ErrorAlert(string Message, string title) : base(Gtk.WindowType.Toplevel) {
			this.Build();
			this.Title = title;
			this.ErrorOutput.Buffer.Text = Message;
			this.ErrorOutput.WrapMode = Gtk.WrapMode.Word;

			OKButton.Pressed += OKButton_Pressed;
		}

		protected override bool OnDeleteEvent(Gdk.Event evnt) {
			WindowShouldClosed.Invoke(this, null);
			return base.OnDeleteEvent(evnt);
		}

		void OKButton_Pressed(object sender, EventArgs e) {
			this.Destroy();
		}

	}
}
