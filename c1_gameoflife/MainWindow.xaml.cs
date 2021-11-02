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

using c1_gameoflife.model;

namespace c1_gameoflife
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool play = true;
		Spiel spiel;

		public MainWindow()
		{
			InitializeComponent();

			this.spiel = new Spiel();
			this.spiel.neuesSpielZufaellig(15, 15);

			this.drawSpielfeld();
		}

		private void drawSpielfeld()
		{
			Rectangle rectangle = new Rectangle();
			rectangle.Stroke = new SolidColorBrush(Colors.Blue);
			rectangle.Fill = new SolidColorBrush(Colors.Blue);


			int hoehe = (int)Cnvs_Spielfeld.Height;
			int breite = (int)Cnvs_Spielfeld.Width;

			int zellenBreite = hoehe / this.spiel.Spielfeld.Hoehe;

			for(int x = 0; x < this.spiel.Spielfeld.Breite; x++)
			{
				Line line = new Line();
				line.Stroke = new SolidColorBrush(Colors.LightGray);
				line.StrokeThickness = 5;

				line.X1 = zellenBreite * x;
				line.Y1 = 0;

				line.X2 = zellenBreite * x;
				line.Y2 = hoehe;

				Cnvs_Spielfeld.Children.Add(line);
			}

			Cnvs_Spielfeld.Children.Add(rectangle);
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
