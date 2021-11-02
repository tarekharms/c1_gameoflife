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
using c1_gameoflife.view;

namespace c1_gameoflife
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private SpielfeldRenderer spielfeldRenderer;
		bool play = true;
		Spiel spiel;

		public MainWindow()
		{
			InitializeComponent();

			this.spiel = new Spiel();
            this.spiel.neuesSpielZufaellig(45, 30);

			this.spielfeldRenderer = new SpielfeldRenderer(Cnvs_Spielfeld);
		}

		private void drawSpielfeld()
		{
			this.spielfeldRenderer.draw(this.spiel.Spielfeld);
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
			this.spiel.step();
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
			this.drawSpielfeld();
        }
    }
}
