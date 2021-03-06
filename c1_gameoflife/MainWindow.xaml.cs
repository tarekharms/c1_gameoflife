using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

using c1_gameoflife.model;
using c1_gameoflife.view;
using c1_gameoflife.interfaces;

namespace c1_gameoflife
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ISpielfeldRenderer spielfeldRenderer;
		private bool isDrawing = false;
		bool play = false;

		Spiel spiel;
		ISavegame savegame;

		public MainWindow()
		{
			this.spiel = new Spiel(new RegelnKlassisch());
			this.savegame = new SavegameHandler();

			InitializeComponent();

			this.spiel.SpielfeldUpdate += onSpielfeldUpdate;
			this.spiel.neuesSpiel(10, 10);

			this.spielfeldRenderer = new SpielfeldRendererBitmap(Img_Spielfeld, Border_Spielfeld);
        }

		private void drawSpielfeld()
		{
			Btn_Generation.Content = "Gen.: " + this.spiel.Generation;

			if (this.isDrawing) return;

			this.isDrawing = true;
			this.spiel.Lock();
			this.spielfeldRenderer.Draw(this.spiel.Spielfeld);
			this.spiel.Unlock();
			this.isDrawing = false;
		}

		private void onSpielfeldUpdate(object sender, EventArgs e)
		{
			this.Dispatcher.Invoke(this.drawSpielfeld, System.Windows.Threading.DispatcherPriority.Background);
		}

		private void Button_Generation_Click(object sender, RoutedEventArgs e)
		{
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
			if (this.play)
			{
				this.spiel.Stop();
				Btn_PlayPause.Content = "Play";
			}

			NeuesSpiel window = new NeuesSpiel();

			window.Owner = this;
			window.ShowDialog();

			if(window.Submitted)
			{
				if(window.Zufaellig)
                {
					this.spiel.neuesSpielZufaellig(
						window.Breite,
						window.Hoehe
					);
                }
				else
                {
					this.spiel.neuesSpiel(
						window.Breite,
						window.Hoehe
					);
				}
				
				this.drawSpielfeld();
			}
		}

		private void Button_Speichern_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.DefaultExt = ".golsave";

			bool? result = dialog.ShowDialog();

			if(result == true)
            {
				this.savegame.save(this.spiel.Spielfeld, dialog.FileName);
			}
		}

		private void Button_Laden_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.DefaultExt = ".golsave";

			bool? result = dialog.ShowDialog();

			if (result == true)
			{
				this.spiel.neuesSpiel(0, 0);
				this.spiel.Spielfeld = this.savegame.load(dialog.FileName);
				this.drawSpielfeld();
			}
		}

		private void Button_Info_Click(object sender, RoutedEventArgs e)
		{
			string fullpath = System.IO.Path.GetFullPath("./handbuch.pdf");

			if(System.IO.File.Exists(fullpath))
            {
				System.Diagnostics.Process.Start(fullpath);
            }
			else
            {
				MessageBox.Show("Datei wurde nicht gefunden.");
            }
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

		private void Img_Spielfeld_MouseDown(object sender, MouseButtonEventArgs e)
		{
			int[] pos;
			Point mousePos = e.GetPosition(Img_Spielfeld);
			pos = this.spielfeldRenderer.GetClickedCell(this.spiel.Spielfeld, mousePos);

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
