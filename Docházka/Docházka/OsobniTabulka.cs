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

        public void addLine(String hash, String a, String b, String c, String d)
        {
            setLine(hash,a,b,c,d);
        }

        public void setLine(String hash, String a, String b, String c, String d)
        {

            int i = HashList.IndexOf(hash);
            if (i == -1)
            {
                HashList.Add(hash);
                Tabulka.Add(new List<string>(4));
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

        public void Reset() {

            HashList = new List<string>();
            Tabulka = new List<List<String>>();

            setLine("4", "7:30", "11:30", "", "");
            setLine("6", "7:30", "13:30", "", "");
            setLine("7", "7:00", "12:30", "13:00", "14:30");
            setLine("D", "D", "D", "D", "D");
            setLine("N", "N", "N", "N", "N");
            setLine("OČR", "OČR", "OČR", "OČR", "OČR");
            setLine("ST", "ST", "ST", "ST", "ST");
            setLine("SV", "SV", "SV", "SV", "SV");
            //------------------------------------------------------
            setLine("8/1", "7:00", "12:30", "13:00", "15:30");
            setLine("8/2", "7:00", "12:30", "13:00", "15:30");
            setLine("8/3", "7:00", "12:30", "13:00", "15:30");
            setLine("8/4", "7:00", "12:30", "13:00", "15:30");
            setLine("8/5", "7:00", "12:30", "13:00", "15:30");

        }
    }
}
