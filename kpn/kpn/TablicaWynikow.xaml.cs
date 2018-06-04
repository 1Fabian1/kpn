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
using System.Text;
using System.Threading.Tasks;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace kpn
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class TablicaWynikow : Page
    {

        public TablicaWynikow() //ładowane jako pierwsze
        {
            MainPage mainPage = new MainPage();
            this.InitializeComponent();
        }

        List<Punkty> listaWyniki = new List<Punkty>(5);
        string jakiesImie;
        string jakisWynik;
        Punkty punkty1 = new Punkty();

        protected async override void OnNavigatedTo(NavigationEventArgs e) //ładowane po konstruktorze
        {
            List<Punkty> Lpkt = new List<Punkty>();
            try
            {
                Lpkt = await czytajWynikiZPliku();
            } catch (Exception ex)
            {
                Lpkt = ladujPlansze();
            }
            
            listaWyniki = Lpkt;
            Debug.WriteLine("On navigated to jak wygląda lista po wczytaniu: ");
            punkty1 = e.Parameter as Punkty;
            jakiesImie = punkty1.imie.ToString();
            jakisWynik = punkty1.wynik.ToString();
            if (listaWyniki.Count == 0)
            {
                listaWyniki.Insert(0, new Punkty(jakiesImie, jakisWynik));
            }
            else
            {
                zarzadzajWynikami(listaWyniki, punkty1);
            }
            listaWyniki.Sort();
            kontrolujDlugoscListy(listaWyniki);
            wydajDoPlanszy(listaWyniki);
            zapiszPlansze();
            
             
        }

        private void wydajDoPlanszy(List<Punkty> pkt)
        {
            lbWyniki.ItemsSource = pkt;
        }

        private List<Punkty> ladujPlansze()
        {
            List<Punkty> listaWynikiB = new List<Punkty>(5);
            listaWynikiB.Insert(0, new Punkty("Gracz", "0"));
            listaWynikiB.Insert(1, new Punkty("Gracz", "0"));
            listaWynikiB.Insert(2, new Punkty("Gracz", "0"));
            listaWynikiB.Insert(3, new Punkty("Gracz", "0"));
            listaWynikiB.Insert(4, new Punkty("Gracz", "0"));
            //lbWyniki.ItemsSource = listaWynikiB;
            return listaWynikiB;
        }

        private void zarzadzajWynikami(List<Punkty> lista, Punkty pkt)
        {
            string minWynik = lista.Min(x => x.wynik);
            Debug.WriteLine("minWynik "+ minWynik);
            int minWynikInt = int.Parse(minWynik);

            if (int.Parse(pkt.wynik) > minWynikInt)
            {
                lista.Add(new Punkty(pkt.imie, pkt.wynik));
            }
            else return;

        }

        private void kontrolujDlugoscListy(List<Punkty> listaPunktow)
        {
            listaPunktow.Sort();
            while (listaPunktow.Count > 5)
            {
                listaPunktow.RemoveAt(5);
            }
        }

        
        private async void zapiszPlansze()
        {
            string im, wn, doZapisu = "";
            StringBuilder builder = new StringBuilder();
            List<Punkty> lista = new List<Punkty>();
            foreach (Punkty x in listaWyniki)
            {
                x.ToString();
                im = x.imie;
                wn = x.wynik;
                builder.AppendLine(im +','+ wn+'.');
            }
            doZapisu = builder.ToString();
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync("wyniki.txt", CreationCollisionOption.ReplaceExisting);
            Debug.WriteLine(storageFolder.Path);
            await FileIO.WriteTextAsync(sampleFile, doZapisu);
        }

        private async Task<List<Punkty>> czytajWynikiZPliku()
        {
            Debug.WriteLine("próbuje czytać plik");
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync("wyniki.txt");
            string text = await FileIO.ReadTextAsync(file);
            Debug.WriteLine("odczytany text: \n"+text);
            string[] wiersze = text.Split('.');
            Array.Resize(ref wiersze, wiersze.Length - 1);
            List<Punkty> listaPkt = new List<Punkty>();
            Debug.WriteLine("Czytanie wierszami");
            int i = 0;
            foreach (string s in wiersze)
            {
                if (s == null || s == "") break;
                
                string[] poz = new string[2];
                poz = s.Split(',');
                Debug.Write(poz[0] + " " + poz[1]);
                listaPkt.Insert(i, new Punkty(poz[0], poz[1]));
                i++;
            }

            return listaPkt;
        }

        private void wyswietlListe(List<Punkty> lista)
        {
            string im, wn = "";
            StringBuilder builder = new StringBuilder();
            foreach (Punkty x in lista)
            {

                x.ToString();
                im = x.imie;
                wn = x.wynik;
                builder.AppendLine(im + "," + wn + ".");
                Debug.WriteLine(x.imie + " Wynik "+ x.wynik);
            }
        }
      
        private void doGry_Click(object sender, RoutedEventArgs e)
        {
            zapiszPlansze();
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
