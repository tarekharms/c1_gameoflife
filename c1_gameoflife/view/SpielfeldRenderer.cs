﻿using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Threading;
using c1_gameoflife.model;

namespace c1_gameoflife.view
{
    public class SpielfeldRenderer
    {
        private Canvas canvas;

        public SpielfeldRenderer(Canvas canvas)
        {
            this.canvas = canvas;
        }
        
        public void draw(Spielfeld spielfeld)
        {
            this.canvas.Children.Clear();

            int hoehe = (int)this.canvas.ActualHeight;
            int breite = (int)this.canvas.ActualWidth;

            int zellenBreite = hoehe / spielfeld.Hoehe;
            int horizontalSpacing = (breite - zellenBreite * spielfeld.Breite) / 2;


            for (int x = 0; x < spielfeld.Breite; x++)
            {
                for (int y = 0; y < spielfeld.Hoehe; y++)
                {
                    SolidColorBrush fill;

                    if (spielfeld.getPunkt(x, y) == Spielfeld.LEBT)
                    {
                        fill = new SolidColorBrush(Colors.Blue);
                    }
                    else
                    {
                        fill = new SolidColorBrush(Colors.White);
                    }

                    Rectangle rect = new Rectangle()
                    {
                        Stroke = new SolidColorBrush(Colors.LightGray),
                        Width = zellenBreite,
                        Height = zellenBreite,
                        Fill = fill
                    };

                    Canvas.SetLeft(rect, horizontalSpacing + x * zellenBreite);
                    Canvas.SetTop(rect, y * zellenBreite);

                    this.canvas.Children.Add(rect);
                }
            }

        }

        public int[] getClickedCell(Spielfeld spielfeld, Point mousePoint)
        {
            int[] position = new int[2];

            int mouseX = (int)mousePoint.X;
            int mouseY = (int)mousePoint.Y;

            int hoehe = (int)this.canvas.ActualHeight;
            int breite = (int)this.canvas.ActualWidth;

            int zellenBreite = hoehe / spielfeld.Hoehe;
            int horizontalSpacing = (breite - zellenBreite * spielfeld.Breite) / 2;

            position[0] = (mouseX - horizontalSpacing) / zellenBreite;
            position[1] = mouseY / zellenBreite;

            return position;
        }
    }
}