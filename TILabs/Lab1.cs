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
			List<string> symbols = new List<string> {"a", "b", "c"};
			for(int i = 0; i < length; i++)
			{
				result += symbols[r.Next(0, symbols.Count)];
			}

			return result;
		}

		public static string GenString2(int length)
		{

			Random r = new Random();
			string result = "";
			List<string> symbols = new List<string> { "a", "b", "c" };
			List<double> probabilities = new List<double> { 0.2, 0.5, 0.3 };

			// Генерация строки
			for (int i = 0; i < length; i++)
			{
				double randomValue = r.NextDouble(); // Случайное число от 0 до 1
				double cumulativeProbability = 0.0;

				for (int j = 0; j < symbols.Count; j++)
				{
					cumulativeProbability += probabilities[j];
					if (randomValue < cumulativeProbability)
					{
						result += symbols[j];
						break;
					}
				}
			}

			return result;
		}


	}
}
