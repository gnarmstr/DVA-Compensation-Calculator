using System;
using System.Diagnostics;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;

namespace DVA_Compensation_Calculator
{
	public partial class DVALinks : Form
	{
		public DVALinks()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X, ActiveForm.Location.Y);
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
			DvaLinks();
		}

		private void DvaLinks()
		{
			var linkAll = new LinkLabel.Link();
			linkAll.LinkData = @"http://factsheets.dva.gov.au/plain-facts-htm.htm";
			linkLabelAllSheets.Links.Add(linkAll);
			var link = new LinkLabel.Link();
			link.LinkData = @"http://www.comlaw.gov.au/Details/F2013C00479/Download";
			linkLabel.Links.Add(link);
			var link1 = new LinkLabel.Link();
			link1.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC01%20Overview.pdf";
			linkLabel1.Links.Add(link1);
			var link2 = new LinkLabel.Link();
			link2.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC02%20Compensation%20coverage%20for%20members%20and%20former%20members%20of%20the%20australian%20defence%20force.pdf";
			linkLabel2.Links.Add(link2);
			var link3 = new LinkLabel.Link();
			link3.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC03%20Types%20of%20MRCA%20service.pdf";
			linkLabel3.Links.Add(link3);
			var link4 = new LinkLabel.Link();
			link4.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC04%20Compensation%20Payment%20Rates.pdf";
			linkLabel4.Links.Add(link4);
			var link5 = new LinkLabel.Link();
			link5.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC05%20Rehabilitation.pdf";
			linkLabel5.Links.Add(link5);
			var link7 = new LinkLabel.Link();
			link7.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC07%20Permanent%20Impairment%20Compensation%20Payments.htm";
			linkLabel7.Links.Add(link7);
			var link8 = new LinkLabel.Link();
			link8.LinkData = @"http://factsheets.dva.gov.au/documents/MRC08%20Incapacity%20Payments.pdf";
			linkLabel8.Links.Add(link8);
			var link9 = new LinkLabel.Link();
			link9.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC09%20Special%20Rate%20DP%20Safety%20Net%20Payment.htm";
			linkLabel9.Links.Add(link9);
			var link10 = new LinkLabel.Link();
			link10.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC10%20MVCS.pdf";
			linkLabel10.Links.Add(link10);
			var link14 = new LinkLabel.Link();
			link14.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC14%20Partners.htm";
			linkLabel14.Links.Add(link14);
			var link15 = new LinkLabel.Link();
			link15.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC15%20Eligible%20Young%20Persons.htm";
			linkLabel15.Links.Add(link15);
			var link20 = new LinkLabel.Link();
			link20.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC20%20Permanent%20Impairment%20Payment%20Choices.htm";
			linkLabel20.Links.Add(link20);
			var link25 = new LinkLabel.Link();
			link25.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC25%20How%20to%20lodge%20a%20claim.htm";
			linkLabel25.Links.Add(link25);
			var link27 = new LinkLabel.Link();
			link27.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC27%20Recon%20and%20Review.htm";
			linkLabel27.Links.Add(link27);
			var link29 = new LinkLabel.Link();
			link29.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC29%20Actuary%20Tables.htm";
			linkLabel29.Links.Add(link29);
			var link33 = new LinkLabel.Link();
			link33.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC33%20%20Common%20Law%20injuries%20and%20diseases.htm";
			linkLabel33.Links.Add(link33);
			var link34 = new LinkLabel.Link();
			link34.LinkData = @"http://factsheets.dva.gov.au/factsheets/documents/MRC34%20Needs%20Assessment.htm";
			linkLabel34.Links.Add(link34);
			var link6 = new LinkLabel.Link();
			link6.LinkData = @"http://dva.gov.au/dvaforms";
			linkLabel6.Links.Add(link6);
		}

		private void linkLabelAllSheets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);

		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabelGARP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel25_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel33_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel34_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData as string);
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pictureBoxOK_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
