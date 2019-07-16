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

        public Osoba (List<int> karty, List<String> dochazky, String jmeno, String prijmeni, String osobnicislo) {

            this.dochazka = new List<List<string>>();
            this.karty = new List<int>();
            this.osobniTabulka = new OsobniTabulka();

            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.osobnicislo = osobnicislo;

            this.karty = karty;

            for (int i = 0; i < dochazky.Count; i++)
            {
                dochazka.Add(dochazky[i].Trim().Split('_').ToList());
            }

        }

        public string kartyToString()
        {

            string s = "";
            foreach (int i in karty)
            {
                s = s + i + "_";
            }

            return s;
        }

        public string getDochazkaLine(int i) {

            string s = "";

            foreach (string hodnota in dochazka[i])
            {
                //s = s + (hodnota == "" ? "©" : hodnota) + "_";
                s = s + hodnota + "_";
            }

            return s;
        }

    }
}
