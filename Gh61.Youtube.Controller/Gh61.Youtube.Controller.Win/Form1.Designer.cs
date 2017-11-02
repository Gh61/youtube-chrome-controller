namespace Gh61.Youtube.Controller.Win
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btnPlayPause = new System.Windows.Forms.Button();
			this.lbl1 = new System.Windows.Forms.Label();
			this.lbl2 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemShow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemStatus = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTitle = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemPlayPause = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemNext = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemPrevious = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.trayMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnPlayPause
			// 
			this.btnPlayPause.Location = new System.Drawing.Point(83, 63);
			this.btnPlayPause.Name = "btnPlayPause";
			this.btnPlayPause.Size = new System.Drawing.Size(109, 23);
			this.btnPlayPause.TabIndex = 0;
			this.btnPlayPause.Text = "Play/Pause";
			this.btnPlayPause.UseVisualStyleBackColor = true;
			this.btnPlayPause.Click += new System.EventHandler(this.PlayPause);
			// 
			// lbl1
			// 
			this.lbl1.AutoSize = true;
			this.lbl1.Location = new System.Drawing.Point(13, 13);
			this.lbl1.Name = "lbl1";
			this.lbl1.Size = new System.Drawing.Size(40, 13);
			this.lbl1.TabIndex = 1;
			this.lbl1.Text = "Status:";
			// 
			// lbl2
			// 
			this.lbl2.AutoSize = true;
			this.lbl2.Location = new System.Drawing.Point(12, 35);
			this.lbl2.Name = "lbl2";
			this.lbl2.Size = new System.Drawing.Size(30, 13);
			this.lbl2.TabIndex = 2;
			this.lbl2.Text = "Title:";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(56, 13);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(16, 13);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "...";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(56, 35);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(16, 13);
			this.lblTitle.TabIndex = 4;
			this.lblTitle.Text = "...";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(198, 63);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(67, 23);
			this.btnRefresh.TabIndex = 5;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.RefreshStatus);
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(12, 63);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(29, 23);
			this.btnPrev.TabIndex = 6;
			this.btnPrev.Text = "|<";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.PlayPrevious);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(47, 63);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(29, 23);
			this.btnNext.TabIndex = 7;
			this.btnNext.Text = ">|";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.PlayNext);
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.trayMenu;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "Youtube Controller";
			this.trayIcon.Visible = true;
			this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
			this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
			// 
			// trayMenu
			// 
			this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShow,
            this.menuSeparator,
            this.menuItemStatus,
            this.menuItemTitle,
            this.menuSeparator2,
            this.menuItemPlayPause,
            this.menuItemNext,
            this.menuItemPrevious,
            this.menuSeparator3,
            this.menuItemExit});
			this.trayMenu.Name = "trayMenu";
			this.trayMenu.Size = new System.Drawing.Size(170, 176);
			// 
			// menuItemShow
			// 
			this.menuItemShow.Image = global::Gh61.Youtube.Controller.Win.Properties.Resources.note_19;
			this.menuItemShow.Name = "menuItemShow";
			this.menuItemShow.Size = new System.Drawing.Size(169, 22);
			this.menuItemShow.Text = "&Show";
			this.menuItemShow.Click += new System.EventHandler(this.menuItemShow_Click);
			// 
			// menuSeparator
			// 
			this.menuSeparator.Name = "menuSeparator";
			this.menuSeparator.Size = new System.Drawing.Size(166, 6);
			// 
			// menuItemStatus
			// 
			this.menuItemStatus.Name = "menuItemStatus";
			this.menuItemStatus.Size = new System.Drawing.Size(169, 22);
			this.menuItemStatus.Text = "...";
			this.menuItemStatus.Visible = false;
			this.menuItemStatus.Click += new System.EventHandler(this.RefreshStatus);
			// 
			// menuItemTitle
			// 
			this.menuItemTitle.Name = "menuItemTitle";
			this.menuItemTitle.Size = new System.Drawing.Size(169, 22);
			this.menuItemTitle.Text = "...";
			this.menuItemTitle.Visible = false;
			this.menuItemTitle.Click += new System.EventHandler(this.RefreshStatus);
			// 
			// menuSeparator2
			// 
			this.menuSeparator2.Name = "menuSeparator2";
			this.menuSeparator2.Size = new System.Drawing.Size(166, 6);
			this.menuSeparator2.Visible = false;
			// 
			// menuItemPlayPause
			// 
			this.menuItemPlayPause.Image = global::Gh61.Youtube.Controller.Win.Properties.Resources.play_19;
			this.menuItemPlayPause.Name = "menuItemPlayPause";
			this.menuItemPlayPause.Size = new System.Drawing.Size(169, 22);
			this.menuItemPlayPause.Text = "&Play/Pause (Click)";
			this.menuItemPlayPause.Click += new System.EventHandler(this.PlayPause);
			// 
			// menuItemNext
			// 
			this.menuItemNext.Image = global::Gh61.Youtube.Controller.Win.Properties.Resources.next_19;
			this.menuItemNext.Name = "menuItemNext";
			this.menuItemNext.Size = new System.Drawing.Size(169, 22);
			this.menuItemNext.Text = "&Next";
			this.menuItemNext.Click += new System.EventHandler(this.PlayNext);
			// 
			// menuItemPrevious
			// 
			this.menuItemPrevious.Image = global::Gh61.Youtube.Controller.Win.Properties.Resources.prev_19;
			this.menuItemPrevious.Name = "menuItemPrevious";
			this.menuItemPrevious.Size = new System.Drawing.Size(169, 22);
			this.menuItemPrevious.Text = "Pr&evious";
			this.menuItemPrevious.Click += new System.EventHandler(this.PlayPrevious);
			// 
			// menuSeparator3
			// 
			this.menuSeparator3.Name = "menuSeparator3";
			this.menuSeparator3.Size = new System.Drawing.Size(166, 6);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(169, 22);
			this.menuItemExit.Text = "&Exit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(277, 98);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrev);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lbl2);
			this.Controls.Add(this.lbl1);
			this.Controls.Add(this.btnPlayPause);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Youtube Controller";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.trayMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPlayPause;
		private System.Windows.Forms.Label lbl1;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.ContextMenuStrip trayMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemStatus;
		private System.Windows.Forms.ToolStripMenuItem menuItemTitle;
		private System.Windows.Forms.ToolStripSeparator menuSeparator;
		private System.Windows.Forms.ToolStripMenuItem menuItemPlayPause;
		private System.Windows.Forms.ToolStripMenuItem menuItemNext;
		private System.Windows.Forms.ToolStripMenuItem menuItemPrevious;
		private System.Windows.Forms.ToolStripMenuItem menuItemShow;
		private System.Windows.Forms.ToolStripSeparator menuSeparator2;
		private System.Windows.Forms.ToolStripSeparator menuSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
	}
}

