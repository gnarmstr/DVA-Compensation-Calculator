using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class Ears : Form
	{
		public Ears()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 10, ActiveForm.Location.Y - 25);
			InitializeComponent();
			MinimumSize = new Size(705, 840);
			MaximumSize = new Size(705, 840);
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			panel2.BackgroundImage = Resources.Background_Blue;
			panel3.BackgroundImage = Resources.Background_Blue;
			switch (GlobalVar.HearingLossPoints)
			{
				case 0: checkBoxOption1.Checked = true;
					GlobalVar.comboBoxHearingLossPartially = 0;
					break;
				case 2: checkBoxOption2.Checked = true;
					break;
				case 5: checkBoxOption3.Checked = true;
					break;
				case 10: checkBoxOption4.Checked = true;
					break;
			}
			comboBoxHearingLossPartially.SelectedIndex = GlobalVar.comboBoxHearingLossPartially;

			switch (GlobalVar.TinnitusPoints)
			{
				case 0: checkBoxTinnitusOption1.Checked = true;
					GlobalVar.comboBoxTinnitusPartially = 0;
					break;
				case 2: checkBoxTinnitusOption2.Checked = true;
					break;
				case 5: checkBoxTinnitusOption3.Checked = true;
					break;
				case 10: checkBoxTinnitusOption4.Checked = true;
					break;
				case 15: checkBoxTinnitusOption5.Checked = true;
					break;
			}
			comboBoxTinnitusPartially.SelectedIndex = GlobalVar.comboBoxTinnitusPartially;
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

#region Hearing Loss
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

		public static int ears;

		public static int Points;

		private void checkBoxOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxOption2.Checked)
			{
				checkBoxOption1.Checked = false;
				checkBoxOption3.Checked = false;
				checkBoxOption4.Checked = false;
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
				Points = 10;
			}
		}
#endregion

#region Tinnitus

		public static int tinnitus;

		public static int PointsTinnitus;

		private void checkBoxTinnitusOption1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption1.Checked)
			{
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 0;
			}
		}

		private void checkBoxTinnitusOption2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption2.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 2;
			}
		}

		private void checkBoxTinnitusOption3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption3.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 5;
			}
		}

		private void checkBoxTinnitusOption4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption4.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption5.Checked = false;
				PointsTinnitus = 10;
			}
		}

		private void checkBoxTinnitusOption5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTinnitusOption5.Checked)
			{
				checkBoxTinnitusOption1.Checked = false;
				checkBoxTinnitusOption2.Checked = false;
				checkBoxTinnitusOption3.Checked = false;
				checkBoxTinnitusOption4.Checked = false;
				PointsTinnitus = 15;
			}
		}

#endregion

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			GlobalVar.comboBoxHearingLossPartially = comboBoxHearingLossPartially.SelectedIndex;
			GlobalVar.HearingLossPoints = Points;
			ears = Points;
			GlobalVar.combinedHearingLossPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][ears][comboBoxHearingLossPartially.SelectedIndex + 2]);
			
			GlobalVar.comboBoxTinnitusPartially = comboBoxTinnitusPartially.SelectedIndex;
			GlobalVar.TinnitusPoints = PointsTinnitus;
			tinnitus = PointsTinnitus;
			GlobalVar.combinedTinnitusPoints = Convert.ToDecimal(GlobalVar.ExcelData[2][tinnitus][comboBoxTinnitusPartially.SelectedIndex + 2]);
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
