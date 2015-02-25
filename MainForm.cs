using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DVA_Compensation_Calculator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			Settings();
			AgeAdjust();
			LoadData();
			importExcel();
		}

		#region Settings
		private void Settings()
		{
			SaveAll.Image = Tools.ResizeImage(Resources.Save, 130, 30);
			//Add Days for Date of Birth
			
			var i = 100;
			do
			{
				comboBoxAge.Items.Add(i);
				i--;
			} while (i > 17);
		}
		#endregion

		#region Setup Age adjustment array

		private void AgeAdjust()
		{
			GlobalVar.ageAdjust = new MultiDimDictList<int, int>();
			var i = 0;
			do
			{
				if (i != 3 & i != 9 & i != 15 & i != 21 & i != 27 & i != 33 & i != 39 & i != 45 & i != 51 & i != 57 & i != 63 & i != 69 & i != 75 & i != 81)
				{
					GlobalVar.ageAdjust.Add(0, i);
				}
				i++;
			} while (GlobalVar.ageAdjust[0].Count < 71);

			i = 0;
			do
			{
				if (i != 5 & i != 16 & i != 27 & i != 38 & i != 60 & i != 49 & i != 71)
				{
					GlobalVar.ageAdjust.Add(1, i);
				}
				i++;
			} while (GlobalVar.ageAdjust[1].Count < 71);

			i = 0;
			do
			{
				GlobalVar.ageAdjust.Add(2, i);
				i++;
			} while (GlobalVar.ageAdjust[2].Count < 71);

			i = 0;
			do
			{
				if (i == 5 || i == 14 || i == 23 || i == 32 || i == 41 || i == 50 || i == 59)
				{
					GlobalVar.ageAdjust.Add(3, i);
				}
				GlobalVar.ageAdjust.Add(3, i);
				i++;
			} while (GlobalVar.ageAdjust[3].Count < 71);

			i = 0;
			do
			{
				if (i == 2 || i == 6 || i == 10 || i == 14 || i == 18 || i == 22 || i == 26 || i == 30 || i == 34 || i == 38 || i == 42 || i == 46 || i == 50 || i == 54)
				{
					GlobalVar.ageAdjust.Add(4, i);
				}
				GlobalVar.ageAdjust.Add(4, i);
				i++;
			} while (GlobalVar.ageAdjust[4].Count < 71);

			i = 0;
			do
			{
				if (i == 1 || i == 4 || i == 6 || i == 8 || i == 11 || i == 13 || i == 15 || i == 18 || i == 20 || i == 22 || i == 25 || i == 27 || i == 29 || i == 32 || i == 34 || i == 36 || i == 39 || i == 41 || i == 43 || i == 46 || i == 48)
				{
					GlobalVar.ageAdjust.Add(5, i);
				}
				GlobalVar.ageAdjust.Add(5, i);
				i++;
			} while (GlobalVar.ageAdjust[5].Count < 71);

			i = 0;
			do
			{
				if (i == 1 || i == 2 || i == 4 || i == 5 || i == 7 || i == 8 || i == 10 || i == 11 || i == 13 || i == 14 || i == 16 || i == 17 || i == 19 || i == 20 || i == 22 || i == 23 || i == 25 || i == 26 || i == 28 || i == 29 || i == 31 || i == 32 || i == 34 || i == 35 || i == 37 || i == 38 || i == 40 || i == 41)
				{
					GlobalVar.ageAdjust.Add(6, i);
				}
				GlobalVar.ageAdjust.Add(6, i);
				i++;
			} while (GlobalVar.ageAdjust[6].Count < 71);

		}
		#endregion

		#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();
			comboBoxAge.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxAge", "50");
			textBoxWeeklyPayment.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxWeeklyPayment", "364.60");

			comboBoxElbow.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxElbow", "- No abnormality. X-ray changes only with normal range of movement.");
			comboBoxWrist.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxWrist", "- No abnormality. X-ray changes only with normal range of movement.");
			comboBoxShoulder.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxShoulder", "- No abnormality. X-ray changes only with normal range of movement.");
			comboBoxFingers.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxFingers", "- No abnormality. X-ray changes only with normal range of movement.");
			
		}
		#endregion

		#region Upperbody

		private void comboBoxElbow_SelectedIndexChanged(object sender, EventArgs e)
		{
			int elbowRawPoints = 0;
			switch (comboBoxElbow.SelectedIndex)
			{
				case (0):
					elbowRawPoints = 0;
				break;
				case (1):
					elbowRawPoints = 10;
				break;
				case (2):
					elbowRawPoints = 20;
				break;
				case (3):
					elbowRawPoints = 30;
				break;
				case (4):
					elbowRawPoints = 40;
				break;
				case (5):
					elbowRawPoints = 50;
				break;
			}
			var ageAdustResult = GlobalVar.ageAdjust[GlobalVar.ageAdjustRange][elbowRawPoints];
			textBoxElbow.Text = ageAdustResult.ToString();
		}

		private void comboBoxShoulder_SelectedIndexChanged(object sender, EventArgs e)
		{
			int shoulderRawPoints = 0;
			switch (comboBoxShoulder.SelectedIndex)
			{
				case (0):
					shoulderRawPoints = 0;
					break;
				case (1):
					shoulderRawPoints = 10;
					break;
				case (2):
					shoulderRawPoints = 20;
					break;
				case (3):
					shoulderRawPoints = 30;
					break;
				case (4):
					shoulderRawPoints = 40;
					break;
				case (5):
					shoulderRawPoints = 50;
					break;
			}
			var ageAdustResult = GlobalVar.ageAdjust[GlobalVar.ageAdjustRange][shoulderRawPoints];
			textBoxShoulder.Text = ageAdustResult.ToString();
		}

		private void comboBoxWrist_SelectedIndexChanged(object sender, EventArgs e)
		{
			int wristRawPoints = 0;
			switch (comboBoxWrist.SelectedIndex)
			{
				case (0):
					wristRawPoints = 0;
					break;
				case (1):
					wristRawPoints = 5;
					break;
				case (2):
					wristRawPoints = 10;
					break;
				case (3):
					wristRawPoints = 15;
					break;
				case (4):
					wristRawPoints = 20;
					break;
				case (5):
					wristRawPoints = 30;
					break;
			}
			var ageAdustResult = GlobalVar.ageAdjust[GlobalVar.ageAdjustRange][wristRawPoints];
			textBoxWrist.Text = ageAdustResult.ToString();
		}

		private void comboBoxFingers_SelectedIndexChanged(object sender, EventArgs e)
		{
			int fingersRawPoints = 0;
			switch (comboBoxFingers.SelectedIndex)
			{
				case (0):
					fingersRawPoints = 0;
					break;
				case (1):
					fingersRawPoints = 5;
					break;
				case (2):
					fingersRawPoints = 10;
					break;
				case (3):
					fingersRawPoints = 15;
					break;
			}
			var ageAdustResult = GlobalVar.ageAdjust[GlobalVar.ageAdjustRange][fingersRawPoints];
			textBoxFingers.Text = ageAdustResult.ToString();
		}

		public class MultiDimDictList<K, T> : Dictionary<K, List<T>>
		{
			public void Add(K key, T addObject)
			{
				if (!ContainsKey(key)) Add(key, new List<T>());
				base[key].Add(addObject);
			}
		}

		private void comboBoxAge_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (Convert.ToInt16(comboBoxAge.SelectedItem) <= 36)
			{
				GlobalVar.ageAdjustRange = 0;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 36 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 45)
			{
				GlobalVar.ageAdjustRange = 1;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 46 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 55)
			{
				GlobalVar.ageAdjustRange = 2;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 56 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 65)
			{
				GlobalVar.ageAdjustRange = 3;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 66 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 75)
			{
				GlobalVar.ageAdjustRange = 4;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 76 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 85)
			{
				GlobalVar.ageAdjustRange = 5;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) > 85)
			{
				GlobalVar.ageAdjustRange = 6;
			}
			comboBoxShoulder_SelectedIndexChanged(null, null);
			comboBoxElbow_SelectedIndexChanged(null, null);
			comboBoxWrist_SelectedIndexChanged(null, null);
			comboBoxFingers_SelectedIndexChanged(null, null);
		}
		#endregion

		#region Close Application
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
			var save = MessageBox.Show(@"Would you like to save all Settings on exit?", @"Save", MessageBoxButtons.YesNoCancel);
			switch (save)
			{
				case DialogResult.Yes:
					Save();
					break;
				case DialogResult.No:
					break;
				case DialogResult.Cancel:
					e.Cancel = true;
					break;
			}
		}
		#endregion

		#region Save Data
		private void Save()
		{
			var profile = new XmlProfileSettings();
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxAge", comboBoxAge.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "valueWeeklyPayment", textBoxWeeklyPayment.Text);

			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxElbow", comboBoxElbow.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxWrist", comboBoxWrist.Text); 
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxShoulder", comboBoxShoulder.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "comboBoxFingers", comboBoxFingers.Text);
			
		}

		private void SaveAll_Click(object sender, EventArgs e)
		{
			Save();
		}
		#endregion

		private void importExcel()
		{
			SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
			ExcelFile ef = ExcelFile.Load("CombinedValueChart.xls");
			DataTable dataTable = new DataTable();
			// Depending on the format of the input file, you need to change this:

			dataTable.Columns.Add("FirstColumn", typeof(string));
			dataTable.Columns.Add("SecondColumn", typeof(string));
			dataTable.Columns.Add("ThirdColumn", typeof(string));
			// Select the first worksheet from the file.

			ExcelWorksheet ws = ef.Worksheets[0];
			ExtractToDataTableOptions options = new ExtractToDataTableOptions(0, 0, 50);
			options.ExtractDataOptions = ExtractDataOptions.StopAtFirstEmptyRow;
			options.ExcelCellToDataTableCellConverting += (sender, e) =>
			{
				if (!e.IsDataTableValueValid)
				{
					// GemBox.Spreadsheet doesn't automatically convert numbers to strings in ExtractToDataTable() method because of culture issues; 

					// someone would expect the number 12.4 as "12.4" and someone else as "12,4".
					e.DataTableValue = e.ExcelCell.Value == null ? null : e.ExcelCell.Value.ToString();
					e.Action = ExtractDataEventAction.Continue;
				}
			};
			// Extract the data from the worksheet to the DataTable.
			// Data is extracted starting at first row and first column for 10 rows or until the first empty row appears.

			ws.ExtractToDataTable(dataTable, options);
			// Write DataTable content
			GlobalVar.combineValue = new MultiDimDictList<object, int>();
			var i = 0;
			foreach (DataRow row in dataTable.Rows)
			{			
				GlobalVar.combineValue.Add(row[0], i);
				GlobalVar.combineValue.Add(row[1], i);
				GlobalVar.combineValue.Add(row[2], i);
				i++;
			}
		}

	}
}
