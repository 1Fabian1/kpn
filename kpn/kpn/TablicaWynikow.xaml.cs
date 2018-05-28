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
            ladujPlansze();
            //kontrolujDlugoscListy(listaWyniki);   
        }

        List<Punkty> listaWyniki = new List<Punkty>(5);
        string jakiesImie;
        string jakisWynik;
        Punkty punkty1 = new Punkty();

        protected async override void OnNavigatedTo(NavigationEventArgs e) //ładowane po konstruktorze
        {
            listaWyniki = await czytajWynikiZPliku();
            punkty1 = e.Parameter as Punkty;
            jakiesImie = punkty1.imie.ToString();
            jakisWynik = punkty1.wynik.ToString();
            //Debug.WriteLine("imie " + jakiesImie);
            zarzadzajWynikami(listaWyniki, punkty1);
            kontrolujDlugoscListy(listaWyniki);
            zapiszPlansze();
            //zapiszWartosci(listaWyniki);
            //zapiszStan();

        }

        public void ladujPlansze()
        {
            listaWyniki.Insert(0, new Punkty("Gracz1", "10"));
            listaWyniki.Insert(1, new Punkty("Gracz2", "1"));
            listaWyniki.Insert(2, new Punkty("Gracz3", "3"));
            listaWyniki.Insert(3, new Punkty("Gracz4", "7"));
            listaWyniki.Insert(4, new Punkty("Gracz5", "1"));
            lbWyniki.ItemsSource = listaWyniki;
        }

        private void zarzadzajWynikami(List<Punkty> lista, Punkty pkt)
        {
            
            string minWynik = lista.Min(x => x.wynik);
            //if (minWynik == null) return;
            Debug.WriteLine("minWynik "+minWynik);
            if (minWynik == null) return;
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

        
        //zapis tabeli z wynikami do pliku
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
            Debug.WriteLine("odczytany text: "+text);
            string[] wiersze = text.Split('.');
            wiersze[5] = wiersze[4];
            //wiersze[4].TrimEnd('.');
           // List<string> wierszeL = text.Split('.').ToList();
            List<Punkty> listaPkt = new List<Punkty>();
            //Debug.WriteLine("Wyświetlanie wczytania");
            //Debug.WriteLine(wierszeL.ToString());
            //List<String> wierszeL = text.Split('.').ToList();
            //Stack<string> wierszeS = new Stack<string>(wierszeL);
            Debug.WriteLine("Czytanie wierszami");
            foreach (string s in wiersze)
            {
                    if (s == null || s == "") return null;
                    int i = 0;
                    string[] poz = s.Split(',');
                    Debug.Write(poz[i] + " " + poz[++i]);
            }

            //Uważaj, USUŃ
            #region 
            // wali błędy jak szalony
            /*
            try
            {
                foreach (Punkty x in listaWyniki)
                {
                    string[] punkt = wiersze[i].Split(',');
                    //List<String> punktL = wierszeS.First().Split();
                    //Stack<string> punktS = wierszeS.First().Split();

                    listaWyniki.Insert(4, new Punkty(punkt[0], punkt[1]));
                    i++;

                    listaWyniki.Sort();
                    kontrolujDlugoscListy(listaWyniki);
                }
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.ToString());
            }
            */
            #endregion 
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
