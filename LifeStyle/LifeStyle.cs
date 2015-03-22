using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public sealed partial class LifeStyle : Form
	{
		public LifeStyle()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 170, ActiveForm.Location.Y + 100);
			InitializeComponent();
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			BackgroundImage = Resources.MainBackground_Green_Form;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;
			buttonPersonalRelationships.BackgroundImage = Resources.Button_Green;
			buttonDomesticActivities.BackgroundImage = Resources.Button_Green;
			buttonEmploymentActivities.BackgroundImage = Resources.Button_Green;
			buttonMobility.BackgroundImage = Resources.Button_Green;
			buttonRecreationalActivities.BackgroundImage = Resources.Button_Green;
			
		}

		private void DomesticActivities_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			textBoxEmploymentActivities.Text = GlobalVar.EmploymentActivities;
			textBoxMobility.Text = GlobalVar.Mobility;
			textBoxPersonalRelationships.Text = GlobalVar.personalRelationships;
			textBoxRecreationalActivities.Text = GlobalVar.RecreationalActivities;
			textBoxDomesticActivities.Text = GlobalVar.DomesticActivities;
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

		private void finalLifeStylePoint()
		{
			GlobalVar.FinalLifeStylePoint = (Math.Round(((Convert.ToDecimal(textBoxPersonalRelationships.Text) + Convert.ToDecimal(textBoxMobility.Text) + Convert.ToDecimal(textBoxRecreationalActivities.Text) + (Math.Max(Convert.ToDecimal(textBoxDomesticActivities.Text), Convert.ToDecimal(textBoxEmploymentActivities.Text)))) / 4), 0)).ToString();
		}

		private void buttonPersonalRelationships_Click(object sender, EventArgs e)
		{
			Hide();
			PersonalRelationships.personalRelationship = Convert.ToInt16(GlobalVar.personalRelationships);
			var personalRelationships = new PersonalRelationships();
			personalRelationships.ShowDialog();
			Show();
			textBoxPersonalRelationships.Text = PersonalRelationships.personalRelationship.ToString();  //No age adjustment
			GlobalVar.personalRelationships = textBoxPersonalRelationships.Text;
		}

		private void buttonMobility_Click(object sender, EventArgs e)
		{
			Hide();
			Mobility.mobility = Convert.ToInt16(GlobalVar.Mobility);
			var mobility = new Mobility();
			mobility.ShowDialog();
			Show();
			textBoxMobility.Text = Mobility.mobility.ToString();
			GlobalVar.Mobility = textBoxMobility.Text;
		}

		private void buttonRecreationalActivities_Click(object sender, EventArgs e)
		{
			Hide();
			RecreationalActivities.recreationalActivities = Convert.ToInt16(GlobalVar.RecreationalActivities);
			var recreationalActivities = new RecreationalActivities();
			recreationalActivities.ShowDialog();
			Show();
			textBoxRecreationalActivities.Text = RecreationalActivities.recreationalActivities.ToString();  //No age adjustment
			GlobalVar.RecreationalActivities = textBoxRecreationalActivities.Text;
		}

		private void buttonDomesticActivities_Click(object sender, EventArgs e)
		{
			Hide();
			DomesticActivities.domesticActivities = Convert.ToInt16(GlobalVar.DomesticActivities);
			var domesticActivities = new DomesticActivities();
			domesticActivities.ShowDialog();
			Show();
			textBoxDomesticActivities.Text = DomesticActivities.domesticActivities.ToString();  //No age adjustment
			GlobalVar.DomesticActivities = textBoxDomesticActivities.Text;
		}

		private void buttonEmploymentActivities_Click(object sender, EventArgs e)
		{
			Hide();
			EmploymentActivities.employmentActivities = Convert.ToInt16(GlobalVar.EmploymentActivities);
			var employmentActivities = new EmploymentActivities();
			employmentActivities.ShowDialog();
			Show();
			textBoxEmploymentActivities.Text = EmploymentActivities.employmentActivities.ToString();  //No age adjustment
			GlobalVar.EmploymentActivities = textBoxEmploymentActivities.Text;
		}
		
		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			finalLifeStylePoint();
			Close();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
