using Controls = System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using c1_gameoflife.model;

namespace c1_gameoflife.view
{
	public class SpielfeldRendererBitmap : ISpielfeldRenderer
	{
		private Controls.Image image;
        private Controls.Border border;
		public SpielfeldRendererBitmap(Controls.Image image, Controls.Border border)
        {
            this.border = border;
			this.image = image;
        }

		public void Draw(Spielfeld spielfeld)
		{
			int canvasHoehe = (int)this.border.ActualHeight - 2*(int)this.border.BorderThickness.Top - 2*(int)this.image.Margin.Top;
            int canvasBreite = (int)this.border.ActualWidth - 2 * (int)this.border.BorderThickness.Left - 2 * (int)this.image.Margin.Left;

            int zellenHoehe = canvasHoehe / spielfeld.Hoehe;
            int zellenBreite = canvasBreite / spielfeld.Breite;

            int seitenlaenge;

            if (zellenBreite > zellenHoehe)
                seitenlaenge = zellenHoehe;
            else
                seitenlaenge = zellenBreite;


            int horizontalSpacing = (canvasBreite - seitenlaenge * spielfeld.Breite) / 2;
            int verticalSpacing = (canvasHoehe - seitenlaenge * spielfeld.Hoehe) / 2;

            Bitmap bm = new Bitmap(canvasBreite, canvasHoehe);

            using (Graphics gr = Graphics.FromImage(bm))
            {

                for (int x = 0; x < spielfeld.Breite; x++)
                {
                    for (int y = 0; y < spielfeld.Hoehe; y++)
                    {
                        gr.SmoothingMode = SmoothingMode.AntiAlias;
                        Color fill;

                        if (spielfeld.getPunkt(x, y) == Spielfeld.LEBT)
                        {
                            fill = ColorTranslator.FromHtml("#00416e");
                        }
                        else
                        {
                            fill = Color.White;
                        }

                        Rectangle rect = new Rectangle(
                            horizontalSpacing + x * seitenlaenge,
                            verticalSpacing + y * seitenlaenge, 
                            seitenlaenge, 
                            seitenlaenge
                        );

                        gr.FillRectangle(new SolidBrush(fill), rect);

                        using (Pen thick_pen = new Pen(Color.Gray, 0.5F))
                        {
                            gr.DrawRectangle(thick_pen, rect);
                        }
                    }
                }
            }

            this.drawBitmap(bm);
        }

        private void drawBitmap(Bitmap bitmap)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            this.image.Source = bi;
        }

		public int[] GetClickedCell(Spielfeld spielfeld, System.Windows.Point mousePoint)
        {
            int[] position = new int[2];

            int mouseX = (int)mousePoint.X;
            int mouseY = (int)mousePoint.Y;

            int canvasHoehe = (int)this.border.ActualHeight - 2 * (int)this.border.BorderThickness.Top - 2 * (int)this.image.Margin.Top;
            int canvasBreite = (int)this.border.ActualWidth - 2 * (int)this.border.BorderThickness.Left - 2 * (int)this.image.Margin.Left;

            int seitenlaenge = canvasHoehe / spielfeld.Hoehe;
            int horizontalSpacing = (canvasBreite - seitenlaenge * spielfeld.Breite) / 2;
            int verticalSpacing = (canvasHoehe - seitenlaenge * spielfeld.Hoehe) / 2;

            position[0] = (mouseX - horizontalSpacing) / seitenlaenge;
            position[1] = (mouseY - verticalSpacing) / seitenlaenge;

            return position;
        }
	}
}
