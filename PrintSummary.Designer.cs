namespace DVA_Compensation_Calculator
{
	partial class PrintSummary
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
			this.printButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// printButton
			// 
			this.printButton.Location = new System.Drawing.Point(24, 39);
			this.printButton.Name = "printButton";
			this.printButton.Size = new System.Drawing.Size(196, 99);
			this.printButton.TabIndex = 0;
			this.printButton.Text = "button1";
			this.printButton.UseVisualStyleBackColor = true;
			// 
			// PrintSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 558);
			this.Controls.Add(this.printButton);
			this.Name = "PrintSummary";
			this.Text = "PrintSummary";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button printButton;
	}
}