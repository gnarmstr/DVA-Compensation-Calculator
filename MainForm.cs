		#region Using

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
using System.Windows.Forms.VisualStyles;
using Common.Resources;
using Common.Resources.Properties;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.IO;
using Application = System.Windows.Forms.Application;
using System.Diagnostics;

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
			DVALinks();
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
			MinimumSize = new Size(730, 720);
			GlobalVar.SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DVA Compensation Calculator");
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

			listViewSummary.Columns.Add("CONDITION", 120, HorizontalAlignment.Left);
			listViewSummary.Columns.Add("RATING", 120, HorizontalAlignment.Left);
			listViewSummary1.Columns.Add("CONDITION", 120, HorizontalAlignment.Left);
			listViewSummary1.Columns.Add("RATING", 120, HorizontalAlignment.Left);

			
		}
		#endregion

		#region DVA LINKS

		private void DVALinks()
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

		private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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

		#endregion

		// Add to this when adding new injury types
		#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();
			comboBoxAge.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxAge", "50");
			textBoxWeeklyPayment.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxWeeklyPayment", "324.60");
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
			checkBoxWholeRightArmWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWholeRightArmWar", false);
			textBoxWholeRightArm.Text = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "WholeRightArm", "0");
			checkBoxWholeLeftArmWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.UpperLimb, "checkBoxWholeLeftArmWar", false);
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
			checkBoxWholeLimbWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.LowerLimb, "checkBoxWholeLimbWar", false);

			textBoxThoraco.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxThoraco", "0");
			ThoracoLumbar.thoracoLumbar = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "thoracoLumbar", "0"));
			checkBoxThoracoWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxThoracoWar", false);
			textBoxThoracoROM.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxThoracoROM", "0");
			ThoracoROM.thoracoROM = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "ThoracoROM", "0"));
			checkBoxThoracoROMWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxThoracoROMWar", false);
			textBoxCervicalSpine.Text = profile.GetSetting(XmlProfileSettings.SettingType.Back, "textBoxCervicalSpine", "0");
			Cervical.cervical = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Back, "Cervical", "0"));
			checkBoxCervicalSpineWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Back, "checkBoxCervicalSpineWar", false);

			textBoxTinnitus.Text = profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "textBoxTinnitus", "0");
			Tinnitus.tinnitus = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Hearing, "Tinnitus", "0"));
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
			
			textBoxLeftMonocular.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftMonocular", "0");
			comboBoxLeftMonocular.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxLeftMonocular", "6/6");
			checkBoxLeftMonocularWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftMonocularWar", false);
			textBoxRightMonocular.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightMonocular", "0");
			comboBoxRightMonocular.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxRightMonocular", "6/6");
			checkBoxRightMonocularWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightMonocularWar", false);
			textBoxLeftVisualFOL.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftVisualFOL", "0");
			VisualFOL.LeftEye = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftEye", "0"));
			checkBoxLeftVisualFOLWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftVisualFOLWar", false);
			textBoxRightVisualFOL.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightVisualFOL", "0");
			VisualFOL.RightEye = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightEye", "0"));
			checkBoxRightVisualFOLWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightVisualFOLWar", false);
			textBoxLeftOtherOcular.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftOtherOcular", "0");
			OcularImpairment.LeftOcular = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "LeftOcular", "0"));
			checkBoxLeftOtherOcularWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftOtherOcularWar", false);
			textBoxRightOtherOcular.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightOtherOcular", "0");
			OcularImpairment.RightOcular = Convert.ToInt16(profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "RightOcular", "0"));
			checkBoxRightOtherOcularWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightOtherOcularWar", false);

			textBoxLeftMiscVisual.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftMiscVisual", "0");
			comboBoxLeftMiscVisual.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxLeftMiscVisual", "");
			checkBoxLeftMiscVisualWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftMiscVisualWar", false);
			textBoxRightMiscVisual.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightMiscVisual", "0");
			comboBoxRightMiscVisual.Text = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxRightMiscVisual", "");
			checkBoxRightMiscVisualWar.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightMiscVisualWar", false);

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

		private void comboBoxAge_SelectedValueChanged(object sender, EventArgs e)
		{
			comboBoxAge_Leave(null, null);
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
			GlobalVar.TheracoHighestPoints = Math.Max(Convert.ToInt16(textBoxThoraco.Text), Convert.ToInt16(textBoxThoracoROM.Text));

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
			//Eyes
			//Left Eye
			var eyeWar = 0;
			if (checkBoxLeftMonocularWar.Checked | checkBoxLeftVisualFOLWar.Checked | checkBoxLeftMiscVisualWar.Checked | checkBoxLeftOtherOcularWar.Checked)
			{
				eyeWar = 1;
			}
			GlobalVar.combinedLeftEyePoints = Math.Round(Convert.ToInt16(textBoxLeftVisualFOL.Text) + Convert.ToDecimal(textBoxLeftMonocular.Text) * (1 - Convert.ToDecimal(textBoxLeftVisualFOL.Text) / 100));
			GlobalVar.combinedLeftEyePoints = Math.Round(GlobalVar.combinedLeftEyePoints + Convert.ToInt16(textBoxLeftMiscVisual.Text) * (1 - GlobalVar.combinedLeftEyePoints / 100));
			GlobalVar.combinedLeftEyePoints = Math.Max(GlobalVar.combinedLeftEyePoints, Convert.ToInt16(textBoxLeftOtherOcular.Text));
			GlobalVar.combinedLeftEyePoints = Math.Round(GlobalVar.combinedLeftEyePoints/5)*5; //Round to nearest 5
			//Right Eye
			if (checkBoxRightMonocularWar.Checked | checkBoxRightVisualFOLWar.Checked | checkBoxRightMiscVisualWar.Checked | checkBoxRightOtherOcularWar.Checked)
			{
				eyeWar = 1;
			}
			GlobalVar.combinedRightEyePoints = Math.Round(Convert.ToInt16(textBoxRightVisualFOL.Text) + Convert.ToDecimal(textBoxRightMonocular.Text) * (1 - Convert.ToDecimal(textBoxRightVisualFOL.Text) / 100));
			GlobalVar.combinedRightEyePoints = Math.Round(GlobalVar.combinedRightEyePoints + Convert.ToInt16(textBoxRightMiscVisual.Text) * (1 - GlobalVar.combinedRightEyePoints / 100));
			GlobalVar.combinedRightEyePoints = Math.Max(GlobalVar.combinedRightEyePoints, Convert.ToInt16(textBoxRightOtherOcular.Text));
			GlobalVar.combinedRightEyePoints = Math.Round(GlobalVar.combinedRightEyePoints / 5) * 5; //Round to nearest 5
			//Both Eyes
			int leftEyeConversion;
			int rightEyeConversion;
			EyeConversion(out leftEyeConversion, GlobalVar.combinedLeftEyePoints);
			EyeConversion(out rightEyeConversion, GlobalVar.combinedRightEyePoints);
			GlobalVar.combinedEyePoints = Convert.ToDecimal(GlobalVar.ExcelData[0][leftEyeConversion + 77][rightEyeConversion]);
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
			if (thoracoWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.TheracoHighestPoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.TheracoHighestPoints).ToString();
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
			if (earsWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxEars.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxEars.Text)).ToString();
			}
			if (noseWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxNose.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxNose.Text)).ToString();
			}
			if (throatWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxThroat.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxThroat.Text)).ToString();
			}
			if (cervicalSpineWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + Convert.ToDecimal(textBoxCervicalSpine.Text)).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + Convert.ToDecimal(textBoxCervicalSpine.Text)).ToString();
			}
			if (eyeWar == 1)
			{
				textBoxTotalWarPoints.Text = (Convert.ToInt16(textBoxTotalWarPoints.Text) + GlobalVar.combinedEyePoints).ToString();
			}
			else
			{
				textBoxTotalPeacePoints.Text = (Convert.ToInt16(textBoxTotalPeacePoints.Text) + GlobalVar.combinedEyePoints).ToString();
			}
			#endregion

		}

		#endregion

		#region Eye Conversion for chart

		private void EyeConversion(out int eyeConversion, decimal combinedEyePoints)
		{
			var eyeConversionInt = Convert.ToInt16(combinedEyePoints);
			switch (eyeConversionInt)
			{
				case 0: eyeConversion = 0;
					break;
				case 5: eyeConversion = 1;
					break;
				case 10: eyeConversion = 2;
					break;
				case 15: eyeConversion = 3;
					break;
				case 20: eyeConversion = 4;
					break;
				case 25: eyeConversion = 5;
					break;
				case 30: eyeConversion = 6;
					break;
				case 35: eyeConversion = 7;
					break;
				case 40: eyeConversion = 8;
					break;
				case 45: eyeConversion = 9;
					break;
				case 50: eyeConversion = 10;
					break;
				case 55: eyeConversion = 11;
					break;
				case 60: eyeConversion = 12;
					break;
				case 65: eyeConversion = 13;
					break;
				case 70: eyeConversion = 14;
					break;
				case 75: eyeConversion = 15;
					break;
				case 80: eyeConversion = 16;
					break;
				case 85: eyeConversion = 17;
					break;
				case 90: eyeConversion = 18;
					break;
				case 95: eyeConversion = 19;
					break;
				case 100: eyeConversion = 20;
					break;
				default: eyeConversion = 0;
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
			combinedPoints = Math.Round(GlobalVar.HighestLeftArmPoints + Convert.ToDecimal(textBoxJointPain.Text) * (1 - Convert.ToDecimal(GlobalVar.leftArmHighestPointsWar) / 100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.HighestRightArmPoints * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.TheracoHighestPoints * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxCervicalSpine.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.HighestLegPoints * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxTinnitus.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxEars.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxNose.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + Convert.ToDecimal(textBoxThroat.Text) * (1 - combinedPoints / 100));
			combinedPoints = Math.Round(combinedPoints + GlobalVar.combinedEyePoints * (1 - combinedPoints / 100));
	
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
			if (Convert.ToInt16(textBoxComibinedPoints.Text) > 80)
			{
				textBoxComibinedPoints.Text = "80";
			}
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

			//Add Information on Summary Page
			listViewSummary.Items.Clear();
			listViewSummary.Items.Add(new ListViewItem(new[] { "UPPER LEFT LIMB", "" }));
			if (textBoxElbow.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label9.Text, textBoxElbow.Text }));
			if (textBoxShoulder.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label11.Text, textBoxShoulder.Text }));
			if (textBoxWrist.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label10.Text, textBoxWrist.Text }));
			if (textBoxFingers.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label12.Text, textBoxFingers.Text }));
			if (textBoxWholeLeftArm.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label59.Text, textBoxWholeLeftArm.Text }));
			listViewSummary.Items.Add(new ListViewItem(new[] { "", "" }));
			listViewSummary.Items.Add(new ListViewItem(new[] { "UPPER RIGHT LIMB", "" }));
			if (textBoxRightElbow.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label42.Text, textBoxRightElbow.Text }));
			if (textBoxRightShoulder.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label46.Text, textBoxRightShoulder.Text }));
			if (textBoxRightWrist.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label44.Text, textBoxRightWrist.Text }));
			if (textBoxRightFingers.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label45.Text, textBoxRightFingers.Text }));
			if (textBoxWholeRightArm.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label62.Text, textBoxWholeRightArm.Text }));
			listViewSummary.Items.Add(new ListViewItem(new[] { "", "" }));
			listViewSummary.Items.Add(new ListViewItem(new[] { "LOWER LIMB", "" }));
			if (textBoxKnee.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label7.Text, textBoxKnee.Text }));
			if (textBoxToes.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label17.Text, textBoxToes.Text }));
			if (textBoxHip.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label15.Text, textBoxHip.Text }));
			if (textBoxAnkle.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label16.Text, textBoxAnkle.Text }));
			if (textBoxWholeLimb.Text != "0") listViewSummary.Items.Add(new ListViewItem(new[] { label56.Text, textBoxWholeLimb.Text }));

			//Add Information on Summary1 Page
			listViewSummary1.Items.Clear();
			listViewSummary1.Items.Add(new ListViewItem(new[] { "BACK", "" }));
			if (textBoxCervicalSpine.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { label82.Text, textBoxCervicalSpine.Text }));
			if (textBoxThoracoROM.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { label81.Text, textBoxThoracoROM.Text }));
			if (textBoxThoraco.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { "Thoraco Lumbar:", textBoxThoraco.Text }));
			listViewSummary1.Items.Add(new ListViewItem(new[] { "", "" }));
			listViewSummary1.Items.Add(new ListViewItem(new[] { "EAR, NOSE, THROAT", "" }));
			if (textBoxEars.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { label70.Text, textBoxEars.Text }));
			if (textBoxTinnitus.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { label64.Text, textBoxTinnitus.Text }));
			if (textBoxNose.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { label74.Text, textBoxNose.Text }));
			if (textBoxThroat.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { label77.Text, textBoxThroat.Text }));
			listViewSummary1.Items.Add(new ListViewItem(new[] { "", "" }));
			listViewSummary1.Items.Add(new ListViewItem(new[] { "JOINT PAIN", "" }));
			if (textBoxJointPain.Text != "0") listViewSummary1.Items.Add(new ListViewItem(new[] { label39.Text, textBoxJointPain.Text }));

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
			profile.PutSetting(XmlProfileSettings.SettingType.Hearing, "Tinnitus", Tinnitus.tinnitus);
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

			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftMonocular", textBoxLeftMonocular.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxLeftMonocular", comboBoxLeftMonocular.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftMonocularWar", checkBoxLeftMonocularWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightMonocular", textBoxRightMonocular.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxRightMonocular", comboBoxRightMonocular.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightMonocularWar", checkBoxRightMonocularWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftVisualFOL", textBoxLeftVisualFOL.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftEye", VisualFOL.LeftEye);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftVisualFOLWar", checkBoxLeftVisualFOLWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightVisualFOL", textBoxRightVisualFOL.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightEye", VisualFOL.RightEye);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightVisualFOLWar", checkBoxRightVisualFOLWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftMiscVisual", textBoxLeftMiscVisual.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxLeftMiscVisual", comboBoxLeftMiscVisual.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftMiscVisualWar", checkBoxLeftMiscVisualWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightMiscVisual", textBoxRightMiscVisual.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "comboBoxRightMiscVisual", comboBoxRightMiscVisual.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightMiscVisualWar", checkBoxRightMiscVisualWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxLeftOtherOcular", textBoxLeftOtherOcular.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "LeftOcular", OcularImpairment.LeftOcular);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxLeftOtherOcularWar", checkBoxLeftOtherOcularWar.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "textBoxRightOtherOcular", textBoxRightOtherOcular.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "RightOcular", OcularImpairment.RightOcular);
			profile.PutSetting(XmlProfileSettings.SettingType.Eyes, "checkBoxRightOtherOcularWar", checkBoxRightOtherOcularWar.Checked.ToString());

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

		//Condition Types
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

		private void buttonThoracoROM_Click(object sender, EventArgs e)
		{
			var thoracoROM = new ThoracoROM();
			thoracoROM.ShowDialog();
			textBoxThoracoROM.Text = GlobalVar.ExcelData[4][ThoracoROM.thoracoROM][GlobalVar.AgeAdjustRange].ToString();  //Age adjustment
			UpdateAll();
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

		#region Ear, Nose and Throat

		#region Tennitus

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

		#region Ears

		private void buttonEars_Click(object sender, EventArgs e)
		{
			var ears = new Ears();
			ears.ShowDialog();
			textBoxEars.Text = Ears.ears.ToString(); //No age adjustment
			UpdateAll();
			UpdateAll();
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

		private void comboBoxAge_KeyUp(object sender, KeyEventArgs e)
		{
			comboBoxAge_Leave(null, null);
		}

		#endregion

		#region EYES

		#region Left Eyes

		private void comboBoxLeftMonocular_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBoxLeftMonocular.Text = (comboBoxLeftMonocular.SelectedIndex * 10).ToString();
			UpdateAll();
			UpdateAll();
		}

		private void checkBoxLeftMonocularWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxLeftMonocular_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void buttonLeftVisualFOL_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftEye";
			var visualFOL = new VisualFOL();
			visualFOL.ShowDialog();
			textBoxLeftVisualFOL.Text = VisualFOL.LeftEye.ToString();  //Not age adjustment
			UpdateAll();
			UpdateAll();
		}
		private void textBoxLeftVisualFOL_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxLeftVisualFOLWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void comboBoxLeftMiscVisual_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBoxLeftMiscVisual.SelectedIndex)
			{
				case 0: textBoxLeftMiscVisual.Text = "0";
					break;
				case 1: textBoxLeftMiscVisual.Text = "0";
					break;
				case 2: textBoxLeftMiscVisual.Text = "0";
					break;
				case 3: textBoxLeftMiscVisual.Text = "2";
					break;
				case 4: textBoxLeftMiscVisual.Text = "2";
					break;
				case 5: textBoxLeftMiscVisual.Text = "5";
					break;
				case 6: textBoxLeftMiscVisual.Text = "5";
					break;
				case 7: textBoxLeftMiscVisual.Text = "5";
					break;
				case 8: textBoxLeftMiscVisual.Text = "10";
					break;
				case 9: textBoxLeftMiscVisual.Text = "5";
					break;
				case 10: textBoxLeftMiscVisual.Text = "5";
					break;
				case 11: textBoxLeftMiscVisual.Text = "5";
					break;
				case 12: textBoxLeftMiscVisual.Text = "10";
					break;
				case 13: textBoxLeftMiscVisual.Text = "10";
					break;
				case 14: textBoxLeftMiscVisual.Text = "10";
					break;
				case 15: textBoxLeftMiscVisual.Text = "10";
					break;
				case 16: textBoxLeftMiscVisual.Text = "15";
					break;
				case 17: textBoxLeftMiscVisual.Text = "15";
					break;
				case 18: textBoxLeftMiscVisual.Text = "15";
					break;
				case 19: textBoxLeftMiscVisual.Text = "25";
					break;
				case 20: textBoxLeftMiscVisual.Text = "10";
					break;
				case 21: textBoxLeftMiscVisual.Text = "10";
					break;
				case 22: textBoxLeftMiscVisual.Text = "25";
					break;
			}
			UpdateAll();
			UpdateAll();
		}

		private void textBoxLeftMiscVisual_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxLeftMiscVisualWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void buttonLeftOtherOcular_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "LeftOcular";
			var ocular = new OcularImpairment();
			ocular.ShowDialog();
			textBoxLeftOtherOcular.Text = OcularImpairment.LeftOcular.ToString();  //Not age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxLeftOtherOcular_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxLeftOtherOcularWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#region Rights Eyes

		private void comboBoxRightMonocular_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBoxRightMonocular.Text = (comboBoxRightMonocular.SelectedIndex * 10).ToString();
			UpdateAll();
			UpdateAll();
		}

		private void buttonRightVisualFOL_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightEye";
			var visualFOL = new VisualFOL();
			visualFOL.ShowDialog();
			textBoxRightVisualFOL.Text = VisualFOL.RightEye.ToString();  //Not age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void checkBoxRightMonocularWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxRightMonocular_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void textBoxRightVisualFOL_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxRightVisualFOLWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void comboBoxRightMiscVisual_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBoxRightMiscVisual.SelectedIndex)
			{
				case 0: textBoxRightMiscVisual.Text = "0";
					break;
				case 1: textBoxRightMiscVisual.Text = "0";
					break;
				case 2: textBoxRightMiscVisual.Text = "0";
					break;
				case 3: textBoxRightMiscVisual.Text = "2";
					break;
				case 4: textBoxRightMiscVisual.Text = "2";
					break;
				case 5: textBoxRightMiscVisual.Text = "5";
					break;
				case 6: textBoxRightMiscVisual.Text = "5";
					break;
				case 7: textBoxRightMiscVisual.Text = "5";
					break;
				case 8: textBoxRightMiscVisual.Text = "10";
					break;
				case 9: textBoxRightMiscVisual.Text = "5";
					break;
				case 10: textBoxRightMiscVisual.Text = "5";
					break;
				case 11: textBoxRightMiscVisual.Text = "5";
					break;
				case 12: textBoxRightMiscVisual.Text = "10";
					break;
				case 13: textBoxRightMiscVisual.Text = "10";
					break;
				case 14: textBoxRightMiscVisual.Text = "10";
					break;
				case 15: textBoxRightMiscVisual.Text = "10";
					break;
				case 16: textBoxRightMiscVisual.Text = "15";
					break;
				case 17: textBoxRightMiscVisual.Text = "15";
					break;
				case 18: textBoxRightMiscVisual.Text = "15";
					break;
				case 19: textBoxRightMiscVisual.Text = "25";
					break;
				case 20: textBoxRightMiscVisual.Text = "10";
					break;
				case 21: textBoxRightMiscVisual.Text = "10";
					break;
				case 22: textBoxRightMiscVisual.Text = "25";
					break;
			}
			UpdateAll();
			UpdateAll();
		}

		private void textBoxRightMiscVisual_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxRightMiscVisualWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void buttonRightOtherOcular_Click(object sender, EventArgs e)
		{
			GlobalVar.Selection = "RightOcular";
			var ocular = new OcularImpairment();
			ocular.ShowDialog();
			textBoxRightOtherOcular.Text = OcularImpairment.RightOcular.ToString();  //Not age adjustment
			UpdateAll();
			UpdateAll();
		}

		private void textBoxRightOtherOcular_TextChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		private void checkBoxRightOtherOcularWar_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		#endregion

	}
}
