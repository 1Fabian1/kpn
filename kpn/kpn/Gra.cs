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

        public int przyznajPunkty(int wynikNiebieski, int wynikCzerwony, Boolean sprawdzRemis, Boolean czyNiebieskiWygrał)
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
                else
                {
                    return wynikCzerwony++;
                }
            }
            
        }

        public RadioButton symulujWcisniecie(RadioButton kamienCzerw, RadioButton papierCzerw, RadioButton nozyceCzerw)
        {
            int traf;
            Random random = new Random();
            //traf = random.Next(0, 2);
            traf = 2;   //sztywne przypisanie
            if (traf == 0) {
                kamienCzerw.IsEnabled = true;
                return kamienCzerw;
            }
            if (traf == 1)
            {
                papierCzerw.IsEnabled = true;
                return papierCzerw;
            }
            if (traf == 2)
            {
                nozyceCzerw.IsEnabled = true;
                return nozyceCzerw;
            }
            else return null;
        }
    }
}
