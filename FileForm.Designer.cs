namespace DVA_Compensation_Calculator
{
    partial class FileForm
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
            this.pictureBoxSave = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.textBox_Filename = new System.Windows.Forms.TextBox();
            this.pictureBoxLoad = new System.Windows.Forms.PictureBox();
            this.pictureBoxNew = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNew)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSave
            // 
            this.pictureBoxSave.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSave.Location = new System.Drawing.Point(214, 194);
            this.pictureBoxSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxSave.Name = "pictureBoxSave";
            this.pictureBoxSave.Size = new System.Drawing.Size(71, 64);
            this.pictureBoxSave.TabIndex = 14;
            this.pictureBoxSave.TabStop = false;
            this.pictureBoxSave.Tag = "7";
            this.pictureBoxSave.Visible = false;
            this.pictureBoxSave.Click += new System.EventHandler(this.pictureBoxSave_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 47);
            this.label2.TabIndex = 22;
            this.label2.Text = "Select or enter\r\nfilename";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBoxNew);
            this.panel1.Controls.Add(this.pictureBoxLoad);
            this.panel1.Controls.Add(this.listBoxFiles);
            this.panel1.Controls.Add(this.pictureBoxCancel);
            this.panel1.Controls.Add(this.textBox_Filename);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBoxSave);
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 381);
            this.panel1.TabIndex = 24;
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 16;
            this.listBoxFiles.Location = new System.Drawing.Point(11, 81);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(187, 292);
            this.listBoxFiles.TabIndex = 25;
            this.listBoxFiles.DoubleClick += new System.EventHandler(this.listBoxFiles_DoubleClick);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.Location = new System.Drawing.Point(214, 277);
            this.pictureBoxCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(71, 64);
            this.pictureBoxCancel.TabIndex = 24;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Tag = "8";
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            // 
            // textBox_Filename
            // 
            this.textBox_Filename.Location = new System.Drawing.Point(11, 53);
            this.textBox_Filename.Name = "textBox_Filename";
            this.textBox_Filename.Size = new System.Drawing.Size(187, 22);
            this.textBox_Filename.TabIndex = 23;
            this.textBox_Filename.Visible = false;
            // 
            // pictureBoxLoad
            // 
            this.pictureBoxLoad.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLoad.Location = new System.Drawing.Point(214, 194);
            this.pictureBoxLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxLoad.Name = "pictureBoxLoad";
            this.pictureBoxLoad.Size = new System.Drawing.Size(71, 64);
            this.pictureBoxLoad.TabIndex = 26;
            this.pictureBoxLoad.TabStop = false;
            this.pictureBoxLoad.Tag = "7";
            this.pictureBoxLoad.Visible = false;
            this.pictureBoxLoad.Click += new System.EventHandler(this.pictureBoxLoad_Click);
            // 
            // pictureBoxNew
            // 
            this.pictureBoxNew.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNew.Location = new System.Drawing.Point(214, 118);
            this.pictureBoxNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxNew.Name = "pictureBoxNew";
            this.pictureBoxNew.Size = new System.Drawing.Size(71, 64);
            this.pictureBoxNew.TabIndex = 27;
            this.pictureBoxNew.TabStop = false;
            this.pictureBoxNew.Tag = "7";
            this.pictureBoxNew.Visible = false;
            this.pictureBoxNew.Click += new System.EventHandler(this.pictureBoxNew_Click);
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(320, 400);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(340, 400);
            this.MinimumSize = new System.Drawing.Size(320, 400);
            this.Name = "FileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Domestic Activities";
            this.Load += new System.EventHandler(this.DomesticActivities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNew)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_Filename;
        public System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.PictureBox pictureBoxLoad;
        private System.Windows.Forms.PictureBox pictureBoxNew;
	}
}