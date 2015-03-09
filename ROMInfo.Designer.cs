namespace DVA_Compensation_Calculator
{
	partial class ROMInfo
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(451, 350);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(85, 80);
			this.button1.TabIndex = 0;
			this.button1.Text = "g";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
			this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
			// 
			// ROMInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(978, 694);
			this.Controls.Add(this.button1);
			this.MaximumSize = new System.Drawing.Size(1000, 750);
			this.MinimumSize = new System.Drawing.Size(1000, 750);
			this.Name = "ROMInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Range Of Motion Information";
			this.Load += new System.EventHandler(this.ROMInfo_Load);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ROMInfo_MouseClick);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
	}
}