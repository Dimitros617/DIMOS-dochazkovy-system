using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docházka
{

    public class OsobniTabulka
    {

        public List<List<String>> Tabulka;
        public List<String> HashList;

        public OsobniTabulka()
        {

            HashList = new List<string>();
            Tabulka = new List<List<String>>();

        }

        /**
         * Redirect metoda na setLine()
         **/
        public void addLine(String hash, String hodina, String a, String b, String c, String d)
        {
            setLine(hash,hodina,a,b,c,d);
        }

        /**
         * Metoda nastaví jeden řádek do pomyslné tabulky rozdělí hash do hash listu a na daný index uloží zbylá data do Listu Listuů
         **/
        public void setLine(String hash, String hodina, String a, String b, String c, String d)
        {

            int i = HashList.IndexOf(hash);
            if (i == -1)
            {
                HashList.Add(hash);
                Tabulka.Add(new List<string>(5));
                Tabulka[HashList.IndexOf(hash)].Add(hodina);
                Tabulka[HashList.IndexOf(hash)].Add(a);
                Tabulka[HashList.IndexOf(hash)].Add(b);
                Tabulka[HashList.IndexOf(hash)].Add(c);
                Tabulka[HashList.IndexOf(hash)].Add(d);
            }
            else
            {

                Tabulka[HashList.IndexOf(hash)].Add(a);
                Tabulka[HashList.IndexOf(hash)].Add(b);
                Tabulka[HashList.IndexOf(hash)].Add(c);
                Tabulka[HashList.IndexOf(hash)].Add(d);

            }


        }

        public Boolean Obsahuje(String s) {

            foreach (String i in HashList)
            {
                if (i.Equals(s, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;

        }

        public string getDecodedString(String s, int index, int day) {

            int i = HashList.IndexOf(s.ToUpper());
            if (i == -1) {
                i = HashList.IndexOf(s.ToUpper() + "/" + day);
            }
            string a = Tabulka[i][index];

            return a;
        }

        public String getDecodedPocetHodin(String s)
        {

            int i = HashList.IndexOf(s.ToUpper());
            if (i == -1)
            {
                for (int j = 0; j < 8; j++)
                {
                    i = HashList.IndexOf(s.ToUpper() + "/" + j);
                    if (i >= 0) break;
                }
                
            }
            if (i != -1)
            {
                return Tabulka[i][0];
            }
            else
            {
                return 0 + "";
            }


            

        }

        /**
         * Metoda naplní tabulku továrníma datama
         **/
        public void Reset() {

            HashList = new List<string>();
            Tabulka = new List<List<String>>();

            setLine("4","4", "7:30", "11:30", "", "");
            setLine("6","6", "7:30", "13:30", "", "");
            setLine("7","7", "7:00", "12:30", "13:00", "14:30");
            setLine("D","0", "D", "D", "D", "D");
            setLine("N","0", "N", "N", "N", "N");
            setLine("OČR","0", "OČR", "OČR", "OČR", "OČR");
            setLine("ST","8", "ST", "ST", "ST", "ST");
            setLine("SV","0", "SV", "SV", "SV", "SV");
            //------------------------------------------------------
            setLine("8/1", "8", "7:00", "12:30", "13:00", "15:30");
            setLine("8/2", "8", "7:00", "12:30", "13:00", "15:30");
            setLine("8/3", "8", "7:00", "12:30", "13:00", "15:30");
            setLine("8/4", "8", "7:00", "12:30", "13:00", "15:30");
            setLine("8/5", "8", "7:00", "12:30", "13:00", "15:30");

        }
    }
}
