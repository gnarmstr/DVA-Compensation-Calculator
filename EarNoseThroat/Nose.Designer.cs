﻿namespace DVA_Compensation_Calculator
{
	partial class Nose
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
			this.checkBoxOption2 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption3 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption1 = new System.Windows.Forms.CheckBox();
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxOption2
			// 
			this.checkBoxOption2.Location = new System.Drawing.Point(30, 167);
			this.checkBoxOption2.Name = "checkBoxOption2";
			this.checkBoxOption2.Size = new System.Drawing.Size(591, 60);
			this.checkBoxOption2.TabIndex = 11;
			this.checkBoxOption2.Text = "Recurrent upper respiratory tract infection.";
			this.checkBoxOption2.UseVisualStyleBackColor = true;
			this.checkBoxOption2.CheckedChanged += new System.EventHandler(this.checkBoxOption2_CheckedChanged);
			// 
			// checkBoxOption3
			// 
			this.checkBoxOption3.Location = new System.Drawing.Point(30, 249);
			this.checkBoxOption3.Name = "checkBoxOption3";
			this.checkBoxOption3.Size = new System.Drawing.Size(591, 75);
			this.checkBoxOption3.TabIndex = 7;
			this.checkBoxOption3.Text = "Symptoms of rhinitis and sinusitis or both which are not relieved by medication a" +
    "nd which occur for more than 4 months every year.";
			this.checkBoxOption3.UseVisualStyleBackColor = true;
			this.checkBoxOption3.CheckedChanged += new System.EventHandler(this.checkBoxOption3_CheckedChanged);
			// 
			// checkBoxOption1
			// 
			this.checkBoxOption1.Location = new System.Drawing.Point(30, 96);
			this.checkBoxOption1.Name = "checkBoxOption1";
			this.checkBoxOption1.Size = new System.Drawing.Size(591, 38);
			this.checkBoxOption1.TabIndex = 6;
			this.checkBoxOption1.Text = "Intermittent post-nasal discharge, rhinorrhoea and/or sneezing.";
			this.checkBoxOption1.UseVisualStyleBackColor = true;
			this.checkBoxOption1.CheckedChanged += new System.EventHandler(this.checkBoxOption1_CheckedChanged);
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.Location = new System.Drawing.Point(720, 370);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxCancel.TabIndex = 15;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.Tag = "8";
			this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.Location = new System.Drawing.Point(596, 370);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 14;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(114, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(466, 42);
			this.label1.TabIndex = 21;
			this.label1.Text = "Select the one that best meets your situation.";
			// 
			// Nose
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(828, 474);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBoxCancel);
			this.Controls.Add(this.pictureBoxOK);
			this.Controls.Add(this.checkBoxOption2);
			this.Controls.Add(this.checkBoxOption3);
			this.Controls.Add(this.checkBoxOption1);
			this.MaximumSize = new System.Drawing.Size(850, 530);
			this.MinimumSize = new System.Drawing.Size(850, 530);
			this.Name = "Nose";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "UPPER RESPIRATORY TRACT AND NASAL CONDITIONS";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxOption2;
		private System.Windows.Forms.CheckBox checkBoxOption3;
		private System.Windows.Forms.CheckBox checkBoxOption1;
		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Label label1;
	}
}