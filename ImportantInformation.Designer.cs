namespace DVA_Compensation_Calculator
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.SuspendLayout();
			// 
			// label85
			// 
			this.label85.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label85.Location = new System.Drawing.Point(11, 51);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(707, 530);
			this.label85.TabIndex = 20;
			this.label85.Text = resources.GetString("label85.Text");
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.Location = new System.Drawing.Point(724, 484);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 21;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// ImportantInformation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(839, 586);
			this.Controls.Add(this.pictureBoxOK);
			this.Controls.Add(this.label85);
			this.MaximumSize = new System.Drawing.Size(861, 642);
			this.MinimumSize = new System.Drawing.Size(861, 642);
			this.Name = "ImportantInformation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Important Information";
			this.Load += new System.EventHandler(this.ImportantInformation_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.PictureBox pictureBoxOK;

	}
}