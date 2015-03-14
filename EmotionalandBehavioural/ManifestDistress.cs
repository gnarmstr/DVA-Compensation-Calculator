using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class ManifestDistress : Form
	{
		public ManifestDistress()
		{
			Location = new Point(GlobalVar.MainFormLocxationX - 10, GlobalVar.MainFormLocxationY);
			InitializeComponent();
			MinimumSize = new Size(740, 650);
			MaximumSize = new Size(740, 650);
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);

			switch (manifestDistress)
			{
				case 0: checkBoxOption1.Checked = true;
					break;
				case 2: checkBoxOption2.Checked = true;
					break;
				case 3: checkBoxOption3.Checked = true;
					break;
				case 6: checkBoxOption4.Checked = true;
					break;
				case 10: checkBoxOption5.Checked = true;
					break;
				case 15: checkBoxOption6.Checked = true;
					break;
				case 20: checkBoxOption7.Checked = true;
					break;
				case 24: checkBoxOption8.Checked = true;
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
				manifestDistress = 0;
			}
		}

		public static int manifestDistress;

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
				manifestDistress = 2;
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
				manifestDistress = 3;
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
				manifestDistress = 6;
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
				manifestDistress = 10;
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
				manifestDistress = 15;
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
				manifestDistress = 20;
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
				manifestDistress = 24;
			}
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
