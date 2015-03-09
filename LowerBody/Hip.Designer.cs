namespace DVA_Compensation_Calculator
{
	partial class Hip
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hip));
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxOption6 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption2 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption4 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption5 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption3 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption1 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.Location = new System.Drawing.Point(601, 523);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxCancel.TabIndex = 15;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.Tag = "8";
			this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.Location = new System.Drawing.Point(477, 523);
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
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(681, 170);
			this.label1.TabIndex = 21;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// checkBoxOption6
			// 
			this.checkBoxOption6.Location = new System.Drawing.Point(35, 531);
			this.checkBoxOption6.Name = "checkBoxOption6";
			this.checkBoxOption6.Size = new System.Drawing.Size(415, 42);
			this.checkBoxOption6.TabIndex = 27;
			this.checkBoxOption6.Text = "Ankylosis in an unfavourable position, or a fail joint.";
			this.checkBoxOption6.UseVisualStyleBackColor = true;
			this.checkBoxOption6.CheckedChanged += new System.EventHandler(this.checkBoxOption6_CheckedChanged);
			// 
			// checkBoxOption2
			// 
			this.checkBoxOption2.Location = new System.Drawing.Point(35, 242);
			this.checkBoxOption2.Name = "checkBoxOption2";
			this.checkBoxOption2.Size = new System.Drawing.Size(591, 36);
			this.checkBoxOption2.TabIndex = 26;
			this.checkBoxOption2.Text = "Loss of about one-quarter normal range of movement.";
			this.checkBoxOption2.UseVisualStyleBackColor = true;
			this.checkBoxOption2.CheckedChanged += new System.EventHandler(this.checkBoxOption2_CheckedChanged);
			// 
			// checkBoxOption4
			// 
			this.checkBoxOption4.Location = new System.Drawing.Point(35, 378);
			this.checkBoxOption4.Name = "checkBoxOption4";
			this.checkBoxOption4.Size = new System.Drawing.Size(591, 47);
			this.checkBoxOption4.TabIndex = 25;
			this.checkBoxOption4.Text = "Loss of about three-quarters normal range of movement.";
			this.checkBoxOption4.UseVisualStyleBackColor = true;
			this.checkBoxOption4.CheckedChanged += new System.EventHandler(this.checkBoxOption4_CheckedChanged);
			// 
			// checkBoxOption5
			// 
			this.checkBoxOption5.Location = new System.Drawing.Point(35, 453);
			this.checkBoxOption5.Name = "checkBoxOption5";
			this.checkBoxOption5.Size = new System.Drawing.Size(591, 50);
			this.checkBoxOption5.TabIndex = 24;
			this.checkBoxOption5.Text = "Loss of almost all movement, or complete ankylosis in position of function.";
			this.checkBoxOption5.UseVisualStyleBackColor = true;
			this.checkBoxOption5.CheckedChanged += new System.EventHandler(this.checkBoxOption5_CheckedChanged);
			// 
			// checkBoxOption3
			// 
			this.checkBoxOption3.Location = new System.Drawing.Point(35, 308);
			this.checkBoxOption3.Name = "checkBoxOption3";
			this.checkBoxOption3.Size = new System.Drawing.Size(591, 37);
			this.checkBoxOption3.TabIndex = 23;
			this.checkBoxOption3.Text = "Loss of about one-half normal range of movement.";
			this.checkBoxOption3.UseVisualStyleBackColor = true;
			this.checkBoxOption3.CheckedChanged += new System.EventHandler(this.checkBoxOption3_CheckedChanged);
			// 
			// checkBoxOption1
			// 
			this.checkBoxOption1.Location = new System.Drawing.Point(35, 182);
			this.checkBoxOption1.Name = "checkBoxOption1";
			this.checkBoxOption1.Size = new System.Drawing.Size(591, 38);
			this.checkBoxOption1.TabIndex = 22;
			this.checkBoxOption1.Text = "X-ray changes only with normal range of movement.";
			this.checkBoxOption1.UseVisualStyleBackColor = true;
			this.checkBoxOption1.CheckedChanged += new System.EventHandler(this.checkBoxOption1_CheckedChanged);
			// 
			// Hip
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(705, 627);
			this.Controls.Add(this.checkBoxOption6);
			this.Controls.Add(this.checkBoxOption2);
			this.Controls.Add(this.checkBoxOption4);
			this.Controls.Add(this.checkBoxOption5);
			this.Controls.Add(this.checkBoxOption3);
			this.Controls.Add(this.checkBoxOption1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBoxCancel);
			this.Controls.Add(this.pictureBoxOK);
			this.MaximumSize = new System.Drawing.Size(727, 683);
			this.MinimumSize = new System.Drawing.Size(727, 683);
			this.Name = "Hip";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Hip";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxOption6;
		private System.Windows.Forms.CheckBox checkBoxOption2;
		private System.Windows.Forms.CheckBox checkBoxOption4;
		private System.Windows.Forms.CheckBox checkBoxOption5;
		private System.Windows.Forms.CheckBox checkBoxOption3;
		private System.Windows.Forms.CheckBox checkBoxOption1;
	}
}