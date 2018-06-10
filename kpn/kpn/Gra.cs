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
            if (kamienCzerw.IsChecked == true && kamienNieb.IsChecked == true) return true;
            if (papierCzerw.IsChecked == true && papierNieb.IsChecked == true) return true;
            if (nozyceCzerw.IsChecked == true && nozyceNieb.IsChecked == true) return true;

            return false;
        }

        public bool zwyciestwoNiebieski(RadioButton kamienCzerw, RadioButton papierCzerw, RadioButton nozyceCzerw,
            RadioButton kamienNieb, RadioButton papierNieb, RadioButton nozyceNieb)
        {
            bool kamCzerw = (bool)kamienCzerw.IsChecked;
            bool papCzerw = (bool)papierCzerw.IsChecked;
            bool nozCzerw = (bool)nozyceCzerw.IsChecked;
            bool kamNieb = (bool)kamienNieb.IsChecked;
            bool papNieb = (bool)papierNieb.IsChecked;
            bool nozNieb = (bool)nozyceNieb.IsChecked;

            if (kamCzerw && papNieb) return true;
            if (kamCzerw && nozNieb) return false;
            if (papCzerw && kamNieb) return false;
            if (papCzerw && nozNieb) return true;
            if (nozCzerw && kamNieb) return true;
            if (nozCzerw && papNieb) return false;

            return true;

        }


        public void symulujWcisniecie(RadioButton kamienCzerw, RadioButton papierCzerw, RadioButton nozyceCzerw)
        {
            int traf;
            traf = random.Next(0, 3);
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
            if (tury >= 15)
            {
                Debug.WriteLine("Koniec gry");
                rb1.IsEnabled = false;
                rb2.IsEnabled = false;
                rb3.IsEnabled = false;
            }
            
        }

        public void restartuj(TextBox tbTura, TextBox wynikNiebieski, TextBox wynikCzerwony, RadioButton rb1, RadioButton rb2, RadioButton rb3)
        {
            int tbDoZera = int.Parse(tbTura.Text); 
            tbDoZera = 0;
            tbTura.Text = tbDoZera.ToString();

            wynikCzerwony.Text = "0";
            wynikNiebieski.Text = wynikCzerwony.Text;

            rb1.IsEnabled = true;
            rb2.IsEnabled = true;
            rb3.IsEnabled = true;
        }

    }
}
