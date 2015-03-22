namespace DVA_Compensation_Calculator
{
	partial class Disclaimer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Disclaimer));
			this.pictureBoxYes = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBoxDisclaimer = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonMainTitle = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxYes
			// 
			this.pictureBoxYes.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxYes.Location = new System.Drawing.Point(452, 599);
			this.pictureBoxYes.Name = "pictureBoxYes";
			this.pictureBoxYes.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxYes.TabIndex = 14;
			this.pictureBoxYes.TabStop = false;
			this.pictureBoxYes.Tag = "7";
			this.pictureBoxYes.Click += new System.EventHandler(this.pictureBoxYes_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(537, 461);
			this.label2.TabIndex = 22;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.checkBoxDisclaimer);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.pictureBoxYes);
			this.panel1.Location = new System.Drawing.Point(22, 70);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(552, 698);
			this.panel1.TabIndex = 24;
			// 
			// checkBoxDisclaimer
			// 
			this.checkBoxDisclaimer.AutoSize = true;
			this.checkBoxDisclaimer.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxDisclaimer.Location = new System.Drawing.Point(34, 622);
			this.checkBoxDisclaimer.Name = "checkBoxDisclaimer";
			this.checkBoxDisclaimer.Size = new System.Drawing.Size(385, 24);
			this.checkBoxDisclaimer.TabIndex = 24;
			this.checkBoxDisclaimer.Text = "I understand and agree with the disclaimer above.";
			this.checkBoxDisclaimer.UseVisualStyleBackColor = false;
			this.checkBoxDisclaimer.CheckedChanged += new System.EventHandler(this.checkBoxDisclaimer_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(185, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 29);
			this.label1.TabIndex = 23;
			this.label1.Text = "DISCLAIMER";
			// 
			// buttonMainTitle
			// 
			this.buttonMainTitle.BackColor = System.Drawing.Color.Transparent;
			this.buttonMainTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonMainTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMainTitle.Location = new System.Drawing.Point(22, 21);
			this.buttonMainTitle.Name = "buttonMainTitle";
			this.buttonMainTitle.Size = new System.Drawing.Size(552, 43);
			this.buttonMainTitle.TabIndex = 95;
			this.buttonMainTitle.Text = "DVA COMPENSATION (MRCA) CALCULATOR";
			this.buttonMainTitle.UseVisualStyleBackColor = false;
			this.buttonMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseDown);
			this.buttonMainTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseMove);
			this.buttonMainTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseUp);
			// 
			// Disclaimer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(600, 800);
			this.Controls.Add(this.buttonMainTitle);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(600, 800);
			this.MinimumSize = new System.Drawing.Size(600, 800);
			this.Name = "Disclaimer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Domestic Activities";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxYes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox checkBoxDisclaimer;
		private System.Windows.Forms.Button buttonMainTitle;
	}
}