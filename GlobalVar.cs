using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVA_Compensation_Calculator
{
	class GlobalVar
	{
		public static string SettingsPath;

		public static int MainFormLocxationX;

		public static int MainFormLocxationY;

		public static MainForm.MultiDimDictList<int, int> AgeAdjust = new MainForm.MultiDimDictList<int, int>();

		public static MainForm.MultiDimDictList<int, object> CombineValue = new MainForm.MultiDimDictList<int, object>();

		public static MainForm.MultiDimDictList<int, object> LifeStylePeace = new MainForm.MultiDimDictList<int, object>();

		public static MainForm.MultiDimDictList<int, object> LifeStyleWar = new MainForm.MultiDimDictList<int, object>();

		public static MainForm.MultiDimDictList<int, object> ActuaryTable = new MainForm.MultiDimDictList<int, object>();

		public static MainForm.MultiDimDictList<int, object> LimbsAgeAdjust = new MainForm.MultiDimDictList<int, object>();
		
		public static int AgeAdjustRange;

		public static MainForm.MultiDimDictList<int, object>[] ExcelData;

		public static int WarlikeService;

		public static int WarlikePoints;

		public static int PeacelikePoints;

		public static bool startup;

		public static string Selection;

		public static decimal leftArmHighestPointsWar;

		public static decimal leftArmHighestPointsPeace;

		public static decimal LeftArmPoints;

		public static decimal HighestLeftArmPoints;

		public static decimal RightArmHighestPointsWar;

		public static decimal RightArmHighestPointsPeace;

		public static decimal RightArmPoints;

		public static decimal HighestRightArmPoints;

		public static decimal legHighestPointsWarArray;

		public static decimal legHighestPointsPeaceArray;

		public static decimal LegPoints;

		public static decimal HighestLegPoints;

		public static int TheracoHighestPoints;

		public static decimal combinedLeftEyePoints;

		public static decimal combinedRightEyePoints;

		public static decimal combinedEyePoints;

		public static int EyeConversaion;

		public static string FinalLifeStylePoint;

		public static string personalRelationships;

		public static string Mobility;

		public static string RecreationalActivities;

		public static string DomesticActivities;

		public static string EmploymentActivities;

		public static int EyeWar;

		public static int LeftEyeConversion;

		public static int RightEyeConversion;

		public static string LeftVisualFOL;

		public static string RightVisualFOL;

		public static string LeftMonocular;

		public static string RightMonocular;

		public static string LeftOtherOcular;

		public static string RightOtherOcular;

		public static string LeftMiscVisual;

		public static string RightMiscVisual;

		public static int EB;

		public static string comboBoxRightMonocular;

		public static string comboBoxLeftMonocular;

		public static string comboBoxRightMiscVisual;

		public static string comboBoxLeftMiscVisual;

		public static bool FirstTimeStart;

		public static bool DisclaimerCheck;

		public static int ToePoints;

		public static decimal combinedToePoints;

		public static int comboBoxToesPartially;

		public static int KneesPoints;

		public static decimal combinedKneesPoints;

		public static int comboBoxKneesPartially;

		public static int HipsPoints;

		public static decimal combinedHipsPoints;

		public static int comboBoxHipsPartially;

		public static int AnklesPoints;

		public static decimal combinedAnklesPoints;

		public static int comboBoxAnklesPartially;

		public static int WholeLimbPoints;

		public static decimal combinedWholeLimbPoints;

		public static int comboBoxWholeLimbPartially;

		public static int LeftElbowPoints;

		public static decimal combinedLeftElbowPoints;

		public static int comboBoxLeftElbowPartially;

		public static int RightElbowPoints;

		public static int comboBoxRightElbowPartially;

		public static decimal combinedRightElbowPoints;

		public static int LeftFingerPoints;

		public static decimal combinedLeftFingerPoints;

		public static int comboBoxLeftFingerPartially;

		public static int RightFingerPoints;

		public static int comboBoxRightFingerPartially;

		public static decimal combinedRightFingerPoints;

		public static int LeftShoulderPoints;

		public static decimal combinedLeftShoulderPoints;

		public static int comboBoxLeftShoulderPartially;

		public static int RightShoulderPoints;

		public static int comboBoxRightShoulderPartially;

		public static decimal combinedRightShoulderPoints;

		public static int LeftWristPoints;

		public static decimal combinedLeftWristPoints;

		public static int comboBoxLeftWristPartially;

		public static int RightWristPoints;

		public static int comboBoxRightWristPartially;

		public static decimal combinedRightWristPoints;

		public static int WholeLeftArmPoints;

		public static decimal combinedWholeLeftArmPoints;

		public static int comboBoxWholeLeftArmPartially;

		public static int WholeRightArmPoints;

		public static decimal combinedWholeRightArmPoints;

		public static int comboBoxWholeRightArmPartially;

		public static int JointPainPoints;

		public static decimal combinedJointPainPoints;

		public static int comboBoxJointPainPartially;

		public static int ThroatPoints;

		public static decimal combinedThroatPoints;

		public static int comboBoxThroatPartially;

		public static int NosePoints;

		public static decimal combinedNosePoints;

		public static int comboBoxNosePartially;

		public static int HearingLossPoints;

		public static decimal combinedHearingLossPoints;

		public static int comboBoxHearingLossPartially;

		public static int TinnitusPoints;

		public static decimal combinedTinnitusPoints;

		public static int comboBoxTinnitusPartially;

		public static int CervicalPoints;

		public static decimal combinedCervicalPoints;

		public static int comboBoxCervicalPartially;

		public static int ThoracoROMPoints;

		public static decimal combinedThoracoROMPoints;

		public static int comboBoxThoracoROMPartially;

		public static int ThoracoLumbarPoints;

		public static decimal combinedThoracoLumbarPoints;

		public static int comboBoxThoracoLumbarPartially;

		public static bool DisableWarning;

		public static bool WarningVisible;

		public static bool dragging;

		public static int offsetX;

		public static int offsetY;

	}
}
