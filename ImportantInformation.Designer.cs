﻿namespace DVA_Compensation_Calculator
{
	partial class ImportantInformation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportantInformation));
			this.label85 = new System.Windows.Forms.Label();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label85
			// 
			this.label85.BackColor = System.Drawing.Color.Transparent;
			this.label85.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label85.Location = new System.Drawing.Point(22, 84);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(707, 519);
			this.label85.TabIndex = 20;
			this.label85.Text = resources.GetString("label85.Text");
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxOK.Location = new System.Drawing.Point(735, 493);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 21;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBoxOK);
			this.panel1.Controls.Add(this.label85);
			this.panel1.Location = new System.Drawing.Point(26, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(855, 614);
			this.panel1.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(240, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 29);
			this.label1.TabIndex = 22;
			this.label1.Text = "IMPORTANT INFORMATION";
			// 
			// ImportantInformation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Azure;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(920, 680);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(920, 680);
			this.MinimumSize = new System.Drawing.Size(920, 680);
			this.Name = "ImportantInformation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Important Information";
			this.Load += new System.EventHandler(this.ImportantInformation_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;

	}
}