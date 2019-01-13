using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docházka
{
    public class Karta
    {

        public Color color;
        public String nazev;
        public List<int> indexyOsob;
        public Main main;

        public Karta() {

            color = new Color();

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

    }
}
