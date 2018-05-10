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
    //zasady.zwyciestwoNiebieski(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony,
    //    btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
    public sealed partial class MainPage : Page
    {
        int pktNiebieski;
        int pktCzerwony;

        Gra gra = new Gra();
        public MainPage()
        {
            this.InitializeComponent();
            Debug.WriteLine("Debug działa");

        }

        private void btKamienNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("kilk kamien");
            btPapierNiebieski.IsChecked = false;
            btNozyceNiebieski.IsChecked = false;
            //przyznajPunkty(btKamienNiebieski, RadioButton rb)
            pktNiebieski = parsujTextBlock(wynikNiebieski);
            pktCzerwony = parsujTextBlock(wynikCzerwony);



        }

        private void btPapierNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("kilk papier");
            btKamienNiebieski.IsChecked = false;
            btNozyceNiebieski.IsChecked = false;

        }

        private void btNozyceNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("kilk nozyce");
            btKamienNiebieski.IsChecked = false;
            btPapierNiebieski.IsChecked = false;
        }

        public int parsujTextBlock(TextBlock textBlock)
        {
            return int.Parse(textBlock.ToString());
        }
    }
}
