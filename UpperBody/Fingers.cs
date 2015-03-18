using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class Fingers : Form
	{
		public Fingers()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 150, ActiveForm.Location.Y + 100);
			InitializeComponent();
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			if (GlobalVar.Selection == "LeftFingers")
			{
				switch (GlobalVar.LeftFingerPoints)
				{
					case 0: checkBoxOption1.Checked = true;
						GlobalVar.comboBoxLeftFingerPartially = 0;
						break;
					case 5: checkBoxOption2.Checked = true;
						break;
					case 10: checkBoxOption3.Checked = true;
						break;
					case 15: checkBoxOption4.Checked = true;
						break;
				}
				comboBoxFingersPartially.SelectedIndex = GlobalVar.comboBoxLeftFingerPartially;
			}
			else
			{
				switch (GlobalVar.RightFingerPoints)
				{
					case 0: checkBoxOption1.Checked = true;
						GlobalVar.comboBoxRightFingerPartially = 0;
						break;
					case 5: checkBoxOption2.Checked = true;
						break;
					case 10: checkBoxOption3.Checked = true;
						break;
					case 15: checkBoxOption4.Checked = true;
						break;
				}
				comboBoxFingersPartially.SelectedIndex = GlobalVar.comboBoxRightFingerPartially;
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

		private void DomesticActivities_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void checkBoxOption1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption1.Checked)
			{
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				Points = 0;
			}
		}

		public static int LeftFingers;

		public static int RightFingers;

		public static int Points;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption2.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				Points = 5;
			}
		}

		private void checkBoxOption3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption3.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption4.Checked = false;
				Points = 10;
			}
		}

		private void checkBoxOption4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption4.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				Points = 15;
			}
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			if (GlobalVar.Selection == "LeftFingers")
			{
				GlobalVar.comboBoxLeftFingerPartially = comboBoxFingersPartially.SelectedIndex;
				GlobalVar.LeftFingerPoints = Points;
				LeftFingers = Convert.ToInt16(GlobalVar.ExcelData[4][Points][GlobalVar.AgeAdjustRange]);
				GlobalVar.combinedLeftFingerPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][LeftFingers][comboBoxFingersPartially.SelectedIndex + 2]);
			}
			else
			{
				GlobalVar.comboBoxRightFingerPartially = comboBoxFingersPartially.SelectedIndex;
				GlobalVar.RightFingerPoints = Points;
				RightFingers = Convert.ToInt16(GlobalVar.ExcelData[4][Points][GlobalVar.AgeAdjustRange]);
				GlobalVar.combinedRightFingerPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][RightFingers][comboBoxFingersPartially.SelectedIndex + 2]);
			}
			Close();
		}

	}
}
