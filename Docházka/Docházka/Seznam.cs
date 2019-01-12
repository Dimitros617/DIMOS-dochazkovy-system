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
    public partial class Seznam : Form
    {

        Main main;
        public Seznam(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Seznam_Load(object sender, EventArgs e)
        {

        }

        private void pridat_Click(object sender, EventArgs e)
        {
            Osoba o = new Osoba();
            main.Osoby.Add(o);
            Editace_osob pridat = new Editace_osob("NEW", o);
            pridat.ShowDialog();
        }
        private void nastaveni_MouseEnter(object sender, EventArgs e)
        {
            nastaveni.BackColor = System.Drawing.Color.White;

        }

        private void nastaveni_MouseLeave(object sender, EventArgs e)
        {
            nastaveni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));

        }

        private void pridat_MouseEnter(object sender, EventArgs e)
        {
            pridat.BackColor = System.Drawing.Color.White;

        }

        private void pridat_MouseLeave(object sender, EventArgs e)
        {
            pridat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));

        }
    }
}
