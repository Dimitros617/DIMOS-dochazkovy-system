using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Docházka
{

    public partial class Main : Form
    {
        private String[] mesice = new String[12] { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };
        private String[] dnyEn = new String[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private String[] dnyCz = new String[7] { "PONDĚLÍ", "ÚTERÝ", "STŘEDA", "ČTVRTEK", "PÁTEK", "SOBOTA", "NEDĚLE" };

        public List<Ucitel> ucitele;
        public OsobniTabulka UniversalniTabulka;

        public Main()
        {
            InitializeComponent();
            UniversalniTabulka = new OsobniTabulka();
            UniversalniTabulka.Reset();

        }

        private void pridat_Click(object sender, EventArgs e)
        {
            Editace_osob pridat = new Editace_osob("NEW");
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

        private void Main_Load(object sender, EventArgs e)
        {
            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute);
            datum.Text = DateTime.Now.Day + ". " + mesice[DateTime.Now.Month - 1];
            den.Text = "" + dnyCz[IndexOf(dnyEn, "" + DateTime.Now.DayOfWeek)];

            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            jmeno.Text = (webClient.DownloadString("http://svatky.adresa.info/txt").Split(';'))[1];

        }

        private int IndexOf(String[] arr, String value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        private void Seznam_Click(object sender, EventArgs e)
        {

        }

        private void Seznam_MouseEnter(object sender, EventArgs e)
        {
            Seznam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));

        }

        private void Seznam_MouseLeave(object sender, EventArgs e)
        {
            Seznam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));

        }
    }
}
