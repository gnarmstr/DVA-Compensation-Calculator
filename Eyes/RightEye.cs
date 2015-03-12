using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class RightEye : Form
	{
		public RightEye()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 145, ActiveForm.Location.Y + 30);
			InitializeComponent();
			MinimumSize = new Size(440, 700);
			MaximumSize = new Size(440, 700);
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
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

		private void Eyes_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			buttonRightOtherOcular.BackgroundImage = Resources.Button_Green;
			buttonRightVisualFOL.BackgroundImage = Resources.Button_Green;
			textBoxRightMonocular.Text = GlobalVar.RightMonocular;
			textBoxRightVisualFOL.Text = GlobalVar.RightVisualFOL;
			textBoxRightMiscVisual.Text = GlobalVar.RightMiscVisual;
			textBoxRightOtherOcular.Text = GlobalVar.RightOtherOcular;

		}

		#region Rights Eye

		private void comboBoxRightMonocular_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBoxRightMonocular.Text = (comboBoxRightMonocular.SelectedIndex * 10).ToString();
			GlobalVar.RightMonocular = textBoxRightMonocular.Text;
		}

		private void buttonRightVisualFOL_Click(object sender, EventArgs e)
		{
			Hide();
			GlobalVar.Selection = "RightEye";
			var visualFOL = new VisualFOL();
			visualFOL.ShowDialog();
			Show();
			textBoxRightVisualFOL.Text = VisualFOL.RightEye.ToString();  //Not age adjustment
			GlobalVar.RightVisualFOL = textBoxRightVisualFOL.Text;
		}

		private void comboBoxRightMiscVisual_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBoxRightMiscVisual.SelectedIndex)
			{
				case 0: textBoxRightMiscVisual.Text = "0";
					break;
				case 1: textBoxRightMiscVisual.Text = "0";
					break;
				case 2: textBoxRightMiscVisual.Text = "0";
					break;
				case 3: textBoxRightMiscVisual.Text = "2";
					break;
				case 4: textBoxRightMiscVisual.Text = "2";
					break;
				case 5: textBoxRightMiscVisual.Text = "5";
					break;
				case 6: textBoxRightMiscVisual.Text = "5";
					break;
				case 7: textBoxRightMiscVisual.Text = "5";
					break;
				case 8: textBoxRightMiscVisual.Text = "10";
					break;
				case 9: textBoxRightMiscVisual.Text = "5";
					break;
				case 10: textBoxRightMiscVisual.Text = "5";
					break;
				case 11: textBoxRightMiscVisual.Text = "5";
					break;
				case 12: textBoxRightMiscVisual.Text = "10";
					break;
				case 13: textBoxRightMiscVisual.Text = "10";
					break;
				case 14: textBoxRightMiscVisual.Text = "10";
					break;
				case 15: textBoxRightMiscVisual.Text = "10";
					break;
				case 16: textBoxRightMiscVisual.Text = "15";
					break;
				case 17: textBoxRightMiscVisual.Text = "15";
					break;
				case 18: textBoxRightMiscVisual.Text = "15";
					break;
				case 19: textBoxRightMiscVisual.Text = "25";
					break;
				case 20: textBoxRightMiscVisual.Text = "10";
					break;
				case 21: textBoxRightMiscVisual.Text = "10";
					break;
				case 22: textBoxRightMiscVisual.Text = "25";
					break;
			}
			GlobalVar.RightMiscVisual = textBoxRightMiscVisual.Text;
		}

		private void buttonRightOtherOcular_Click(object sender, EventArgs e)
		{
			Hide();
			GlobalVar.Selection = "RightOcular";
			var ocular = new OcularImpairment();
			ocular.ShowDialog();
			Show();
			textBoxRightOtherOcular.Text = OcularImpairment.RightOcular.ToString();  //Not age adjustment
			GlobalVar.RightOtherOcular = textBoxRightOtherOcular.Text;
		}
	
		#endregion

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			GlobalVar.combinedRightEyePoints = Math.Round(Convert.ToInt16(textBoxRightVisualFOL.Text) + Convert.ToDecimal(textBoxRightMonocular.Text) * (1 - Convert.ToDecimal(textBoxRightVisualFOL.Text) / 100));
			GlobalVar.combinedRightEyePoints = Math.Round(GlobalVar.combinedRightEyePoints + Convert.ToInt16(textBoxRightMiscVisual.Text) * (1 - GlobalVar.combinedRightEyePoints / 100));
			GlobalVar.combinedRightEyePoints = Math.Max(GlobalVar.combinedRightEyePoints, Convert.ToInt16(textBoxRightOtherOcular.Text));
			GlobalVar.combinedRightEyePoints = Math.Round(GlobalVar.combinedRightEyePoints / 5) * 5; //Round to nearest 5
			
			MainForm.EyeConversion(out GlobalVar.RightEyeConversion, GlobalVar.combinedRightEyePoints);
			Close();
		}
	}
}
