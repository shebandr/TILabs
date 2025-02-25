using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace TILabs
{
	internal class FileProcessor
	{
		public static string FileToString(string path)
		{
			string data;

			StreamReader stream = new StreamReader(path);
			data = stream.ReadLine();



			return data;
		}

		public static void StringToFile(string path, string data)
		{
			using (StreamWriter writer = new StreamWriter(path))
			{
				writer.WriteLine(data);
			}
		}
	}
}
