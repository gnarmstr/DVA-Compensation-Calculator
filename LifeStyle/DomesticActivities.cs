﻿using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class DomesticActivities : Form
	{
		public DomesticActivities()
		{
			Location = new Point(GlobalVar.MainFormLocxationX - 10, GlobalVar.MainFormLocxationY);
			InitializeComponent();
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			MinimumSize = new Size(740, 690);
			MaximumSize = new Size(740, 690);
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			switch (Convert.ToInt16(GlobalVar.DomesticActivities))
			{
				case 0: checkBoxOption1.Checked = true;
					break;
				case 1: checkBoxOption2.Checked = true;
					break;
				case 2: checkBoxOption3.Checked = true;
					break;
				case 3: checkBoxOption4.Checked = true;
					break;
				case 4: checkBoxOption5.Checked = true;
					break;
				case 5: checkBoxOption6.Checked = true;
					break;
				case 6: checkBoxOption7.Checked = true;
					break;
				case 7: checkBoxOption8.Checked = true;
					break;
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

		private void buttonMainTitle_MouseDown(object sender, MouseEventArgs e)
		{
			FormDrag.formDrag_MouseDown(e);
		}

		private void buttonMainTitle_MouseMove(object sender, MouseEventArgs e)
		{
			if (GlobalVar.dragging)
			{
				Left = e.X + Left - GlobalVar.offsetX;
				Top = e.Y + Top - GlobalVar.offsetY;
			}
		}

		private void buttonMainTitle_MouseUp(object sender, MouseEventArgs e)
		{
			FormDrag.formDrag_MouseUp(e);
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
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				domesticActivities = 0;
			}
		}

		public static int domesticActivities;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption2.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				domesticActivities = 1;
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
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				domesticActivities = 2;
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
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				domesticActivities = 3;
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
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				domesticActivities = 4;
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
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				domesticActivities = 5;
			}
		}

		private void checkBoxOption7_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption7.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption8.Checked = false;
				domesticActivities = 6;
			}
		}

		private void checkBoxOption8_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption8.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption7.Checked = false;
				domesticActivities = 7;
			}
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
