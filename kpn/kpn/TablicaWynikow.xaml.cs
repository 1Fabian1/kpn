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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace kpn
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class TablicaWynikow : Page
    {
        public TablicaWynikow()
        {
            this.InitializeComponent();
            ladujPlansze();
            
        }

        List<Punkty> wyniki = new List<Punkty>();

        public void ladujPlansze()
        {
            if(wyniki.Count == 0)
            {
                wyniki.Insert(0, new Punkty("Gracz","0"));
                wyniki.Insert(1, new Punkty("Gracz", "0"));
                wyniki.Insert(2, new Punkty("Gracz", "0"));
                wyniki.Insert(3, new Punkty("Gracz", "0"));
                wyniki.Insert(4, new Punkty("Gracz", "0"));
                lbWyniki.ItemsSource = wyniki;

            }
            
        }

        private void ustawWyniki(List<Punkty> listaPunktow)
        {
            //dać listę
            //sprawdzić min element, jeśli mniejszy zamienić
            //posortować i wyświetlić
            //dać możliwość zmiany imienia

        }
       

        private void doGry_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
