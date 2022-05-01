using System;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using System.Drawing;
using System.IO;

namespace DVA_Compensation_Calculator
{
    public partial class FileForm : Form
	{
        private string tempPath;

		public FileForm()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + 180, ActiveForm.Location.Y);
			InitializeComponent();
			BackgroundImage = Resources.Button_Green;
			BackgroundImageLayout = ImageLayout.Stretch;
			panel1.BackgroundImage = Resources.Background_Blue;

            tempPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DVA Compensation Calculator");

            switch (GlobalVar.FileFormResult)
            {
                case "Load":
                    pictureBoxLoad.Visible = true;
                    pictureBoxNew.Visible = true;
                    break;
                case "Save":
                    label2.Visible = true;
                    textBox_Filename.Visible = true;
                    pictureBoxSave.Visible = true;
                    break;
            }
            
            listBoxFiles.Items.Clear();

            string[] fileEntries = Directory.GetFiles(tempPath);
            foreach (string fileName in fileEntries)
            {
                listBoxFiles.Items.Add(Path.GetFileNameWithoutExtension(fileName));
            }

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
            pictureBoxLoad.Image = Tools.GetIcon(Resources.Open, 40);
            pictureBoxNew.Image = Tools.GetIcon(Resources.New, 40);
            pictureBoxSave.Image = Tools.GetIcon(Resources.Save, 40);
            pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
		}

		private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            if (textBox_Filename.Text != "")
            {
                GlobalVar.documentPath = tempPath + "\\" + textBox_Filename.Text + ".xml";
            }
            else
            {
                GlobalVar.documentPath = tempPath + "\\" + listBoxFiles.SelectedItem.ToString() + ".xml";
            }

            GlobalVar.FileFormResult = "Save";
            Close();
        }

        private void pictureBoxLoad_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            GlobalVar.documentPath = tempPath + "\\" + listBoxFiles.SelectedItem.ToString() + ".xml";
            GlobalVar.FileFormResult = "Load";
            Close();
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            GlobalVar.FileFormResult = "Cancel";
            Close();
        }

        private void listBoxFiles_DoubleClick(object sender, EventArgs e)
        {
            switch (GlobalVar.FileFormResult)
            {
                case "Load":
                    pictureBoxLoad_Click(null, null);
                    break;
                case "Save":
                    pictureBoxSave_Click(null, null);
                    break;
            }
        }

        private void pictureBoxNew_Click(object sender, EventArgs e)
        {

            GlobalVar.documentPath = tempPath + "\\Settings.xml";
            GlobalVar.FileFormResult = "Load";
            Close();

        }
	}
}
