using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVA_Compensation_Calculator
{
	public partial class PrintSummary : Form
	{
	//	private Button printButton = new Button();
		private PrintDocument printDocument1 = new PrintDocument();

		public PrintSummary()
		{
			InitializeComponent();
			printButton.Text = "Print Summary";
			printButton.Click += printButton_Click;
			printDocument1.PrintPage += printDocument1_PrintPage;
		}

		private void printButton_Click(object sender, EventArgs e)
		{
			CaptureScreen();
			printDocument1.Print();
		}

		private Bitmap memoryImage;

		private void CaptureScreen()
		{
			Graphics myGraphics = CreateGraphics();
			Size s = Size;
			memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
			Graphics memoryGraphics = Graphics.FromImage(memoryImage);
			memoryGraphics.CopyFromScreen(Location.X, Location.Y, 0, 0, s);
		}

		private void printDocument1_PrintPage(Object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(memoryImage, 0, 0);
		}
	}
}
