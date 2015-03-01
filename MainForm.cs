﻿using System;
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
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

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
			GlobalVar.startup = false;
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

			GlobalVar.startup = true;
		}
		#endregion

		#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();
			comboBoxAge.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxAge", "50");
			textBoxWeeklyPayment.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxWeeklyPayment", "0");
			checkBoxMale.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMale", true);
			
			textBoxElbow.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxElbow", "0");
			textBoxRightElbow.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightElbow", "0");
			Elbow.LeftElbow = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftElbow", "0"));
			Elbow.RightElbow = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "RightElbow", "0"));
			textBoxWrist.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxWrist", "0");
			textBoxRightWrist.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightWrist", "0");
			Wrist.LeftWrist = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftWrist", "0"));
			Wrist.RightWrist = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "RightWrist", "0"));
			textBoxShoulder.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxShoulder", "0");
			textBoxRightShoulder.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightShoulder", "0");
			Shoulder.LeftShoulder = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftShoulder", "0"));
			Shoulder.RightShoulder = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "RightShoulder", "0"));
			textBoxFingers.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxFingers", "0");
			textBoxRightFingers.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightFingers", "0");
			Fingers.LeftFingers = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftFingers", "0"));
			Fingers.RightFingers = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "RightFingers", "0"));
			checkBoxElbowWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxElbowWar", false);
			checkBoxShoulderWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxShoulderWar", false);
			checkBoxWristWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWristWar", false);
			checkBoxFingersWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxFingersWar", false);

			textBoxPersonalRelationships.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxPersonalRelationships", "0");
			textBoxMobility.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxMobility", "0");
			textBoxRecreationalActivities.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxRecreationalActivities", "0");
			textBoxDomesticActivities.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxDomesticActivities", "0");
			textBoxEmploymentActivities.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxEmploymentActivities", "0");

			textBoxJointPain.Text = profile.GetSetting(XmlProfileSettings.SettingType.Other, "textBoxJointPain", "0");
			JointPain.jointPain = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Other, "JointPain", "0"));
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

		public class MultiDimDictList<K, T> : Dictionary<K, List<T>>
		{
			public void Add(K key, T addObject)
			{
				if (!ContainsKey(key)) Add(key, new List<T>());
				base[key].Add(addObject);
			}
		}
		#endregion

		#region Age Selection

		private void comboBoxAge_Leave(object sender, EventArgs e)
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
			textBoxElbow.Text = GlobalVar.ExcelData[4][Elbow.LeftElbow][GlobalVar.AgeAdjustRange].ToString();
			textBoxShoulder.Text = GlobalVar.ExcelData[4][Shoulder.LeftShoulder][GlobalVar.AgeAdjustRange].ToString();
			textBoxWrist.Text = GlobalVar.ExcelData[4][Wrist.LeftWrist][GlobalVar.AgeAdjustRange].ToString();
			textBoxFingers.Text = GlobalVar.ExcelData[4][Fingers.LeftFingers][GlobalVar.AgeAdjustRange].ToString();
			textBoxRightElbow.Text = GlobalVar.ExcelData[4][Elbow.RightElbow][GlobalVar.AgeAdjustRange].ToString();
			textBoxRightShoulder.Text = GlobalVar.ExcelData[4][Shoulder.RightShoulder][GlobalVar.AgeAdjustRange].ToString();
			textBoxRightWrist.Text = GlobalVar.ExcelData[4][Wrist.RightWrist][GlobalVar.AgeAdjustRange].ToString();
			textBoxRightFingers.Text = GlobalVar.ExcelData[4][Fingers.RightFingers][GlobalVar.AgeAdjustRange].ToString();
			if (!GlobalVar.startup)
			{
				UpdateAll();
			}
		}

		private void comboBoxAge_SelectedValueChanged(object sender, EventArgs e)
		{
			comboBoxAge_Leave(null, null);
		}
		#endregion

		#region Final Payout

		private void FinalPayout()
		{
			if (Convert.ToInt16(textBoxComibinedPoints.Text) > 0)
			{
				textBoxCompensationFactorWar.Text = GlobalVar.ExcelData[0][Convert.ToInt16(textBoxComibinedPoints.Text) - 4][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}
			else
			{
				textBoxCompensationFactorWar.Text = GlobalVar.ExcelData[0][Convert.ToInt16(textBoxComibinedPoints.Text)][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}
			if (Convert.ToInt16(textBoxComibinedPoints.Text) > 0)
			{
				textBoxCompensationFactorPeace.Text = GlobalVar.ExcelData[1][Convert.ToInt16(textBoxComibinedPoints.Text) - 4][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}
			else
			{
				textBoxCompensationFactorPeace.Text = GlobalVar.ExcelData[1][Convert.ToInt16(textBoxComibinedPoints.Text)][Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}
		}
		#endregion

		#region Total Combined Point

		private void combinedPoints()
		{
			//Add a line per claim.
			decimal combinedPoints;
			combinedPoints = Math.Round(Convert.ToDecimal(textBoxElbow.Text) + Convert.ToDecimal(textBoxShoulder.Text) * (1 - Convert.ToDecimal(textBoxElbow.Text) / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxWrist.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxFingers.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxJointPain.Text) * (1 - combinedPoints / 100));
			textBoxComibinedPoints.Text = combinedPoints.ToString();
		}
		#endregion

		#region Final Compensation Factor
		private void finalCompensationFactor()
		{
			try
			{
			decimal combinedCompensation;
			combinedCompensation = ((Convert.ToDecimal(textBoxTotalWarPoints.Text) * Convert.ToDecimal(textBoxCompensationFactorWar.Text)) + (Convert.ToDecimal(textBoxTotalPeacePoints.Text) * Convert.ToDecimal(textBoxCompensationFactorPeace.Text))) / (Convert.ToDecimal(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxTotalPeacePoints.Text));
			textBoxFinalCompensationFactor.Text = Math.Round(combinedCompensation, 3).ToString();

			}
			catch (Exception)
			{
			}
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxWeeklyPayment", textBoxWeeklyPayment.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMale", checkBoxMale.Checked.ToString());
			
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxElbow", textBoxElbow.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightElbow", textBoxRightElbow.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftElbow", Elbow.LeftElbow);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "RightElbow", Elbow.RightElbow);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxWrist", textBoxWrist.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightWrist", textBoxRightWrist.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftWrist", Wrist.LeftWrist);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "RightWrist", Wrist.RightWrist);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxShoulder", textBoxShoulder.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightShoulder", textBoxRightShoulder.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftShoulder", Shoulder.LeftShoulder);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "RightShoulder", Shoulder.RightShoulder);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxFingers", textBoxFingers.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightFingers", textBoxRightFingers.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftFingers", Fingers.LeftFingers);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "RightFingers", Fingers.RightFingers);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxElbowWar", checkBoxElbowWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxShoulderWar", checkBoxShoulderWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWristWar", checkBoxWristWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxFingerWar", checkBoxFingersWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxPersonalRelationships", textBoxPersonalRelationships.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxMobility", textBoxMobility.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxRecreationalActivities", textBoxRecreationalActivities.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxDomesticActivities", textBoxDomesticActivities.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxEmploymentActivities", textBoxEmploymentActivities.Text);

			profile.PutSetting(XmlProfileSettings.SettingType.Other, "textBoxJointPain", textBoxJointPain.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Other, "JointPain", JointPain.jointPain);
			

			MessageBox.Show(@"Settings and Data have been saved");
		}

		private void SaveAll_Click(object sender, EventArgs e)
		{
			Save();
		}
		#endregion

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void comboBoxAge_MouseLeave(object sender, EventArgs e)
		{
			UpdateAll();
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
			UpdateAll();
		}

		private void finalLifeStylePoint()
		{
			textBoxFinalLifeStylePoint.Text = (Math.Round(((Convert.ToDecimal(textBoxPersonalRelationships.Text) + Convert.ToDecimal(textBoxMobility.Text) + Convert.ToDecimal(textBoxRecreationalActivities.Text) + (Math.Max(Convert.ToDecimal(textBoxDomesticActivities.Text), Convert.ToDecimal(textBoxEmploymentActivities.Text)))) / 4),0)).ToString();
		}

		private void textBoxMobility_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxRecreationalActivities_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxDomesticActivities_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxEmploymentActivities_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxFinalLifeStylePoint_TextChanged(object sender, EventArgs e)
		{
			FinalPayout();
		}

		#region Arm
		private void buttonElbow_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftElbow";
			var ebow = new Elbow();
			ebow.ShowDialog();
			textBoxElbow.Text = GlobalVar.ExcelData[4][Elbow.LeftElbow][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}

		private void buttonShoulder_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftShoulder";
			var shoulder = new Shoulder();
			shoulder.ShowDialog();
			textBoxShoulder.Text = GlobalVar.ExcelData[4][Shoulder.LeftShoulder][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}

		private void buttonWrist_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftWrist";
			var wrist = new Wrist();
			wrist.ShowDialog();
			textBoxWrist.Text = GlobalVar.ExcelData[4][Wrist.LeftWrist][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}

		private void buttonFingers_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftFingers";
			var fingers = new Fingers();
			fingers.ShowDialog();
			textBoxFingers.Text = GlobalVar.ExcelData[4][Fingers.LeftFingers][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}

		private void buttonRightElbow_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightElbow";
			var elbow = new Elbow();
			elbow.ShowDialog();
			textBoxRightElbow.Text = GlobalVar.ExcelData[4][Elbow.RightElbow][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}

		private void buttonRightShoulder_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightShoulder";
			var shoulder = new Shoulder();
			shoulder.ShowDialog();
			textBoxRightShoulder.Text = GlobalVar.ExcelData[4][Shoulder.RightShoulder][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}

		private void buttonRightWrist_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightWrist";
			var wrist = new Wrist();
			wrist.ShowDialog();
			textBoxRightWrist.Text = GlobalVar.ExcelData[4][Wrist.RightWrist][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}

		private void buttonRightFingers_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightFingers";
			var fingers = new Fingers();
			fingers.ShowDialog();
			textBoxRightFingers.Text = GlobalVar.ExcelData[4][Fingers.RightFingers][GlobalVar.AgeAdjustRange].ToString();
			UpdateAll();
		}
		#endregion

		private void textBoxElbow_TextChanged(object sender, EventArgs e)
		{ 
			UpdateAll();
		}

		private void textBoxShoulder_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxWrist_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxFingers_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxElbowWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void totalPoint()
		{
			//Only used for display purpose and not required for any calculations
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
			if (checkBoxJointPainWar.Checked)
			{
				GlobalVar.WarlikePoints += Convert.ToInt16(textBoxJointPain.Text);
			}
			else
			{
				GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxJointPain.Text);
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
			FinalPayout();
			finalLifeStylePoint();
			combinedPoints();
			totalPoint();
			finalCompensationFactor();
			textBoxWeeklyPayout.Text = (Math.Round(Convert.ToDecimal(textBoxFinalCompensationFactor.Text)*Convert.ToDecimal(textBoxWeeklyPayment.Text), 2)).ToString();
			int sex;
			if (checkBoxMale.Checked)
			{
				sex = 0;
			}
			else
			{
				sex = 1;
			}
			if (Convert.ToInt16(comboBoxAge.Text) <= 31)
			{
				textBoxLumpSumPayout.Text = (Math.Round(Convert.ToDecimal(GlobalVar.ExcelData[2][0][sex]) * Convert.ToDecimal(textBoxWeeklyPayout.Text),2)).ToString();
			}
			else
			{
				if (Convert.ToInt16(comboBoxAge.Text) > 89)
				textBoxLumpSumPayout.Text = (Math.Round(Convert.ToDecimal(GlobalVar.ExcelData[2][59][sex]) * Convert.ToDecimal(textBoxWeeklyPayout.Text), 2)).ToString();
				else
				{
					textBoxLumpSumPayout.Text = (Math.Round(Convert.ToDecimal(GlobalVar.ExcelData[2][Convert.ToInt16(comboBoxAge.Text) - 31][sex]) * Convert.ToDecimal(textBoxWeeklyPayout.Text), 2)).ToString();
				}
			}
			
		}

		private void checkBoxMale_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxFemale.Checked = !checkBoxMale.Checked;
			if (!GlobalVar.startup)
			{
				UpdateAll();
			}
		}

		private void checkBoxFemale_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxMale.Checked = !checkBoxFemale.Checked;
			if (!GlobalVar.startup)
			{
				UpdateAll();
			}
		}

		private void textBoxWeeklyPayment_TextChanged(object sender, EventArgs e)
		{
			if (!GlobalVar.startup)
			{
				UpdateAll();
			}
		}

		private void buttonJointPain_Click(object sender, EventArgs e)
		{
			var jointPain = new JointPain();
			jointPain.ShowDialog();
			textBoxJointPain.Text = JointPain.jointPain.ToString();
			UpdateAll();
		}

		private void textBoxJointPain_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxJointPainWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxRightElbowWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxRightShoulderWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxRightWristWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxRightFingersWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}


	}
}