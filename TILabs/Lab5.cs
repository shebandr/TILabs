using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
    internal class Lab5
    {
        public static string HammingCode(string input, int wordLen)
        {
            string result = "";

            // Итерация по словам
            for (int i = 0; i < input.Length; i += wordLen)
            {
                // Берем слово длины wordLen
                string word = input.Substring(i, Math.Min(wordLen, input.Length - i));

                // Создаем массив для хранения закодированного слова
                int encodedLength = word.Length + (int)Math.Ceiling(Math.Log(word.Length + 1, 2));
                char[] encodedWord = new char[encodedLength];

                // Заполняем биты данных на свои позиции
                int dataIndex = 0;
                for (int j = 1; j <= encodedWord.Length; j++)
                {
                    if ((j & (j - 1)) != 0) // Если j не степень двойки, это бит данных
                    {
                        if (dataIndex < word.Length)
                        {
                            encodedWord[j - 1] = word[dataIndex];
                            dataIndex++;
                        }
                        else
                        {
                            encodedWord[j - 1] = '0'; // Дополняем нулями, если данных не хватает
                        }
                    }
                }

                // Вычисляем контрольные биты
                for (int j = 1; j <= encodedWord.Length; j *= 2)
                {
                    int parity = 0;
                    for (int k = j; k <= encodedWord.Length; k += 2 * j)
                    {
                        for (int m = 0; m < j && k + m <= encodedWord.Length; m++)
                        {
                            if (encodedWord[k + m - 1] == '1')
                            {
                                parity ^= 1;
                            }
                        }
                    }
                    encodedWord[j - 1] = parity == 1 ? '1' : '0'; // Устанавливаем контрольный бит
                }

                // Добавляем закодированное слово к результату
                result += new string(encodedWord);
            }

            return result;
        }

		public static string HammingDecode(string encodedInput, int wordLen)
		{
			string result = "";

			int controlBitsCount = (int)Math.Ceiling(Math.Log(wordLen, 2)) + 1;
			int totalWordLen = wordLen + controlBitsCount;

			for (int i = 0; i < encodedInput.Length; i += totalWordLen)
			{
				int remainingLength = Math.Min(totalWordLen, encodedInput.Length - i);
				if (remainingLength <= 0) break;

				string encodedWord = encodedInput.Substring(i, remainingLength);

				int errorPosition = 0;
				for (int j = 1; j <= encodedWord.Length; j *= 2)
				{
					int parity = 0;
					for (int k = j; k <= encodedWord.Length; k += 2 * j)
					{
						for (int m = 0; m < j && k + m <= encodedWord.Length; m++)
						{
							if (encodedWord[k + m - 1] == '1')
							{
								parity ^= 1;
							}
						}
					}
					if (parity != 0)
					{
						errorPosition += j; 
					}
				}

				if (errorPosition > 0 && errorPosition <= encodedWord.Length)
				{
					char[] wordArray = encodedWord.ToCharArray();
					wordArray[errorPosition - 1] = wordArray[errorPosition - 1] == '1' ? '0' : '1';
					encodedWord = new string(wordArray);
				}

				string decodedWord = "";
				for (int j = 1; j <= encodedWord.Length; j++)
				{
					if ((j & (j - 1)) != 0) 
					{
						decodedWord += encodedWord[j - 1];
					}
				}

				result += decodedWord;
			}

			return result;
		}
	}
}
