using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class LifeStyleRatingCheck : Form
	{
		public LifeStyleRatingCheck()
		{
			
			
			if (ActiveForm != null)
			{
				Location = new Point(ActiveForm.Location.X + 180, ActiveForm.Location.Y + 300);
			}
			else
			{
				Location = new Point(300, 50);
			}
			InitializeComponent();
			BackgroundImage = Resources.Button_Green;
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

		private void DomesticActivities_Load(object sender, EventArgs e)
		{
			pictureBoxYes.Image = Tools.GetIcon(Resources.Ok, 40);
			if (GlobalVar.WarningVisible)
			{
				checkBoxDisableWarning.Visible = true;
			}
			if (GlobalVar.DisableWarning)
			{
				Close();
			}
		}

		private void pictureBoxYes_Click(object sender, EventArgs e)
		{
			GlobalVar.WarningVisible = true;
			if (checkBoxDisableWarning.Checked)
			{
				GlobalVar.DisableWarning = true;
			}
			Close();
		}
	}
}
