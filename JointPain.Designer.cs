namespace DVA_Compensation_Calculator
{
	partial class JointPain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JointPain));
			this.checkBoxOption2 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption4 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption5 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption3 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption1 = new System.Windows.Forms.CheckBox();
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label37 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxOption2
			// 
			this.checkBoxOption2.Location = new System.Drawing.Point(12, 353);
			this.checkBoxOption2.Name = "checkBoxOption2";
			this.checkBoxOption2.Size = new System.Drawing.Size(1048, 77);
			this.checkBoxOption2.TabIndex = 11;
			this.checkBoxOption2.Text = " Pain in any joint, or combination of joints, that is often present at rest but " +
    "which is mild.\r\n Pain in the back that limits comfortable sitting to less than " +
    "30 minutes at a time.";
			this.checkBoxOption2.UseVisualStyleBackColor = true;
			this.checkBoxOption2.CheckedChanged += new System.EventHandler(this.checkBoxOption2_CheckedChanged);
			// 
			// checkBoxOption4
			// 
			this.checkBoxOption4.Location = new System.Drawing.Point(12, 537);
			this.checkBoxOption4.Name = "checkBoxOption4";
			this.checkBoxOption4.Size = new System.Drawing.Size(1048, 74);
			this.checkBoxOption4.TabIndex = 9;
			this.checkBoxOption4.Text = "Severe pain in any joint, or combination of joints, that is often present at rest" +
    " but which does not respond adequately to medication or to therapeutic measures." +
    "";
			this.checkBoxOption4.UseVisualStyleBackColor = true;
			this.checkBoxOption4.CheckedChanged += new System.EventHandler(this.checkBoxOption4_CheckedChanged);
			// 
			// checkBoxOption5
			// 
			this.checkBoxOption5.Location = new System.Drawing.Point(12, 609);
			this.checkBoxOption5.Name = "checkBoxOption5";
			this.checkBoxOption5.Size = new System.Drawing.Size(1048, 93);
			this.checkBoxOption5.TabIndex = 8;
			this.checkBoxOption5.Text = resources.GetString("checkBoxOption5.Text");
			this.checkBoxOption5.UseVisualStyleBackColor = true;
			this.checkBoxOption5.CheckedChanged += new System.EventHandler(this.checkBoxOption5_CheckedChanged);
			// 
			// checkBoxOption3
			// 
			this.checkBoxOption3.Location = new System.Drawing.Point(12, 448);
			this.checkBoxOption3.Name = "checkBoxOption3";
			this.checkBoxOption3.Size = new System.Drawing.Size(1048, 69);
			this.checkBoxOption3.TabIndex = 7;
			this.checkBoxOption3.Text = resources.GetString("checkBoxOption3.Text");
			this.checkBoxOption3.UseVisualStyleBackColor = true;
			this.checkBoxOption3.CheckedChanged += new System.EventHandler(this.checkBoxOption3_CheckedChanged);
			// 
			// checkBoxOption1
			// 
			this.checkBoxOption1.Location = new System.Drawing.Point(12, 283);
			this.checkBoxOption1.Name = "checkBoxOption1";
			this.checkBoxOption1.Size = new System.Drawing.Size(1048, 46);
			this.checkBoxOption1.TabIndex = 6;
			this.checkBoxOption1.Text = "Pain in any joint, or combination of joints, that is not usually present at rest." +
    "";
			this.checkBoxOption1.UseVisualStyleBackColor = true;
			this.checkBoxOption1.CheckedChanged += new System.EventHandler(this.checkBoxOption1_CheckedChanged);
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.Location = new System.Drawing.Point(965, 852);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxCancel.TabIndex = 15;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.Tag = "8";
			this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.Location = new System.Drawing.Point(841, 852);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 14;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// label37
			// 
			this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label37.Location = new System.Drawing.Point(26, 24);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(1034, 220);
			this.label37.TabIndex = 22;
			this.label37.Text = resources.GetString("label37.Text");
			// 
			// JointPain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(1094, 944);
			this.Controls.Add(this.label37);
			this.Controls.Add(this.pictureBoxCancel);
			this.Controls.Add(this.pictureBoxOK);
			this.Controls.Add(this.checkBoxOption2);
			this.Controls.Add(this.checkBoxOption4);
			this.Controls.Add(this.checkBoxOption5);
			this.Controls.Add(this.checkBoxOption3);
			this.Controls.Add(this.checkBoxOption1);
			this.Name = "JointPain";
			this.Text = "Resting Joint Pain";
			this.Load += new System.EventHandler(this.JointPain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxOption2;
		private System.Windows.Forms.CheckBox checkBoxOption4;
		private System.Windows.Forms.CheckBox checkBoxOption5;
		private System.Windows.Forms.CheckBox checkBoxOption3;
		private System.Windows.Forms.CheckBox checkBoxOption1;
		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Label label37;
	}
}