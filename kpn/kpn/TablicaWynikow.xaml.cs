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
using Windows.Storage;

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
            kontrolujDlugoscListy(listaWyniki);
            

        }

        List<Punkty> listaWyniki = new List<Punkty>(5);
        string jakiesImie;
        string jakisWynik;
        Punkty punkty1 = new Punkty("Wooow", "10");

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            punkty1 = e.Parameter as Punkty;
            jakiesImie = punkty1.imie.ToString();
            jakisWynik = punkty1.wynik.ToString();
            //Debug.WriteLine("imie " + jakiesImie);
            zarzadzajWynikami(listaWyniki, punkty1);
            kontrolujDlugoscListy(listaWyniki);
            //zapiszWartosci(listaWyniki);
            //zapiszStan();
            

        }

        public async void ladujPlansze()
        {
            /*
            StorageFile storageFile = null;
            storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("lista");
            listaWyniki = List<Punkty> as storageFile;
            */
            if(listaWyniki.Count == 0)
            {
                listaWyniki.Insert(0, new Punkty("Gracz1","10"));
                listaWyniki.Insert(1, new Punkty("Gracz2", "1"));
                listaWyniki.Insert(2, new Punkty("Gracz3", "11"));
                listaWyniki.Insert(3, new Punkty("Gracz4", "7"));
                listaWyniki.Insert(4, new Punkty("Gracz5", "2"));
                lbWyniki.ItemsSource = listaWyniki;
            }
            
        }

        private void zarzadzajWynikami(List<Punkty> lista, Punkty pkt)
        {
            if (lista == null || pkt.imie == null || pkt.wynik == null) return;

            if (int.Parse(pkt.wynik) > int.Parse(lista[4].wynik))
            {
                lista.Add(new Punkty(pkt.imie, pkt.wynik));
            }

        }

        private void kontrolujDlugoscListy(List<Punkty> listaPunktow)
        {
            listaPunktow.Sort();
            while (listaPunktow.Count > 5)
            {
                listaPunktow.RemoveAt(5);
            }
        }

        /*
        private async void zapiszWartosci(List<Punkty> listaPunktow)
        {
            StorageFile storageFile1 = listaPunktow;
            storageFile1 = await ApplicationData.Current.LocalFolder.CreateFileAsync("lista");
        }
        */
       

        private void doGry_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        

    }
}
