using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class Tinnitus : Form
	{
		public Tinnitus()
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
				Points = 0;
			}
		}

		public static int tinnitus;

		public static int Points;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption2.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
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
				Points = 15;
			}
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			tinnitus = Points;
			Close();
		}

	}
}
