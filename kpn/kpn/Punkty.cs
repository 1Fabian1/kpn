using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpn
{
    class Punkty : IComparable
    {
        public Punkty() { }

        public int CompareTo(Object pktDoPorownania0)
        {
            Punkty pktDoPorownania = pktDoPorownania0 as Punkty;

            if (pktDoPorownania == null) return 0;

            if (int.Parse(this.wynik) < int.Parse(pktDoPorownania.wynik)) return 1;
            if (int.Parse(this.wynik) > int.Parse(pktDoPorownania.wynik)) return -1;

            return 0;
        }
        public Punkty(string imie, string wynik)
        {
            this.imie = imie;
            this.wynik = wynik;
        }
        public string imie { get; set; }
        public string wynik { get; set; }

        public override string ToString()
        {
            return imie + " " + wynik;
        }


    }

    

}
