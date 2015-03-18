namespace DVA_Compensation_Calculator
{
	partial class LifeStyleRatingCheck
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LifeStyleRatingCheck));
			this.pictureBoxYes = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxDisableWarning = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxYes)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxYes
			// 
			this.pictureBoxYes.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxYes.Location = new System.Drawing.Point(496, 253);
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
			this.label2.Location = new System.Drawing.Point(6, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(537, 187);
			this.label2.TabIndex = 22;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.checkBoxDisableWarning);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.pictureBoxYes);
			this.panel1.Location = new System.Drawing.Point(22, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(595, 347);
			this.panel1.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(169, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(234, 25);
			this.label1.TabIndex = 23;
			this.label1.Text = "LIFESTYLE WARNING";
			// 
			// checkBoxDisableWarning
			// 
			this.checkBoxDisableWarning.AutoSize = true;
			this.checkBoxDisableWarning.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxDisableWarning.Location = new System.Drawing.Point(32, 280);
			this.checkBoxDisableWarning.Name = "checkBoxDisableWarning";
			this.checkBoxDisableWarning.Size = new System.Drawing.Size(431, 24);
			this.checkBoxDisableWarning.TabIndex = 24;
			this.checkBoxDisableWarning.Text = "Select to disable Life Style Warnings during this session.";
			this.checkBoxDisableWarning.UseVisualStyleBackColor = false;
			this.checkBoxDisableWarning.Visible = false;
			// 
			// LifeStyleRatingCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(650, 400);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(650, 400);
			this.MinimumSize = new System.Drawing.Size(650, 400);
			this.Name = "LifeStyleRatingCheck";
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
		private System.Windows.Forms.CheckBox checkBoxDisableWarning;
	}
}