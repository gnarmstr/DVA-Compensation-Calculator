namespace DVA_Compensation_Calculator
{
	partial class VisualFOL
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualFOL));
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.valueFOL = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.valueFOL)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.Location = new System.Drawing.Point(594, 526);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxCancel.TabIndex = 15;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.Tag = "8";
			this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.Location = new System.Drawing.Point(470, 526);
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
			this.label1.Location = new System.Drawing.Point(135, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(415, 33);
			this.label1.TabIndex = 21;
			this.label1.Text = "Methods of measuring visual field loss";
			// 
			// valueFOL
			// 
			this.valueFOL.Location = new System.Drawing.Point(341, 548);
			this.valueFOL.Name = "valueFOL";
			this.valueFOL.Size = new System.Drawing.Size(95, 26);
			this.valueFOL.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(681, 460);
			this.label2.TabIndex = 23;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 550);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(302, 20);
			this.label3.TabIndex = 24;
			this.label3.Text = "Number of dots as per above instructions:";
			// 
			// VisualFOL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(705, 627);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.valueFOL);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBoxCancel);
			this.Controls.Add(this.pictureBoxOK);
			this.MaximumSize = new System.Drawing.Size(727, 683);
			this.MinimumSize = new System.Drawing.Size(727, 683);
			this.Name = "VisualFOL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Visual Field Loss";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.valueFOL)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.NumericUpDown valueFOL;
	}
}