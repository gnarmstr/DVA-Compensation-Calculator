﻿using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;

namespace DVA_Compensation_Calculator
{
	public partial class Wrist : Form
	{
		public Wrist()
		{
			InitializeComponent();
		}

		private void DomesticActivities_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void checkBoxOption1_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			Points = 0;
		}

		public static int LeftWrist;

		public static int RightWrist;

		public static int Points;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			Points = 5;
		}

		private void checkBoxOption3_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			Points = 10;
		}

		private void checkBoxOption4_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			Points = 15;
		}

		private void checkBoxOption5_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption6.Checked = false;
			Points = 20;
		}

		private void checkBoxOption6_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			Points = 30;
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			if (GlobalVar.Selection == "LeftWrist")
			{
				LeftWrist = 0;
			}
			else
			{
				RightWrist = 0;
			}
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			if (GlobalVar.Selection == "LeftWrist")
			{
				LeftWrist = Points;
			}
			else
			{
				RightWrist = Points;
			}
			Close();
		}

	}
}