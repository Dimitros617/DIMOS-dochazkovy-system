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
    public partial class Editace_Karty : Form
    {

        Color blue = Color.FromArgb(32, 65, 48);
        Color red = Color.FromArgb(252, 67, 73);

        int index;
        Main main;
        Karta karta;
        Boolean ukoncit = true;

        public TableLayoutPanel tabulka;

        public Editace_Karty(int i, Main main)
        {
            InitializeComponent();
            this.main = main;
            index = i;
            karta = main.poleKaret[index];

            textBoxNazev.Text = karta.nazev;
            buttonBarva.BackColor = karta.color;

            tabulka = table;
            this.table.CellPaint += table_CellPaint;
        }

        /**
         * Metoda vykresluje čáry jako hranice v tabulce
         **/
        private void table_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            e.Graphics.DrawLine(Pens.LightGray, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
        }

        private void Editace_Karty_Load(object sender, EventArgs e)
        {

            labelZadneVysledkyHledani.Visible = main.Osoby.Count == 0 ? true : false;
            vykresliSeznam();
            Refresh();
        }

        private void vykresliSeznam() {

            for (int i = 0; i < main.Osoby.Count; i++)
            {

                //--- Vykreslit tlačítko přidat / smazat
                var remove = new Button() { Text = karta.indexyOsob.IndexOf(i) == -1 ? "Přidat" : "Smazat" };
                remove.Click += new EventHandler(change_Click);
                remove.BackColor = karta.indexyOsob.IndexOf(i) == -1 ? blue : red;
                remove.Cursor = System.Windows.Forms.Cursors.Hand;
                remove.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                remove.ForeColor = System.Drawing.Color.White;
                remove.Size = new System.Drawing.Size(142, 32);
                remove.TabIndex = i;
                table.Controls.Add(remove, 2, i);
                //--- Vykreslení ID
                table.Controls.Add(new Label() { Margin = new Padding(5, 9, 0, 0), Text = "" + (i + 1) + ".", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 0, i);
                //--- Vykreslení Jména
                table.Controls.Add(new Label() { Margin = new Padding(10, 9, 0, 0), Text = main.Osoby[i].jmeno + " " + main.Osoby[i].prijmeni, AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 1, i);

            }
        }

        private void change_Click(object sender, EventArgs e)
        {

            int index = ((Button)sender).TabIndex;

            if (karta.indexyOsob.IndexOf(index) == -1)
            {

                karta.pridatOsobu(index);
                ((Button)sender).Text = "Smazat";
                ((Button)sender).BackColor = red;

            }
            else {

                karta.indexyOsob.RemoveAll(x => x == index);
                ((Button)sender).Text = "Přidat";
                ((Button)sender).BackColor = blue;

            }

            Refresh();
        }

        private void buttonBarva_Click(object sender, EventArgs e)
        {

            
                ColorDialog dlg = new ColorDialog();

                if (dlg.ShowDialog() == DialogResult.OK)
                    karta.color = dlg.Color;

                buttonBarva.BackColor = karta.color;
                Refresh();
        }

        private void Editace_Karty_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ukoncit)
            {
                DialogResult result = MessageBox.Show("Přejete si data nejdříve uložit ?", "Uložit ?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    buttonUlozit_Click(sender, e);
                    this.Close();
                }
                else
                {
                    ukoncit = false;
                    this.Close();
                }
            }
        }

        private void buttonUlozit_Click(object sender, EventArgs e)
        {

            karta.nazev = textBoxNazev.Text;

            ukoncit = false;
            Close();

        }

        private void table_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
