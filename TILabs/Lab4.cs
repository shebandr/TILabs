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

    }
}
