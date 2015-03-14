using System;
using System.Drawing;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;

namespace DVA_Compensation_Calculator
{
	public partial class Instructions : Form
	{
		public Instructions()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 55, ActiveForm.Location.Y + 50);
			InitializeComponent();
			MinimumSize = new Size(613, 655);
			MaximumSize = new Size(613, 655);
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

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ImportantInformation_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
		}

		
	}
}
