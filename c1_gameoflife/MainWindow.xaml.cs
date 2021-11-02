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

namespace c1_gameoflife
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool play = true;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_PlayPause_Click(object sender, RoutedEventArgs e)
		{
			this.play = !this.play;

			if (this.play)
			{
				PlayStatus.Text = "Status: Play";
			} 
			else
			{
				PlayStatus.Text = "Status: Stop";
			}
		}

		private void Button_Einzelschritt_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Reset_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Speichern_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Laden_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Info_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Slider_Geschwindigkeit_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			int value = (int)e.NewValue;


			Lbl_Geschwindigkeit.Text = "Geschwindigkeit: " + value;
		}
	}
}
