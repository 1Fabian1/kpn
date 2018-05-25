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
        public TablicaWynikow()
        {
            MainPage mainPage = new MainPage();
            this.InitializeComponent();
            ladujPlansze();
            kontrolujDlugoscListy(listaWyniki);
            //zapiszPlansze();
            

        }

        List<Punkty> listaWyniki = new List<Punkty>(5);
        string jakiesImie;
        string jakisWynik;
        Punkty punkty1 = new Punkty("Wooow", "10");

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            punkty1 = e.Parameter as Punkty;
            jakiesImie = punkty1.imie.ToString();
            jakisWynik = punkty1.wynik.ToString();
            //Debug.WriteLine("imie " + jakiesImie);
            zarzadzajWynikami(listaWyniki, punkty1);
            kontrolujDlugoscListy(listaWyniki);
            //zapiszWartosci(listaWyniki);
            //zapiszStan();
            listaWyniki = await czytajWynikiZPliku();
            czytajWynikiZPliku();

            zapiszPlansze();
            
            //czytajWynikiZPliku();

            Debug.WriteLine("wyswietlanie listy");
            wyswietlListe(listaWyniki);
            

        }

        public void ladujPlansze()
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
                builder.AppendLine(im +","+ wn+".");
                //Debug.WriteLine(x.imie + " Wynik "+ x.wynik);
            }
            doZapisu = builder.ToString();
            //Debug.Write(doZapisu);
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync("wyniki.txt", CreationCollisionOption.ReplaceExisting);
            Debug.WriteLine(storageFolder.Path);
            await FileIO.WriteTextAsync(sampleFile, doZapisu);
            //string doZapisu = string.Join(",", lista.ToString());
            //Debug.WriteLine(doZapisu);
        }

        private async Task<List<Punkty>> czytajWynikiZPliku()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync("wyniki.txt");
            string text = await FileIO.ReadTextAsync(file);
            //Debug.WriteLine(text);
            string[] wiersze = text.Split('.');
            Debug.WriteLine("Wyświetlanie wczytania");
            Debug.WriteLine(text);
            //List<String> wierszeL = text.Split('.').ToList();
            //Stack<string> wierszeS = new Stack<string>(wierszeL);
            int i = 0;
            List<Punkty> listaPkt = new List<Punkty>();
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
            return listaPkt;
            

        }

        private void wyswietlListe(List<Punkty> lista)
        {
            string im, wn, doZapisu = "";
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
