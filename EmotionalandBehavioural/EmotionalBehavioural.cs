﻿using System;
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
			Location = new Point(GlobalVar.MainFormLocxationX + 110, GlobalVar.MainFormLocxationY + 30);
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

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
