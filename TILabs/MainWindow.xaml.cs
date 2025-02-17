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
			string a = "asfsdagsdgывп";
			FileProcessor.StringToFile(path, a);
		}

		private void FileGen2Lab1_Click(object sender, RoutedEventArgs e)
		{

		}

		private void FileGen3Lab1_Click(object sender, RoutedEventArgs e)
		{

		}



		private void FileRead1Lab1_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string path = "";

			if (openFileDialog.ShowDialog() == true)
			{
				path = openFileDialog.FileName;
			}
			FileProcessor.FileToString(path);
		}

		private void FileRead2Lab1_Click(object sender, RoutedEventArgs e)
		{

		}

		private void FileRead3Lab1_Click(object sender, RoutedEventArgs e)
		{

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
