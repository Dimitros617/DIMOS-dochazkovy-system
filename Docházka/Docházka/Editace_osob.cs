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
    public partial class Editace_osob : Form
    {

        public OsobniTabulka osobniTabulka;
        public Osoba osoba;
        public Seznam seznam;


        public Editace_osob(String p, Osoba osoba)
        {
            InitializeComponent();
            this.osobniTabulka = osoba.osobniTabulka;
            this.osoba = osoba;

            if (p.Equals("NEW"))
                labelNadpis.Text = "Přidat osobu";
            else
                labelNadpis.Text = "Upravit osobu";

            textBoxJmeno.Text = osoba.jmeno;
            textBoxPrijmeni.Text = osoba.prijmeni;
            textBoxOC.Text = osoba.osobnicislo;
            nactiTabulku();
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tabulka.Padding = new Padding(0, 0, vertScrollWidth, 0);
        }

        public Editace_osob(String p, Osoba osoba, Seznam seznam)
        {
            InitializeComponent();
            this.osobniTabulka = osoba.osobniTabulka;
            this.seznam = seznam;
            this.osoba = osoba;

            if (p.Equals("NEW"))
                labelNadpis.Text = "Přidat osobu";
            else
                labelNadpis.Text = "Upravit osobu";

            textBoxJmeno.Text = osoba.jmeno;
            textBoxPrijmeni.Text = osoba.prijmeni;
            textBoxOC.Text = osoba.osobnicislo;
            nactiTabulku();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RowStyle temp = tabulka.RowStyles[tabulka.RowCount - 1];
            tabulka.RowCount++;
            //tabulka.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            int index = tabulka.RowCount == 2 ? 4 : (tabulka.RowCount - 2 )* 5 + 4;
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { ForeColor = System.Drawing.Color.White, TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++, BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))))}, 0, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 1, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 2, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 3, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 4, tabulka.RowCount);

        }

        private void Editace_osob_Load(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (tabulka.RowCount != 1)
                tabulka.Controls.Clear();

            tabulka.RowCount = 1;
            nactiTabulku();
        }


        // metoda dokáže vymyzat prázdné řádky v tabulce
       /* private void button1_Click_1(object sender, EventArgs e)
        {

            if (tabulka.RowCount != 1)
            {

                for (int j = tabulka.RowCount; j > 1; j--)
                {
                    int prazdnyRadek = 0;

                    for (int i = 0; i < tabulka.ColumnCount; i++)
                    {
                        Control c = tabulka.GetControlFromPosition(i, j);
                        String s = c.Text.Trim();
                        prazdnyRadek = s.Equals("") ? prazdnyRadek : prazdnyRadek + 1;
                    }

                    if (prazdnyRadek == 0)
                    {
                        for (int i = 0; i < tabulka.ColumnCount; i++)
                        {
                            Control c = tabulka.GetControlFromPosition(i, j);
                            tabulka.Controls.Remove(c);
                            c.Dispose();
                        }
                        tabulka.RowCount--;
                    }
                }
                
            }
            Refresh();

        }*/


        private void nactiTabulku() {

            if (tabulka.RowCount != 1)
                tabulka.Controls.Clear();

            tabulka.RowCount = 1;

            OsobniTabulka t = osobniTabulka;
            tabulka.Controls.Clear();

            for (int i = 0; i < t.HashList.Count; i++) {

                //RowStyle temp = tabulka.RowStyles[tabulka.RowCount - 1];
                tabulka.RowCount++;
                //tabulka.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                int index = tabulka.RowCount == 2 ? 4 : (tabulka.RowCount - 2) * 5 + 4;
                tabulka.Controls.Add(new System.Windows.Forms.TextBox() { Text = t.HashList[i], ForeColor = System.Drawing.Color.White, TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++, BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73))))) }, 0, tabulka.RowCount);
                tabulka.Controls.Add(new System.Windows.Forms.TextBox() { Text = t.Tabulka[i][0], TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 1, tabulka.RowCount);
                tabulka.Controls.Add(new System.Windows.Forms.TextBox() { Text = t.Tabulka[i][1], TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 2, tabulka.RowCount);
                tabulka.Controls.Add(new System.Windows.Forms.TextBox() { Text = t.Tabulka[i][2], TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 3, tabulka.RowCount);
                tabulka.Controls.Add(new System.Windows.Forms.TextBox() { Text = t.Tabulka[i][3], TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 4, tabulka.RowCount);


            }

        }

        private void buttonPridatRadek_MouseEnter(object sender, EventArgs e)
        {
            this.buttonPridatRadek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));

        }

        private void buttonPridatRadek_MouseLeave(object sender, EventArgs e)
        {
            buttonPridatRadek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
        }

        private void buttonReset_MouseEnter(object sender, EventArgs e)
        {
            this.buttonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));

        }

        private void buttonReset_MouseLeave(object sender, EventArgs e)
        {
            buttonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
        }

        private void buttonUlozit_Click(object sender, EventArgs e)
        {

            osoba.jmeno = textBoxJmeno.Text.Trim();
            osoba.prijmeni = textBoxPrijmeni.Text.Trim();
            osoba.osobnicislo = textBoxOC.Text.Trim();

            OsobniTabulka ostab = new OsobniTabulka();

            for (int j = 2; j <= tabulka.RowCount; j++)
            {
                int prazdnyRadek = 0;

                for (int i = 0; i < tabulka.ColumnCount; i++)
                {
                    Control c = tabulka.GetControlFromPosition(i, j);
                    String s = c.Text.Trim();
                    prazdnyRadek = s.Equals("") ? prazdnyRadek : prazdnyRadek + 1;
                }

                if (prazdnyRadek != 0)
                {

                    ostab.setLine(tabulka.GetControlFromPosition(0, j).Text, tabulka.GetControlFromPosition(1, j).Text, tabulka.GetControlFromPosition(2, j).Text, tabulka.GetControlFromPosition(3, j).Text, tabulka.GetControlFromPosition(4, j).Text);

                }
            }

            osoba.osobniTabulka = ostab;


            Close();
        }

        private void buttonUlozit_MouseEnter(object sender, EventArgs e)
        {
            buttonUlozit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));

        }

        private void buttonUlozit_MouseLeave(object sender, EventArgs e)
        {
            buttonUlozit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));

        }
    }
}
