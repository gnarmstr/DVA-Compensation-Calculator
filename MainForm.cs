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

namespace DVA_Compensation_Calculator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			Settings();
			getLifeStyleWar();
			getLifeStylePeace();
			getActuaryTable();
			getCombinedValue();
			getLimbsAgeAdjust();
			LoadData();
			FinalPayout();
			combinedPoints();
			UpdateAll();
		}

		#region Settings
		private void Settings()
		{
			SaveAll.Image = Tools.ResizeImage(Resources.Save, 130, 30);
			GlobalVar.ExcelData = new[] { GlobalVar.LifeStyleWar, GlobalVar.LifeStylePeace, GlobalVar.ActuaryTable, GlobalVar.CombineValue, GlobalVar.LimbsAgeAdjust };
			//Add Days for Date of Birth
			
			var i = 100;
			do
			{
				comboBoxAge.Items.Add(i);
				i--;
			} while (i > 17);
		}
		#endregion

		#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();
			comboBoxAge.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxAge", "50");
			textBoxWeeklyPayment.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxWeeklyPayment", "364.60");

			textBoxElbow.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxElbow", "0");
			textBoxWrist.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxWrist", "0");
			textBoxShoulder.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxShoulder", "0");
			textBoxFingers.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxFingers", "0");
			checkBoxElbowWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxElbowWar", false);
			checkBoxShoulderWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxShoulderWar", false);
			checkBoxWristWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWristWar", false);
			checkBoxFingersWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxFingersWar", false);

			textBoxPersonalRelationships.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxPersonalRelationships", "0");
			textBoxMobility.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxMobility", "0");
			textBoxRecreationalActivities.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxRecreationalActivities", "0");
			textBoxDomesticActivities.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxDomesticActivities", "0");
			textBoxEmploymentActivities.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxEmploymentActivities", "0");
			
		}
		#endregion

		#region Get Excel Data Tables
		private void getLifeStyleWar()
		{
			var columns = 8;
			var sheet = 0;
			var excelData = 0;
			importExcel(columns, sheet, excelData);
		}

		private void getLifeStylePeace()
		{
			var columns = 8;
			var sheet = 1;
			var excelData = 1;
			importExcel(columns, sheet, excelData);
		}

		private void getActuaryTable()
		{
			var columns = 2;
			var sheet = 2;
			var excelData = 2;
			importExcel(columns, sheet, excelData);
		}

		private void getCombinedValue()
		{
			var columns = 100;
			var sheet = 3;
			var excelData = 3;
			importExcel(columns, sheet, excelData);
		}

		private void getLimbsAgeAdjust()
		{
			var columns = 7;
			var sheet = 4;
			var excelData = 4;
			importExcel(columns, sheet, excelData);
		}

		private void importExcel(int columns, int sheet, int excelData)
		{
			SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
			ExcelFile ef = ExcelFile.Load("DVA_Tables.xls");
			DataTable dataTable = new DataTable();
			// Depending on the format of the input file, you need to change this:
			var i = 0;
			do
			{
				dataTable.Columns.Add("Column" + i, typeof(string));
				i++;
			} while (i < columns);
			// Select the first worksheet from the file.

			ExcelWorksheet ws = ef.Worksheets[sheet];
			ExtractToDataTableOptions options = new ExtractToDataTableOptions(0, 0, 100);
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
			// Data is extracted starting at first row and first column.

			ws.ExtractToDataTable(dataTable, options);
			// Write DataTable content
			GlobalVar.ExcelData[excelData] = new MultiDimDictList<int, object>();
			i = 0;
			int ii;
			foreach (DataRow row in dataTable.Rows)
			{
				ii = 0;
				do
				{
					GlobalVar.ExcelData[excelData].Add(i, row[ii]);
					ii++;
				} while (ii < columns);
				i++;
			}
		}
		#endregion

		#region Upperbody


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
				GlobalVar.AgeAdjustRange = 0;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 36 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 45)
			{
				GlobalVar.AgeAdjustRange = 1;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 46 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 55)
			{
				GlobalVar.AgeAdjustRange = 2;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 56 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 65)
			{
				GlobalVar.AgeAdjustRange = 3;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 66 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 75)
			{
				GlobalVar.AgeAdjustRange = 4;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) >= 76 & Convert.ToInt16(comboBoxAge.SelectedItem) <= 85)
			{
				GlobalVar.AgeAdjustRange = 5;
			}
			if (Convert.ToInt16(comboBoxAge.SelectedItem) > 85)
			{
				GlobalVar.AgeAdjustRange = 6;
			}
			textBoxElbow.Text = GlobalVar.ExcelData[4][Ebow.ebow][GlobalVar.AgeAdjustRange].ToString();
			textBoxShoulder.Text = GlobalVar.ExcelData[4][Shoulder.shoulder][GlobalVar.AgeAdjustRange].ToString();
			textBoxWrist.Text = GlobalVar.ExcelData[4][Wrist.wrist][GlobalVar.AgeAdjustRange].ToString();
			textBoxFingers.Text = GlobalVar.ExcelData[4][Fingers.fingers][GlobalVar.AgeAdjustRange].ToString();
		}
		#endregion

		#region Final Payout

		private void FinalPayout()
		{
			if (checkBoxElbowWar.Checked || checkBoxShoulderWar.Checked || checkBoxWristWar.Checked || checkBoxFingersWar.Checked)
			{
				if (Convert.ToInt16(textBoxComibinedPoints.Text) > 0)
				{
					textBoxCompensationFactorWar.Text = GlobalVar.ExcelData[0][Convert.ToInt16(textBoxComibinedPoints.Text) - 4][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
				}
				else
				{
					textBoxCompensationFactorWar.Text = GlobalVar.ExcelData[0][Convert.ToInt16(textBoxComibinedPoints.Text)][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
				}
			}
			else
			{
				if (Convert.ToInt16(textBoxComibinedPoints.Text) > 0)
				{
					textBoxCompensationFactorPeace.Text = GlobalVar.ExcelData[1][Convert.ToInt16(textBoxComibinedPoints.Text) - 4][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
				}
				else
				{
					textBoxCompensationFactorPeace.Text = GlobalVar.ExcelData[1][Convert.ToInt16(textBoxComibinedPoints.Text)][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
				}

			}
		}
		#endregion

		#region Total Combined Point

		private void combinedPoints()
		{
			decimal combinedPoints;
			combinedPoints = Math.Round(Convert.ToDecimal(textBoxElbow.Text) + Convert.ToDecimal(textBoxShoulder.Text) * (1 - Convert.ToDecimal(textBoxElbow.Text) / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxWrist.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxFingers.Text) * (1 - combinedPoints / 100));
			textBoxComibinedPoints.Text = combinedPoints.ToString();
		}
		#endregion

		#region Final Compensation Factor
		private void finalCompensationFactor()
		{
			decimal combinedCompensation;
			combinedCompensation = ((Convert.ToDecimal(textBoxTotalWarPoints.Text) * Convert.ToDecimal(textBoxCompensationFactorWar.Text)) + (Convert.ToDecimal(textBoxTotalPeacePoints.Text) * Convert.ToDecimal(textBoxCompensationFactorPeace.Text))) / (Convert.ToDecimal(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxTotalPeacePoints.Text));
			textBoxFinalCompensationFactor.Text = Math.Round(combinedCompensation, 3).ToString();
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

			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxElbow", textBoxElbow.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxWrist", textBoxWrist.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxShoulder", textBoxShoulder.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxFingers", textBoxFingers.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxElbowWar", checkBoxElbowWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxShouldeWar", checkBoxElbowWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWristWar", checkBoxWristWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxFingerWar", checkBoxFingersWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxPersonalRelationships", textBoxPersonalRelationships.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxMobility", textBoxMobility.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxRecreationalActivities", textBoxRecreationalActivities.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxDomesticActivities", textBoxDomesticActivities.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxEmploymentActivities", textBoxEmploymentActivities.Text);
			
		}

		private void SaveAll_Click(object sender, EventArgs e)
		{
			Save();
		}
		#endregion

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			FinalPayout();
		}

		private void comboBoxAge_MouseLeave(object sender, EventArgs e)
		{
			FinalPayout();
		}

		private void buttonPersonalRelationships_Click(object sender, EventArgs e)
		{
			var personalRelationships = new PersonalRelationships();
			personalRelationships.ShowDialog();
			textBoxPersonalRelationships.Text = PersonalRelationships.personalRelationship.ToString();
		}

		private void buttonMobility_Click(object sender, EventArgs e)
		{
			var mobility = new Mobility();
			mobility.ShowDialog();
			textBoxMobility.Text = Mobility.mobility.ToString();
		}

		private void buttonRecreationalActivities_Click(object sender, EventArgs e)
		{
			var recreationalActivities = new RecreationalActivities();
			recreationalActivities.ShowDialog();
			textBoxRecreationalActivities.Text = RecreationalActivities.recreationalActivities.ToString();
		}

		private void buttonDomesticActivities_Click(object sender, EventArgs e)
		{
			var domesticActivities = new DomesticActivities();
			domesticActivities.ShowDialog();
			textBoxDomesticActivities.Text = DomesticActivities.domesticActivities.ToString();
		}

		private void buttonEmploymentActivities_Click(object sender, EventArgs e)
		{

			var employmentActivities = new EmploymentActivities();
			employmentActivities.ShowDialog();
			textBoxEmploymentActivities.Text = EmploymentActivities.employmentActivities.ToString();
		}

		private void textBoxPersonalRelationships_TextChanged(object sender, EventArgs e)
		{
			finalLifeStylePoint();
		}

		private void finalLifeStylePoint()
		{
			textBoxFinalLifeStylePoint.Text = (Math.Round(((Convert.ToDecimal(textBoxPersonalRelationships.Text) + Convert.ToDecimal(textBoxMobility.Text) + Convert.ToDecimal(textBoxRecreationalActivities.Text) + (Math.Max(Convert.ToDecimal(textBoxDomesticActivities.Text), Convert.ToDecimal(textBoxEmploymentActivities.Text)))) / 4),0)).ToString();
		}

		private void textBoxMobility_TextChanged(object sender, EventArgs e)
		{
			finalLifeStylePoint();
		}

		private void textBoxRecreationalActivities_TextChanged(object sender, EventArgs e)
		{
			finalLifeStylePoint();
		}

		private void textBoxDomesticActivities_TextChanged(object sender, EventArgs e)
		{
			finalLifeStylePoint();
		}

		private void textBoxEmploymentActivities_TextChanged(object sender, EventArgs e)
		{
			finalLifeStylePoint();
		}

		private void textBoxFinalLifeStylePoint_TextChanged(object sender, EventArgs e)
		{
			FinalPayout();
		}

		private void buttonElbow_Click(object sender, EventArgs e)
		{
			var ebow = new Ebow();
			ebow.ShowDialog();
			textBoxElbow.Text = GlobalVar.ExcelData[4][Ebow.ebow][GlobalVar.AgeAdjustRange].ToString();
		}

		private void buttonShoulder_Click(object sender, EventArgs e)
		{
			var shoulder = new Shoulder();
			shoulder.ShowDialog();
			textBoxShoulder.Text = GlobalVar.ExcelData[4][Shoulder.shoulder][GlobalVar.AgeAdjustRange].ToString();
		}

		private void buttonWrist_Click(object sender, EventArgs e)
		{
			var wrist = new Wrist();
			wrist.ShowDialog();
			textBoxWrist.Text = GlobalVar.ExcelData[4][Wrist.wrist][GlobalVar.AgeAdjustRange].ToString();
		}

		private void buttonFingers_Click(object sender, EventArgs e)
		{
			var fingers = new Fingers();
			fingers.ShowDialog();
			textBoxFingers.Text = GlobalVar.ExcelData[4][Fingers.fingers][GlobalVar.AgeAdjustRange].ToString();
		}

		private void textBoxElbow_TextChanged(object sender, EventArgs e)
		{
			combinedPoints();
			UpdateAll();
		}

		private void textBoxShoulder_TextChanged(object sender, EventArgs e)
		{
			combinedPoints();
			UpdateAll();
		}

		private void textBoxWrist_TextChanged(object sender, EventArgs e)
		{
			combinedPoints();
			UpdateAll();
		}

		private void textBoxFingers_TextChanged(object sender, EventArgs e)
		{
			combinedPoints();
			UpdateAll();
		}

		private void checkBoxElbowWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void totalPoint()
		{
			GlobalVar.WarlikePoints = 0;
			GlobalVar.PeacelikePoints = 0;
			if (checkBoxElbowWar.Checked)
			{
				GlobalVar.WarlikePoints += Convert.ToInt16(textBoxElbow.Text);
			}
			else
			{
				GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxElbow.Text);
			}
			if (checkBoxShoulderWar.Checked)
			{
				GlobalVar.WarlikePoints += Convert.ToInt16(textBoxShoulder.Text);
			}
			else
			{
				GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxShoulder.Text);
			}
			if (checkBoxWristWar.Checked)
			{
				GlobalVar.WarlikePoints += Convert.ToInt16(textBoxWrist.Text);
			}
			else
			{
				GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxWrist.Text);
			}
			if (checkBoxFingersWar.Checked)
			{
				GlobalVar.WarlikePoints += Convert.ToInt16(textBoxFingers.Text);
			}
			else
			{
				GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxFingers.Text);
			}
			textBoxTotalWarPoints.Text = GlobalVar.WarlikePoints.ToString();
			textBoxTotalPeacePoints.Text = GlobalVar.PeacelikePoints.ToString();
		}

		private void checkBoxShoulderWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxWristWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxFingersWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void UpdateAll()
		{
			totalPoint();
			finalCompensationFactor();
			textBoxWeeklyPayout.Text = (Convert.ToDecimal(textBoxFinalCompensationFactor.Text)*Convert.ToDecimal(textBoxWeeklyPayment.Text)).ToString();
	//		textBoxLumpSumPayout.Text = ((GlobalVar.ExcelData[2][Convert.ToInt16(comboBoxAge.Text) - 35][0]) * (Convert.ToDecimal(textBoxWeeklyPayment.Text))).ToString();
		}

	}
}
