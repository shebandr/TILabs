using Microsoft.Win32;
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
		int length = 1500;
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
            h2_3.Content = sh23;

            h3_1.Content = sh31;
            h3_2.Content = sh32;
            h3_3.Content = sh33;

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

			h5_1.Content = Lab1.Shennon(text, counts51);
			h5_2.Content = Lab1.Shennon(text2, counts52);
			h5_3.Content = "-";

           

        }


		private void lab1Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Visible;
			StackPanelLab2.Visibility = Visibility.Collapsed;
			StackPanelLab3.Visibility = Visibility.Collapsed;
		}

		private void lab2Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Collapsed;
			StackPanelLab2.Visibility = Visibility.Visible;
			StackPanelLab3.Visibility = Visibility.Collapsed;

		}
		private void lab3Open_Click(object sender, RoutedEventArgs e)
		{
			StackPanelLab1.Visibility = Visibility.Collapsed;
			StackPanelLab2.Visibility = Visibility.Collapsed;
			StackPanelLab3.Visibility = Visibility.Visible;

		}


	}
}
