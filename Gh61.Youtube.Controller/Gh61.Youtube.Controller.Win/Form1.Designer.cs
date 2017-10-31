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
			this.btnPlayPause = new System.Windows.Forms.Button();
			this.lbl1 = new System.Windows.Forms.Label();
			this.lbl2 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnPlayPause
			// 
			this.btnPlayPause.Location = new System.Drawing.Point(83, 63);
			this.btnPlayPause.Name = "btnPlayPause";
			this.btnPlayPause.Size = new System.Drawing.Size(99, 23);
			this.btnPlayPause.TabIndex = 0;
			this.btnPlayPause.Text = "Play/Pause";
			this.btnPlayPause.UseVisualStyleBackColor = true;
			this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
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
			this.lblStatus.Location = new System.Drawing.Point(80, 13);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(16, 13);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "...";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(80, 35);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(16, 13);
			this.lblTitle.TabIndex = 4;
			this.lblTitle.Text = "...";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(188, 63);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(67, 23);
			this.btnRefresh.TabIndex = 5;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(267, 98);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lbl2);
			this.Controls.Add(this.lbl1);
			this.Controls.Add(this.btnPlayPause);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "Youtube Controller";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
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
	}
}

