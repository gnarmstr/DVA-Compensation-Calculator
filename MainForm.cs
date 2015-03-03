		#region Using

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
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

#endregion

namespace DVA_Compensation_Calculator
{
	public partial class MainForm : Form
	{
		#region Initialization
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
			UpdateAll();
		}
		#endregion

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
			checkBoxRightElbowWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightElbowWar", false);
			checkBoxRightShoulderWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightShoulderWar", false);
			checkBoxRightWristWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightWristWar", false);
			checkBoxRightFingersWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightFingersWar", false);

			textBoxKnee.Text = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxKnee", "0");
			Knee.knee = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "Knee", "0"));
			textBoxHip.Text = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxHip", "0");
			Hip.hip = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "Hip", "0"));
			textBoxToes.Text = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxToes", "0");
			Toes.toes = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "Toes", "0"));
			textBoxAnkle.Text = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxAnkle", "0");
			Ankle.ankle = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "Ankle", "0"));
			checkBoxKneeWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxKneeWar", false);
			checkBoxHipWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxHipWar", false);
			checkBoxToesWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxToesWar", false);
			checkBoxAnkleWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxAnkleWar", false);
			textBoxWholeLimb.Text = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxWholeLimb", "0");
			WholeLimb.wholeLimb = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "WholeLimb", "0"));
			checkBoxWholeLimbWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxWholeLimbWar", false);

			textBoxThoraco.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxThoraco", "0");
			ThoracoLumbar.thoracoLumbar = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "thoracoLumbar", "0"));
			checkBoxThoracoWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxThoracoWar", false);

			textBoxTinnitus.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxTinnitus", "0");
			Tinnitus.tinnitus = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "Tinnitus", "0"));
			checkBoxTinnitusWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxTinnitusWar", false);

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

		#region Total Points - Add to this when adding new injury types

		private void totalPoint()
		{
			GlobalVar.WarlikePoints = 0;
			GlobalVar.PeacelikePoints = 0;

			//LEFT ARM
			var leftArmHighestPointsWarArray = new decimal[4];
			var leftArmHighestPointsPeaceArray = new decimal[4];
			var leftwar = 0;
			if (checkBoxElbowWar.Checked)
			{
				leftArmHighestPointsWarArray[0] = Convert.ToDecimal(textBoxElbow.Text);
				leftwar = 1;
			}
			else
			{
				leftArmHighestPointsPeaceArray[0] = Convert.ToDecimal(textBoxElbow.Text);
			}
			if (checkBoxShoulderWar.Checked)
			{
				leftArmHighestPointsWarArray[1] = Convert.ToDecimal(textBoxShoulder.Text);
				leftwar = 1;
			}
			else
			{
				leftArmHighestPointsPeaceArray[1] = Convert.ToDecimal(textBoxShoulder.Text);
			}

			if (checkBoxWristWar.Checked)
			{
				leftArmHighestPointsWarArray[2] = Convert.ToDecimal(textBoxWrist.Text);
				leftwar = 1;
			}
			else
			{
				leftArmHighestPointsPeaceArray[2] = Convert.ToDecimal(textBoxWrist.Text);
			}
			if (checkBoxFingersWar.Checked)
			{
				leftArmHighestPointsWarArray[3] = Convert.ToDecimal(textBoxFingers.Text);
				leftwar = 1;
			}
			else
			{
				leftArmHighestPointsPeaceArray[3] = Convert.ToDecimal(textBoxFingers.Text);
			}
			if (checkBoxWholeLeftArmWar.Checked) //LEFT WHOLE ARM
			{
				leftwar = 1;
			}
			GlobalVar.leftArmHighestPointsWar = leftArmHighestPointsWarArray.Max();
			GlobalVar.leftArmHighestPointsPeace = leftArmHighestPointsPeaceArray.Max();
			GlobalVar.LeftArmPoints = Math.Max(GlobalVar.leftArmHighestPointsWar, GlobalVar.leftArmHighestPointsPeace);
			GlobalVar.HighestLeftArmPoints = Math.Max(GlobalVar.LeftArmPoints, Convert.ToInt16(textBoxWholeLeftArm.Text));

			//RIGHT ARM
			var rightArmHighestPointsWarArray = new decimal[4];
			var rightArmHighestPointsPeaceArray = new decimal[4];
			var rightArmWar = 0;
			if (checkBoxRightElbowWar.Checked)
			{
				rightArmHighestPointsWarArray[0] = Convert.ToDecimal(textBoxRightElbow.Text);
				rightArmWar = 1;
			}
			else
			{
				rightArmHighestPointsPeaceArray[0] = Convert.ToDecimal(textBoxRightElbow.Text);
			}
			if (checkBoxRightShoulderWar.Checked)
			{
				rightArmHighestPointsWarArray[1] = Convert.ToDecimal(textBoxRightShoulder.Text);
				rightArmWar = 1;
			}
			else
			{
				rightArmHighestPointsPeaceArray[1] = Convert.ToDecimal(textBoxRightShoulder.Text);
			}

			if (checkBoxRightWristWar.Checked)
			{
				rightArmHighestPointsWarArray[2] = Convert.ToDecimal(textBoxRightWrist.Text);
				rightArmWar = 1;
			}
			else
			{
				rightArmHighestPointsPeaceArray[2] = Convert.ToDecimal(textBoxRightWrist.Text);
			}
			if (checkBoxRightFingersWar.Checked)
			{
				rightArmHighestPointsWarArray[3] = Convert.ToDecimal(textBoxRightFingers.Text);
				rightArmWar = 1;
			}
			else
			{
				rightArmHighestPointsPeaceArray[3] = Convert.ToDecimal(textBoxRightFingers.Text);
			}
			if (checkBoxWholeRightArmWar.Checked) //RIGHT WHOLE ARM
			{
				rightArmWar = 1;
			}
			GlobalVar.RightArmHighestPointsWar = rightArmHighestPointsWarArray.Max();
			GlobalVar.RightArmHighestPointsPeace = rightArmHighestPointsPeaceArray.Max();
			GlobalVar.RightArmPoints = Math.Max(GlobalVar.RightArmHighestPointsWar, GlobalVar.RightArmHighestPointsPeace);
			GlobalVar.HighestRightArmPoints = Math.Max(GlobalVar.RightArmPoints, Convert.ToInt16(textBoxWholeRightArm.Text));

			//LEG
			var legHighestPointsWarArray = new decimal[4];
			var legHighestPointsPeaceArray = new decimal[4];
			var legWar = 0;
			if (checkBoxAnkleWar.Checked)
			{
				legHighestPointsWarArray[0] = Convert.ToDecimal(textBoxAnkle.Text);
				legWar = 1;
			}
			else
			{
				legHighestPointsPeaceArray[0] = Convert.ToDecimal(textBoxAnkle.Text);
			}
			if (checkBoxKneeWar.Checked)
			{
				legHighestPointsWarArray[1] = Convert.ToDecimal(textBoxKnee.Text);
				legWar = 1;
			}
			else
			{
				legHighestPointsPeaceArray[1] = Convert.ToDecimal(textBoxKnee.Text);
			}

			if (checkBoxHipWar.Checked)
			{
				legHighestPointsWarArray[2] = Convert.ToDecimal(textBoxHip.Text);
				legWar = 1;
			}
			else
			{
				legHighestPointsPeaceArray[2] = Convert.ToDecimal(textBoxHip.Text);
			}
			if (checkBoxToesWar.Checked)
			{
				legHighestPointsWarArray[3] = Convert.ToDecimal(textBoxToes.Text);
				legWar = 1;
			}
			else
			{
				legHighestPointsPeaceArray[3] = Convert.ToDecimal(textBoxToes.Text);
			}
			if (checkBoxWholeLimbWar.Checked)
			{
				legWar = 1;
			}
			GlobalVar.legHighestPointsWarArray = legHighestPointsWarArray.Max();
			GlobalVar.legHighestPointsPeaceArray = legHighestPointsPeaceArray.Max();
			GlobalVar.LegPoints = Math.Max(GlobalVar.legHighestPointsWarArray, GlobalVar.legHighestPointsPeaceArray);
			GlobalVar.HighestLegPoints = Math.Max(GlobalVar.LegPoints, Convert.ToInt16(textBoxWholeLimb.Text));

			//Thoraco Lumber Spine
			var thoracoLumbarWar = 0;
			if (checkBoxThoracoWar.Checked)
			{
				thoracoLumbarWar = 1;
			}

			//Joint Pain
			var jointPainWar = 0;
			if (checkBoxJointPainWar.Checked)
			{
				jointPainWar = 1;
			}

			//Hearing Tinnitus
			var tinnitusWar = 0;
			if (checkBoxTinnitusWar.Checked)
			{
				tinnitusWar = 1;
			}

			// Just for Display Only
			GlobalVar.WarlikePoints += Convert.ToInt16(GlobalVar.HighestRightArmPoints);
			GlobalVar.WarlikePoints += Convert.ToInt16(GlobalVar.HighestLeftArmPoints);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxJointPain.Text);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxThoraco.Text);
			GlobalVar.WarlikePoints += Convert.ToInt16(GlobalVar.HighestLegPoints);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxTinnitus.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(GlobalVar.HighestLeftArmPoints);
			GlobalVar.PeacelikePoints += Convert.ToInt16(GlobalVar.HighestRightArmPoints);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxJointPain.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxThoraco.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(GlobalVar.HighestLegPoints);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxTinnitus.Text);
			//

			textBoxTotalWarPoints.Text = "0";
			textBoxTotalPeacePoints.Text = "0";
			if (leftwar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.HighestLeftArmPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.HighestLeftArmPoints).ToString();
			}
			if (rightArmWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.HighestRightArmPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.HighestRightArmPoints).ToString();
			}
			if (jointPainWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxJointPain.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxJointPain.Text)).ToString();
			}
			if (thoracoLumbarWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxThoraco.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxThoraco.Text)).ToString();
			}
			if (legWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.HighestLegPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.HighestLegPoints).ToString();
			}
			if (tinnitusWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxTinnitus.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxTinnitus.Text)).ToString();
			}
			
		}

		#endregion

		#region Total Combined Point - Add to this when adding new injury types

		private void combinedPoints()
		{
			//Add a line per claim.
			decimal combinedPoints;
			combinedPoints = Math.Round(GlobalVar.HighestLeftArmPoints + Convert.ToDecimal(textBoxJointPain.Text) * (1 - Convert.ToDecimal(GlobalVar.leftArmHighestPointsWar) / 100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.HighestRightArmPoints * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxThoraco.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.HighestLegPoints * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxTinnitus.Text) * (1 - combinedPoints / 100));
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

		#region Update All

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
		#endregion

		#region Misc

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

		private void buttonROMInfo_Click(object sender, EventArgs e)
		{
			var rOMInfo = new ROMInfo();
			rOMInfo.ShowDialog();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void comboBoxAge_MouseLeave(object sender, EventArgs e)
		{
			UpdateAll();
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
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightElbowWar", checkBoxRightElbowWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightShoulderWar", checkBoxRightShoulderWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightWristWar", checkBoxRightWristWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightFingerWar", checkBoxRightFingersWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxKnee", textBoxKnee.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "Knee", Knee.knee);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxHip", textBoxHip.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "Hip", Hip.hip);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxToes", textBoxToes.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "Toes", Toes.toes);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxAnkle", textBoxAnkle.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "Ankle", Ankle.ankle);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxKneeWar", checkBoxKneeWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxHipWar", checkBoxHipWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxToesWar", checkBoxToesWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxAnkleWar", checkBoxAnkleWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "textBoxWholeLimb", textBoxWholeLimb.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "WholeLimb", WholeLimb.wholeLimb);
			profile.PutSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxWholeLimbWar", checkBoxWholeLimbWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.Back, "textBoxThoraco", textBoxThoraco.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "thoracoLumbar", ThoracoLumbar.thoracoLumbar);
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "checkBoxThoracoWar", checkBoxThoracoWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "textBoxTinnitus", textBoxTinnitus.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "Tinnitus", Tinnitus.tinnitus);
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "checkBoxTinnitusWar", checkBoxTinnitusWar.Checked.ToString());

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

		//Injury Types

		#region Back

		private void buttonThoraco_Click(object sender, EventArgs e)
		{
			var thoraco = new ThoracoLumbar();
			thoraco.ShowDialog();
			//Will age adjust the points
			textBoxThoraco.Text = GlobalVar.ExcelData[4][ThoracoLumbar.thoracoLumbar][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void checkBoxThoracoWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxThoracoLumbar_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region LifeStyle

		private void buttonPersonalRelationships_Click(object sender, EventArgs e)
		{
			var personalRelationships = new PersonalRelationships();
			personalRelationships.ShowDialog();
			textBoxPersonalRelationships.Text = PersonalRelationships.personalRelationship.ToString();  //No age adjustment
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
			textBoxRecreationalActivities.Text = RecreationalActivities.recreationalActivities.ToString();  //No age adjustment
		}

		private void buttonDomesticActivities_Click(object sender, EventArgs e)
		{
			var domesticActivities = new DomesticActivities();
			domesticActivities.ShowDialog();
			textBoxDomesticActivities.Text = DomesticActivities.domesticActivities.ToString();  //No age adjustment
		}

		private void buttonEmploymentActivities_Click(object sender, EventArgs e)
		{

			var employmentActivities = new EmploymentActivities();
			employmentActivities.ShowDialog();
			textBoxEmploymentActivities.Text = EmploymentActivities.employmentActivities.ToString();  //No age adjustment
		}

		private void textBoxPersonalRelationships_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
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

		private void finalLifeStylePoint()
		{
			textBoxFinalLifeStylePoint.Text = (Math.Round(((Convert.ToDecimal(textBoxPersonalRelationships.Text) + Convert.ToDecimal(textBoxMobility.Text) + Convert.ToDecimal(textBoxRecreationalActivities.Text) + (Math.Max(Convert.ToDecimal(textBoxDomesticActivities.Text), Convert.ToDecimal(textBoxEmploymentActivities.Text)))) / 4), 0)).ToString();
		}

		private void textBoxFinalLifeStylePoint_TextChanged(object sender, EventArgs e)
		{
			FinalPayout();
		}

		#endregion

		#region Lower Body

		private void buttonKnee_Click(object sender, EventArgs e)
		{
			var knee = new Knee();
			knee.ShowDialog();
			textBoxKnee.Text = GlobalVar.ExcelData[4][Knee.knee][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonHip_Click(object sender, EventArgs e)
		{
			var hip = new Hip();
			hip.ShowDialog();
			textBoxHip.Text = GlobalVar.ExcelData[4][Hip.hip][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonAnkle_Click(object sender, EventArgs e)
		{
			var ankle = new Ankle();
			ankle.ShowDialog();
			textBoxAnkle.Text = GlobalVar.ExcelData[4][Ankle.ankle][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonToes_Click(object sender, EventArgs e)
		{
			var toes = new Toes();
			toes.ShowDialog();
			textBoxToes.Text = GlobalVar.ExcelData[4][Toes.toes][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxKnee_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxHip_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxAnkle_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxToes_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxKneeWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxHipWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxAnkleWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxToesWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void buttonWholeLimb_Click(object sender, EventArgs e)
		{
			var wholeLimb = new WholeLimb();
			wholeLimb.ShowDialog();
			textBoxWholeLimb.Text = WholeLimb.wholeLimb.ToString();  //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxWholeLimb_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxWholeLimbWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Joint Pain

		private void buttonJointPain_Click(object sender, EventArgs e)
		{
			var jointPain = new JointPain();
			jointPain.ShowDialog();
			textBoxJointPain.Text = JointPain.jointPain.ToString();  //No age adjustment
			UpdateAll();
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

		#endregion

		#region Upper Body

		#region Left Arm
		private void buttonElbow_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftElbow";
			var ebow = new Elbow();
			ebow.ShowDialog();
			textBoxElbow.Text = GlobalVar.ExcelData[4][Elbow.LeftElbow][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonShoulder_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftShoulder";
			var shoulder = new Shoulder();
			shoulder.ShowDialog();
			textBoxShoulder.Text = GlobalVar.ExcelData[4][Shoulder.LeftShoulder][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonWrist_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftWrist";
			var wrist = new Wrist();
			wrist.ShowDialog();
			textBoxWrist.Text = GlobalVar.ExcelData[4][Wrist.LeftWrist][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonFingers_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftFingers";
			var fingers = new Fingers();
			fingers.ShowDialog();
			textBoxFingers.Text = GlobalVar.ExcelData[4][Fingers.LeftFingers][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonWholeLeftArm_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftArm";
			var arm = new WholeArm();
			arm.ShowDialog();
			textBoxWholeLeftArm.Text = WholeArm.wholeLeftArm.ToString();  //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxWholeLeftArm_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxWholeLeftArmWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

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

		#endregion

		#region Right Arm

		private void buttonRightElbow_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightElbow";
			var elbow = new Elbow();
			elbow.ShowDialog();
			textBoxRightElbow.Text = GlobalVar.ExcelData[4][Elbow.RightElbow][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightShoulder_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightShoulder";
			var shoulder = new Shoulder();
			shoulder.ShowDialog();
			textBoxRightShoulder.Text = GlobalVar.ExcelData[4][Shoulder.RightShoulder][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightWrist_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightWrist";
			var wrist = new Wrist();
			wrist.ShowDialog();
			textBoxRightWrist.Text = GlobalVar.ExcelData[4][Wrist.RightWrist][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightFingers_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightFingers";
			var fingers = new Fingers();
			fingers.ShowDialog();
			textBoxRightFingers.Text = GlobalVar.ExcelData[4][Fingers.RightFingers][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonWholeRightArm_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightArm";
			var arm = new WholeArm();
			arm.ShowDialog();
			textBoxWholeRightArm.Text = WholeArm.wholeRightArm.ToString();   //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxWholeRightArm_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxWholeRightArmWar_CheckedChanged(object sender, EventArgs e)
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

		private void textBoxRightElbow_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxRightShoulder_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxRightWrist_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxRightFingers_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#endregion

		#region Hearing

		private void buttonTinnitus_Click(object sender, EventArgs e)
		{
			var tinnitus = new Tinnitus();
			tinnitus.ShowDialog();
			textBoxTinnitus.Text = Tinnitus.tinnitus.ToString(); //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxTinnitus_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxTinnitusWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}
		#endregion
	}
}
