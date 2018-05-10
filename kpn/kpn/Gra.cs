using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;


namespace kpn
{
    class Gra
    {
        Random random = new Random();
        public bool remis(RadioButton kamienCzerw, RadioButton papierCzerw, RadioButton nozyceCzerw,
            RadioButton kamienNieb, RadioButton papierNieb, RadioButton nozyceNieb)
        {
            if (kamienCzerw.IsChecked == true || kamienNieb.IsChecked == true) return true;
            if (papierCzerw.IsChecked == true || papierNieb.IsChecked == true) return true;
            if (nozyceCzerw.IsChecked == true || nozyceNieb.IsChecked == true) return true;
            return true;
        }

        public bool zwyciestwoNiebieski(RadioButton kamienCzerw, RadioButton papierCzerw, RadioButton nozyceCzerw,
            RadioButton kamienNieb, RadioButton papierNieb, RadioButton nozyceNieb)
        {
            //if (kamienCzerw.IsEnabled || kamienNieb.IsEnabled) return false;
            if (kamienCzerw.IsEnabled || papierNieb.IsEnabled) return true;
            if (kamienCzerw.IsEnabled || nozyceNieb.IsEnabled) return false;
            if (papierCzerw.IsEnabled || kamienNieb.IsEnabled) return false;
            //if (papierCzerw.IsEnabled || papierNieb.IsEnabled) return false;
            if (papierCzerw.IsEnabled || nozyceNieb.IsEnabled) return true;
            if (nozyceCzerw.IsEnabled || kamienNieb.IsEnabled) return true;
            if (nozyceCzerw.IsEnabled || papierNieb.IsEnabled) return false;
            //if (nozyceCzerw.IsEnabled || nozyceNieb.IsEnabled) return false;
            else return false;
        }

        public int przyznajPunktyNiebieski(int wynikNiebieski, int wynikCzerwony, Boolean sprawdzRemis, Boolean czyNiebieskiWygrał)
        {
            if (sprawdzRemis == true)
            {
                Debug.WriteLine("Sprawdzam remis");
                return 0;
            }
            else
            {
                if (czyNiebieskiWygrał == true)
                {
                    return wynikNiebieski++;
                }
            }
            return 0;
            
        }

        public int przyznajPunktyCzerwony(int wynikNiebieski, int wynikCzerwony, Boolean sprawdzRemis, Boolean czyNiebieskiWygrał)
        {
            if (sprawdzRemis == true)
            {
                Debug.WriteLine("Sprawdzam remis");
                return 0;
            }
            else
            {
                if (czyNiebieskiWygrał ==false)
                {
                    return wynikCzerwony++;
                }
            }
            return 0;

        }

        public void symulujWcisniecie(RadioButton kamienCzerw, RadioButton papierCzerw, RadioButton nozyceCzerw)
        {
            int traf;
            traf = random.Next(0, 2);
            if (traf == 0) {
                kamienCzerw.IsChecked = true;
            }
            else if (traf == 1)
            {
                papierCzerw.IsChecked = true;
            }
            else if (traf == 2)
            {
                nozyceCzerw.IsChecked = true;
            }
        }

        public void pilnujGry(TextBox tbTura, RadioButton rb1, RadioButton rb2, RadioButton rb3)
        {
            int tury = int.Parse(tbTura.Text);
            if (tury >=10)
            {
                Debug.WriteLine("Koniec gry");
                rb1.IsEnabled = false;
                rb2.IsEnabled = false;
                rb3.IsEnabled = false;
            }
        }
    }
}
