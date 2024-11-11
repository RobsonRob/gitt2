using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace kolko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();
            Color kolor = Ustawienia.Czytaj();
            rectangle.Fill = new SolidColorBrush(kolor);
            sliderB.Value = kolor.B;
            sliderG.Value = kolor.G;
            sliderR.Value = kolor.R;


        }

        private void sliders_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color kolor = Color.FromRgb(
                (byte)sliderR.Value,
                (byte)sliderG.Value,
                (byte)sliderB.Value);
            //(rectangle.Fill as SolidColorBrush).Color = kolor;
            zminiaKoloru = kolor;

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close(); 
        }

        private Color zminiaKoloru
        {
            get
            {
                return (rectangle.Fill as SolidColorBrush).Color;
            }
            set
            {
                (rectangle.Fill as SolidColorBrush).Color = value;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Ustawienia.Zapisz(zminiaKoloru);
        }
    }
}
