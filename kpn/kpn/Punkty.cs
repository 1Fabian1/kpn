using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpn
{
    class Punkty
    {
        public Punkty() { }
        public Punkty(string imie, string wynik)
        {
            this.imie = imie;
            this.wynik = wynik;
        }
        public string imie { get; set; }
        public string wynik { get; set; }
    }
}
