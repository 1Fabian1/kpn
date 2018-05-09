using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace kpn
{
    class Gra
    {

        public bool zwyciestwoNiebieski(Button kamienCzerw, Button papierCzerw, Button nozyceCzerw, Button kamienNieb, Button papierNieb, Button nozyceNieb)
        {
            if (kamienCzerw.IsEnabled || kamienNieb.IsEnabled) return false;
            if (kamienCzerw.IsEnabled || papierNieb.IsEnabled) return true;
            if (kamienCzerw.IsEnabled || nozyceNieb.IsEnabled) return false;
            if (papierCzerw.IsEnabled || kamienNieb.IsEnabled) return false;
            if (papierCzerw.IsEnabled || papierNieb.IsEnabled) return false;
            if (papierCzerw.IsEnabled || nozyceNieb.IsEnabled) return true;
            if (nozyceCzerw.IsEnabled || kamienNieb.IsEnabled) return true;
            if (nozyceCzerw.IsEnabled || papierNieb.IsEnabled) return false;
            if (nozyceCzerw.IsEnabled || nozyceNieb.IsEnabled) return false;
            else return false;
        }

        public Button symulujWcisniecie(Button kamienCzerw, Button papierCzerw, Button nozyceCzerw)
        {
            int traf;
            Random random = new Random();
            //traf = random.Next(0, 2);
            traf = 2;
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
            else return new Button();


        }
    }
}
