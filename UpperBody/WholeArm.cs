using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class WholeArm : Form
	{
		public WholeArm()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
			InitializeComponent();
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
				checkBoxOption9.Checked = false;
				Points = 0;
			}
		}

		public static int wholeLeftArm;

		public static int wholeRightArm;

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
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				checkBoxOption9.Checked = false;
				Points = 2;
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
				checkBoxOption9.Checked = false;
				Points = 5;
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
				checkBoxOption9.Checked = false;
				Points = 10;
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
				checkBoxOption9.Checked = false;
				Points = 15;
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
				checkBoxOption9.Checked = false;
				Points = 20;
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
				checkBoxOption9.Checked = false;
				Points = 30;
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
				checkBoxOption9.Checked = false;
				Points = 40;
			}
		}

		private void checkBoxOption9_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption9.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				Points = 50;
			}
		}

		private void checkBoxOption10_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption10.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				checkBoxOption9.Checked = false;
				Points = 60;
			}
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			if (GlobalVar.Selection == "LeftArm")
			{
				wholeLeftArm = Points;
			}
			else
			{
				wholeRightArm = Points;
			}
			Close();
		}

	}
}
