using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Common.Resources;
using Common.Resources.Properties;

namespace DVA_Compensation_Calculator
{
	public partial class Mobility : Form
	{
		public Mobility()
		{
			InitializeComponent();
		}

		private void Mobility_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void checkBoxmobility1_CheckedChanged(object sender, EventArgs e)
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

		public static int mobility;

		private void checkBoxMobility2_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxMobility3_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxMobility4_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxMobility5_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxMobility6_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxMobility7_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxMobility8_CheckedChanged(object sender, EventArgs e)
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

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			mobility = 0;
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
