using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class EmotionalBehavioural : Form
	{
		public EmotionalBehavioural()
		{
			Location = new Point(GlobalVar.MainFormLocxationX + 120, GlobalVar.MainFormLocxationY + 30);
			InitializeComponent();
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

		private void DomesticActivities_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		public static int Continue;

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Continue = 0;
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Continue = 1;
			Close();
		}

	}
}
