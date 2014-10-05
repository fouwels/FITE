using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fite
{
	public static class KvPs
	{
		public static Dictionary<string, string> Red = new Dictionary<string, string>
		{
			{"UP" , "W"},
			{"DOWN", "S"},
			{"LEFT" , "A"},
			{"RIGHT" , "d"},
			{"LP" , "Z"},
			{"MP" , "X"},
			{"HP" , "C"},
			{"LK" , "V"},
			{"MK" , "B"},
			{"HK", "N"},
			{"TH" , "Q"},
		};
		public static Dictionary<string, string> Blue = new Dictionary<string, string>
		{

			{"UP" , "UP"},
			{"DOWN", "DOWN"},
			{"LEFT" , "LEFT"},
			{"RIGHT" , "RIGHT"},
			{"LP" , "1"},
			{"MP" , "2"},
			{"HP" , "3"},
			{"LK" , "5"},
			{"MK" , "6"},
			{"HK", "7"},
			{"TH" , "8"}

		};
	}								
}