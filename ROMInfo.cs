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
	}
}
