using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
    internal class Lab2
    {
        public static Dictionary<string, int> CalcCount(string text)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            List<int> counts = new List<int>();
            List<string> alphabet = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!result.ContainsKey(text[i].ToString()))
                {
                    result.Add(text[i].ToString(), 1);

                } else
                {
                    result[text[i].ToString()]++;
                }

            }
        return result.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value); ;
        }


    }
}
