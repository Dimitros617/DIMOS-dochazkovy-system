using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docházka
{
    public class Ucitel
    {
        public List<List<String>> dochazka;
        public String jmeno;
        public String prijmeni;
        public String osobnicislo;
        public OsobniTabulka osobniTabulka;

        public Ucitel(){

            dochazka = new List<List<string>>();
            osobniTabulka = new OsobniTabulka();
        }

    }
}
