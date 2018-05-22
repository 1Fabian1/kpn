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
            MainPage mainPage = new MainPage();
            this.InitializeComponent();
            ladujPlansze();
            int a = mainPage.podajWynik();
            kontrolujDlugoscListy(listaWyniki);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            punkty1 = e.Parameter as Punkty;
        }

        List<Punkty> listaWyniki = new List<Punkty>(5);
        Punkty punkty1 = new Punkty();

        public void ladujPlansze()
        {
            if(listaWyniki.Count == 0)
            {
                listaWyniki.Insert(0, new Punkty("Gracz","0"));
                listaWyniki.Insert(1, new Punkty("Gracz", "0"));
                listaWyniki.Insert(2, new Punkty("Gracz", "0"));
                listaWyniki.Insert(3, new Punkty("Gracz", "0"));
                listaWyniki.Insert(4, new Punkty("Gracz", "0"));
                lbWyniki.ItemsSource = listaWyniki;
            }
            
        }

        private void ustawWyniki(List<Punkty> listaPunktow, string wynik , string imie)
        {
            int wynikRundy = int.Parse(wynik);
            Punkty pkt = new Punkty();
            //dać listę
            listaPunktow.Sort();
            pkt = listaPunktow.Last<Punkty>();
            int pktZListy = int.Parse(pkt.wynik.ToString());
            //sprawdzić min element, jeśli mniejszy zamienić
            if (wynikRundy > pktZListy)
            {
                Punkty nowyPkt = new Punkty(imie, wynikRundy.ToString());
                listaPunktow.Insert(4, nowyPkt);
            }
            //posortować i wyświetlić
            listaPunktow.Sort();
            //dać możliwość zmiany imienia

        }


        private void kontrolujDlugoscListy(List<Punkty> listaPunktow)
        {
            listaPunktow.Sort();
            while (listaPunktow.Count > 5)
            {
                listaPunktow.RemoveAt(5);
            }
        }

       

        private void doGry_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        

    }
}
