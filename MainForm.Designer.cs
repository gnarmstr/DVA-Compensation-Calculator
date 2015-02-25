namespace DVA_Compensation_Calculator
{
	partial class MainForm
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
			this.textBoxWeeklyPayout = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxLumpSumPayout = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPagePersonalDetails = new System.Windows.Forms.TabPage();
			this.textBoxWeeklyPayment = new System.Windows.Forms.TextBox();
			this.comboBoxAge = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPageLowerLimbs = new System.Windows.Forms.TabPage();
			this.tabPageUpperLimb = new System.Windows.Forms.TabPage();
			this.comboBoxShoulder = new System.Windows.Forms.ComboBox();
			this.comboBoxWrist = new System.Windows.Forms.ComboBox();
			this.comboBoxElbow = new System.Windows.Forms.ComboBox();
			this.comboBoxFingers = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxElbow = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxFingers = new System.Windows.Forms.TextBox();
			this.textBoxWrist = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxShoulder = new System.Windows.Forms.TextBox();
			this.tabPageBack = new System.Windows.Forms.TabPage();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SaveAll = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBoxKnee = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxKnee = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPagePersonalDetails.SuspendLayout();
			this.tabPageLowerLimbs.SuspendLayout();
			this.tabPageUpperLimb.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxWeeklyPayout
			// 
			this.textBoxWeeklyPayout.Location = new System.Drawing.Point(266, 636);
			this.textBoxWeeklyPayout.Name = "textBoxWeeklyPayout";
			this.textBoxWeeklyPayout.Size = new System.Drawing.Size(196, 26);
			this.textBoxWeeklyPayout.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 639);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(237, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Compensation Payout per week:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(518, 639);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Lump Sum Payout:";
			// 
			// textBoxLumpSumPayout
			// 
			this.textBoxLumpSumPayout.Location = new System.Drawing.Point(675, 636);
			this.textBoxLumpSumPayout.Name = "textBoxLumpSumPayout";
			this.textBoxLumpSumPayout.Size = new System.Drawing.Size(196, 26);
			this.textBoxLumpSumPayout.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPagePersonalDetails);
			this.tabControl1.Controls.Add(this.tabPageUpperLimb);
			this.tabControl1.Controls.Add(this.tabPageLowerLimbs);
			this.tabControl1.Controls.Add(this.tabPageBack);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(889, 602);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPagePersonalDetails
			// 
			this.tabPagePersonalDetails.BackColor = System.Drawing.SystemColors.Info;
			this.tabPagePersonalDetails.Controls.Add(this.textBoxWeeklyPayment);
			this.tabPagePersonalDetails.Controls.Add(this.comboBoxAge);
			this.tabPagePersonalDetails.Controls.Add(this.label5);
			this.tabPagePersonalDetails.Controls.Add(this.label4);
			this.tabPagePersonalDetails.Location = new System.Drawing.Point(4, 29);
			this.tabPagePersonalDetails.Name = "tabPagePersonalDetails";
			this.tabPagePersonalDetails.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePersonalDetails.Size = new System.Drawing.Size(881, 569);
			this.tabPagePersonalDetails.TabIndex = 0;
			this.tabPagePersonalDetails.Text = "Personal Details";
			// 
			// textBoxWeeklyPayment
			// 
			this.textBoxWeeklyPayment.Enabled = false;
			this.textBoxWeeklyPayment.Location = new System.Drawing.Point(269, 73);
			this.textBoxWeeklyPayment.Name = "textBoxWeeklyPayment";
			this.textBoxWeeklyPayment.Size = new System.Drawing.Size(112, 26);
			this.textBoxWeeklyPayment.TabIndex = 15;
			// 
			// comboBoxAge
			// 
			this.comboBoxAge.FormattingEnabled = true;
			this.comboBoxAge.Location = new System.Drawing.Point(269, 132);
			this.comboBoxAge.Name = "comboBoxAge";
			this.comboBoxAge.Size = new System.Drawing.Size(102, 28);
			this.comboBoxAge.TabIndex = 12;
			this.comboBoxAge.SelectedIndexChanged += new System.EventHandler(this.comboBoxAge_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(35, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(156, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Age at next Birthday:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(233, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Maximum Weekly payment:      $";
			this.toolTip1.SetToolTip(this.label4, "Enter the Weekly payment as per DVA");
			// 
			// tabPageLowerLimbs
			// 
			this.tabPageLowerLimbs.BackColor = System.Drawing.SystemColors.Info;
			this.tabPageLowerLimbs.Controls.Add(this.label6);
			this.tabPageLowerLimbs.Controls.Add(this.comboBox1);
			this.tabPageLowerLimbs.Controls.Add(this.comboBox2);
			this.tabPageLowerLimbs.Controls.Add(this.comboBoxKnee);
			this.tabPageLowerLimbs.Controls.Add(this.comboBox4);
			this.tabPageLowerLimbs.Controls.Add(this.label7);
			this.tabPageLowerLimbs.Controls.Add(this.textBoxKnee);
			this.tabPageLowerLimbs.Controls.Add(this.label14);
			this.tabPageLowerLimbs.Controls.Add(this.label15);
			this.tabPageLowerLimbs.Controls.Add(this.textBox2);
			this.tabPageLowerLimbs.Controls.Add(this.textBox3);
			this.tabPageLowerLimbs.Controls.Add(this.label16);
			this.tabPageLowerLimbs.Controls.Add(this.label17);
			this.tabPageLowerLimbs.Controls.Add(this.textBox4);
			this.tabPageLowerLimbs.Location = new System.Drawing.Point(4, 29);
			this.tabPageLowerLimbs.Name = "tabPageLowerLimbs";
			this.tabPageLowerLimbs.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLowerLimbs.Size = new System.Drawing.Size(881, 569);
			this.tabPageLowerLimbs.TabIndex = 1;
			this.tabPageLowerLimbs.Text = "Lower Limbs";
			// 
			// tabPageUpperLimb
			// 
			this.tabPageUpperLimb.BackColor = System.Drawing.SystemColors.Info;
			this.tabPageUpperLimb.Controls.Add(this.label3);
			this.tabPageUpperLimb.Controls.Add(this.comboBoxShoulder);
			this.tabPageUpperLimb.Controls.Add(this.comboBoxWrist);
			this.tabPageUpperLimb.Controls.Add(this.comboBoxElbow);
			this.tabPageUpperLimb.Controls.Add(this.comboBoxFingers);
			this.tabPageUpperLimb.Controls.Add(this.label9);
			this.tabPageUpperLimb.Controls.Add(this.textBoxElbow);
			this.tabPageUpperLimb.Controls.Add(this.label13);
			this.tabPageUpperLimb.Controls.Add(this.label10);
			this.tabPageUpperLimb.Controls.Add(this.textBoxFingers);
			this.tabPageUpperLimb.Controls.Add(this.textBoxWrist);
			this.tabPageUpperLimb.Controls.Add(this.label12);
			this.tabPageUpperLimb.Controls.Add(this.label11);
			this.tabPageUpperLimb.Controls.Add(this.textBoxShoulder);
			this.tabPageUpperLimb.Location = new System.Drawing.Point(4, 29);
			this.tabPageUpperLimb.Name = "tabPageUpperLimb";
			this.tabPageUpperLimb.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageUpperLimb.Size = new System.Drawing.Size(881, 569);
			this.tabPageUpperLimb.TabIndex = 2;
			this.tabPageUpperLimb.Text = "Upper Limbs";
			// 
			// comboBoxShoulder
			// 
			this.comboBoxShoulder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxShoulder.DropDownWidth = 300;
			this.comboBoxShoulder.FormattingEnabled = true;
			this.comboBoxShoulder.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Loss of about one-quarter normal range of movement.",
            "- Loss of about one-half normal range of movement.",
            "- Loss of about three-quarters normal range of movement.",
            "- Loss of almost all movement, or complete ankylosis in position of function.",
            "- Ankylosis in an unfavourable position, or a flail joint."});
			this.comboBoxShoulder.Location = new System.Drawing.Point(189, 126);
			this.comboBoxShoulder.Name = "comboBoxShoulder";
			this.comboBoxShoulder.Size = new System.Drawing.Size(553, 28);
			this.comboBoxShoulder.TabIndex = 19;
			this.comboBoxShoulder.SelectedIndexChanged += new System.EventHandler(this.comboBoxShoulder_SelectedIndexChanged);
			// 
			// comboBoxWrist
			// 
			this.comboBoxWrist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxWrist.DropDownWidth = 300;
			this.comboBoxWrist.FormattingEnabled = true;
			this.comboBoxWrist.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Loss of about one-quarter normal range of movement.",
            "- Loss of about one-half normal range of movement.",
            "- Loss of about three-quarters normal range of movement.",
            "- Loss of almost all movement, or complete ankylosis in position of function.",
            "- Ankylosis in an unfavourable position, or a flail joint."});
			this.comboBoxWrist.Location = new System.Drawing.Point(189, 182);
			this.comboBoxWrist.Name = "comboBoxWrist";
			this.comboBoxWrist.Size = new System.Drawing.Size(553, 28);
			this.comboBoxWrist.TabIndex = 20;
			this.comboBoxWrist.SelectedIndexChanged += new System.EventHandler(this.comboBoxWrist_SelectedIndexChanged);
			// 
			// comboBoxElbow
			// 
			this.comboBoxElbow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxElbow.DropDownWidth = 300;
			this.comboBoxElbow.FormattingEnabled = true;
			this.comboBoxElbow.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Loss of about one-quarter normal range of movement.",
            "- Loss of about one-half normal range of movement.",
            "- Loss of about three-quarters normal range of movement.",
            "- Loss of almost all movement, or complete ankylosis in position of function.",
            "- Ankylosis in an unfavourable position, or a flail joint."});
			this.comboBoxElbow.Location = new System.Drawing.Point(189, 68);
			this.comboBoxElbow.Name = "comboBoxElbow";
			this.comboBoxElbow.Size = new System.Drawing.Size(553, 28);
			this.comboBoxElbow.TabIndex = 18;
			this.comboBoxElbow.SelectedIndexChanged += new System.EventHandler(this.comboBoxElbow_SelectedIndexChanged);
			// 
			// comboBoxFingers
			// 
			this.comboBoxFingers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFingers.DropDownWidth = 900;
			this.comboBoxFingers.FormattingEnabled = true;
			this.comboBoxFingers.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Ankylosis in any position of joints of 4th or 5th finger. Ankylosis in any posi" +
                "tion of function of any joints of 2nd or 3rd finger.",
            "- Ankylosis in an unfavourable position of any or all joints of 2nd and 3rd finge" +
                "r. Thumb: loss of almost all movement or complete ankylosis of any or all joints" +
                " (in position of function).",
            "- Thumb: ankylosis of any or all joints in an unfavourable position."});
			this.comboBoxFingers.Location = new System.Drawing.Point(189, 239);
			this.comboBoxFingers.Name = "comboBoxFingers";
			this.comboBoxFingers.Size = new System.Drawing.Size(553, 28);
			this.comboBoxFingers.TabIndex = 19;
			this.comboBoxFingers.SelectedIndexChanged += new System.EventHandler(this.comboBoxFingers_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 71);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 20);
			this.label9.TabIndex = 6;
			this.label9.Text = "Elbow:";
			// 
			// textBoxElbow
			// 
			this.textBoxElbow.Enabled = false;
			this.textBoxElbow.Location = new System.Drawing.Point(783, 68);
			this.textBoxElbow.Name = "textBoxElbow";
			this.textBoxElbow.Size = new System.Drawing.Size(70, 26);
			this.textBoxElbow.TabIndex = 7;
			this.textBoxElbow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(761, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(114, 49);
			this.label13.TabIndex = 17;
			this.label13.Text = "Age Adjusted Points:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 192);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(49, 20);
			this.label10.TabIndex = 9;
			this.label10.Text = "Wrist:";
			// 
			// textBoxFingers
			// 
			this.textBoxFingers.Enabled = false;
			this.textBoxFingers.Location = new System.Drawing.Point(782, 239);
			this.textBoxFingers.Name = "textBoxFingers";
			this.textBoxFingers.Size = new System.Drawing.Size(71, 26);
			this.textBoxFingers.TabIndex = 16;
			this.textBoxFingers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxWrist
			// 
			this.textBoxWrist.Enabled = false;
			this.textBoxWrist.Location = new System.Drawing.Point(783, 182);
			this.textBoxWrist.Name = "textBoxWrist";
			this.textBoxWrist.Size = new System.Drawing.Size(71, 26);
			this.textBoxWrist.TabIndex = 10;
			this.textBoxWrist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(16, 242);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(150, 20);
			this.label12.TabIndex = 15;
			this.label12.Text = "Thumb and Fingers:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(16, 129);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 20);
			this.label11.TabIndex = 12;
			this.label11.Text = "Shoulder:";
			// 
			// textBoxShoulder
			// 
			this.textBoxShoulder.Enabled = false;
			this.textBoxShoulder.Location = new System.Drawing.Point(782, 126);
			this.textBoxShoulder.Name = "textBoxShoulder";
			this.textBoxShoulder.Size = new System.Drawing.Size(71, 26);
			this.textBoxShoulder.TabIndex = 13;
			this.textBoxShoulder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tabPageBack
			// 
			this.tabPageBack.BackColor = System.Drawing.SystemColors.Info;
			this.tabPageBack.Location = new System.Drawing.Point(4, 29);
			this.tabPageBack.Name = "tabPageBack";
			this.tabPageBack.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageBack.Size = new System.Drawing.Size(881, 569);
			this.tabPageBack.TabIndex = 3;
			this.tabPageBack.Text = "Back";
			// 
			// SaveAll
			// 
			this.SaveAll.Location = new System.Drawing.Point(670, 755);
			this.SaveAll.Name = "SaveAll";
			this.SaveAll.Size = new System.Drawing.Size(200, 40);
			this.SaveAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.SaveAll.TabIndex = 70;
			this.SaveAll.TabStop = false;
			this.SaveAll.Tag = "20";
			this.toolTip1.SetToolTip(this.SaveAll, "This will Save all settings and lists. ");
			this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(54, 696);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(816, 56);
			this.label8.TabIndex = 5;
			this.label8.Text = "NOTE: The information with this software is for your personal use and may not be " +
    "accurate. DVA have no affiliation with this calculator.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(223, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(493, 20);
			this.label3.TabIndex = 21;
			this.label3.Text = "LOSS OF MUSCULOSKELETAL FUNCTION: UPPER LIMB JOINTS";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(223, 33);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(493, 20);
			this.label6.TabIndex = 35;
			this.label6.Text = "LOSS OF MUSCULOSKELETAL FUNCTION: UPPER LIMB JOINTS";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.DropDownWidth = 300;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Loss of about one-quarter normal range of movement.",
            "- Loss of about one-half normal range of movement.",
            "- Loss of about three-quarters normal range of movement.",
            "- Loss of almost all movement, or complete ankylosis in position of function.",
            "- Ankylosis in an unfavourable position, or a flail joint."});
			this.comboBox1.Location = new System.Drawing.Point(189, 126);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(553, 28);
			this.comboBox1.TabIndex = 32;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.DropDownWidth = 300;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Loss of about one-quarter normal range of movement.",
            "- Loss of about one-half normal range of movement.",
            "- Loss of about three-quarters normal range of movement.",
            "- Loss of almost all movement, or complete ankylosis in position of function.",
            "- Ankylosis in an unfavourable position, or a flail joint."});
			this.comboBox2.Location = new System.Drawing.Point(189, 182);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(553, 28);
			this.comboBox2.TabIndex = 34;
			// 
			// comboBoxKnee
			// 
			this.comboBoxKnee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxKnee.DropDownWidth = 300;
			this.comboBoxKnee.FormattingEnabled = true;
			this.comboBoxKnee.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Loss of about one-quarter normal range of movement.",
            "- Loss of about one-half normal range of movement.",
            "- Loss of about three-quarters normal range of movement.",
            "- Loss of almost all movement, or complete ankylosis in position of function.",
            "- Ankylosis in an unfavourable position, or a flail joint."});
			this.comboBoxKnee.Location = new System.Drawing.Point(189, 68);
			this.comboBoxKnee.Name = "comboBoxKnee";
			this.comboBoxKnee.Size = new System.Drawing.Size(553, 28);
			this.comboBoxKnee.TabIndex = 31;
			// 
			// comboBox4
			// 
			this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox4.DropDownWidth = 900;
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Items.AddRange(new object[] {
            "- No abnormality. X-ray changes only with normal range of movement.",
            "- Ankylosis in any position of joints of 4th or 5th finger. Ankylosis in any posi" +
                "tion of function of any joints of 2nd or 3rd finger.",
            "- Ankylosis in an unfavourable position of any or all joints of 2nd and 3rd finge" +
                "r. Thumb: loss of almost all movement or complete ankylosis of any or all joints" +
                " (in position of function).",
            "- Thumb: ankylosis of any or all joints in an unfavourable position."});
			this.comboBox4.Location = new System.Drawing.Point(189, 239);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(553, 28);
			this.comboBox4.TabIndex = 33;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 71);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 20);
			this.label7.TabIndex = 22;
			this.label7.Text = "Knee:";
			// 
			// textBoxKnee
			// 
			this.textBoxKnee.Enabled = false;
			this.textBoxKnee.Location = new System.Drawing.Point(783, 68);
			this.textBoxKnee.Name = "textBoxKnee";
			this.textBoxKnee.Size = new System.Drawing.Size(70, 26);
			this.textBoxKnee.TabIndex = 23;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(761, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(114, 49);
			this.label14.TabIndex = 30;
			this.label14.Text = "Age Adjusted Points:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(16, 192);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(49, 20);
			this.label15.TabIndex = 24;
			this.label15.Text = "Wrist:";
			// 
			// textBox2
			// 
			this.textBox2.Enabled = false;
			this.textBox2.Location = new System.Drawing.Point(782, 239);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(71, 26);
			this.textBox2.TabIndex = 29;
			// 
			// textBox3
			// 
			this.textBox3.Enabled = false;
			this.textBox3.Location = new System.Drawing.Point(783, 182);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(71, 26);
			this.textBox3.TabIndex = 25;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(16, 242);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(150, 20);
			this.label16.TabIndex = 28;
			this.label16.Text = "Thumb and Fingers:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(16, 129);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(77, 20);
			this.label17.TabIndex = 26;
			this.label17.Text = "Shoulder:";
			// 
			// textBox4
			// 
			this.textBox4.Enabled = false;
			this.textBox4.Location = new System.Drawing.Point(782, 126);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(71, 26);
			this.textBox4.TabIndex = 27;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(905, 829);
			this.Controls.Add(this.SaveAll);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxLumpSumPayout);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxWeeklyPayout);
			this.Name = "MainForm";
			this.Text = "DVA Compensation Calulator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabPagePersonalDetails.ResumeLayout(false);
			this.tabPagePersonalDetails.PerformLayout();
			this.tabPageLowerLimbs.ResumeLayout(false);
			this.tabPageLowerLimbs.PerformLayout();
			this.tabPageUpperLimb.ResumeLayout(false);
			this.tabPageUpperLimb.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxWeeklyPayout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxLumpSumPayout;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPagePersonalDetails;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TabPage tabPageLowerLimbs;
		private System.Windows.Forms.TabPage tabPageUpperLimb;
		private System.Windows.Forms.ComboBox comboBoxAge;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tabPageBack;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBoxFingers;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxShoulder;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBoxWrist;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxElbow;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comboBoxElbow;
		private System.Windows.Forms.ComboBox comboBoxWrist;
		private System.Windows.Forms.ComboBox comboBoxFingers;
		private System.Windows.Forms.ComboBox comboBoxShoulder;
		private System.Windows.Forms.TextBox textBoxWeeklyPayment;
		private System.Windows.Forms.PictureBox SaveAll;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBoxKnee;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxKnee;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox4;
	}
}

