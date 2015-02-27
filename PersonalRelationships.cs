using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;

namespace DVA_Compensation_Calculator
{
	public partial class PersonalRelationships : Form
	{
		public PersonalRelationships()
		{
			InitializeComponent();
		}

		private void PersonalRelationships_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void checkBoxPersonalRelations1_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxPersonalRelations2_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxPersonalRelations3_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxPersonalRelations4_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxPersonalRelations5_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxPersonalRelations6_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxPersonalRelations7_CheckedChanged(object sender, EventArgs e)
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

		private void checkBoxPersonalRelations8_CheckedChanged(object sender, EventArgs e)
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

		public static int personalRelationship;

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			personalRelationship = 0;
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
