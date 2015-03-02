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
			this.SuspendLayout();
			// 
			// ROMInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(978, 694);
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
	}
}