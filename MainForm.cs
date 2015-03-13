		#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Common.Resources;
using Common.Resources.Properties;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.IO;

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

		#region Used to allow graphgic refresh and draw before display to stop flickering
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | 0x2000000;
				return cp;
			}
		}
		#endregion

		#region Settings

		private void Settings()
		{
			MinimumSize = new Size(725, 790);
			MaximumSize = new Size(725, 790);
			GlobalVar.SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"DVA Compensation Calculator");
			SaveAll.Image = Tools.ResizeImage(Resources.Save, 130, 30);
			GlobalVar.ExcelData = new[]
			{
				GlobalVar.LifeStyleWar, GlobalVar.LifeStylePeace, GlobalVar.ActuaryTable, GlobalVar.CombineValue,
				GlobalVar.LimbsAgeAdjust
			};

			//Add Days for Date of Birth

			var i = 100;
			do
			{
				comboBoxAge.Items.Add(i);
				i--;
			} while (i > 17);

			GlobalVar.startup = true;

			panelMainPoints.BackgroundImage = Resources.Bones_Blue_Small;
			BackgroundImage = Resources.MainBackground_Green_Small1;
			BackgroundImageLayout = ImageLayout.Stretch;
			buttonImportantInfo.BackgroundImage = Resources.button_Blue_Small;
			buttonDVALinks.BackgroundImage = Resources.button_Blue_Small;
			buttonLifeStyle.BackgroundImage = Resources.Button_Green;
			buttonROMInfo.BackgroundImage = Resources.button_Blue_Small;
			buttonThoraco.BackgroundImage = Resources.Button_Green;
			buttonWholeLeftArm.BackgroundImage = Resources.Button_Green;
			buttonJointPain.BackgroundImage = Resources.Button_Green;
			buttonWholeLimb.BackgroundImage = Resources.Button_Green;
			buttonWholeRightArm.BackgroundImage = Resources.Button_Green;
			pictureBoxClose.BackgroundImage = Resources.Close;
			buttonMainTitle.BackgroundImage = Resources.button_Blue_Small;
			buttonLeftEye.BackgroundImage = Resources.LeftEye;
			buttonRightEye.BackgroundImage = Resources.RightEye;
			buttonLeftKnee.FlatStyle = FlatStyle.Flat;
			buttonRightKnee.FlatStyle = FlatStyle.Flat;
			buttonLeftHip.FlatStyle = FlatStyle.Flat;
			buttonRightHip.FlatStyle = FlatStyle.Flat;
			buttonLeftAnkle.FlatStyle = FlatStyle.Flat;
			buttonRightAnkle.FlatStyle = FlatStyle.Flat;
			buttonLeftToes.FlatStyle = FlatStyle.Flat;
			buttonRightToes.FlatStyle = FlatStyle.Flat;
			buttonLeftElbow.FlatStyle = FlatStyle.Flat;
			buttonRightElbow.FlatStyle = FlatStyle.Flat;
			buttonLeftFingers.FlatStyle = FlatStyle.Flat;
			buttonRightFingers.FlatStyle = FlatStyle.Flat;
			buttonLeftShoulder.FlatStyle = FlatStyle.Flat;
			buttonRightShoulder.FlatStyle = FlatStyle.Flat;
			buttonLeftWrist.FlatStyle = FlatStyle.Flat;
			buttonRightWrist.FlatStyle = FlatStyle.Flat;
			buttonThoracoROM.FlatStyle = FlatStyle.Flat;
			buttonCervical.FlatStyle = FlatStyle.Flat;
			buttonThroat.FlatStyle = FlatStyle.Flat;
			buttonLeftEye.FlatStyle = FlatStyle.Flat;
			buttonRightEye.FlatStyle = FlatStyle.Flat;
			buttonLeftEar.FlatStyle = FlatStyle.Flat;
			buttonRightEar.FlatStyle = FlatStyle.Flat;
			buttonNose.FlatStyle = FlatStyle.Flat;
			buttonRightEye.BackgroundImage = Resources.Blank;
			buttonLeftEye.BackgroundImage = Resources.Blank;

			textBoxKnee.Visible = false;

		}

		#endregion

		// Add to this when adding new injury types
		#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();
			comboBoxAge.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxAge", "50");
			textBoxWeeklyPayment.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxWeeklyPayment",
				"324.60");
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
			Shoulder.LeftShoulder =
				Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftShoulder", "0"));
			Shoulder.RightShoulder =
				Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "RightShoulder", "0"));
			textBoxFingers.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxFingers", "0");
			textBoxRightFingers.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxRightFingers", "0");
			Fingers.LeftFingers =
				Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "LeftFingers", "0"));
			Fingers.RightFingers =
				Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "RightFingers", "0"));
			checkBoxElbowWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxElbowWar", false);
			checkBoxShoulderWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxShoulderWar",
				false);
			checkBoxWristWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWristWar", false);
			checkBoxFingersWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxFingersWar", false);
			checkBoxRightElbowWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightElbowWar",
				false);
			checkBoxRightShoulderWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb,
				"checkBoxRightShoulderWar", false);
			checkBoxRightWristWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxRightWristWar",
				false);
			checkBoxRightFingersWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb,
				"checkBoxRightFingersWar", false);
			checkBoxWholeRightArmWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb,
				"checkBoxWholeRightArmWar", false);
			textBoxWholeRightArm.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "WholeRightArm", "0");
			checkBoxWholeLeftArmWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb,
				"checkBoxWholeLeftArmWar", false);
			textBoxWholeLeftArm.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "WholeLeftArm", "0");

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
			checkBoxWholeLimbWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxWholeLimbWar",
				false);

			textBoxThoraco.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxThoraco", "0");
			ThoracoLumbar.thoracoLumbar =
				Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "thoracoLumbar", "0"));
			checkBoxThoracoWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxThoracoWar", false);
			textBoxThoracoROM.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxThoracoROM", "0");
			ThoracoROM.thoracoROM = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "ThoracoROM", "0"));
			checkBoxThoracoROMWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxThoracoROMWar",
				false);
			textBoxCervicalSpine.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxCervicalSpine", "0");
			Cervical.cervical = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "Cervical", "0"));
			checkBoxCervicalSpineWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxCervicalSpineWar",
				false);

			textBoxTinnitus.Text = profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "textBoxTinnitus", "0");
			Ears.tinnitus = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "Tinnitus", "0"));
			checkBoxTinnitusWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "checkBoxTinnitusWar", false);
			textBoxEars.Text = profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "textBoxEars", "0");
			Ears.ears = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "Ears", "0"));
			checkBoxEarsWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "checkBoxEarsWar", false);

			textBoxNose.Text = profile.GetSetting(XmlProfileSettings.SettingType.Nose, "textBoxNose", "0");
			Nose.nose = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Nose, "Nose", "0"));
			checkBoxNoseWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Nose, "checkBoxNoseWar", false);

			textBoxThroat.Text = profile.GetSetting(XmlProfileSettings.SettingType.Throat, "textBoxThroat", "0");
			Throat.throat = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Throat, "Throat", "0"));
			checkBoxThroatWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Throat, "checkBoxThroatWar", false);

			GlobalVar.LeftEyeConversion = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftEyeConversion", 0);
			GlobalVar.RightEyeConversion = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightEyeConversion", 0);
			GlobalVar.combinedEyePoints = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "combinedEyePoints", 0);
			GlobalVar.EyeWar = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "EyeWar", 0);
			GlobalVar.RightMonocular = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightMonocular", "0");
			GlobalVar.RightVisualFOL = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightVisualFOL", "0");
			GlobalVar.RightMiscVisual = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightMiscVisual", "0");
			GlobalVar.RightOtherOcular = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightOtherOcular", "0");
			GlobalVar.LeftMonocular = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftMonocular", "0");
			GlobalVar.LeftVisualFOL = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftVisualFOL", "0");
			GlobalVar.LeftMiscVisual = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftMiscVisual", "0");
			GlobalVar.LeftOtherOcular = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftOtherOcular", "0");
			VisualFOL.LeftEye = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftEye", "0"));
			VisualFOL.RightEye = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightEye", "0"));
			OcularImpairment.LeftOcular = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftOcular", "0"));
			OcularImpairment.RightOcular = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightOcular", "0"));
			textBoxFinalEyes.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxFinalEyes", "0");
			checkBoxEyesWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxEyesWar", false);

			GlobalVar.personalRelationships = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxPersonalRelationships", "0");
			GlobalVar.Mobility = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxMobility", "0");
			GlobalVar.RecreationalActivities = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxRecreationalActivities", "0");
			GlobalVar.DomesticActivities = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxDomesticActivities", "0");
			GlobalVar.EmploymentActivities = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxEmploymentActivities", "0");
			GlobalVar.FinalLifeStylePoint = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "FinalLifeStylePoint", "0");
			textBoxFinalLifeStylePoint.Text = profile.GetSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxFinalLifeStylePoint", "0");

			textBoxJointPain.Text = profile.GetSetting(XmlProfileSettings.SettingType.Other, "textBoxJointPain", "0");
			JointPain.jointPain = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Other, "JointPain", "0"));
		}

		#endregion

		#region Get Excel Data Tables

		private void getLifeStyleWar()
		{
			var columns = 21;
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
			ExcelFile ef = ExcelFile.Load(GlobalVar.SettingsPath + @"\DVA_Tables.xls");
			DataTable dataTable = new DataTable();
			// Depending on the format of the input file, you need to change this:
			var i = 0;
			do
			{
				dataTable.Columns.Add("Column" + i, typeof (string));
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
			if (Convert.ToInt16(comboBoxAge.Text) <= 36)
			{
				GlobalVar.AgeAdjustRange = 0;
			}
			if (Convert.ToInt16(comboBoxAge.Text) >= 36 & Convert.ToInt16(comboBoxAge.Text) <= 45)
			{
				GlobalVar.AgeAdjustRange = 1;
			}
			if (Convert.ToInt16(comboBoxAge.Text) >= 46 & Convert.ToInt16(comboBoxAge.Text) <= 55)
			{
				GlobalVar.AgeAdjustRange = 2;
			}
			if (Convert.ToInt16(comboBoxAge.Text) >= 56 & Convert.ToInt16(comboBoxAge.Text) <= 65)
			{
				GlobalVar.AgeAdjustRange = 3;
			}
			if (Convert.ToInt16(comboBoxAge.Text) >= 66 & Convert.ToInt16(comboBoxAge.Text) <= 75)
			{
				GlobalVar.AgeAdjustRange = 4;
			}
			if (Convert.ToInt16(comboBoxAge.Text) >= 76 & Convert.ToInt16(comboBoxAge.Text) <= 85)
			{
				GlobalVar.AgeAdjustRange = 5;
			}
			if (Convert.ToInt16(comboBoxAge.Text) > 85)
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

		#endregion

		// Add to this when adding new injury types
		#region Total Points

		private void totalPoint()
		{
			GlobalVar.WarlikePoints = 0;
			GlobalVar.PeacelikePoints = 0;

			#region Left Arm

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

			#endregion

			#region Right Arm

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

			#endregion

			#region Leg

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

			#endregion

			#region Back

			//Thoraco Lumber Spine
			var thoracoWar = 0;
			if (checkBoxThoracoWar.Checked)
			{
				thoracoWar = 1;
			}

			//ThoracoROM
			if (checkBoxThoracoROMWar.Checked)
			{
				thoracoWar = 1;
			}
			GlobalVar.TheracoHighestPoints = Math.Max(Convert.ToInt16(textBoxThoraco.Text),
				Convert.ToInt16(textBoxThoracoROM.Text));

			//Cervical Spine
			var cervicalSpineWar = 0;
			if (checkBoxCervicalSpineWar.Checked)
			{
				cervicalSpineWar = 1;
			}

			#endregion

			#region Joint Pain

			//Joint Pain
			var jointPainWar = 0;
			if (checkBoxJointPainWar.Checked)
			{
				jointPainWar = 1;
			}

			#endregion

			#region Ear Nose Throat

			//Hearing Tinnitus
			var tinnitusWar = 0;
			if (checkBoxTinnitusWar.Checked)
			{
				tinnitusWar = 1;
			}

			//Hearing Ears
			var earsWar = 0;
			if (checkBoxEarsWar.Checked)
			{
				earsWar = 1;
			}

			//Nose
			var noseWar = 0;
			if (checkBoxNoseWar.Checked)
			{
				noseWar = 1;
			}

			//Throat
			var throatWar = 0;
			if (checkBoxThroatWar.Checked)
			{
				throatWar = 1;
			}

			#endregion

			#region Eyes

			GlobalVar.combinedEyePoints =
				Convert.ToDecimal(GlobalVar.ExcelData[0][GlobalVar.LeftEyeConversion + 77][GlobalVar.RightEyeConversion]);
			textBoxFinalEyes.Text = GlobalVar.combinedEyePoints.ToString();

			#endregion

			#region Display War and Peace values. Display only

			// Just for Display Only
			GlobalVar.WarlikePoints += Convert.ToInt16(GlobalVar.HighestRightArmPoints);
			GlobalVar.WarlikePoints += Convert.ToInt16(GlobalVar.HighestLeftArmPoints);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxJointPain.Text);
			GlobalVar.WarlikePoints += GlobalVar.TheracoHighestPoints;
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxCervicalSpine.Text);
			GlobalVar.WarlikePoints += Convert.ToInt16(GlobalVar.HighestLegPoints);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxTinnitus.Text);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxEars.Text);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxNose.Text);
			GlobalVar.WarlikePoints += Convert.ToInt16(textBoxThroat.Text);
			GlobalVar.WarlikePoints += Convert.ToInt16(GlobalVar.combinedEyePoints);

			GlobalVar.PeacelikePoints += Convert.ToInt16(GlobalVar.HighestLeftArmPoints);
			GlobalVar.PeacelikePoints += Convert.ToInt16(GlobalVar.HighestRightArmPoints);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxJointPain.Text);
			GlobalVar.PeacelikePoints += GlobalVar.TheracoHighestPoints;
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxCervicalSpine.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(GlobalVar.HighestLegPoints);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxTinnitus.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxEars.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxNose.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(textBoxThroat.Text);
			GlobalVar.PeacelikePoints += Convert.ToInt16(GlobalVar.combinedEyePoints);

			#endregion

			#region Adjust value for War and Peace

			// Adjust value for War and Peace
			textBoxTotalWarPoints.Text = "0";
			textBoxTotalPeacePoints.Text = "0";
			if (leftwar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.HighestLeftArmPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.HighestLeftArmPoints).ToString();
			}
			if (rightArmWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.HighestRightArmPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.HighestRightArmPoints).ToString();
			}
			if (jointPainWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxJointPain.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxJointPain.Text)).ToString();
			}
			if (thoracoWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.TheracoHighestPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.TheracoHighestPoints).ToString();
			}
			if (legWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.HighestLegPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.HighestLegPoints).ToString();
			}
			if (tinnitusWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxTinnitus.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxTinnitus.Text)).ToString();
			}
			if (earsWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxEars.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxEars.Text)).ToString();
			}
			if (noseWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxNose.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxNose.Text)).ToString();
			}
			if (throatWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxThroat.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxThroat.Text)).ToString();
			}
			if (cervicalSpineWar == 1)
			{
				textBoxTotalWarPoints.Text =
					(Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxCervicalSpine.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxCervicalSpine.Text)).ToString();
			}
			if (checkBoxEyesWar.Checked)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.combinedEyePoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text =
					(Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.combinedEyePoints).ToString();
			}

			#endregion

		}

		#endregion

		#region Eye Conversion for chart

		public static void EyeConversion(out int eyeConversion, decimal combinedEyePoints)
		{
			var eyeConversionInt = Convert.ToInt16(combinedEyePoints);
			switch (eyeConversionInt)
			{
				case 0:
					eyeConversion = 0;
					break;
				case 5:
					eyeConversion = 1;
					break;
				case 10:
					eyeConversion = 2;
					break;
				case 15:
					eyeConversion = 3;
					break;
				case 20:
					eyeConversion = 4;
					break;
				case 25:
					eyeConversion = 5;
					break;
				case 30:
					eyeConversion = 6;
					break;
				case 35:
					eyeConversion = 7;
					break;
				case 40:
					eyeConversion = 8;
					break;
				case 45:
					eyeConversion = 9;
					break;
				case 50:
					eyeConversion = 10;
					break;
				case 55:
					eyeConversion = 11;
					break;
				case 60:
					eyeConversion = 12;
					break;
				case 65:
					eyeConversion = 13;
					break;
				case 70:
					eyeConversion = 14;
					break;
				case 75:
					eyeConversion = 15;
					break;
				case 80:
					eyeConversion = 16;
					break;
				case 85:
					eyeConversion = 17;
					break;
				case 90:
					eyeConversion = 18;
					break;
				case 95:
					eyeConversion = 19;
					break;
				case 100:
					eyeConversion = 20;
					break;
				default:
					eyeConversion = 0;
					break;
			}
		}

		#endregion

		// Add to this when adding new injury types
		#region Total Combined Point

		private void combinedPoints()
		{
			//Add a line per claim.
			decimal combinedPoints;
			combinedPoints =
				Math.Round(GlobalVar.HighestLeftArmPoints +
				           Convert.ToDecimal(textBoxJointPain.Text)*(1 - Convert.ToDecimal(GlobalVar.leftArmHighestPointsWar)/100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.HighestRightArmPoints*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.TheracoHighestPoints*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxCervicalSpine.Text)*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.HighestLegPoints*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxTinnitus.Text)*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxEars.Text)*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxNose.Text)*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxThroat.Text)*(1 - combinedPoints/100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.combinedEyePoints*(1 - combinedPoints/100));

			textBoxComibinedPoints.Text = combinedPoints.ToString();
		}

		#endregion

		#region Final Compensation Factor

		private void finalCompensationFactor()
		{
			try
			{
				decimal combinedCompensation;
				combinedCompensation = ((Convert.ToDecimal(textBoxTotalWarPoints.Text)*
				                         Convert.ToDecimal(textBoxCompensationFactorWar.Text)) +
				                        (Convert.ToDecimal(textBoxTotalPeacePoints.Text)*
				                         Convert.ToDecimal(textBoxCompensationFactorPeace.Text)))/
				                       (Convert.ToDecimal(textBoxTotalWarPoints.Text) +
				                        Convert.ToDecimal(textBoxTotalPeacePoints.Text));
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
			if (Convert.ToInt16(textBoxComibinedPoints.Text) > 80)
			{
				textBoxComibinedPoints.Text = "80";
			}
			if (Convert.ToInt16(textBoxComibinedPoints.Text) > 0)
			{
				textBoxCompensationFactorWar.Text =
					GlobalVar.ExcelData[0][Convert.ToInt16(textBoxComibinedPoints.Text) - 4][
						Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}
			else
			{
				textBoxCompensationFactorWar.Text =
					GlobalVar.ExcelData[0][Convert.ToInt16(textBoxComibinedPoints.Text)][
						Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}

			if (Convert.ToInt16(textBoxComibinedPoints.Text) > 0)
			{
				textBoxCompensationFactorPeace.Text =
					GlobalVar.ExcelData[1][Convert.ToInt16(textBoxComibinedPoints.Text) - 4][
						Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}
			else
			{
				textBoxCompensationFactorPeace.Text =
					GlobalVar.ExcelData[1][Convert.ToInt16(textBoxComibinedPoints.Text)][
						Convert.ToInt16(textBoxFinalLifeStylePoint.Text)].ToString();
			}
		}

		#endregion

		#region Update All

		private void UpdateAll()
		{
			FinalPayout();
			combinedPoints();
			totalPoint();
			finalCompensationFactor();
			textBoxWeeklyPayout.Text =
				(Math.Round(Convert.ToDecimal(textBoxFinalCompensationFactor.Text)*Convert.ToDecimal(textBoxWeeklyPayment.Text), 2))
					.ToString();
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
				textBoxLumpSumPayout.Text =
					(Math.Round(Convert.ToDecimal(GlobalVar.ExcelData[2][0][sex])*Convert.ToDecimal(textBoxWeeklyPayout.Text), 2))
						.ToString();
			}
			else
			{
				if (Convert.ToInt16(comboBoxAge.Text) > 89)
					textBoxLumpSumPayout.Text =
						(Math.Round(Convert.ToDecimal(GlobalVar.ExcelData[2][59][sex])*Convert.ToDecimal(textBoxWeeklyPayout.Text), 2))
							.ToString();
				else
				{
					textBoxLumpSumPayout.Text =
						(Math.Round(
							Convert.ToDecimal(GlobalVar.ExcelData[2][Convert.ToInt16(comboBoxAge.Text) - 31][sex])*
							Convert.ToDecimal(textBoxWeeklyPayout.Text), 2)).ToString();
				}
			}
			Visability();

		}
		#endregion

		#region Check Visability

		private void Visability()
		{

			if (textBoxShoulder.Text != "0")
			{
				textBoxShoulder.Visible = true;
				checkBoxShoulderWar.Visible = true;
				labelLeftShoulder.Visible = true;
			}
			else
			{
				textBoxShoulder.Visible = false;
				checkBoxShoulderWar.Visible = false;
				labelLeftShoulder.Visible = false;
			}
			if (textBoxRightShoulder.Text != "0")
			{
				textBoxRightShoulder.Visible = true;
				checkBoxRightShoulderWar.Visible = true;
				labelRightShoulder.Visible = true;
			}
			else
			{
				textBoxRightShoulder.Visible = false;
				checkBoxRightShoulderWar.Visible = false;
				labelRightShoulder.Visible = false;
			}
			if (textBoxKnee.Text != "0")
			{
				textBoxKnee.Visible = true;
				checkBoxKneeWar.Visible = true;
				labelKnees.Visible = true;
			}
			else
			{
				textBoxKnee.Visible = false;
				checkBoxKneeWar.Visible = false;
				labelKnees.Visible = false;
			}
			if (textBoxWrist.Text != "0")
			{
				textBoxWrist.Visible = true;
				checkBoxWristWar.Visible = true;
				labelLeftWrist.Visible = true;
			}
			else
			{
				textBoxWrist.Visible = false;
				checkBoxWristWar.Visible = false;
				labelLeftWrist.Visible = false;
			}
			if (textBoxRightWrist.Text != "0")
			{
				textBoxRightWrist.Visible = true;
				checkBoxRightWristWar.Visible = true;
				labelRightWrist.Visible = true;
			}
			else
			{
				textBoxRightWrist.Visible = false;
				checkBoxRightWristWar.Visible = false;
				labelRightWrist.Visible = false;
			}
			if (textBoxFingers.Text != "0")
			{
				textBoxFingers.Visible = true;
				checkBoxFingersWar.Visible = true;
				labelLeftFingers.Visible = true;
			}
			else
			{
				textBoxFingers.Visible = false;
				checkBoxFingersWar.Visible = false;
				labelLeftFingers.Visible = false;
			}
			if (textBoxRightFingers.Text != "0")
			{
				textBoxRightFingers.Visible = true;
				checkBoxRightFingersWar.Visible = true;
				labelRightFingers.Visible = true;
			}
			else
			{
				textBoxRightFingers.Visible = false;
				checkBoxRightFingersWar.Visible = false;
				labelRightFingers.Visible = false;
			}
			if (textBoxElbow.Text != "0")
			{
				textBoxElbow.Visible = true;
				checkBoxElbowWar.Visible = true;
				labelLeftElbow.Visible = true;
			}
			else
			{
				textBoxElbow.Visible = false;
				checkBoxElbowWar.Visible = false;
				labelLeftElbow.Visible = false;
			}
			if (textBoxRightElbow.Text != "0")
			{
				textBoxRightElbow.Visible = true;
				checkBoxRightElbowWar.Visible = true;
				labelRightElbow.Visible = true;
			}
			else
			{
				textBoxRightElbow.Visible = false;
				checkBoxRightElbowWar.Visible = false;
				labelRightElbow.Visible = false;
			}
			if (textBoxHip.Text != "0")
			{
				textBoxHip.Visible = true;
				checkBoxHipWar.Visible = true;
			}
			else
			{
				textBoxHip.Visible = false;
				checkBoxHipWar.Visible = false;
			}
			if (textBoxAnkle.Text != "0")
			{
				textBoxAnkle.Visible = true;
				checkBoxAnkleWar.Visible = true;
				labelAnkles.Visible = true;
			}
			else
			{
				textBoxAnkle.Visible = false;
				checkBoxAnkleWar.Visible = false;
				labelAnkles.Visible = false;
			}
			if (textBoxToes.Text != "0")
			{
				textBoxToes.Visible = true;
				checkBoxToesWar.Visible = true;
				labelToes.Visible = true;
			}
			else
			{
				textBoxToes.Visible = false;
				checkBoxToesWar.Visible = false;
				labelToes.Visible = false;
			}
			if (textBoxWholeLeftArm.Text != "0")
			{
				textBoxWholeLeftArm.Visible = true;
				checkBoxWholeLeftArmWar.Visible = true;
			}
			else
			{
				textBoxWholeLeftArm.Visible = false;
				checkBoxWholeLeftArmWar.Visible = false;
			}
			if (textBoxWholeRightArm.Text != "0")
			{
				textBoxWholeRightArm.Visible = true;
				checkBoxWholeRightArmWar.Visible = true;
			}
			else
			{
				textBoxWholeRightArm.Visible = false;
				checkBoxWholeRightArmWar.Visible = false;
			}
			if (textBoxWholeLimb.Text != "0")
			{
				textBoxWholeLimb.Visible = true;
				checkBoxWholeLimbWar.Visible = true;
			}
			else
			{
				textBoxWholeLimb.Visible = false;
				checkBoxWholeLimbWar.Visible = false;
			}
			if (textBoxJointPain.Text != "0")
			{
				textBoxJointPain.Visible = true;
				checkBoxJointPainWar.Visible = true;
			}
			else
			{
				textBoxJointPain.Visible = false;
				checkBoxJointPainWar.Visible = false;
			}
			if (textBoxThoracoROM.Text != "0")
			{
				textBoxThoracoROM.Visible = true;
				checkBoxThoracoROMWar.Visible = true;
			}
			else
			{
				textBoxThoracoROM.Visible = false;
				checkBoxThoracoROMWar.Visible = false;
			}
			if (textBoxCervicalSpine.Text != "0")
			{
				textBoxCervicalSpine.Visible = true;
				checkBoxCervicalSpineWar.Visible = true;
			}
			else
			{
				textBoxCervicalSpine.Visible = false;
				checkBoxCervicalSpineWar.Visible = false;
			}
			if (textBoxThoraco.Text != "0")
			{
				textBoxThoraco.Visible = true;
				checkBoxThoracoWar.Visible = true;
			}
			else
			{
				textBoxThoraco.Visible = false;
				checkBoxThoracoWar.Visible = false;
			}
			if (textBoxThroat.Text != "0")
			{
				textBoxThroat.Visible = true;
				checkBoxThroatWar.Visible = true;
				labelThroat.Visible = true;
			}
			else
			{
				textBoxThroat.Visible = false;
				checkBoxThroatWar.Visible = false;
				labelThroat.Visible = false;
			}
			if (textBoxNose.Text != "0")
			{
				textBoxNose.Visible = true;
				checkBoxNoseWar.Visible = true;
				labelNose.Visible = true;
			}
			else
			{
				textBoxNose.Visible = false;
				checkBoxNoseWar.Visible = false;
				labelNose.Visible = false;
			}
			if (textBoxEars.Text != "0")
			{
				textBoxEars.Visible = true;
				checkBoxEarsWar.Visible = true;
				labelHearingLoss.Visible = true;
			}
			else
			{
				textBoxEars.Visible = false;
				checkBoxEarsWar.Visible = false;
				labelHearingLoss.Visible = false;
			}
			if (textBoxTinnitus.Text != "0")
			{
				textBoxTinnitus.Visible = true;
				checkBoxTinnitusWar.Visible = true;
				labelTinnitus.Visible = true;
			}
			else
			{
				textBoxTinnitus.Visible = false;
				checkBoxTinnitusWar.Visible = false;
				labelTinnitus.Visible = false;
			}
			if (textBoxFinalEyes.Text != "0")
			{
				textBoxFinalEyes.Visible = true;
				checkBoxEyesWar.Visible = true;
				labelEyes.Visible = true;
			}
			else
			{
				textBoxFinalEyes.Visible = false;
				checkBoxEyesWar.Visible = false;
				labelEyes.Visible = false;
			}

		}

		#endregion

		#region Misc

		private void comboBoxAge_SelectedValueChanged(object sender, EventArgs e)
		{
			comboBoxAge_Leave(null, null);
		}

		private void comboBoxAge_KeyUp(object sender, KeyEventArgs e)
		{
			comboBoxAge_Leave(null, null);
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
			comboBoxAge_Leave(null, null);
		}

		#endregion

		#region Print Summary Page

		private void buttonPrint_Click(object sender, EventArgs e)
		{
			var printSummary = new PrintSummary();
			printSummary.ShowDialog();
		}

		#endregion

		#region Life Style Assessment

		private void buttonLifeStyle_Click(object sender, EventArgs e)
		{
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			var lifeStyle = new LifeStyle();
			lifeStyle.ShowDialog();
			textBoxFinalLifeStylePoint.Text = GlobalVar.FinalLifeStylePoint;
			UpdateAll();
			UpdateAll();
		}
		#endregion

		#region Drag Main Form around

		public static bool dragging;

		public static int offsetX;

		public static int offsetY;

		private void buttonMainTitle_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				dragging = true;
				offsetX = e.X;
				offsetY = e.Y;
			}
		}

		private void buttonMainTitle_MouseMove(object sender, MouseEventArgs e)
		{
			if (dragging)
			{
				Left = e.X + Left - offsetX;
				Top = e.Y + Top - offsetY;
			}
		}

		private void buttonMainTitle_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				dragging = false;
			}
		}

		private void buttonDVALinks_Click(object sender, EventArgs e)
		{
			var dVALinks = new DVALinks();
			dVALinks.ShowDialog();
		}
		#endregion

		#region Important Information
		private void buttonImportantInformation_Click(object sender, EventArgs e)
		{
			var importantInformation = new ImportantInformation();
			importantInformation.ShowDialog();
		}
		#endregion

		#region Close Application
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
			//var save = MessageBox.Show(@"Would you like to save all Settings on exit?", @"Save", MessageBoxButtons.YesNoCancel);
				switch (SaveMessage.SaveClose)
				{
					case 0:
						e.Cancel = true;
						break;
					case 1:
						Save();
						break;
					case 2:
						break;
				}
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			var saveMessage = new SaveMessage();
			saveMessage.ShowDialog();
			Close();
		}

		#endregion

		// Add to this when adding new injury types
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
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxWholeRightArm", textBoxWholeRightArm.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "WholeRightArm", WholeArm.wholeRightArm);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWholeRightArmWar", checkBoxWholeRightArmWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "textBoxWholeLeftArm", textBoxWholeLeftArm.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "WholeLeftArm", WholeArm.wholeLeftArm);
			profile.PutSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWholeLeftArmWar", checkBoxWholeLeftArmWar.Checked.ToString());

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
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "textBoxThoracoROM", textBoxThoracoROM.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "ThoracoROM", ThoracoROM.thoracoROM);
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "checkBoxThoracoROMWar", checkBoxThoracoROMWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "textBoxCervicalSpine", textBoxCervicalSpine.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "Cervical", Cervical.cervical);
			profile.PutSetting(XmlProfileSettings.SettingType.Back, "checkBoxCervicalSpineWar", checkBoxCervicalSpineWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "textBoxTinnitus", textBoxTinnitus.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "Tinnitus", Ears.tinnitus);
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "checkBoxTinnitusWar", checkBoxTinnitusWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "textBoxEars", textBoxEars.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "Ears", Ears.ears);
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "checkBoxEarsWar", checkBoxEarsWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.Nose, "textBoxNose", textBoxNose.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Nose, "Nose", Nose.nose);
			profile.PutSetting(XmlProfileSettings.SettingType.Nose, "checkBoxNoseWar", checkBoxNoseWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.Throat, "textBoxThroat", textBoxThroat.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Throat, "Throat", Throat.throat);
			profile.PutSetting(XmlProfileSettings.SettingType.Throat, "checkBoxThroatWar", checkBoxThroatWar.Checked.ToString());

			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftEyeConversion", GlobalVar.LeftEyeConversion.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightEyeConversion", GlobalVar.RightEyeConversion.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "combinedEyePoints", GlobalVar.combinedEyePoints.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxEyesWar", checkBoxEyesWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxFinalEyes", textBoxFinalEyes.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "EyeWar", GlobalVar.EyeWar);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightMonocular", GlobalVar.RightMonocular);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightVisualFOL", GlobalVar.RightVisualFOL);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightMiscVisual", GlobalVar.RightMiscVisual);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightOtherOcular", GlobalVar.RightOtherOcular);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftMonocular", GlobalVar.LeftMonocular);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftVisualFOL", GlobalVar.LeftVisualFOL);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftMiscVisual", GlobalVar.LeftMiscVisual);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftOtherOcular", GlobalVar.LeftOtherOcular);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftEye", VisualFOL.LeftEye);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightEye", VisualFOL.RightEye);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftOcular", OcularImpairment.LeftOcular);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightOcular", OcularImpairment.RightOcular);

			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxFinalLifeStylePoint", textBoxFinalLifeStylePoint.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxPersonalRelationships", GlobalVar.personalRelationships);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxMobility", GlobalVar.Mobility);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxRecreationalActivities", GlobalVar.RecreationalActivities);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxDomesticActivities", GlobalVar.DomesticActivities);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "textBoxEmploymentActivities", GlobalVar.EmploymentActivities);
			profile.PutSetting(XmlProfileSettings.SettingType.LifeStyle, "FinalLifeStylePoint", GlobalVar.FinalLifeStylePoint);

			profile.PutSetting(XmlProfileSettings.SettingType.Other, "textBoxJointPain", textBoxJointPain.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Other, "JointPain", JointPain.jointPain);

			var okMessage = new OkMessage();
			okMessage.ShowDialog();
		}

		private void SaveAll_Click(object sender, EventArgs e)
		{
			Save();
		}
		#endregion

		//Condition Types
		#region Condition Type
		#region Back

		private void buttonThoracoROM_Click(object sender, EventArgs e)
		{
			var thoracoROM = new ThoracoROM();
			thoracoROM.ShowDialog();
			textBoxThoracoROM.Text = GlobalVar.ExcelData[4][ThoracoROM.thoracoROM][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonThoracoROM_MouseEnter(object sender, EventArgs e)
		{
			buttonThoracoROM.BackgroundImage = Resources.Thoraco;
			toolTip1.Show("Thoraco - Lumbar Spine", buttonThoracoROM, 30, -10, 10000);
		}

		private void buttonThoracoROM_MouseLeave(object sender, EventArgs e)
		{
			buttonThoracoROM.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonThoracoROM);
		}

		private void buttonCervical_MouseEnter(object sender, EventArgs e)
		{
			buttonCervical.BackgroundImage = Resources.Cervical;
			toolTip1.Show("Cervical Spine", buttonCervical, 30, -10, 10000);
		}

		private void buttonCervical_MouseLeave(object sender, EventArgs e)
		{
			buttonCervical.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonCervical);
		}

		private void buttonThroat_MouseEnter(object sender, EventArgs e)
		{
			buttonThroat.BackgroundImage = Resources.Throat;
			toolTip1.Show("Throat", buttonThroat, 30, -10, 10000);
		}

		private void buttonThroat_MouseLeave(object sender, EventArgs e)
		{
			buttonThroat.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonThroat);
		}

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

		private void buttonCervicalSpine_Click(object sender, EventArgs e)
		{
			var cervical = new Cervical();
			cervical.ShowDialog();
			textBoxCervicalSpine.Text = GlobalVar.ExcelData[4][Cervical.cervical][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxCervicalSpine_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxCervicalSpineWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxThoracoROM_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxThoracoROM_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Life Style
		private void textBoxFinalLifeStylePoint_TextChanged(object sender, EventArgs e)
		{
			FinalPayout();
		}
		#endregion

		#region Lower Body

		#region Knee

		private void buttonLeftKnee_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftKnee.BackgroundImage = Resources.Blank;
			buttonRightKnee.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightKnee);
		}

		private void buttonLeftKnee_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftKnee.BackgroundImage = Resources.LeftKnee;
			buttonRightKnee.BackgroundImage = Resources.RightKnee;
			toolTip1.Show("Knees", buttonRightKnee, 30, -10, 10000);
		}

		private void buttonRightKnee_MouseEnter(object sender, EventArgs e)
		{
			buttonRightKnee.BackgroundImage = Resources.RightKnee;
			buttonLeftKnee.BackgroundImage = Resources.LeftKnee;
			toolTip1.Show("Knees", buttonRightKnee, 30, -10, 10000);
		}

		private void buttonRightKnee_MouseLeave(object sender, EventArgs e)
		{
			buttonRightKnee.BackgroundImage = Resources.Blank;
			buttonLeftKnee.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightKnee);
		}

		private void buttonLeftKnee_Click(object sender, EventArgs e)
		{
			var knee = new Knee();
			knee.ShowDialog();
			textBoxKnee.Text = GlobalVar.ExcelData[4][Knee.knee][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightKnee_Click(object sender, EventArgs e)
		{
			var knee = new Knee();
			knee.ShowDialog();
			textBoxKnee.Text = GlobalVar.ExcelData[4][Knee.knee][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void checkBoxKneeWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxKnee_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Hip
		private void buttonRightHip_MouseEnter(object sender, EventArgs e)
		{
			buttonRightHip.BackgroundImage = Resources.RightHip;
			buttonLeftHip.BackgroundImage = Resources.LeftHip;
			toolTip1.Show("Hips", buttonRightHip, -27, 35, 10000);
		}

		private void buttonRightHip_MouseLeave(object sender, EventArgs e)
		{
			buttonRightHip.BackgroundImage = Resources.Blank;
			buttonLeftHip.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightHip);
		}

		private void buttonLeftHip_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftHip.BackgroundImage = Resources.LeftHip;
			buttonRightHip.BackgroundImage = Resources.RightHip;
			toolTip1.Show("Hips", buttonRightHip, -27, 35, 10000);
		}

		private void buttonLeftHip_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftHip.BackgroundImage = Resources.Blank;
			buttonRightHip.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightHip);
		}

		private void buttonLeftHip_Click(object sender, EventArgs e)
		{
			var hip = new Hip();
			hip.ShowDialog();
			textBoxHip.Text = GlobalVar.ExcelData[4][Hip.hip][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightHip_Click(object sender, EventArgs e)
		{
			var hip = new Hip();
			hip.ShowDialog();
			textBoxHip.Text = GlobalVar.ExcelData[4][Hip.hip][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void checkBoxHipWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxHip_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}
		#endregion

		#region Ankle

		private void buttonLeftAnkle_Click(object sender, EventArgs e)
		{
			var ankle = new Ankle();
			ankle.ShowDialog();
			textBoxAnkle.Text = GlobalVar.ExcelData[4][Ankle.ankle][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonLeftAnkle_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftAnkle.BackgroundImage = Resources.LeftAnkle;
			buttonRightAnkle.BackgroundImage = Resources.RightAnkle;
			toolTip1.Show("Ankles", buttonRightAnkle, 30, -10, 10000);
		}

		private void buttonLeftAnkle_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftAnkle.BackgroundImage = Resources.Blank;
			buttonRightAnkle.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightAnkle);
		}

		private void buttonRightAnkle_Click(object sender, EventArgs e)
		{
			var ankle = new Ankle();
			ankle.ShowDialog();
			textBoxAnkle.Text = GlobalVar.ExcelData[4][Ankle.ankle][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightAnkle_MouseEnter(object sender, EventArgs e)
		{
			buttonRightAnkle.BackgroundImage = Resources.RightAnkle;
			buttonLeftAnkle.BackgroundImage = Resources.LeftAnkle;
			toolTip1.Show("Ankles", buttonRightAnkle, 30, -10, 10000);
		}

		private void buttonRightAnkle_MouseLeave(object sender, EventArgs e)
		{
			buttonRightAnkle.BackgroundImage = Resources.Blank;
			buttonLeftAnkle.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightAnkle);
		}

		private void checkBoxAnkleWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxAnkle_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Toes

		private void buttonLeftToes_Click(object sender, EventArgs e)
		{
			var toes = new Toes();
			toes.ShowDialog();
			textBoxToes.Text = GlobalVar.ExcelData[4][Toes.toes][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonLeftToes_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftToes.BackgroundImage = Resources.LeftToes;
			buttonRightToes.BackgroundImage = Resources.RightToes;
			toolTip1.Show("Toes", buttonRightToes, 30, -10, 10000);
		}

		private void buttonLeftToes_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftToes.BackgroundImage = Resources.Blank;
			buttonRightToes.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightToes);
		}

		private void buttonRightToes_Click(object sender, EventArgs e)
		{
			var toes = new Toes();
			toes.ShowDialog();
			textBoxToes.Text = GlobalVar.ExcelData[4][Toes.toes][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightToes_MouseEnter(object sender, EventArgs e)
		{
			buttonRightToes.BackgroundImage = Resources.RightToes;
			buttonLeftToes.BackgroundImage = Resources.LeftToes;
			toolTip1.Show("Toes", buttonRightToes, 30, -10, 10000);
		}

		private void buttonRightToes_MouseLeave(object sender, EventArgs e)
		{
			buttonRightToes.BackgroundImage = Resources.Blank;
			buttonLeftToes.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightToes);
		}

		private void checkBoxToesWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxToes_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Whole Lower Limb

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

		#region Fingers

		private void buttonRightFingers_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightFingers";
			var fingers = new Fingers();
			fingers.ShowDialog();
			textBoxRightFingers.Text = GlobalVar.ExcelData[4][Fingers.RightFingers][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightFingers_MouseEnter(object sender, EventArgs e)
		{
			buttonRightFingers.BackgroundImage = Resources.RightFingers;
			toolTip1.Show("Fingers", buttonRightFingers, 30, -10, 10000);
		}

		private void buttonRightFingers_MouseLeave(object sender, EventArgs e)
		{
			buttonRightFingers.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightFingers);
		}

		private void buttonLeftFingers_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftFingers";
			var fingers = new Fingers();
			fingers.ShowDialog();
			textBoxFingers.Text = GlobalVar.ExcelData[4][Fingers.LeftFingers][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonLeftFingers_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftFingers.BackgroundImage = Resources.LeftFingers;
			toolTip1.Show("Fingers", buttonLeftFingers, -65, -10, 10000);
		}

		private void buttonLeftFingers_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftFingers.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonLeftFingers);
		}
		private void textBoxFingers_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxFingersWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Elbow

		private void buttonLeftElbow_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftElbow";
			var ebow = new Elbow();
			ebow.ShowDialog();
			textBoxElbow.Text = GlobalVar.ExcelData[4][Elbow.LeftElbow][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonLeftElbow_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftElbow.BackgroundImage = Resources.LeftElbow;
			toolTip1.Show("Elbow", buttonLeftElbow, -60, -10, 10000);
		}

		private void buttonLeftElbow_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftElbow.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonLeftElbow);
		}

		private void textBoxElbow_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}
		private void checkBoxElbowWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

#endregion

		#region Whole Arm

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

#endregion

		#region Shoulder

		private void buttonLeftShoulder_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftShoulder";
			var shoulder = new Shoulder();
			shoulder.ShowDialog();
			textBoxShoulder.Text = GlobalVar.ExcelData[4][Shoulder.LeftShoulder][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonLeftShoulder_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftShoulder.BackgroundImage = Resources.LeftShoulder;
			toolTip1.Show("Shoulder", buttonLeftShoulder, -65, -10, 10000);

		}

		private void buttonLeftShoulder_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftShoulder.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonLeftShoulder);
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

		private void buttonRightShoulder_MouseEnter(object sender, EventArgs e)
		{
			buttonRightShoulder.BackgroundImage = Resources.RightShoulder;
			toolTip1.Show("Shoulder", buttonRightShoulder, 30, -10, 10000);
		}

		private void buttonRightShoulder_MouseLeave(object sender, EventArgs e)
		{
			buttonRightShoulder.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightShoulder);
		}

		private void textBoxShoulder_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxShoulderWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

#endregion

		#region Wrist

		private void buttonLeftWrist_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftWrist";
			var wrist = new Wrist();
			wrist.ShowDialog();
			textBoxWrist.Text = GlobalVar.ExcelData[4][Wrist.LeftWrist][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonLeftWrist_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftWrist.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonLeftWrist);
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

		private void buttonRightWrist_MouseEnter(object sender, EventArgs e)
		{
			buttonRightWrist.BackgroundImage = Resources.RightWrist;
			toolTip1.Show("Wrist", buttonRightWrist, 30, -10, 10000);
		}

		private void buttonRightWrist_MouseLeave(object sender, EventArgs e)
		{
			buttonRightWrist.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightWrist);
		}

		private void buttonLeftWrist_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftWrist.BackgroundImage = Resources.LeftWrist;
			toolTip1.Show("Wrist", buttonLeftWrist, -60, -10, 10000);
		}

		private void textBoxWrist_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxWristWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}
#endregion
		
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

		private void buttonRightElbow_MouseEnter(object sender, EventArgs e)
		{
			buttonRightElbow.BackgroundImage = Resources.RightElbow;
			toolTip1.Show("Elbow", buttonRightElbow, 30, -10, 10000);
		}

		private void buttonRightElbow_MouseLeave(object sender, EventArgs e)
		{
			buttonRightElbow.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightElbow);
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

		#region Ear, Nose and Throat

		#region Tennitus

		private void buttonTinnitus_Click(object sender, EventArgs e)
		{
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

		#region Ears

		private void buttonLeftEar_Click(object sender, EventArgs e)
		{
			var ears = new Ears();
			ears.ShowDialog();
			textBoxEars.Text = Ears.ears.ToString(); //No age adjustment
			textBoxTinnitus.Text = Ears.tinnitus.ToString(); //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonLeftEar_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftEar.BackgroundImage = Resources.LeftEar;
			buttonRightEar.BackgroundImage = Resources.RightEar;
			toolTip1.Show("Hearing", buttonLeftEar, -65, -10, 10000);
		}

		private void buttonLeftEar_MouseLeave(object sender, EventArgs e)
		{
			buttonRightEar.BackgroundImage = Resources.Blank;
			buttonLeftEar.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightEar);
		}

		private void buttonRightEar_Click(object sender, EventArgs e)
		{
			var ears = new Ears();
			ears.ShowDialog();
			textBoxEars.Text = Ears.ears.ToString(); //No age adjustment
			textBoxTinnitus.Text = Ears.tinnitus.ToString(); //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightEar_MouseEnter(object sender, EventArgs e)
		{
			buttonRightEar.BackgroundImage = Resources.RightEar;
			buttonLeftEar.BackgroundImage = Resources.LeftEar;
			toolTip1.Show("Hearing", buttonRightEar, 30, -10, 10000);
		}

		private void buttonRightEar_MouseLeave(object sender, EventArgs e)
		{
			buttonRightEar.BackgroundImage = Resources.Blank;
			buttonLeftEar.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightEar);
		}

		private void textBoxEars_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxEarsWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Nose
		private void buttonNose_Click(object sender, EventArgs e)
		{
			var nose = new Nose();
			nose.ShowDialog();
			textBoxNose.Text = Nose.nose.ToString(); //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void buttonNose_MouseEnter(object sender, EventArgs e)
		{
			buttonNose.BackgroundImage = Resources.Nose;
			toolTip1.Show("Nose", buttonNose, 50, -10, 10000);
		}

		private void buttonNose_MouseLeave(object sender, EventArgs e)
		{
			buttonNose.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonNose);
		}


		private void textBoxNose_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxNoseWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}
		#endregion

		#region Throat

		private void buttonThroat_Click(object sender, EventArgs e)
		{
			var throat = new Throat();
			throat.ShowDialog();
			textBoxThroat.Text = Throat.throat.ToString();  //No age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxThroat_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxThroatWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}
		#endregion

		#endregion
		
		#region Eye

		private void buttonLeftEye_Click(object sender, EventArgs e)
		{
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			var rightEye = new RightEye();
			rightEye.ShowDialog();
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightEye_Click(object sender, EventArgs e)
		{
			GlobalVar.MainFormLocxationX = Location.X;
			GlobalVar.MainFormLocxationY = Location.Y;
			var leftEye = new LeftEye();
			leftEye.ShowDialog();
			UpdateAll();
			UpdateAll();
		}

		private void textBoxFinalEyes_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxEyesWar_CheckedChanged(object sender, EventArgs e)
		{

			UpdateAll();
		}

		private void buttonLeftEye_MouseEnter(object sender, EventArgs e)
		{
			buttonLeftEye.BackgroundImage = Resources.LeftEye;
			toolTip1.Show("Eye", buttonLeftEye, -55, -10, 10000);
		}

		private void buttonLeftEye_MouseLeave(object sender, EventArgs e)
		{
			buttonLeftEye.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonLeftEye);
		}

		private void buttonRightEye_MouseEnter(object sender, EventArgs e)
		{
			buttonRightEye.BackgroundImage = Resources.RightEye;
			toolTip1.Show("Eye", buttonRightEye, 30, -10, 10000);
		}

		private void buttonRightEye_MouseLeave(object sender, EventArgs e)
		{
			buttonRightEye.BackgroundImage = Resources.Blank;
			toolTip1.Hide(buttonRightEye);
		}
		#endregion
		#endregion

	}
}
