﻿namespace StopWatch.UI.Views
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lblUpdate = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopWatchInstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commitAdminTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMainDisplay = new System.Windows.Forms.Label();
            this.lblAdminTimer = new System.Windows.Forms.Label();
            this.lblAdminTimeText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(407, 9);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(35, 13);
            this.lblUpdate.TabIndex = 0;
            this.lblUpdate.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.adminTimerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadUpdateToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // downloadUpdateToolStripMenuItem
            // 
            this.downloadUpdateToolStripMenuItem.Name = "downloadUpdateToolStripMenuItem";
            this.downloadUpdateToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.downloadUpdateToolStripMenuItem.Text = "Download Update";
            this.downloadUpdateToolStripMenuItem.Click += new System.EventHandler(this.DownloadUpdateToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopWatchInstancesToolStripMenuItem,
            this.timeDisplayToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // stopWatchInstancesToolStripMenuItem
            // 
            this.stopWatchInstancesToolStripMenuItem.Name = "stopWatchInstancesToolStripMenuItem";
            this.stopWatchInstancesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.stopWatchInstancesToolStripMenuItem.Text = "StopWatch Instances";
            this.stopWatchInstancesToolStripMenuItem.Click += new System.EventHandler(this.StopWatchInstancesToolStripMenuItem_Click);
            // 
            // timeDisplayToolStripMenuItem
            // 
            this.timeDisplayToolStripMenuItem.Name = "timeDisplayToolStripMenuItem";
            this.timeDisplayToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.timeDisplayToolStripMenuItem.Text = "Time Display";
            this.timeDisplayToolStripMenuItem.Click += new System.EventHandler(this.TimeDisplayToolStripMenuItem_Click);
            // 
            // adminTimerToolStripMenuItem
            // 
            this.adminTimerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableTimerToolStripMenuItem,
            this.resetTimerToolStripMenuItem,
            this.commitAdminTimeToolStripMenuItem});
            this.adminTimerToolStripMenuItem.Name = "adminTimerToolStripMenuItem";
            this.adminTimerToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.adminTimerToolStripMenuItem.Text = "Admin Timer";
            // 
            // enableTimerToolStripMenuItem
            // 
            this.enableTimerToolStripMenuItem.Name = "enableTimerToolStripMenuItem";
            this.enableTimerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.enableTimerToolStripMenuItem.Text = "Disable Timer";
            this.enableTimerToolStripMenuItem.Click += new System.EventHandler(this.EnableTimerToolStripMenuItem_Click);
            // 
            // resetTimerToolStripMenuItem
            // 
            this.resetTimerToolStripMenuItem.Name = "resetTimerToolStripMenuItem";
            this.resetTimerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.resetTimerToolStripMenuItem.Text = "Reset Timer";
            this.resetTimerToolStripMenuItem.Click += new System.EventHandler(this.ResetTimerToolStripMenuItem_Click);
            // 
            // commitAdminTimeToolStripMenuItem
            // 
            this.commitAdminTimeToolStripMenuItem.Name = "commitAdminTimeToolStripMenuItem";
            this.commitAdminTimeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.commitAdminTimeToolStripMenuItem.Text = "Commit Admin Time";
            this.commitAdminTimeToolStripMenuItem.Click += new System.EventHandler(this.CommitAdminTimeToolStripMenuItem_Click);
            // 
            // lblMainDisplay
            // 
            this.lblMainDisplay.AutoSize = true;
            this.lblMainDisplay.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblMainDisplay.Location = new System.Drawing.Point(12, 24);
            this.lblMainDisplay.Name = "lblMainDisplay";
            this.lblMainDisplay.Size = new System.Drawing.Size(431, 65);
            this.lblMainDisplay.TabIndex = 2;
            this.lblMainDisplay.Text = "00:00:00.0000000";
            // 
            // lblAdminTimer
            // 
            this.lblAdminTimer.AutoSize = true;
            this.lblAdminTimer.Location = new System.Drawing.Point(407, 24);
            this.lblAdminTimer.Name = "lblAdminTimer";
            this.lblAdminTimer.Size = new System.Drawing.Size(94, 13);
            this.lblAdminTimer.TabIndex = 3;
            this.lblAdminTimer.Text = "00:00:00.0000000";
            // 
            // lblAdminTimeText
            // 
            this.lblAdminTimeText.AutoSize = true;
            this.lblAdminTimeText.Location = new System.Drawing.Point(339, 24);
            this.lblAdminTimeText.Name = "lblAdminTimeText";
            this.lblAdminTimeText.Size = new System.Drawing.Size(65, 13);
            this.lblAdminTimeText.TabIndex = 4;
            this.lblAdminTimeText.Text = "Admin Time:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 306);
            this.Controls.Add(this.lblAdminTimeText);
            this.Controls.Add(this.lblAdminTimer);
            this.Controls.Add(this.lblMainDisplay);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "StopWatch";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetTimerToolStripMenuItem;
        private System.Windows.Forms.Label lblMainDisplay;
        private System.Windows.Forms.Label lblAdminTimer;
        private System.Windows.Forms.Label lblAdminTimeText;
        private System.Windows.Forms.ToolStripMenuItem commitAdminTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopWatchInstancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeDisplayToolStripMenuItem;
    }
}
