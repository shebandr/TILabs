using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
    public class vertex
    {
        public string data = "";
        public vertex left;
        public vertex right;
        public int weight;
    }
    internal class Lab2
    {
        public static Dictionary<string, int> CalcCount(string text, int len)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            List<int> counts = new List<int>();
            List<string> alphabet = new List<string>();
            
            for (int i = 0; i < text.Length-len; i+=len)
             {
				string tempKey = "";
                for(int j = 0; j < len; j++)
                {
                    tempKey += text[i + j];
                }
				if (!result.ContainsKey(tempKey))
                {
                    result.Add(tempKey, 1);

                } else
                {
                    result[tempKey]++;
                }

            }
        return result.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value); ;
        }

		private static void TraverseTree(vertex node, string code, Dictionary<string, string> codeDictionary)
		{
			if (node == null)
				return;
/*            Console.Write(node.data + "|");*/
            if (!string.IsNullOrEmpty(node.data))
			{
				codeDictionary[node.data] = code;
                Console.WriteLine(code);
				return;
			}

			TraverseTree(node.left, code + "0", codeDictionary); 
			TraverseTree(node.right, code + "1", codeDictionary); 
		}
	

	    public static Dictionary<string, string> Haffman(Dictionary<string, int> alphabet)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<vertex> vertices = new List<vertex>();

            foreach(var s in alphabet)
            {
                vertex temp = new vertex();
                temp.data = s.Key;
                temp.weight = s.Value;
                vertices.Add(temp);
                result.Add(s.Key, "");
            }

            while (true)
            {
/*                foreach(var v in vertices)
                {
                    Console.Write(v.data + " " + v.weight + " | ");
                }
                Console.WriteLine();*/
				if (vertices.Count < 2)
				{
					break;
				}
				vertex temp = new vertex();

				temp.left = vertices[vertices.Count - 1];
				temp.right = vertices[vertices.Count - 2];
                temp.weight = temp.left.weight + temp.right.weight;
				vertices.RemoveAt(vertices.Count - 1);
				vertices.RemoveAt(vertices.Count - 1);
                vertices.Add(temp);
				vertices = vertices.OrderByDescending(v => v.weight).ToList();
            }

            TraverseTree(vertices[0], "", result);


			return result;
        }

        private static void SFRecursive(Dictionary<string, int> alphabet, vertex vertexVar)
        {
			var list = alphabet.ToList();
			if (alphabet.Count == 0)
            {
                return;
            }
            if (alphabet.Count == 1)
            {
                vertexVar.data = alphabet.First().Key;
                return;
            }
			int totalWeight = list.Sum(pair => pair.Value);
			int halfWeight = totalWeight / 2;
			int currentWeight = 0;
			int delimeter = 0;

			// Ищем точку разделения
			for (int i = 0; i < list.Count; i++)
			{
				currentWeight += list[i].Value;
				if (currentWeight >= halfWeight)
				{
					delimeter = i + 1;
					break;
				}
			}

			vertex tempL = new vertex();
			vertex tempR = new vertex();
            vertexVar.left = tempL;
            vertexVar.right = tempR;
			SFRecursive(alphabet.Take(delimeter).ToDictionary(pair => pair.Key, pair => pair.Value), vertexVar.left);

			SFRecursive(alphabet.Skip(delimeter).ToDictionary(pair => pair.Key, pair => pair.Value), vertexVar.right);

		}

		public static Dictionary<string, string> ShennonFano(Dictionary<string, int> alphabet)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
			vertex root = new vertex();

            SFRecursive(alphabet, root);

            TraverseTree(root, "", result);




			return result;
        }

    }
}
