using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Docházka
{
    public partial class KartaTabulka : Form
    {
        Karta data;
        Main main;

        public KartaTabulka(Main main, Karta karta)
        {
            InitializeComponent();

            this.main = main;
            data = karta;
        }

        private void KartaTabulka_Load(object sender, EventArgs e)
        {
            ActiveControl = panel1;
            this.Text = this.Text + data.nazev;
            labelRok.Text = data.rok;
            labelMesic.Text = data.mesic;
        }

        private void buttonNastavit_Click(object sender, EventArgs e)
        {
            Editace_Karty k = new Editace_Karty(data, main);
            k.ShowDialog();
        }
    }
}
