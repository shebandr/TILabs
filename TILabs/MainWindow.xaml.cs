﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TILabs
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

        List<string> symbols = new List<string> { "a", "b", "c" };
        List<double> probabilities = new List<double> { 0.2, 0.5, 0.3 };
		int length = 15000;
        public MainWindow()
		{
			InitializeComponent();
		}


		private void FileGen1Lab1_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			string path = "";

			
			if (saveFileDialog.ShowDialog() == true)
			{
				path = saveFileDialog.FileName;
			}
			string a = Lab1.GenString1(symbols, length);
			FileProcessor.StringToFile(path, a);
		}

		private void FileGen2Lab1_Click(object sender, RoutedEventArgs e)
		{
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string path = "";


            if (saveFileDialog.ShowDialog() == true)
            {
                path = saveFileDialog.FileName;
            }
            string a = Lab1.GenString2(symbols, probabilities, length);
            FileProcessor.StringToFile(path, a);

        }

		private void Calc1Lab1_Click(object sender, RoutedEventArgs e)
		{
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path = "";

            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }
            string text = FileProcessor.FileToString(path);
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            string path2 = "";

            if (openFileDialog2.ShowDialog() == true)
            {
                path2 = openFileDialog2.FileName;
            }
            string text2 = FileProcessor.FileToString(path2);
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            string path3 = "";

            if (openFileDialog3.ShowDialog() == true)
            {
                path3 = openFileDialog3.FileName;
            }
            string text3 = FileProcessor.FileToString(path3);



            List<int> counts11 = Lab1.CalcCount(text, 1);
            List<int> counts12 = Lab1.CalcCount(text2, 1);
            List<int> counts13 = Lab1.CalcCount(text3, 1);

            List<int> counts21 = Lab1.CalcCount(text, 2);
            List<int> counts22 = Lab1.CalcCount(text2, 2);
            List<int> counts23 = Lab1.CalcCount(text3, 2);

            List<int> counts31 = Lab1.CalcCount(text, 3);
            List<int> counts32 = Lab1.CalcCount(text2, 3);
            List<int> counts33 = Lab1.CalcCount(text3, 3);

            double sh11 = Lab1.Shennon(text, counts11);
            double sh12 = Lab1.Shennon(text2, counts12);
            double sh13 = Lab1.Shennon(text3, counts13);

            double sh21 = Lab1.Shennon(text, counts21);
            double sh22 = Lab1.Shennon(text2, counts22);
            double sh23 = Lab1.Shennon(text3, counts23);

            double sh31 = Lab1.Shennon(text, counts31);
            double sh32 = Lab1.Shennon(text2, counts32);
            double sh33 = Lab1.Shennon(text3, counts33);

            h1_1.Content = sh11;
            h1_2.Content = sh12;
            h1_3.Content = sh13;

            h2_1.Content = sh21;
            h2_2.Content = sh22;
            h2_3.Content = sh23/2;

            h3_1.Content = sh31;
            h3_2.Content = sh32;
            h3_3.Content = sh33/3;

            h4_1.Content = Math.Log(counts11.Count, 2.0);
            h4_2.Content = Math.Log(counts12.Count, 2.0);
            h4_3.Content = Math.Log(counts13.Count, 2.0);

			List<int> counts51 = new List<int>();
			for (int i = 0; i < probabilities.Count; i++)
			{
				counts51.Add((int)((1.0/ (double)symbols.Count) * length));
                Console.Write(counts51[i] + " ");
			}
            Console.WriteLine();
			List<int> counts52 = new List<int>();
			for (int i = 0; i < probabilities.Count; i++)
			{
				counts52.Add((int)(probabilities[i] * length));
				Console.Write(counts52[i] + " ");
			}
			Console.WriteLine();
			List<int> counts53 = new List<int>();
            /*			for (int i = 0; i < Lab1.probTextRussian.Count; i++)
                        {
                            counts53.Add((int)(Lab1.probTextRussian[i] * text3.Length));
                            Console.Write(counts53[i] + " ");
                        }*/

            Console.WriteLine(counts13);
			h5_1.Content = Lab1.Shennon(text, counts51);
			h5_2.Content = Lab1.Shennon(text2, counts52);
			h5_3.Content = counts13.Count;

           

        }


		private void lab1Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Visible;
			StackPanelLab2.Visibility = Visibility.Collapsed;
			StackPanelLab3.Visibility = Visibility.Collapsed;
			StackPanelLab4.Visibility = Visibility.Collapsed;
			StackPanelLab5.Visibility = Visibility.Collapsed;
		}

		private void lab2Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Collapsed;
			StackPanelLab2.Visibility = Visibility.Visible;
			StackPanelLab3.Visibility = Visibility.Collapsed;
			StackPanelLab4.Visibility = Visibility.Collapsed;
			StackPanelLab5.Visibility = Visibility.Collapsed;
		}
		private void lab3Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Collapsed;
			StackPanelLab2.Visibility = Visibility.Collapsed;
			StackPanelLab3.Visibility = Visibility.Visible;
			StackPanelLab4.Visibility = Visibility.Collapsed;
			StackPanelLab5.Visibility = Visibility.Collapsed;
		}
		private void lab4Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Collapsed;
			StackPanelLab2.Visibility = Visibility.Collapsed;
			StackPanelLab3.Visibility = Visibility.Collapsed;
			StackPanelLab4.Visibility = Visibility.Visible;
			StackPanelLab5.Visibility = Visibility.Collapsed;
		}

		private void lab5Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Collapsed;
			StackPanelLab2.Visibility = Visibility.Collapsed;
			StackPanelLab3.Visibility = Visibility.Collapsed;
			StackPanelLab4.Visibility = Visibility.Collapsed;
			StackPanelLab5.Visibility = Visibility.Visible;
		}
		private void Calc2Lab1_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string path = "";

			if (openFileDialog.ShowDialog() == true)
			{
				path = openFileDialog.FileName;
			}
			string text = FileProcessor.FileToString(path);
            Dictionary<string, int> counts = Lab2.CalcCount(text, 1);
            Dictionary<string, string> haffman = Lab2.Haffman(counts);



			double codeLengthH = 0;
			foreach (var s in haffman)
            {
                Console.WriteLine(s.Key + " = " + s.Value);
                codeLengthH += (double)s.Value.Length * (double)((double)counts[s.Key] / (double)text.Length);
            }
            Console.WriteLine(codeLengthH);
            List<int> countsForShennon = new List<int>();
            foreach (var s in counts)
            {
                countsForShennon.Add(s.Value);
            }

            double entropyH = Lab1.Shennon(text, countsForShennon);
            Console.WriteLine(codeLengthH + " " + entropyH + " " + (codeLengthH-entropyH));

            string codedTextH = "";
            for(int i = 0; i<text.Length; i++)
            {
                codedTextH += haffman[text[i].ToString()];
			}

            Dictionary<string, string> sf = Lab2.ShennonFano(counts);
			double codeLengthSF = 0;
			foreach (var s in sf)
			{
				Console.WriteLine(s.Key + " = " + s.Value);
				codeLengthSF += (double)s.Value.Length * (double)((double)counts[s.Key] / (double)text.Length);
			}

			double entropySF = Lab1.Shennon(text, countsForShennon);

			string codedTextSF = "";
			for (int i = 0; i < text.Length; i++)
			{
				codedTextSF += sf[text[i].ToString()];
			}



			Console.WriteLine(1);
			List<int> counts211 = Lab1.CalcCount(codedTextH, 1);

			Console.WriteLine(2);
			List<int> counts212 = Lab1.CalcCount(codedTextH, 2);
			
            Console.WriteLine(3);
            List<int> counts213 = Lab1.CalcCount(codedTextH, 3);


			Console.WriteLine(1);
			List<int> counts221 = Lab1.CalcCount(codedTextSF, 1);

			Console.WriteLine(2);
			List<int> counts222 = Lab1.CalcCount(codedTextSF, 2);

			Console.WriteLine(3);
			List<int> counts223 = Lab1.CalcCount(codedTextSF, 3);


			h23_1.Content = Lab1.Shennon(codedTextH, counts211);
			h24_1.Content = Lab1.Shennon(codedTextH, counts212) / 2;
			h25_1.Content = Lab1.Shennon(codedTextH, counts213) / 3;

			h23_2.Content = Lab1.Shennon(codedTextSF, counts221);
			h24_2.Content = Lab1.Shennon(codedTextSF, counts222) / 2;
			h25_2.Content = Lab1.Shennon(codedTextSF, counts223) / 3;

			h22_1.Content = codeLengthH - entropyH;
			h22_2.Content = codeLengthSF - entropySF;


		}

		private void Calc3Lab1_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string path = "";

			if (openFileDialog.ShowDialog() == true)
			{
				path = openFileDialog.FileName;
			}
			string text = FileProcessor.FileToString(path);
			List< Dictionary<string, int>> counts = new List< Dictionary<string, int> >();
			List<double> entropy = new List< double >();
			List< Dictionary<string, string>> codesH = new List< Dictionary<string, string> >();
			List<double> codeLengths = new List< double >();
			List<double> overCode = new List<double> ();
			List<List<string>> splitedText = new List<List<string>>();
			List<string> codedText = new List< string >();
			for (int i = 0; i<4; i++)
			{
				counts.Add(Lab2.CalcCount(text, i+1));
				List<int> tempCounts = new List<int>();
				foreach (var s in counts[i])
				{
					tempCounts.Add(s.Value);
				}
				
				codesH.Add(Lab2.Haffman(counts[i]));
				codedText.Add("");
				splitedText.Add(new List<string>());
				for (int q = 0; q < text.Length; q+=i+1)
				{
					string t = "";
					for(int j = 0; j<i+1; j++)
					{
						t += text[q + j];
					}
					splitedText[i].Add(t);
				}

				for(int q = 0; q< splitedText[i].Count; q++)
				{
					codedText[i] += codesH[i][splitedText[i][q]];
				}


				entropy.Add(Lab1.Shennon(splitedText[i].Count, tempCounts));

				codeLengths.Add(0);
				foreach (var s in codesH[i])
				{
//					Console.WriteLine(s.Key + " = " + s.Value);
					codeLengths[i] += (double)s.Value.Length * (double)((double)counts[i][s.Key] / ((double)splitedText[i].Count));
				}

                Console.WriteLine(i + ") " + codedText[i].Length + " " + text.Length);

                overCode.Add((codeLengths[i] - entropy[i])/ (double)(i+1));
	//			Console.WriteLine(codeLengths[i] + " " + entropy[i] + " " + overCode[i]);
			}
			

			h32_1.Content = overCode[0];
			h33_1.Content = overCode[1];
			h34_1.Content = overCode[2];
			h35_1.Content = overCode[3];


		}

		private void Calc4Lab1_Click(object sender, RoutedEventArgs e)
		{
			List<List<List<int>>> tables = new List<List<List<int>>>();
			List<int> minDist = new List<int>();
			for(int i = 0; i<5; i++)
			{
				tables.Add(Lab4.GenMatrix(5 + (i * 3), 3+i));
				minDist.Add(Lab4.CalcMinCodeDist(tables[i]));
			}




			h41_0.Content = tables[0].Count + "x" + tables[0][0].Count;
			h42_0.Content = tables[1].Count + "x" + tables[1][0].Count;
			h43_0.Content = tables[2].Count + "x" + tables[2][0].Count;
			h44_0.Content = tables[3].Count + "x" + tables[3][0].Count;
			h45_0.Content = tables[4].Count + "x" + tables[4][0].Count;

			h41_1.Content = tables[0].Count;
			h42_1.Content = tables[1].Count;
			h43_1.Content = tables[2].Count;
			h44_1.Content = tables[3].Count;
			h45_1.Content = tables[4].Count;

			h41_2.Content = Math.Pow(2,tables[0].Count);
			h42_2.Content = Math.Pow(2, tables[1].Count);
			h43_2.Content = Math.Pow(2, tables[2].Count);
			h44_2.Content = Math.Pow(2, tables[3].Count);
			h45_2.Content = Math.Pow(2, tables[4].Count);

			h41_3.Content = minDist[0];
			h42_3.Content = minDist[1];
			h43_3.Content = minDist[2];
			h44_3.Content = minDist[3];
			h45_3.Content = minDist[4];
		}

		private void Calc5Lab1_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != true) return;

			string text = FileProcessor.FileToString(openFileDialog.FileName);
			if (string.IsNullOrEmpty(text)) return;

			Dictionary<string, int> counts = Lab2.CalcCount(text, 1);
			Dictionary<string, string> haffman = Lab2.Haffman(counts);

			string original = "";
			for (int i = 0; i < text.Length; i++)
			{
				original += haffman[text[i].ToString()];
			}

			string coded = Lab5.HammingCode(original, 8);

			Random rand = new Random();
			string result1 = new string(coded.Select(c => (rand.NextDouble() < 0.1) ? (c == '1' ? '0' : '1') : c).ToArray());
			string result2 = new string(coded.Select(c => (rand.NextDouble() < 0.01) ? (c == '1' ? '0' : '1') : c).ToArray());
			string result3 = new string(coded.Select(c => (rand.NextDouble() < 0.001) ? (c == '1' ? '0' : '1') : c).ToArray());
			string result4 = new string(coded.Select(c => (rand.NextDouble() < 0.0001) ? (c == '1' ? '0' : '1') : c).ToArray());

			string decoded1 = Lab5.HammingDecode(result1, 8);
			string decoded2 = Lab5.HammingDecode(result2, 8);
			string decoded3 = Lab5.HammingDecode(result3, 8);
			string decoded4 = Lab5.HammingDecode(result4, 8);

			int err1 = decoded1.Zip(original, (d, o) => d != o ? 1 : 0).Sum();
			int err2 = decoded2.Zip(original, (d, o) => d != o ? 1 : 0).Sum();
			int err3 = decoded3.Zip(original, (d, o) => d != o ? 1 : 0).Sum();
			int err4 = decoded4.Zip(original, (d, o) => d != o ? 1 : 0).Sum();

			h51_0.Content = err1;
			h51_1.Content = err2;
			h51_2.Content = err3;
			h51_3.Content = err4;

			Console.WriteLine(original.Length);
		}
	}
}
