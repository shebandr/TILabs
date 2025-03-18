using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
    internal class Lab4
    {
        static Random rand = new Random();
        public static List<List<int>> GenMatrix(int x, int y)
        {
            List<List<int>> result = new List<List<int>>();

            for(int  i = 0; i < y; i++)
            {
                result.Add(new List<int>());
                for(int j = 0; j < y; j++)
                {
                    if(j==i ){
                        result[i].Add(1);
                    } else
                    {

                        result[i].Add(0);
                    }

                }
            }
            for (int i = 0; i < y; i++)
            {
                for (int j = y; j < x; j++)
                {
                    result[i].Add(rand.Next(0, 2));
                }
            }



            return result;
        }
		public static int CalcMinCodeDist(List<List<int>> matrix)
		{
			// Проверка на пустую матрицу
			if (matrix == null || matrix.Count == 0 || matrix[0].Count == 0)
			{
				throw new ArgumentException("Матрица не может быть пустой.");
			}

			int k = matrix.Count; // Количество строк (размерность кода)
			int n = matrix[0].Count; // Длина кодового слова

			// Генерация всех возможных информационных комбинаций
			List<List<int>> infoCombinations = GenerateAllInfoCombinations(k);

			// Генерация всех кодовых слов
			List<List<int>> codeWords = new List<List<int>>();
			foreach (var info in infoCombinations)
			{
				List<int> codeWord = MultiplyInfoByMatrix(info, matrix);
				codeWords.Add(codeWord);
			}

			// Вычисление весов всех кодовых слов
			List<int> weights = new List<int>();
			foreach (var word in codeWords)
			{
				int weight = word.Sum(); // Вес = количество единиц
				weights.Add(weight);
			}

			// Нахождение минимального веса среди ненулевых кодовых слов
			int minDistance = weights.Where(w => w != 0).Min();

			return minDistance;
		}

		// Генерация всех возможных информационных комбинаций
		private static List<List<int>> GenerateAllInfoCombinations(int k)
		{
			List<List<int>> combinations = new List<List<int>>();
			int totalCombinations = (int)Math.Pow(2, k);

			for (int i = 0; i < totalCombinations; i++)
			{
				List<int> combination = new List<int>();
				for (int j = 0; j < k; j++)
				{
					combination.Add((i >> j) & 1); // Получаем j-й бит числа i
				}
				combinations.Add(combination);
			}

			return combinations;
		}

		// Умножение информационной комбинации на порождающую матрицу
		private static List<int> MultiplyInfoByMatrix(List<int> info, List<List<int>> matrix)
		{
			int n = matrix[0].Count;
			List<int> codeWord = new List<int>(new int[n]);

			for (int i = 0; i < info.Count; i++)
			{
				if (info[i] == 1)
				{
					for (int j = 0; j < n; j++)
					{
						codeWord[j] = (codeWord[j] + matrix[i][j]) % 2; // Сложение по модулю 2
					}
				}
			}

			return codeWord;
		}


	}
}
