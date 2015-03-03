using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVA_Compensation_Calculator
{
	class GlobalVar
	{
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

	}
}
