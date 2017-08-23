
using System;
using System.Windows.Forms;

namespace SDVMMR
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.activeMods = new System.Windows.Forms.ListView();
            this.activeModsLabel = new System.Windows.Forms.Label();
            this.SDVV = new System.Windows.Forms.Label();
            this.SdvvmrV = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.Launch = new System.Windows.Forms.ToolStripSplitButton();
            this.launchSDVItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchSMAPIItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMod = new System.Windows.Forms.ToolStripSplitButton();
            this.downloadModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSDV = new System.Windows.Forms.ToolStripSplitButton();
            this.OpenSDVMM = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenAPPData = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripButton();
            this.donate = new System.Windows.Forms.ToolStripButton();
            this.About = new System.Windows.Forms.ToolStripButton();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.search = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SMAPIUpdate = new System.Windows.Forms.LinkLabel();
            this.Toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // activeMods
            // 
            this.activeMods.Location = new System.Drawing.Point(12, 218);
            this.activeMods.Name = "activeMods";
            this.activeMods.Size = new System.Drawing.Size(931, 320);
            this.activeMods.TabIndex = 3;
            this.activeMods.UseCompatibleStateImageBehavior = false;
            this.activeMods.View = System.Windows.Forms.View.List;
            this.activeMods.SelectedIndexChanged += new System.EventHandler(this.activeMods_SelectedIndexChanged);
            this.activeMods.MouseDown += new System.Windows.Forms.MouseEventHandler(this.activeMods_MouseDown);
            // 
            // activeModsLabel
            // 
            this.activeModsLabel.AutoSize = true;
            this.activeModsLabel.Location = new System.Drawing.Point(437, 192);
            this.activeModsLabel.Name = "activeModsLabel";
            this.activeModsLabel.Size = new System.Drawing.Size(33, 13);
            this.activeModsLabel.TabIndex = 4;
            this.activeModsLabel.Text = "Mods";
            // 
            // SDVV
            // 
            this.SDVV.AutoSize = true;
            this.SDVV.Location = new System.Drawing.Point(13, 545);
            this.SDVV.Name = "SDVV";
            this.SDVV.Size = new System.Drawing.Size(35, 13);
            this.SDVV.TabIndex = 5;
            this.SDVV.Text = "label1";
            // 
            // SdvvmrV
            // 
            this.SdvvmrV.AutoSize = true;
            this.SdvvmrV.Location = new System.Drawing.Point(823, 545);
            this.SdvvmrV.Name = "SdvvmrV";
            this.SdvvmrV.Size = new System.Drawing.Size(35, 13);
            this.SdvvmrV.TabIndex = 6;
            this.SdvvmrV.Text = "label2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 61);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 61);
            // 
            // Toolbar
            // 
            this.Toolbar.AutoSize = false;
            this.Toolbar.CanOverflow = false;
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Launch,
            this.toolStripSeparator1,
            this.addMod,
            this.OpenSDV,
            this.Settings,
            this.donate,
            this.About,
            this.toolStripSeparator2});
            this.Toolbar.Location = new System.Drawing.Point(0, 109);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(952, 61);
            this.Toolbar.Stretch = true;
            this.Toolbar.TabIndex = 2;
            this.Toolbar.Text = "Toolbar";
            // 
            // Launch
            // 
            this.Launch.AutoSize = false;
            this.Launch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchSDVItem,
            this.launchSMAPIItem});
            this.Launch.Image = global::SDVMMR.Properties.Resources.SMAPI;
            this.Launch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Launch.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.Launch.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Launch.Name = "Launch";
            this.Launch.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Launch.Size = new System.Drawing.Size(120, 50);
            this.Launch.Text = "Launch SDV";
            this.Launch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Launch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Launch.ButtonClick += new System.EventHandler(this.Launch_ButtonClick);
            // 
            // launchSDVItem
            // 
            this.launchSDVItem.CheckOnClick = true;
            this.launchSDVItem.Name = "launchSDVItem";
            this.launchSDVItem.Size = new System.Drawing.Size(151, 22);
            this.launchSDVItem.Text = "Launch SDV";
            this.launchSDVItem.Click += new System.EventHandler(this.launchSDVMMItem_Click);
            // 
            // launchSMAPIItem
            // 
            this.launchSMAPIItem.CheckOnClick = true;
            this.launchSMAPIItem.Name = "launchSMAPIItem";
            this.launchSMAPIItem.Size = new System.Drawing.Size(151, 22);
            this.launchSMAPIItem.Text = "Launch SMAPI";
            this.launchSMAPIItem.Click += new System.EventHandler(this.launchSMAPIItem_Click);
            // 
            // addMod
            // 
            this.addMod.AutoSize = false;
            this.addMod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadModsToolStripMenuItem});
            this.addMod.Image = global::SDVMMR.Properties.Resources.Add_16x;
            this.addMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addMod.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.addMod.Name = "addMod";
            this.addMod.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.addMod.Size = new System.Drawing.Size(120, 50);
            this.addMod.Text = "Add";
            this.addMod.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addMod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addMod.ButtonClick += new System.EventHandler(this.addMod_ButtonClick);
            this.addMod.Click += new System.EventHandler(this.addMod_Click);
            // 
            // downloadModsToolStripMenuItem
            // 
            this.downloadModsToolStripMenuItem.Name = "downloadModsToolStripMenuItem";
            this.downloadModsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.downloadModsToolStripMenuItem.Text = "Download Mods";
            this.downloadModsToolStripMenuItem.Click += new System.EventHandler(this.downloadModsToolStripMenuItem_Click);
            // 
            // OpenSDV
            // 
            this.OpenSDV.AutoSize = false;
            this.OpenSDV.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenSDVMM,
            this.OpenAPPData});
            this.OpenSDV.Image = global::SDVMMR.Properties.Resources.Folder_256x;
            this.OpenSDV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenSDV.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.OpenSDV.Name = "OpenSDV";
            this.OpenSDV.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.OpenSDV.Size = new System.Drawing.Size(120, 50);
            this.OpenSDV.Text = "open";
            this.OpenSDV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpenSDV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OpenSDV.ButtonClick += new System.EventHandler(this.OpenSDV_ButtonClick);
            // 
            // OpenSDVMM
            // 
            this.OpenSDVMM.Name = "OpenSDVMM";
            this.OpenSDVMM.Size = new System.Drawing.Size(149, 22);
            this.OpenSDVMM.Text = "OpenSDV";
            this.OpenSDVMM.Click += new System.EventHandler(this.OpenSDVMM_Click);
            // 
            // OpenAPPData
            // 
            this.OpenAPPData.Name = "OpenAPPData";
            this.OpenAPPData.Size = new System.Drawing.Size(149, 22);
            this.OpenAPPData.Text = "OpenAPPData";
            this.OpenAPPData.Click += new System.EventHandler(this.OpenAPPData_Click);
            // 
            // Settings
            // 
            this.Settings.AutoSize = false;
            this.Settings.Image = global::SDVMMR.Properties.Resources.Settings_256x;
            this.Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Settings.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Settings.Size = new System.Drawing.Size(120, 50);
            this.Settings.Text = "Settings";
            this.Settings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // donate
            // 
            this.donate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.donate.AutoSize = false;
            this.donate.Image = global::SDVMMR.Properties.Resources.VSO_Favorite_blue_16x;
            this.donate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.donate.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.donate.Name = "donate";
            this.donate.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.donate.Size = new System.Drawing.Size(120, 50);
            this.donate.Text = "spenden";
            this.donate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.donate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.donate.Click += new System.EventHandler(this.donate_Click);
            // 
            // About
            // 
            this.About.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.About.AutoSize = false;
            this.About.Image = global::SDVMMR.Properties.Resources.InformationSymbol_32xLG;
            this.About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.About.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.About.Name = "About";
            this.About.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.About.Size = new System.Drawing.Size(120, 50);
            this.About.Text = "About";
            this.About.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.About.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Mode
            // 
            this.Mode.FormattingEnabled = true;
            this.Mode.Location = new System.Drawing.Point(856, 192);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(87, 21);
            this.Mode.TabIndex = 7;
            this.Mode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(657, 193);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(182, 20);
            this.search.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SDVMMR.Properties.Resources.SDVM;
            this.pictureBox1.InitialImage = global::SDVMMR.Properties.Resources.SDVM;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(952, 113);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // SMAPIUpdate
            // 
            this.SMAPIUpdate.AutoSize = true;
            this.SMAPIUpdate.Location = new System.Drawing.Point(144, 545);
            this.SMAPIUpdate.Name = "SMAPIUpdate";
            this.SMAPIUpdate.Size = new System.Drawing.Size(49, 13);
            this.SMAPIUpdate.TabIndex = 9;
            this.SMAPIUpdate.TabStop = true;
            this.SMAPIUpdate.Text = "SUpdate";
            this.SMAPIUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SMAPIUpdate_LinkClicked);
            this.SMAPIUpdate.Click += new System.EventHandler(this.SMAPIUpdate_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 565);
            this.Controls.Add(this.SMAPIUpdate);
            this.Controls.Add(this.search);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SdvvmrV);
            this.Controls.Add(this.SDVV);
            this.Controls.Add(this.activeModsLabel);
            this.Controls.Add(this.activeMods);
            this.Controls.Add(this.Toolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "StarDew Valley Mod Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Mods;
        private System.Windows.Forms.ListView activeMods;
        private System.Windows.Forms.Label activeModsLabel;
        private System.Windows.Forms.Label SDVV;
        private System.Windows.Forms.Label SdvvmrV;
        private System.Windows.Forms.ToolStripSplitButton Launch;
        private System.Windows.Forms.ToolStripMenuItem launchSDVItem;
        private System.Windows.Forms.ToolStripMenuItem launchSMAPIItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton OpenSDV;
        private System.Windows.Forms.ToolStripMenuItem OpenSDVMM;
        private System.Windows.Forms.ToolStripMenuItem OpenAPPData;
        private System.Windows.Forms.ToolStripButton Settings;
        private System.Windows.Forms.ToolStripButton donate;
        private System.Windows.Forms.ToolStripButton About;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip Toolbar;
        private ComboBox Mode;
        private TextBox search;
        private LinkLabel SMAPIUpdate;
        private ToolStripSplitButton addMod;
        private ToolStripMenuItem downloadModsToolStripMenuItem;
    }
}

