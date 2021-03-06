﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;

namespace DVA_Compensation_Calculator
{
	public partial class ImportantInformation : Form
	{
		public ImportantInformation()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 55, ActiveForm.Location.Y + 50);
			InitializeComponent();
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
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

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ImportantInformation_Load(object sender, EventArgs e)
		{
			pictureBoxOK.Image = Tools.GetIcon(Resources.Ok, 40);
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		
	}
}
