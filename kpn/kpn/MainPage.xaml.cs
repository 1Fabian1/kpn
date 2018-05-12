using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;


//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace kpn
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        Gra gra = new Gra();
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void btKamienNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("kilk kamien");
            btPapierNiebieski.IsChecked = false;
            btNozyceNiebieski.IsChecked = false;
            akcjaPoWyborze();
            btKamienNiebieski.IsChecked = false;  //na sam koniec
        }

        private void btPapierNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("kilk papier");
            btKamienNiebieski.IsChecked = false;
            btNozyceNiebieski.IsChecked = false;
            akcjaPoWyborze();
            btPapierNiebieski.IsChecked = false;

        }

        private void btNozyceNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("kilk nozyce");
            btKamienNiebieski.IsChecked = false;
            btPapierNiebieski.IsChecked = false;
            akcjaPoWyborze();
            btNozyceNiebieski.IsChecked = false;

        }

        public int parsujTextBox(TextBox textBlock)
        {
            return int.Parse(textBlock.Text);
        }

        public void zwiekszTextBoxO1(TextBox tura)
        {
            int turyINT = parsujTextBox(tura);
            turyINT++;
            tura.Text = turyINT.ToString();
        }

        private void akcjaPoWyborze()
        {
            gra.symulujWcisniecie(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony);
            bool remis = gra.remis(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony, btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
            if (remis == false)
            {
                bool wygranaNiebieski = gra.zwyciestwoNiebieski(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony, btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
                if (wygranaNiebieski == true)
                {
                    zwiekszTextBoxO1(wynikNiebieski);
                    zwiekszTextBoxO1(tbTura);

                }
                if (wygranaNiebieski == false)
                {
                    zwiekszTextBoxO1(wynikCzerwony);
                    zwiekszTextBoxO1(tbTura);
                }
            }
            else
            {
                zwiekszTextBoxO1(tbTura);
            }
            gra.pilnujGry(tbTura, btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
        }

    }
}
