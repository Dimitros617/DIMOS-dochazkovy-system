using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Docházka
{
    public class Karta
    {

        public Color color;
        public String nazev = "Karta";
        public List<int> indexyOsob;
        public Main main;

        public String mesic;
        public String rok;

        public Karta(Main main) {

            this.main = main;
            indexyOsob = new List<int>();
            color = new Color();
            setColor(32,45,68);
            rok = DateTime.Now.Year + "";
            mesic = main.mesice[DateTime.Now.Month-1];

        }

        public void setColor(String r, String g, String b) {

            int R = Int32.Parse(r.Trim());
            int G = Int32.Parse(g.Trim());
            int B = Int32.Parse(b.Trim());

            setColor(R,G,B);
        }

        public void setColor(int r, int g, int b)
        {
            color = Color.FromArgb(r,g,b);
         
        }

        public void pridatOsobu(int i) {

            indexyOsob.Add(i);

        }

        public int getPocetDnuVMesici() {

            return DateTime.DaysInMonth(Int32.Parse(rok), main.IndexOf(main.mesice,mesic)+1);

        }

    }
}
