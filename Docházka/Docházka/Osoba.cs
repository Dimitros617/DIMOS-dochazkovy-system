using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docházka
{
    public class Osoba
    {
        public List<int> karty;
        public List<List<String>> dochazka;
        public String jmeno;
        public String prijmeni;
        public String osobnicislo;
        public OsobniTabulka osobniTabulka;

        public Osoba(){

            dochazka = new List<List<string>>();
            karty = new List<int>();
            osobniTabulka = new OsobniTabulka();
            osobniTabulka.Reset();
        }

    }
}
