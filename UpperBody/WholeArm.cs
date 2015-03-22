using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class WholeArm : Form
	{
		public WholeArm()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 30, ActiveForm.Location.Y);
			InitializeComponent();
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			MinimumSize = new Size(670, 710);
			MaximumSize = new Size(670, 710);
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			if (GlobalVar.Selection == "LeftArm")
			{
				switch (GlobalVar.WholeLeftArmPoints)
				{
					case 0: checkBoxOption1.Checked = true;
						GlobalVar.comboBoxWholeLeftArmPartially = 0;
						break;
					case 2: checkBoxOption2.Checked = true;
						break;
					case 5: checkBoxOption3.Checked = true;
						break;
					case 10: checkBoxOption4.Checked = true;
						break;
					case 15: checkBoxOption5.Checked = true;
						break;
					case 20: checkBoxOption6.Checked = true;
						break;
					case 30: checkBoxOption7.Checked = true;
						break;
					case 40: checkBoxOption8.Checked = true;
						break;
					case 50: checkBoxOption9.Checked = true;
						break;
				}
				comboBoxWholeArmPartially.SelectedIndex = GlobalVar.comboBoxWholeLeftArmPartially;
			}
			else
			{
				switch (GlobalVar.WholeRightArmPoints)
				{
					case 0: checkBoxOption1.Checked = true;
						GlobalVar.comboBoxWholeRightArmPartially = 0;
						break;
					case 2: checkBoxOption2.Checked = true;
						break;
					case 5: checkBoxOption3.Checked = true;
						break;
					case 10: checkBoxOption4.Checked = true;
						break;
					case 15: checkBoxOption5.Checked = true;
						break;
					case 20: checkBoxOption6.Checked = true;
						break;
					case 30: checkBoxOption7.Checked = true;
						break;
					case 40: checkBoxOption8.Checked = true;
						break;
					case 50: checkBoxOption9.Checked = true;
						break;
				}
				comboBoxWholeArmPartially.SelectedIndex = GlobalVar.comboBoxWholeRightArmPartially;
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

		private void buttonMainTitle_MouseDown(object sender, MouseEventArgs e)
		{
			FormDrag.formDrag_MouseDown(e);
		}

		private void buttonMainTitle_MouseMove(object sender, MouseEventArgs e)
		{
			if (GlobalVar.dragging)
			{
				Left = e.X + Left - GlobalVar.offsetX;
				Top = e.Y + Top - GlobalVar.offsetY;
			}
		}

		private void buttonMainTitle_MouseUp(object sender, MouseEventArgs e)
		{
			FormDrag.formDrag_MouseUp(e);
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
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				checkBoxOption9.Checked = false;
				Points = 0;
			}
		}

		public static int wholeLeftArm;

		public static int wholeRightArm;

		public static int Points;

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
				checkBoxOption9.Checked = false;
				Points = 2;
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
				checkBoxOption9.Checked = false;
				Points = 5;
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
				checkBoxOption9.Checked = false;
				Points = 10;
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
				checkBoxOption9.Checked = false;
				Points = 15;
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
				checkBoxOption9.Checked = false;
				Points = 20;
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
				checkBoxOption9.Checked = false;
				Points = 30;
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
				checkBoxOption9.Checked = false;
				Points = 40;
			}
		}

		private void checkBoxOption9_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption9.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				Points = 50;
			}
		}

		private void checkBoxOption10_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption10.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption2.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
				checkBoxOption5.Checked = false;
				checkBoxOption6.Checked = false;
				checkBoxOption7.Checked = false;
				checkBoxOption8.Checked = false;
				checkBoxOption9.Checked = false;
				Points = 60;
			}
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			if (GlobalVar.Selection == "LeftArm")
			{
				GlobalVar.comboBoxWholeLeftArmPartially = comboBoxWholeArmPartially.SelectedIndex;
				GlobalVar.WholeLeftArmPoints = Points;
				wholeLeftArm = Convert.ToInt16(GlobalVar.ExcelData[4][Points][GlobalVar.AgeAdjustRange]);
				GlobalVar.combinedWholeLeftArmPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][wholeLeftArm][comboBoxWholeArmPartially.SelectedIndex + 2]);
			}
			else
			{
				GlobalVar.comboBoxWholeRightArmPartially = comboBoxWholeArmPartially.SelectedIndex;
				GlobalVar.WholeRightArmPoints = Points;
				wholeRightArm = Convert.ToInt16(GlobalVar.ExcelData[4][Points][GlobalVar.AgeAdjustRange]);
				GlobalVar.combinedWholeRightArmPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][wholeRightArm][comboBoxWholeArmPartially.SelectedIndex + 2]);
			}
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
