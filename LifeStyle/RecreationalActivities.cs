using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class RecreationalActivities : Form
	{
		public RecreationalActivities()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
			InitializeComponent();
		}

		private void Mobility_Load(object sender, EventArgs e)
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
			checkBoxOption7.Checked = false;
			checkBoxOption8.Checked = false;
			recreationalActivities = 0;
		}

		public static int recreationalActivities;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			checkBoxOption7.Checked = false;
			checkBoxOption8.Checked = false;
			recreationalActivities = 1;
		}

		private void checkBoxOption3_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			checkBoxOption7.Checked = false;
			checkBoxOption8.Checked = false;
			recreationalActivities = 2;
		}

		private void checkBoxOption4_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			checkBoxOption7.Checked = false;
			checkBoxOption8.Checked = false;
			recreationalActivities = 3;
		}

		private void checkBoxOption5_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption6.Checked = false;
			checkBoxOption7.Checked = false;
			checkBoxOption8.Checked = false;
			recreationalActivities = 4;
		}

		private void checkBoxOption6_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption7.Checked = false;
			checkBoxOption8.Checked = false;
			recreationalActivities = 5;
		}

		private void checkBoxOption7_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			checkBoxOption8.Checked = false;
			recreationalActivities = 6;
		}

		private void checkBoxOption8_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			checkBoxOption4.Checked = false;
			checkBoxOption5.Checked = false;
			checkBoxOption6.Checked = false;
			checkBoxOption7.Checked = false;
			recreationalActivities = 7;
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			recreationalActivities = 0;
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
