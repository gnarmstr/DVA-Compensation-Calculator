using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class PersonalRelationships : Form
	{
		public PersonalRelationships()
		{
			Location = new Point(GlobalVar.MainFormLocxationX + 30, GlobalVar.MainFormLocxationY + 30);
			InitializeComponent();
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			switch (Convert.ToInt16(GlobalVar.personalRelationships))
			{
				case 0: checkBoxPersonalRelations1.Checked = true;
					break;
				case 1: checkBoxPersonalRelations2.Checked = true;
					break;
				case 2: checkBoxPersonalRelations3.Checked = true;
					break;
				case 3: checkBoxPersonalRelations4.Checked = true;
					break;
				case 4: checkBoxPersonalRelations5.Checked = true;
					break;
				case 5: checkBoxPersonalRelations6.Checked = true;
					break;
				case 6: checkBoxPersonalRelations7.Checked = true;
					break;
				case 7: checkBoxPersonalRelations8.Checked = true;
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

		private void PersonalRelationships_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void checkBoxPersonalRelations1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations1.Checked)
			{
				checkBoxPersonalRelations2.Checked = false;
				checkBoxPersonalRelations3.Checked = false;
				checkBoxPersonalRelations4.Checked = false;
				checkBoxPersonalRelations5.Checked = false;
				checkBoxPersonalRelations6.Checked = false;
				checkBoxPersonalRelations7.Checked = false;
				checkBoxPersonalRelations8.Checked = false;
				personalRelationship = 0;
			}
		}

		private void checkBoxPersonalRelations2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations2.Checked)
			{
				checkBoxPersonalRelations1.Checked = false;
				checkBoxPersonalRelations3.Checked = false;
				checkBoxPersonalRelations4.Checked = false;
				checkBoxPersonalRelations5.Checked = false;
				checkBoxPersonalRelations6.Checked = false;
				checkBoxPersonalRelations7.Checked = false;
				checkBoxPersonalRelations8.Checked = false;
				personalRelationship = 1;
			}
		}

		private void checkBoxPersonalRelations3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations3.Checked)
			{
				checkBoxPersonalRelations1.Checked = false;
				checkBoxPersonalRelations2.Checked = false;
				checkBoxPersonalRelations4.Checked = false;
				checkBoxPersonalRelations5.Checked = false;
				checkBoxPersonalRelations6.Checked = false;
				checkBoxPersonalRelations7.Checked = false;
				checkBoxPersonalRelations8.Checked = false;
				personalRelationship = 2;
			}
		}

		private void checkBoxPersonalRelations4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations4.Checked)
			{
				checkBoxPersonalRelations1.Checked = false;
				checkBoxPersonalRelations2.Checked = false;
				checkBoxPersonalRelations3.Checked = false;
				checkBoxPersonalRelations5.Checked = false;
				checkBoxPersonalRelations6.Checked = false;
				checkBoxPersonalRelations7.Checked = false;
				checkBoxPersonalRelations8.Checked = false;
				personalRelationship = 3;
			}
		}

		private void checkBoxPersonalRelations5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations5.Checked)
			{
				checkBoxPersonalRelations1.Checked = false;
				checkBoxPersonalRelations2.Checked = false;
				checkBoxPersonalRelations3.Checked = false;
				checkBoxPersonalRelations4.Checked = false;
				checkBoxPersonalRelations6.Checked = false;
				checkBoxPersonalRelations7.Checked = false;
				checkBoxPersonalRelations8.Checked = false;
				personalRelationship = 4;
			}
		}

		private void checkBoxPersonalRelations6_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations6.Checked)
			{
				checkBoxPersonalRelations1.Checked = false;
				checkBoxPersonalRelations2.Checked = false;
				checkBoxPersonalRelations3.Checked = false;
				checkBoxPersonalRelations4.Checked = false;
				checkBoxPersonalRelations5.Checked = false;
				checkBoxPersonalRelations7.Checked = false;
				checkBoxPersonalRelations8.Checked = false;
				personalRelationship = 5;
			}
		}

		private void checkBoxPersonalRelations7_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations7.Checked)
			{
				checkBoxPersonalRelations1.Checked = false;
				checkBoxPersonalRelations2.Checked = false;
				checkBoxPersonalRelations3.Checked = false;
				checkBoxPersonalRelations4.Checked = false;
				checkBoxPersonalRelations5.Checked = false;
				checkBoxPersonalRelations6.Checked = false;
				checkBoxPersonalRelations8.Checked = false;
				personalRelationship = 6;
			}
		}

		private void checkBoxPersonalRelations8_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPersonalRelations8.Checked)
			{
				checkBoxPersonalRelations1.Checked = false;
				checkBoxPersonalRelations2.Checked = false;
				checkBoxPersonalRelations3.Checked = false;
				checkBoxPersonalRelations4.Checked = false;
				checkBoxPersonalRelations5.Checked = false;
				checkBoxPersonalRelations6.Checked = false;
				checkBoxPersonalRelations7.Checked = false;
				personalRelationship = 7;
			}
		}

		public static int personalRelationship;

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
