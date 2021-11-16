using System.Windows;
using System.Windows.Controls;

namespace c1_gameoflife.view
{
    /// <summary>
    /// Interaktionslogik für NeuesSpiel.xaml
    /// </summary>
    public partial class NeuesSpiel : Window
    {
        private int hoehe;
        public int Hoehe { get { return this.hoehe; } }

        private int breite;
        public int Breite { get { return this.breite; } }

        private bool zufaellig;
        public bool Zufaellig { get { return this.zufaellig; } }

        private bool submitted;
        public bool Submitted { get { return this.submitted; } }
        
        private bool submitEnabled;
        


        public NeuesSpiel()
        {
            InitializeComponent();
        }

        private void TxtBx_Hoehe_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = TxtBx_Hoehe.Text;

            if(int.TryParse(value, out int hoehe))
            {
                this.hoehe = hoehe;
            }
            else
            {
                if(value.Equals(""))
                {
                    TxtBx_Hoehe.Text = "";
                }
                else
                {
                    TxtBx_Hoehe.Text = this.hoehe.ToString();
                    TxtBx_Hoehe.CaretIndex = this.hoehe.ToString().Length;
                }
            }

            this.validateInputs();
        }

        private void TxtBx_Breite_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = TxtBx_Breite.Text;

            if (int.TryParse(value, out int breite))
            {
                this.breite = breite;
            }
            else
            {
                if (value.Equals(""))
                {
                    TxtBx_Breite.Text = "";
                }
                else
                {
                    TxtBx_Breite.Text = this.breite.ToString();
                    TxtBx_Breite.CaretIndex = this.breite.ToString().Length;
                }
            }

            this.validateInputs();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.zufaellig = (bool)this.ChckBx_zufaellig.IsChecked;
        }

        private void validateInputs()
        {
            if (
                this.hoehe > 4 && this.hoehe < 51 &&
                this.breite > 4 && this.breite < 101
                )
            {
                this.submitEnabled = true;
            }
            else
            {
                this.submitEnabled = false;
            }

            this.Cmd_Submit.IsEnabled = this.submitEnabled;
        }

        private void Cmd_Submit_Click(object sender, RoutedEventArgs e)
        {
            this.submitted = true;
            this.Close();
        }

        private void Button_Abort_Click(object sender, RoutedEventArgs e)
        {
            this.submitted = false;
            this.Close();
        }
    }
}
