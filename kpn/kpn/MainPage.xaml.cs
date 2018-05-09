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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace kpn
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    /// 
    //zasady.zwyciestwoNiebieski(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony,
    //    btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
    public sealed partial class MainPage : Page
    {

        Gra gra = new Gra();
        public MainPage()
        {
            this.InitializeComponent();
           

        }

        private void btKamienNiebieski_Click(object sender, RoutedEventArgs e)
        {
            gra.symulujWcisniecie(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony);
            if (gra.zwyciestwoNiebieski(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony,
                btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski))
            {
                wynikNiebieski.Text = "Niebieski WINNER";
            }
            else {
                wynikCzerwony.Text = "Czerwony Winner";
            }
        }

        private void btPapierNiebieski_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void btNozyceNiebieski_Click(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
