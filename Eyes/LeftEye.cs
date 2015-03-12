using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class LeftEye : Form
	{
		public LeftEye()
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
			buttonLeftOtherOcular.BackgroundImage = Resources.Button_Green;
			buttonLeftVisualFOL.BackgroundImage = Resources.Button_Green;
			textBoxLeftMonocular.Text = GlobalVar.LeftMonocular;
			textBoxLeftVisualFOL.Text = GlobalVar.LeftVisualFOL;
			textBoxLeftMiscVisual.Text = GlobalVar.LeftMiscVisual;
			textBoxLeftOtherOcular.Text = GlobalVar.LeftOtherOcular;
		}

		#region Left Eyes

		private void comboBoxLeftMonocular_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBoxLeftMonocular.Text = (comboBoxLeftMonocular.SelectedIndex * 10).ToString();
			GlobalVar.LeftMonocular = textBoxLeftMonocular.Text;
		}

		private void buttonLeftVisualFOL_Click(object sender, EventArgs e)
		{
			Hide();
			GlobalVar.Selection = "LeftEye";
			var visualFOL = new VisualFOL();
			visualFOL.ShowDialog();
			Show();
			textBoxLeftVisualFOL.Text = VisualFOL.LeftEye.ToString();  //Not age adjustment
			GlobalVar.LeftVisualFOL = textBoxLeftVisualFOL.Text;
		}

		private void comboBoxLeftMiscVisual_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBoxLeftMiscVisual.SelectedIndex)
			{
				case 0: textBoxLeftMiscVisual.Text = "0";
					break;
				case 1: textBoxLeftMiscVisual.Text = "0";
					break;
				case 2: textBoxLeftMiscVisual.Text = "0";
					break;
				case 3: textBoxLeftMiscVisual.Text = "2";
					break;
				case 4: textBoxLeftMiscVisual.Text = "2";
					break;
				case 5: textBoxLeftMiscVisual.Text = "5";
					break;
				case 6: textBoxLeftMiscVisual.Text = "5";
					break;
				case 7: textBoxLeftMiscVisual.Text = "5";
					break;
				case 8: textBoxLeftMiscVisual.Text = "10";
					break;
				case 9: textBoxLeftMiscVisual.Text = "5";
					break;
				case 10: textBoxLeftMiscVisual.Text = "5";
					break;
				case 11: textBoxLeftMiscVisual.Text = "5";
					break;
				case 12: textBoxLeftMiscVisual.Text = "10";
					break;
				case 13: textBoxLeftMiscVisual.Text = "10";
					break;
				case 14: textBoxLeftMiscVisual.Text = "10";
					break;
				case 15: textBoxLeftMiscVisual.Text = "10";
					break;
				case 16: textBoxLeftMiscVisual.Text = "15";
					break;
				case 17: textBoxLeftMiscVisual.Text = "15";
					break;
				case 18: textBoxLeftMiscVisual.Text = "15";
					break;
				case 19: textBoxLeftMiscVisual.Text = "25";
					break;
				case 20: textBoxLeftMiscVisual.Text = "10";
					break;
				case 21: textBoxLeftMiscVisual.Text = "10";
					break;
				case 22: textBoxLeftMiscVisual.Text = "25";
					break;
			}
			GlobalVar.LeftMiscVisual = textBoxLeftMiscVisual.Text;
		}

		private void buttonLeftOtherOcular_Click(object sender, EventArgs e)
		{
			Hide();
			GlobalVar.Selection = "LeftOcular";
			var ocular = new OcularImpairment();
			ocular.ShowDialog();
			Show();
			textBoxLeftOtherOcular.Text = OcularImpairment.LeftOcular.ToString();  //Not age adjustment
			GlobalVar.LeftOtherOcular = textBoxLeftOtherOcular.Text;
		}

		#endregion

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			GlobalVar.combinedLeftEyePoints = Math.Round(Convert.ToInt16(textBoxLeftVisualFOL.Text) + Convert.ToDecimal(textBoxLeftMonocular.Text) * (1 - Convert.ToDecimal(textBoxLeftVisualFOL.Text) / 100));
			GlobalVar.combinedLeftEyePoints = Math.Round(GlobalVar.combinedLeftEyePoints + Convert.ToInt16(textBoxLeftMiscVisual.Text) * (1 - GlobalVar.combinedLeftEyePoints / 100));
			GlobalVar.combinedLeftEyePoints = Math.Max(GlobalVar.combinedLeftEyePoints, Convert.ToInt16(textBoxLeftOtherOcular.Text));
			GlobalVar.combinedLeftEyePoints = Math.Round(GlobalVar.combinedLeftEyePoints / 5) * 5; //Round to nearest 5
			
			MainForm.EyeConversion(out GlobalVar.LeftEyeConversion, GlobalVar.combinedLeftEyePoints);
			Close();
		}

	}
}
