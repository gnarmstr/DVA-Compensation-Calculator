namespace DVA_Compensation_Calculator
{
	partial class Nose
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
			this.components = new System.ComponentModel.Container();
			this.checkBoxOption2 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption3 = new System.Windows.Forms.CheckBox();
			this.checkBoxOption1 = new System.Windows.Forms.CheckBox();
			this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxNosePartially = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.buttonMainTitle = new System.Windows.Forms.Button();
			this.pictureBoxClose = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxOption2
			// 
			this.checkBoxOption2.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption2.Location = new System.Drawing.Point(24, 177);
			this.checkBoxOption2.Name = "checkBoxOption2";
			this.checkBoxOption2.Size = new System.Drawing.Size(591, 60);
			this.checkBoxOption2.TabIndex = 11;
			this.checkBoxOption2.Text = "Recurrent upper respiratory tract infection.";
			this.checkBoxOption2.UseVisualStyleBackColor = false;
			this.checkBoxOption2.CheckedChanged += new System.EventHandler(this.checkBoxOption2_CheckedChanged);
			// 
			// checkBoxOption3
			// 
			this.checkBoxOption3.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption3.Location = new System.Drawing.Point(24, 259);
			this.checkBoxOption3.Name = "checkBoxOption3";
			this.checkBoxOption3.Size = new System.Drawing.Size(591, 75);
			this.checkBoxOption3.TabIndex = 7;
			this.checkBoxOption3.Text = "Symptoms of rhinitis and sinusitis or both which are not relieved by medication a" +
    "nd which occur for more than 4 months every year.";
			this.checkBoxOption3.UseVisualStyleBackColor = false;
			this.checkBoxOption3.CheckedChanged += new System.EventHandler(this.checkBoxOption3_CheckedChanged);
			// 
			// checkBoxOption1
			// 
			this.checkBoxOption1.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxOption1.Location = new System.Drawing.Point(24, 106);
			this.checkBoxOption1.Name = "checkBoxOption1";
			this.checkBoxOption1.Size = new System.Drawing.Size(591, 38);
			this.checkBoxOption1.TabIndex = 6;
			this.checkBoxOption1.Text = "Intermittent post-nasal discharge, rhinorrhoea and/or sneezing.";
			this.checkBoxOption1.UseVisualStyleBackColor = false;
			this.checkBoxOption1.CheckedChanged += new System.EventHandler(this.checkBoxOption1_CheckedChanged);
			// 
			// pictureBoxCancel
			// 
			this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCancel.Location = new System.Drawing.Point(639, 340);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxCancel.TabIndex = 15;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.Tag = "8";
			this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxOK.Location = new System.Drawing.Point(535, 340);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxOK.TabIndex = 14;
			this.pictureBoxOK.TabStop = false;
			this.pictureBoxOK.Tag = "7";
			this.pictureBoxOK.Click += new System.EventHandler(this.pictureBoxOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(140, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(445, 25);
			this.label1.TabIndex = 21;
			this.label1.Text = "Select the one that best meets your situation.";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(19, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(700, 29);
			this.label2.TabIndex = 22;
			this.label2.Text = "UPPER RESPIRATORY TRACT AND NASAL CONDITIONS";
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.comboBoxNosePartially);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBoxCancel);
			this.panel1.Controls.Add(this.pictureBoxOK);
			this.panel1.Controls.Add(this.checkBoxOption2);
			this.panel1.Controls.Add(this.checkBoxOption3);
			this.panel1.Controls.Add(this.checkBoxOption1);
			this.panel1.Location = new System.Drawing.Point(28, 77);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(737, 438);
			this.panel1.TabIndex = 23;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(29, 381);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(275, 20);
			this.label3.TabIndex = 61;
			this.label3.Text = "Partially Contributing Impairment:";
			this.toolTip1.SetToolTip(this.label3, "Partially contributing impairment is to be applied whenever an impairment is not " +
        "due solely to the effects of the accepted condition.\r\n\"Complete\" indicates the a" +
        "ccepted condition is fully covered.");
			// 
			// comboBoxNosePartially
			// 
			this.comboBoxNosePartially.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxNosePartially.FormattingEnabled = true;
			this.comboBoxNosePartially.Items.AddRange(new object[] {
            "Complete",
            "About 3/4",
            "About 2/3",
            "About 1/2",
            "About 1/3",
            "About 1/4"});
			this.comboBoxNosePartially.Location = new System.Drawing.Point(337, 378);
			this.comboBoxNosePartially.Name = "comboBoxNosePartially";
			this.comboBoxNosePartially.Size = new System.Drawing.Size(142, 28);
			this.comboBoxNosePartially.TabIndex = 31;
			this.toolTip1.SetToolTip(this.comboBoxNosePartially, "Partially contributing impairment is to be applied whenever an impairment is not " +
        "due solely to the effects of the accepted condition.\r\n\"Complete\" indicates the a" +
        "ccepted condition is fully covered.");
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 10000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// buttonMainTitle
			// 
			this.buttonMainTitle.BackColor = System.Drawing.Color.Transparent;
			this.buttonMainTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonMainTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMainTitle.Location = new System.Drawing.Point(28, 28);
			this.buttonMainTitle.Name = "buttonMainTitle";
			this.buttonMainTitle.Size = new System.Drawing.Size(688, 43);
			this.buttonMainTitle.TabIndex = 94;
			this.buttonMainTitle.Text = "DVA COMPENSATION (MRCA) CALCULATOR";
			this.buttonMainTitle.UseVisualStyleBackColor = false;
			this.buttonMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseDown);
			this.buttonMainTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseMove);
			this.buttonMainTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonMainTitle_MouseUp);
			// 
			// pictureBoxClose
			// 
			this.pictureBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxClose.Location = new System.Drawing.Point(722, 28);
			this.pictureBoxClose.Name = "pictureBoxClose";
			this.pictureBoxClose.Size = new System.Drawing.Size(43, 43);
			this.pictureBoxClose.TabIndex = 93;
			this.pictureBoxClose.TabStop = false;
			this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
			// 
			// Nose
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(800, 550);
			this.Controls.Add(this.buttonMainTitle);
			this.Controls.Add(this.pictureBoxClose);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(800, 550);
			this.MinimumSize = new System.Drawing.Size(800, 550);
			this.Name = "Nose";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "UPPER RESPIRATORY TRACT AND NASAL CONDITIONS";
			this.Load += new System.EventHandler(this.DomesticActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxOption2;
		private System.Windows.Forms.CheckBox checkBoxOption3;
		private System.Windows.Forms.CheckBox checkBoxOption1;
		public System.Windows.Forms.PictureBox pictureBoxCancel;
		private System.Windows.Forms.PictureBox pictureBoxOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboBoxNosePartially;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonMainTitle;
		private System.Windows.Forms.PictureBox pictureBoxClose;
	}
}