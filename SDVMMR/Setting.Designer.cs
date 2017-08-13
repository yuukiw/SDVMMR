namespace SDVMMR
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.ModSettings = new System.Windows.Forms.GroupBox();
            this.overwriteButton = new System.Windows.Forms.CheckBox();
            this.SteamFolder = new System.Windows.Forms.Label();
            this.GameFolder = new System.Windows.Forms.Label();
            this.IsGOG = new System.Windows.Forms.Label();
            this.SteamFolderBox = new System.Windows.Forms.TextBox();
            this.GeneralSettings = new System.Windows.Forms.GroupBox();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.isGogBtn = new System.Windows.Forms.Button();
            this.GameFolderBtn = new System.Windows.Forms.Button();
            this.SteamFolderBtn = new System.Windows.Forms.Button();
            this.IsGOGBox = new System.Windows.Forms.TextBox();
            this.GameFolderBox = new System.Windows.Forms.TextBox();
            this.SteamSettings = new System.Windows.Forms.GroupBox();
            this.SetVDF = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.ModSettings.SuspendLayout();
            this.GeneralSettings.SuspendLayout();
            this.SteamSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModSettings
            // 
            this.ModSettings.Controls.Add(this.overwriteButton);
            this.ModSettings.Location = new System.Drawing.Point(12, 162);
            this.ModSettings.Name = "ModSettings";
            this.ModSettings.Size = new System.Drawing.Size(503, 51);
            this.ModSettings.TabIndex = 2;
            this.ModSettings.TabStop = false;
            this.ModSettings.Text = "groupBox2";
            // 
            // overwriteButton
            // 
            this.overwriteButton.AutoSize = true;
            this.overwriteButton.Location = new System.Drawing.Point(196, 19);
            this.overwriteButton.Name = "overwriteButton";
            this.overwriteButton.Size = new System.Drawing.Size(80, 17);
            this.overwriteButton.TabIndex = 0;
            this.overwriteButton.Text = "checkBox1";
            this.overwriteButton.UseVisualStyleBackColor = true;
            // 
            // SteamFolder
            // 
            this.SteamFolder.Location = new System.Drawing.Point(6, 19);
            this.SteamFolder.Name = "SteamFolder";
            this.SteamFolder.Size = new System.Drawing.Size(80, 20);
            this.SteamFolder.TabIndex = 0;
            this.SteamFolder.Text = "label1";
            // 
            // GameFolder
            // 
            this.GameFolder.Location = new System.Drawing.Point(6, 49);
            this.GameFolder.Name = "GameFolder";
            this.GameFolder.Size = new System.Drawing.Size(80, 20);
            this.GameFolder.TabIndex = 1;
            this.GameFolder.Text = "label2";
            // 
            // IsGOG
            // 
            this.IsGOG.Location = new System.Drawing.Point(6, 80);
            this.IsGOG.Name = "IsGOG";
            this.IsGOG.Size = new System.Drawing.Size(80, 20);
            this.IsGOG.TabIndex = 2;
            this.IsGOG.Text = "label3";
            // 
            // SteamFolderBox
            // 
            this.SteamFolderBox.Location = new System.Drawing.Point(106, 16);
            this.SteamFolderBox.Name = "SteamFolderBox";
            this.SteamFolderBox.Size = new System.Drawing.Size(300, 20);
            this.SteamFolderBox.TabIndex = 3;
            this.SteamFolderBox.TextChanged += new System.EventHandler(this.SteamFolderBox_TextChanged);
            // 
            // GeneralSettings
            // 
            this.GeneralSettings.Controls.Add(this.LanguageBox);
            this.GeneralSettings.Controls.Add(this.LanguageLabel);
            this.GeneralSettings.Controls.Add(this.isGogBtn);
            this.GeneralSettings.Controls.Add(this.GameFolderBtn);
            this.GeneralSettings.Controls.Add(this.SteamFolderBtn);
            this.GeneralSettings.Controls.Add(this.IsGOGBox);
            this.GeneralSettings.Controls.Add(this.GameFolderBox);
            this.GeneralSettings.Controls.Add(this.SteamFolderBox);
            this.GeneralSettings.Controls.Add(this.IsGOG);
            this.GeneralSettings.Controls.Add(this.GameFolder);
            this.GeneralSettings.Controls.Add(this.SteamFolder);
            this.GeneralSettings.Location = new System.Drawing.Point(12, 12);
            this.GeneralSettings.Name = "GeneralSettings";
            this.GeneralSettings.Size = new System.Drawing.Size(503, 144);
            this.GeneralSettings.TabIndex = 1;
            this.GeneralSettings.TabStop = false;
            this.GeneralSettings.Text = "groupBox1";
            // 
            // LanguageBox
            // 
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Location = new System.Drawing.Point(106, 107);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(390, 21);
            this.LanguageBox.TabIndex = 10;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Location = new System.Drawing.Point(6, 109);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(80, 20);
            this.LanguageLabel.TabIndex = 9;
            this.LanguageLabel.Text = "label3";
            // 
            // isGogBtn
            // 
            this.isGogBtn.Location = new System.Drawing.Point(421, 77);
            this.isGogBtn.Name = "isGogBtn";
            this.isGogBtn.Size = new System.Drawing.Size(75, 23);
            this.isGogBtn.TabIndex = 8;
            this.isGogBtn.Text = "button3";
            this.isGogBtn.UseVisualStyleBackColor = true;
            this.isGogBtn.Click += new System.EventHandler(this.isGogBtn_Click);
            // 
            // GameFolderBtn
            // 
            this.GameFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("GameFolderBtn.Image")));
            this.GameFolderBtn.Location = new System.Drawing.Point(421, 44);
            this.GameFolderBtn.Name = "GameFolderBtn";
            this.GameFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.GameFolderBtn.TabIndex = 7;
            this.GameFolderBtn.UseVisualStyleBackColor = true;
            // 
            // SteamFolderBtn
            // 
            this.SteamFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("SteamFolderBtn.Image")));
            this.SteamFolderBtn.Location = new System.Drawing.Point(421, 13);
            this.SteamFolderBtn.Name = "SteamFolderBtn";
            this.SteamFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.SteamFolderBtn.TabIndex = 6;
            this.SteamFolderBtn.UseVisualStyleBackColor = true;
            // 
            // IsGOGBox
            // 
            this.IsGOGBox.Location = new System.Drawing.Point(106, 77);
            this.IsGOGBox.Name = "IsGOGBox";
            this.IsGOGBox.ReadOnly = true;
            this.IsGOGBox.Size = new System.Drawing.Size(300, 20);
            this.IsGOGBox.TabIndex = 5;
            // 
            // GameFolderBox
            // 
            this.GameFolderBox.Location = new System.Drawing.Point(106, 46);
            this.GameFolderBox.Name = "GameFolderBox";
            this.GameFolderBox.Size = new System.Drawing.Size(300, 20);
            this.GameFolderBox.TabIndex = 4;
            // 
            // SteamSettings
            // 
            this.SteamSettings.Controls.Add(this.SetVDF);
            this.SteamSettings.Location = new System.Drawing.Point(12, 219);
            this.SteamSettings.Name = "SteamSettings";
            this.SteamSettings.Size = new System.Drawing.Size(503, 56);
            this.SteamSettings.TabIndex = 3;
            this.SteamSettings.TabStop = false;
            this.SteamSettings.Text = "groupBox3";
            // 
            // SetVDF
            // 
            this.SetVDF.Location = new System.Drawing.Point(171, 20);
            this.SetVDF.Name = "SetVDF";
            this.SetVDF.Size = new System.Drawing.Size(146, 23);
            this.SetVDF.TabIndex = 0;
            this.SetVDF.Text = "button1";
            this.SetVDF.UseVisualStyleBackColor = true;
            this.SetVDF.Click += new System.EventHandler(this.SetVDF_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(439, 282);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 4;
            this.Save.Text = "button2";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 308);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SteamSettings);
            this.Controls.Add(this.ModSettings);
            this.Controls.Add(this.GeneralSettings);
            this.Name = "Setting";
            this.Text = "Settings";
            this.ModSettings.ResumeLayout(false);
            this.ModSettings.PerformLayout();
            this.GeneralSettings.ResumeLayout(false);
            this.GeneralSettings.PerformLayout();
            this.SteamSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox ModSettings;
        private System.Windows.Forms.CheckBox overwriteButton;
        private System.Windows.Forms.Label SteamFolder;
        private System.Windows.Forms.Label GameFolder;
        private System.Windows.Forms.Label IsGOG;
        private System.Windows.Forms.TextBox SteamFolderBox;
        private System.Windows.Forms.GroupBox GeneralSettings;
        private System.Windows.Forms.ComboBox LanguageBox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.Button isGogBtn;
        private System.Windows.Forms.Button GameFolderBtn;
        private System.Windows.Forms.Button SteamFolderBtn;
        private System.Windows.Forms.TextBox IsGOGBox;
        private System.Windows.Forms.TextBox GameFolderBox;
        private System.Windows.Forms.GroupBox SteamSettings;
        private System.Windows.Forms.Button SetVDF;
        private System.Windows.Forms.Button Save;
    }
}