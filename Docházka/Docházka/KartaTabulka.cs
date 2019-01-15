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
        Karta karta;
        Main main;

        public KartaTabulka(Main main, Karta karta)
        {
            InitializeComponent();

            this.main = main;
            this.karta = karta;
        }

        private void KartaTabulka_Load(object sender, EventArgs e)
        {
            Location = new Point(0,0);
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            


            ActiveControl = panel1;
            this.Text = this.Text + karta.nazev;
            labelRok.Text = karta.rok;
            labelMesic.Text = karta.mesic;

            vykresliTabulku();
            this.WindowState = FormWindowState.Maximized;
        }

        private void vykresliTabulku() {


            if (karta.indexyOsob.Count != 0)
            {
                
                table.Visible = true;
                labelMesic.Visible = true;
                labelRok.Visible = true;
                label1.Visible = true;
                labelZadneVysledkyHledani.Visible = false;

                //--- vykreslení hlavyčky a nastavení veliskoti tabulky
                //table.Size = new Size(Size.Width, (2 + karta.indexyOsob.Count) * 30);
                table.Controls.Clear();
                table.ColumnStyles.Clear();
                table.RowStyles.Clear();
                //table.Dock = DockStyle.Top;
                table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;


                table.ColumnCount = 4 + karta.getPocetDnuVMesici();
                table.RowCount = 1 + 2 * karta.indexyOsob.Count;

                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F)); // ID
                table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));  // Jmeno prijmeni
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F)); // Pracovní doba a přesčas

                table.Controls.Add(new Label() { Margin = new Padding(8, 6, 0, 0), Text = "ID", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 0, 0);
                table.Controls.Add(new Label() { Margin = new Padding(5, 6, 0, 0), Text = "Jméno Příjmení ", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 1, 0);
                table.Controls.Add(new Label() { Margin = new Padding(5, 5, 0, 0), Text = "Pracovní doba" + System.Environment.NewLine + "Přesčas", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 2, 0);


                for (int i = 3; i < karta.getPocetDnuVMesici() + 3; i++)
                {

                    table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / karta.getPocetDnuVMesici())));
                    table.Controls.Add(new Label() { Anchor = AnchorStyles.Top, Margin = new Padding(0, 7, 0, 0), Text = i - 2 + "", BackColor = Color.Transparent, AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, i, 0);


                }



                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
                table.Controls.Add(new Label() { Margin = new Padding(5, 9, 0, 0), Text = "Počet dnů", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, table.ColumnCount - 1, 0);

                //----- vykreslení osob

                for (int i = 0; i < karta.indexyOsob.Count; i++)
                {
                    vykresliOsobu(i);
                }

                //table.Refresh();

            }
            else
            {
                table.Visible = false;
                labelMesic.Visible = false;
                labelRok.Visible = false;
                label1.Visible = false;
                labelZadneVysledkyHledani.Visible = true;
            }
        }




        private void vykresliOsobu(int i) {

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            table.Controls.Add(new Label() { Margin = new Padding(8, 6, 0, 0), Text = i+1 + ".", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 0, i+1);
            table.Controls.Add(new Label() { Margin = new Padding(5, 6, 0, 0), Text = main.Osoby[karta.indexyOsob[i]].jmeno + " " + main.Osoby[karta.indexyOsob[i]].prijmeni + " ", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 1, i+1);

        }

        private void buttonNastavit_Click(object sender, EventArgs e)
        {
            Editace_Karty k = new Editace_Karty(karta, main);
            
            k.ShowDialog();
            
            new KartaTabulka(main, karta).ShowDialog();
            this.Close();
        }

        private void table_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            List<int> SoNe = new List<int>();

            for (int i = 3; i < karta.getPocetDnuVMesici() + 3; i++)
            {
                
            }

            for (int i = 3; i < karta.getPocetDnuVMesici() + 3; i++) {

            
                int day = (int)new DateTime(karta.getIntRok(), karta.getIntMesic(), i - 2).DayOfWeek;
                if (day > 5 && e.Column == i || day > 5 && e.Column == i+1)
                    e.Graphics.FillRectangle(Brushes.Yellow, e.CellBounds);
            }
        }
    }
}
