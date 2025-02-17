using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
	internal class Lab1
	{
		public static string GenString1(int length)
		{
			Random r = new Random();
			string result = "";
			List<string> symbols = new List<string> {"a", "b", "c", "d", "e" };
			for(int i = 0; i < length; i++)
			{
				result += symbols[r.Next(0, symbols.Count)];
			}

			return result;
		}
	}
}
