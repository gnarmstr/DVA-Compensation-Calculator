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
				Location = new Point(ActiveForm.Location.X, ActiveForm.Location.Y);
			InitializeComponent();
			MinimumSize = new Size(940, 650);
			MaximumSize = new Size(940, 650);
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Range_of_Motion;
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

		private void ROMInfo_MouseClick(object sender, MouseEventArgs e)
		{
			Close();
		}

		private void panel1_MouseClick(object sender, MouseEventArgs e)
		{
			Close();
		}

	}
}
