using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class ROMInfo : Form
	{
		public ROMInfo()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
			InitializeComponent();
		}

		private void ROMInfo_Load(object sender, EventArgs e)
		{
			BackgroundImage = Tools.GetIcon(Resources.Range_of_Motion_Table3_5_11, 1700);
		}

		private void ROMInfo_MouseClick(object sender, MouseEventArgs e)
		{
			Close();
		}

		private void button1_MouseHover(object sender, EventArgs e)
		{
			button1.Text = "Left Arm";

		}

		private void button1_MouseLeave(object sender, EventArgs e)
		{
			button1.Text = "";
		}
	}
}
