namespace DVA_Compensation_Calculator
{
	partial class OcularImpairment
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OcularImpairment));
			this.checkBoxOption2 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption4 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption3 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption1 = new System.Windows.Forms.CheckBox();
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBoxOption2
			// 
			this.checkBoxOption2.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption2.Location = new System.Drawing.Point(18, 200);
			this.checkBoxOption2.Name = "checkBoxOption2";
			this.checkBoxOption2.Size = new System.Drawing.Size(591, 36);
			this.checkBoxOption2.TabIndex = 11;
			this.checkBoxOption2.Text = "Intermittent conjunctivitis - at least 6 separate episodes per year.";
			this.checkBoxOption2.UseVisualStyleBackColor = false;
			this.checkBoxOption2.CheckedChanged += new System.EventHandler(this.checkBoxOption2_CheckedChanged);
			// 
			// checkBoxOption4
			// 
			this.checkBoxOption4.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption4.Location = new System.Drawing.Point(18, 430);
			this.checkBoxOption4.Name = "checkBoxOption4";
			this.checkBoxOption4.Size = new System.Drawing.Size(591, 47);
			this.checkBoxOption4.TabIndex = 9;
			this.checkBoxOption4.Text = "Symptoms and signs of severe eye irritation, present all of the time.";
			this.checkBoxOption4.UseVisualStyleBackColor = false;
			this.checkBoxOption4.CheckedChanged += new System.EventHandler(this.checkBoxOption4_CheckedChanged);
			// 
			// checkBoxOption3
			// 
			this.checkBoxOption3.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption3.Location = new System.Drawing.Point(18, 283);
			this.checkBoxOption3.Name = "checkBoxOption3";
			this.checkBoxOption3.Size = new System.Drawing.Size(611, 109);
			this.checkBoxOption3.TabIndex = 7;
			this.checkBoxOption3.Text = resources.GetString("checkBoxOption3.Text");
			this.checkBoxOption3.UseVisualStyleBackColor = false;
			this.checkBoxOption3.CheckedChanged += new System.EventHandler(this.checkBoxOption3_CheckedChanged);
			// 
			// checkBoxOption1
			// 
			this.checkBoxOption1.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption1.Location = new System.Drawing.Point(18, 127);
			this.checkBoxOption1.Name = "checkBoxOption1";
			this.checkBoxOption1.Size = new System.Drawing.Size(591, 38);
			this.checkBoxOption1.TabIndex = 6;
			this.checkBoxOption1.Text = "Occasional conjunctivitis.";
			this.checkBoxOption1.UseVisualStyleBackColor = false;
			this.checkBoxOption1.CheckedChanged += new System.EventHandler(this.checkBoxOption1_CheckedChanged);
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCancel.Location = new System.Drawing.Point(520, 513);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxCancel.TabIndex = 15;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.Tag = "8";
			this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxOK.Location = new System.Drawing.Point(396, 513);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 14;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(100, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(445, 25);
			this.label1.TabIndex = 21;
			this.label1.Text = "Select the one that best meets your situation.";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(174, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(284, 29);
			this.label2.TabIndex = 22;
			this.label2.Text = "OCULAR IMPAIRMENT";
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBoxCancel);
			this.panel1.Controls.Add(this.pictureBoxOK);
			this.panel1.Controls.Add(this.checkBoxOption2);
			this.panel1.Controls.Add(this.checkBoxOption4);
			this.panel1.Controls.Add(this.checkBoxOption3);
			this.panel1.Controls.Add(this.checkBoxOption1);
			this.panel1.Location = new System.Drawing.Point(33, 37);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(652, 606);
			this.panel1.TabIndex = 23;
			// 
			// OcularImpairment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(727, 683);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(727, 683);
			this.MinimumSize = new System.Drawing.Size(727, 683);
			this.Name = "OcularImpairment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ocular Impairment";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxOption2;
		private System.Windows.Forms.CheckBox checkBoxOption4;
		private System.Windows.Forms.CheckBox checkBoxOption3;
		private System.Windows.Forms.CheckBox checkBoxOption1;
		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
	}
}