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
            this.ActiveControl = null;
            SendKeys.Send("{TAB}");
            this.main = main;
            index = i;
            karta = main.poleKaret[index];

            textBoxNazev.Text = karta.nazev;
            buttonBarva.BackColor = karta.color;

            tabulka = table;
            this.table.CellPaint += table_CellPaint;
        }

        public Editace_Karty(Karta karta, Main main) {

            InitializeComponent();
            this.ActiveControl = null;
            SendKeys.Send("{TAB}");
            this.main = main;
            index = main.poleKaret.IndexOf(karta);
            this.karta = main.poleKaret[index];

            textBoxNazev.Text = karta.nazev;
            buttonBarva.BackColor = karta.color;

            tabulka = table;
            this.table.CellPaint += table_CellPaint;

        }

        public void ResizeTable() {

            table.Location = new Point(table.Location.X, table.Location.Y + 20);
            table.Size = new System.Drawing.Size(Width - 6, Height - (panel1.Size.Height + 70));
            table.MaximumSize = new System.Drawing.Size(table.Size.Width, Height - (panel1.Size.Height + 70));

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
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Size.Height / 2));

            if (main.Osoby.Count == 0)
            {
                labelZadneVysledkyHledani.Visible = true;
                comboBoxRok.Visible = false;
                comboBoxMesic.Visible = false;
            }

            if (karta.Finally) {

                comboBoxMesic.Enabled = false;
                comboBoxRok.Enabled = false;

            }

            setComboBox();
            vykresliSeznam();
            ResizeTable();
            Refresh();
        }

        private void setComboBox() {

            object[] mesice = new object[] { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };
            comboBoxMesic.Items.AddRange(mesice);
            comboBoxMesic.Text = karta.mesic;

            int rok = Int32.Parse(karta.rok) - 1;
            for (int i = 0; i < 10; i++)
            {
                comboBoxRok.Items.Add((rok+i) + "");
            }
            
            comboBoxRok.Text = karta.rok;

        }

        private void vykresliSeznam() {

            for (int i = 0; i < main.Osoby.Count; i++)
            {

                //--- Vykreslit tlačítko přidat / smazat
                var remove = new Button() { Text = karta.indexyOsob.IndexOf(i) == -1 ? "Přidat" : "Odebrat" };
                remove.Click += new EventHandler(change_Click);
                remove.MouseEnter += new System.EventHandler(change_MouseEnter);
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
            {// zde se přidává osoba do karty

                karta.pridatOsobu(index);
                main.Osoby[index].karty.Add(main.poleKaret.IndexOf(karta));
                main.Osoby[index].dochazka.Add(new List<string>());
                ((Button)sender).Text = "Odebrat";
                ((Button)sender).BackColor = red;

            }
            else
            {// zde se odebírá osoba z karty

                main.Osoby[index].dochazka.RemoveAt(main.Osoby[index].karty.IndexOf(main.poleKaret.IndexOf(karta)));
                main.Osoby[index].karty.RemoveAll(x => x == main.poleKaret.IndexOf(karta));
                karta.indexyOsob.RemoveAll(x => x == index);
                ((Button)sender).Text = "Přidat";
                ((Button)sender).BackColor = blue;

            }

            Refresh();
        }

        private void change_MouseEnter(object sender, EventArgs e)
        {

            if (ModifierKeys == Keys.Control)
                change_Click(sender, e);

        }

        private void buttonBarva_Click(object sender, EventArgs e)
        {

            
                ColorDialog dlg = new ColorDialog();

                if (dlg.ShowDialog() == DialogResult.OK)
                    buttonBarva.BackColor = dlg.Color;

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

            if (!karta.Finally)
            {
                DialogResult result = MessageBox.Show("Měsíc a Rok lze nastavit pouze jednou, chcete tedy vše uložit ?", "POZOR", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    karta.nazev = textBoxNazev.Text;
                    karta.color = buttonBarva.BackColor;
                    karta.mesic = comboBoxMesic.Text;
                    karta.rok = comboBoxRok.Text;

                    karta.Finally = true;
                    ukoncit = false;
                    Close();
                    this.Close();
                }

            }
            else {

                karta.nazev = textBoxNazev.Text;
                karta.color = buttonBarva.BackColor;

                karta.Finally = true;
                ukoncit = false;
                Close();
                this.Close();

            }

        }

        private void table_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
