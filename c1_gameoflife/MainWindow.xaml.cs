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
		private bool isDrawing = false;
		bool play = false;
		Spiel spiel;

		public MainWindow()
		{
			this.spiel = new Spiel();

			InitializeComponent();

			this.spiel.SpielfeldUpdate += onSpielfeldUpdate;
			this.spiel.neuesSpiel(100, 50);

			this.spielfeldRenderer = new SpielfeldRenderer(Cnvs_Spielfeld);
		}

		private void drawSpielfeld()
		{
			if (this.isDrawing) return;

			this.isDrawing = true;
			this.spielfeldRenderer.draw(this.spiel.Spielfeld);
			this.isDrawing = false;
		}

		private void onSpielfeldUpdate(object sender, EventArgs e)
		{
			long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

			this.Dispatcher.Invoke(this.drawSpielfeld);
		}

		private void Button_PlayPause_Click(object sender, RoutedEventArgs e)
		{
			this.play = !this.play;

			if (this.play)
			{
				this.spiel.Start();
				Btn_PlayPause.Content = "Pause";
			} 
			else
			{
				this.spiel.Stop();
				Btn_PlayPause.Content = "Play";
			}
		}

		private void Button_Einzelschritt_Click(object sender, RoutedEventArgs e)
		{
			this.spiel.step();
		}

		private void Button_Reset_Click(object sender, RoutedEventArgs e)
		{
			this.spiel.neuesSpielZufaellig(100, 50);
			this.drawSpielfeld();
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

			this.spiel.Geschwindigkeit = value;


			Lbl_Geschwindigkeit.Text = "Geschwindigkeit: " + value;
		}

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
			this.drawSpielfeld();
        }

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.spiel.Stop();
		}

		private void Cnvs_Spielfeld_MouseDown(object sender, MouseButtonEventArgs e)
		{
			int[] pos;
			Point mousePos = e.GetPosition(Cnvs_Spielfeld);
			pos = this.spielfeldRenderer.getClickedCell(this.spiel.Spielfeld, mousePos);

			CanvasClicked.Text = "Clicked: Yes Pos(" + pos[0] + ";" + pos[1] + ")";

			if (pos[0] < 0 || pos[0] > this.spiel.Spielfeld.Breite
				|| pos[1] < 0 || pos[1] > this.spiel.Spielfeld.Hoehe)
			{
				return;
			}

			

			this.spiel.Spielfeld.changePunkt(pos[0], pos[1]);
			this.drawSpielfeld();
		}
	}
}
