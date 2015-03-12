namespace DVA_Compensation_Calculator
{
	partial class Toes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toes));
			this.checkBoxOption2 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption4 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption3 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption1 = new System.Windows.Forms.CheckBox();
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBoxOption2
			// 
			this.checkBoxOption2.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption2.Location = new System.Drawing.Point(35, 308);
			this.checkBoxOption2.Name = "checkBoxOption2";
			this.checkBoxOption2.Size = new System.Drawing.Size(591, 36);
			this.checkBoxOption2.TabIndex = 11;
			this.checkBoxOption2.Text = "Ankylosis of any toe other than hallux.";
			this.checkBoxOption2.UseVisualStyleBackColor = false;
			this.checkBoxOption2.CheckedChanged += new System.EventHandler(this.checkBoxOption2_CheckedChanged);
			// 
			// checkBoxOption4
			// 
			this.checkBoxOption4.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption4.Location = new System.Drawing.Point(35, 448);
			this.checkBoxOption4.Name = "checkBoxOption4";
			this.checkBoxOption4.Size = new System.Drawing.Size(411, 79);
			this.checkBoxOption4.TabIndex = 9;
			this.checkBoxOption4.Text = "Hallux: ankylosis in an unfavourable position of either interphalangeal joint and" +
    "/or metatarso-phalangeal joint.";
			this.checkBoxOption4.UseVisualStyleBackColor = false;
			this.checkBoxOption4.CheckedChanged += new System.EventHandler(this.checkBoxOption4_CheckedChanged);
			// 
			// checkBoxOption3
			// 
			this.checkBoxOption3.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption3.Location = new System.Drawing.Point(35, 374);
			this.checkBoxOption3.Name = "checkBoxOption3";
			this.checkBoxOption3.Size = new System.Drawing.Size(591, 52);
			this.checkBoxOption3.TabIndex = 7;
			this.checkBoxOption3.Text = "Hallux: ankylosis in favourable position of either interphalangeal joint; or meta" +
    "tarsophalangeal joint.";
			this.checkBoxOption3.UseVisualStyleBackColor = false;
			this.checkBoxOption3.CheckedChanged += new System.EventHandler(this.checkBoxOption3_CheckedChanged);
			// 
			// checkBoxOption1
			// 
			this.checkBoxOption1.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption1.Location = new System.Drawing.Point(35, 248);
			this.checkBoxOption1.Name = "checkBoxOption1";
			this.checkBoxOption1.Size = new System.Drawing.Size(591, 38);
			this.checkBoxOption1.TabIndex = 6;
			this.checkBoxOption1.Text = "Incomplete loss of range of movement of any toe.";
			this.checkBoxOption1.UseVisualStyleBackColor = false;
			this.checkBoxOption1.CheckedChanged += new System.EventHandler(this.checkBoxOption1_CheckedChanged);
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCancel.Location = new System.Drawing.Point(596, 439);
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
			this.pictureBoxOK.Location = new System.Drawing.Point(472, 439);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 14;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(681, 173);
			this.label1.TabIndex = 21;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBoxCancel);
			this.panel1.Controls.Add(this.pictureBoxOK);
			this.panel1.Controls.Add(this.checkBoxOption2);
			this.panel1.Controls.Add(this.checkBoxOption4);
			this.panel1.Controls.Add(this.checkBoxOption3);
			this.panel1.Controls.Add(this.checkBoxOption1);
			this.panel1.Location = new System.Drawing.Point(22, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(717, 563);
			this.panel1.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(298, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 29);
			this.label2.TabIndex = 22;
			this.label2.Text = "TOES";
			// 
			// Toes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(770, 630);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(770, 630);
			this.MinimumSize = new System.Drawing.Size(770, 630);
			this.Name = "Toes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Toes";
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
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
	}
}