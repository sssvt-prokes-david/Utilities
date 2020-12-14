using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vysvedceni
{
    class Znamka
    {
        public string Jmeno;
        public Predmet Predmet;
        public int Hodnota;
        public string Datum;

        public Znamka(string jmeno, Predmet predmet, int hodnota, string datum)
        {
            Jmeno = jmeno;
            Predmet = predmet;
            Hodnota = hodnota;
            Datum = datum;
        }
    }
}
