using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class Ears : Form
	{
		public Ears()
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

#region Hearing Loss
		private void checkBoxOption1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption1.Checked)
			{
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				Points = 0;
			}
		}

		public static int ears;

		public static int Points;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption2.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
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
				Points = 10;
			}
		}
#endregion

#region Tinnitus

		public static int tinnitus;

		public static int PointsTinnitus;

		private void checkBoxTinnitusOption1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption1.Checked)
			{
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 0;
			}
		}

		private void checkBoxTinnitusOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption2.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 2;
			}
		}

		private void checkBoxTinnitusOption3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption3.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 5;
			}
		}

		private void checkBoxTinnitusOption4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption4.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 10;
			}
		}

		private void checkBoxTinnitusOption5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption5.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				PointsTinnitus = 15;
			}
		}

#endregion

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			ears = Points;
			tinnitus = PointsTinnitus;
			Close();
		}

	}
}
