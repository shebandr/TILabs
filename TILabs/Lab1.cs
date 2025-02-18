using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
	internal class Lab1
	{
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

        public static List<int> CalcCount(string text)
        {
            List<int> counts = new List<int>();
            List<string> alphabet = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!alphabet.Contains(text[i].ToString()))
                {
                    alphabet.Add(text[i].ToString());

                    counts.Add(0);
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                for (int q = 0; q < alphabet.Count; q++)
                {
                    if (text[i].ToString() == alphabet[q])
                    {
                        counts[q]++;
                        break;
                    }
                }
            }
            return counts;
        }

        public static List<int> CalcCountPairs(string text)
        {
            List<int> counts = new List<int>();
            List<string> alphabet = new List<string>();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (!alphabet.Contains(text[i].ToString() + text[i + 1].ToString()))
                {
                    alphabet.Add(text[i].ToString() + text[i + 1].ToString());

                    counts.Add(0);
                }
            }

            for (int i = 0; i < text.Length - 1; i++)
            {
                for (int q = 0; q < alphabet.Count; q++)
                {
                    if (text[i].ToString() + text[i + 1].ToString() == alphabet[q])
                    {
                        counts[q]++;
                        break;
                    }
                }
            }
            for (int i = 0; i < alphabet.Count; i++)
            {
                Console.WriteLine(alphabet[i] + " " + counts[i]);
            }
            return counts;
        }

        public static List<int> CalcCountTriples(string text)
        {
            List<int> counts = new List<int>();
            List<string> alphabet = new List<string>();

            for (int i = 0; i < text.Length - 2; i++)
            {
                if (!alphabet.Contains(text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString()))
                {
                    alphabet.Add(text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());

                    counts.Add(0);
                }
            }

            for (int i = 0; i < text.Length - 2; i++)
            {
                for (int q = 0; q < alphabet.Count; q++)
                {
                    if (text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString() == alphabet[q])
                    {
                        counts[q]++;
                        break;
                    }
                }
            }
            for (int i = 0; i < alphabet.Count; i++)
            {
                Console.WriteLine(alphabet[i] + " " + counts[i]);
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
