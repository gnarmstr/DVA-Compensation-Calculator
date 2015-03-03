using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class Nose : Form
	{
		public Nose()
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
			checkBoxOption2.Checked = false;
			checkBoxOption3.Checked = false;
			Points = 0;
		}

		public static int nose;

		public static int Points;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption3.Checked = false;
			Points = 2;
		}

		private void checkBoxOption3_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxOption1.Checked = false;
			checkBoxOption2.Checked = false;
			Points = 5;
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			nose = 0;
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			nose = Points;
			Close();
		}

	}
}
