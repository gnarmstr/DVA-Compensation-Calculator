﻿using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class Wrist : Form
	{
		public Wrist()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 100, ActiveForm.Location.Y + 100);
			InitializeComponent();
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			if (GlobalVar.Selection == "LeftWrist")
			{
				switch (GlobalVar.LeftWristPoints)
				{
					case 0: checkBoxOption1.Checked = true;
						GlobalVar.comboBoxLeftWristPartially = 0;
						break;
					case 5: checkBoxOption2.Checked = true;
						break;
					case 10: checkBoxOption3.Checked = true;
						break;
					case 15: checkBoxOption4.Checked = true;
						break;
					case 20: checkBoxOption5.Checked = true;
						break;
					case 30: checkBoxOption6.Checked = true;
						break;
				}
				comboBoxWristPartially.SelectedIndex = GlobalVar.comboBoxLeftWristPartially;
			}
			else
			{
				switch (GlobalVar.RightWristPoints)
				{
					case 0: checkBoxOption1.Checked = true;
						GlobalVar.comboBoxRightWristPartially = 0;
						break;
					case 5: checkBoxOption2.Checked = true;
						break;
					case 10: checkBoxOption3.Checked = true;
						break;
					case 15: checkBoxOption4.Checked = true;
						break;
					case 20: checkBoxOption5.Checked = true;
						break;
					case 30: checkBoxOption6.Checked = true;
						break;
				}
				comboBoxWristPartially.SelectedIndex = GlobalVar.comboBoxRightWristPartially;
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | 0x2000000;
				return cp;
			}
		}

		private void DomesticActivities_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void checkBoxOption1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption1.Checked)
			{
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				Points = 0;
			}
		}

		public static int LeftWrist;

		public static int RightWrist;

		public static int Points;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption2.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				Points = 5;
			}
		}

		private void checkBoxOption3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption3.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				Points = 10;
			}
		}

		private void checkBoxOption4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption4.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				Points = 15;
			}
		}

		private void checkBoxOption5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption5.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption6.Checked = false;
				Points = 20;
			}
		}

		private void checkBoxOption6_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption6.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				Points = 30;
			}
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			if (GlobalVar.Selection == "LeftWrist")
			{
				GlobalVar.comboBoxLeftWristPartially = comboBoxWristPartially.SelectedIndex;
				GlobalVar.LeftWristPoints = Points;
				LeftWrist = Convert.ToInt16(GlobalVar.ExcelData[4][Points][GlobalVar.AgeAdjustRange]);
				GlobalVar.combinedLeftWristPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][LeftWrist][comboBoxWristPartially.SelectedIndex + 2]);
			}
			else
			{
				GlobalVar.comboBoxRightWristPartially = comboBoxWristPartially.SelectedIndex;
				GlobalVar.RightWristPoints = Points;
				RightWrist = Convert.ToInt16(GlobalVar.ExcelData[4][Points][GlobalVar.AgeAdjustRange]);
				GlobalVar.combinedRightWristPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][RightWrist][comboBoxWristPartially.SelectedIndex + 2]);
			}
			Close();
		}

	}
}
