using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fite
{
	public static class KvPs
	{
		public static List<KeyValuePair<string, string>> Red = new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("UP", "W"),
			new KeyValuePair<string, string>("DOWN", "S"),
			new KeyValuePair<string, string>("LEFT", "A"),
			new KeyValuePair<string, string>("RIGHT", "d"),
			new KeyValuePair<string, string>("LP", "Z"),
			new KeyValuePair<string, string>("MP", "X"),
			new KeyValuePair<string, string>("HP", "C"),
			new KeyValuePair<string, string>("LK", "V"),
			new KeyValuePair<string, string>("MK", "B"),
			new KeyValuePair<string, string>("TH", "Q"),

		};
		public static List<KeyValuePair<string, string>> Blue = new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("UP", "UP"),
			new KeyValuePair<string, string>("DOWN", "DOWN"),
			new KeyValuePair<string, string>("LEFT", "LEFT"),
			new KeyValuePair<string, string>("RIGHT", "RIGHT"),
			new KeyValuePair<string, string>("LP", "1"),
			new KeyValuePair<string, string>("MP", "2"),
			new KeyValuePair<string, string>("HP", "3"),
			new KeyValuePair<string, string>("LK", "5"),
			new KeyValuePair<string, string>("MK", "6"),
			new KeyValuePair<string, string>("HK", "7"),
			new KeyValuePair<string, string>("TH", "8"),

		};
	}								
}