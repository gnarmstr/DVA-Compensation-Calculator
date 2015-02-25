using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVA_Compensation_Calculator
{
	class GlobalVar
	{
		public static MainForm.MultiDimDictList<int, int> ageAdjust = new MainForm.MultiDimDictList<int, int>();

		public static MainForm.MultiDimDictList<object, int> combineValue = new MainForm.MultiDimDictList<object, int>();

		public static int ageAdjustRange;
	}
}
