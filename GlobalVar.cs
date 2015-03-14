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


	}
}
