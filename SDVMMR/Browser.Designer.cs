using Gecko;
using System.IO;

namespace SDVMMR
{
    partial class Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webBrowser1 = new Gecko.GeckoWebBrowser();
            this.back = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.FrameEventsPropagateToMainWindow = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 33);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1539, 476);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.UseHttpActivityObserver = false;
            this.webBrowser1.Navigating += new System.EventHandler<Gecko.Events.GeckoNavigatingEventArgs>(this.webBrowser1_Navigating);
            // 
            // back
            // 
            this.back.Image = global::SDVMMR.Properties.Resources.Backward_16x;
            this.back.Location = new System.Drawing.Point(13, 4);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 1;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // forward
            // 
            this.forward.Image = global::SDVMMR.Properties.Resources.Forward_16x;
            this.forward.Location = new System.Drawing.Point(177, 4);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(75, 23);
            this.forward.TabIndex = 3;
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // home
            // 
            this.home.Image = global::SDVMMR.Properties.Resources.Home_16x;
            this.home.Location = new System.Drawing.Point(96, 4);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(75, 23);
            this.home.TabIndex = 2;
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 511);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.home);
            this.Controls.Add(this.back);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Browser";
            this.Text = "Browser";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        //private System.Windows.Forms.WebBrowser webBrowser1;
        private GeckoWebBrowser webBrowser1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Button forward;
    }
}