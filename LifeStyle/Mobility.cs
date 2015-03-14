using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class Mobility : Form
	{
		public Mobility()
		{
			Location = new Point(GlobalVar.MainFormLocxationX - 20, GlobalVar.MainFormLocxationY);
			InitializeComponent();
			MinimumSize = new Size(780, 720);
			MaximumSize = new Size(780, 720);
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			switch (Convert.ToInt16(GlobalVar.Mobility))
			{
				case 0: checkBoxMobility1.Checked = true;
					break;
				case 1: checkBoxMobility2.Checked = true;
					break;
				case 2: checkBoxMobility3.Checked = true;
					break;
				case 3: checkBoxMobility4.Checked = true;
					break;
				case 4: checkBoxMobility5.Checked = true;
					break;
				case 5: checkBoxMobility6.Checked = true;
					break;
				case 6: checkBoxMobility7.Checked = true;
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

		private void Mobility_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void checkBoxmobility1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility1.Checked)
			{
				checkBoxMobility2.Checked = false;
				checkBoxMobility3.Checked = false;
				checkBoxMobility4.Checked = false;
				checkBoxMobility5.Checked = false;
				checkBoxMobility6.Checked = false;
				checkBoxMobility7.Checked = false;
				checkBoxMobility8.Checked = false;
				mobility = 0;
			}
		}

		public static int mobility;

		private void checkBoxMobility2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility2.Checked)
			{
				checkBoxMobility1.Checked = false;
				checkBoxMobility3.Checked = false;
				checkBoxMobility4.Checked = false;
				checkBoxMobility5.Checked = false;
				checkBoxMobility6.Checked = false;
				checkBoxMobility7.Checked = false;
				checkBoxMobility8.Checked = false;
				mobility = 1;
			}
		}

		private void checkBoxMobility3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility3.Checked)
			{
				checkBoxMobility1.Checked = false;
				checkBoxMobility2.Checked = false;
				checkBoxMobility4.Checked = false;
				checkBoxMobility5.Checked = false;
				checkBoxMobility6.Checked = false;
				checkBoxMobility7.Checked = false;
				checkBoxMobility8.Checked = false;
				mobility = 2;
			}
		}

		private void checkBoxMobility4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility4.Checked)
			{
				checkBoxMobility1.Checked = false;
				checkBoxMobility2.Checked = false;
				checkBoxMobility3.Checked = false;
				checkBoxMobility5.Checked = false;
				checkBoxMobility6.Checked = false;
				checkBoxMobility7.Checked = false;
				checkBoxMobility8.Checked = false;
				mobility = 3;
			}
		}

		private void checkBoxMobility5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility5.Checked)
			{
				checkBoxMobility1.Checked = false;
				checkBoxMobility2.Checked = false;
				checkBoxMobility3.Checked = false;
				checkBoxMobility4.Checked = false;
				checkBoxMobility6.Checked = false;
				checkBoxMobility7.Checked = false;
				checkBoxMobility8.Checked = false;
				mobility = 4;
			}
		}

		private void checkBoxMobility6_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility6.Checked)
			{
				checkBoxMobility1.Checked = false;
				checkBoxMobility2.Checked = false;
				checkBoxMobility3.Checked = false;
				checkBoxMobility4.Checked = false;
				checkBoxMobility5.Checked = false;
				checkBoxMobility7.Checked = false;
				checkBoxMobility8.Checked = false;
				mobility = 5;
			}
		}

		private void checkBoxMobility7_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility7.Checked)
			{
				checkBoxMobility1.Checked = false;
				checkBoxMobility2.Checked = false;
				checkBoxMobility3.Checked = false;
				checkBoxMobility4.Checked = false;
				checkBoxMobility5.Checked = false;
				checkBoxMobility6.Checked = false;
				checkBoxMobility8.Checked = false;
				mobility = 6;
			}
		}

		private void checkBoxMobility8_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMobility8.Checked)
			{
				checkBoxMobility1.Checked = false;
				checkBoxMobility2.Checked = false;
				checkBoxMobility3.Checked = false;
				checkBoxMobility4.Checked = false;
				checkBoxMobility5.Checked = false;
				checkBoxMobility6.Checked = false;
				checkBoxMobility7.Checked = false;
				mobility = 7;
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

	}
}
