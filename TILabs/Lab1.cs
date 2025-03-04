using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
	internal class Lab1
	{
		public static List<double> probTextRussian = new List<double>
        {
	        0.062,  // 'а'
            0.014,  // 'б'
            0.038,  // 'в'
            0.025,  // 'г'
            0.072,  // 'д'
            0.072,  // 'е' (включая 'ё')
            0.016,  // 'ж'
            0.062,  // 'з'
            0.062,  // 'и'
            0.010,  // 'й'
            0.028,  // 'к'
            0.035,  // 'л'
            0.026,  // 'м'
            0.053,  // 'н'
            0.090,  // 'о'
            0.023,  // 'п'
            0.040,  // 'р'
            0.045,  // 'с'
            0.053,  // 'т'
            0.021,  // 'у'
            0.002,  // 'ф'
            0.009,  // 'х'
            0.004,  // 'ц'
            0.012,  // 'ч'
            0.006,  // 'ш'
            0.003,  // 'щ'
            0.014,  // 'ъ' (объединён с 'ь')
            0.014,  // 'ы'
            0.006,  // 'ь' (объединён с 'ъ')
            0.018,  // 'э'
            0.016,  // 'ю'
            0.006,  // 'я'
            0.175   // пробел
        };
		public static string GenString1(List<string> symbols, int length)
		{
			Random r = new Random();
			string result = "";
			for(int i = 0; i < length; i++)
			{
				result += symbols[r.Next(0, symbols.Count)];
			}

			return result;
		}

		public static string GenString2(List<string> symbols, List<double> probabilities, int length)
		{

			Random r = new Random();
			string result = "";


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

        public static List<int> CalcCount(string text, int len)
        {
            List<int> counts = new List<int>();
            List<string> alphabet = new List<string>();
            for (int i = 0; i < text.Length - (len-1); i++)
            {
                string temp = "";
                for(int j = 0; j<len; j++)
                {
                    temp+= text[i+j];
					
				}
				if (!alphabet.Contains(temp))
				{
					alphabet.Add(temp);

					counts.Add(0);
				}

			}

            Console.WriteLine(text.Length + " " + alphabet.Count + " " + counts.Count);
            for (int i = 0; i < text.Length - (len-1); i++)
            {
                for (int q = 0; q < alphabet.Count; q++)
                {
					string temp = "";
					for (int j = 0; j < len; j++)
					{
						temp += text[i + j];

					}
					if (temp == alphabet[q])
                    {
                        counts[q]++;
                        break;
                    }
                }
            }
            return counts;
        }

        public static double Shennon(string text, List<int> counts)
		{
            double result = 0;

            for (int i = 0; i < counts.Count; i++)
            {
                if (counts[i] != 0)
                {
                    double p_i = (double)counts[i] / text.Length;
                    if (p_i > 0)
                    {
                        result -= p_i * Math.Log(p_i, 2.0);
                    }
                }
            }

            return result;
        }

	}
}
