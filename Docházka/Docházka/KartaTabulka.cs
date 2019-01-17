﻿using System;
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

        int posledniRadek;

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

            SetDoubleBuffered(table);
            vykresliTabulku();
            this.WindowState = FormWindowState.Maximized;

            ResizeTable();
        }

        private void ResizeTable()
        {

            table.Location = new Point(table.Location.X, table.Location.Y + 20);
            table.Size = new System.Drawing.Size(Width - 6, Height - (panel1.Size.Height + 70));
            table.MaximumSize = new System.Drawing.Size(table.Size.Width, Height - (panel1.Size.Height + 70));

        }


        /**
         * Metoda se stará o vykreslen celé tabulky její velikost a pod.
         * 
         **/
        private void vykresliTabulku() {
            table.SuspendLayout();
            table.Visible = false;
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


                table.ColumnCount = 4 + karta.getPocetDnuVMesici(); // nastavení celkového počtu sloupců ve finální tabulce podle aktuálního počtu osob které jsou přidané do listu
                table.RowCount = 2 + 2 * karta.indexyOsob.Count; // --||-- pro řádky

                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F)); // ID
                table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));  // Jmeno prijmeni
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F)); // Pracovní doba a přesčas

                table.Controls.Add(new Label() {
                    Margin = new Padding(8, 6, 0, 0),
                    Text = "ID",
                    AutoSize = true,
                    Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) },
                    0, 0);
                table.Controls.Add(new Label() {
                    Margin = new Padding(5, 6, 0, 0),
                    Text = "Jméno Příjmení ",
                    AutoSize = true,
                    Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) },
                    1, 0);
                table.Controls.Add(new Label() {
                    Margin = new Padding(5, 5, 0, 0),
                    Text = "Pracovní doba" + System.Environment.NewLine + "Přesčas",
                    AutoSize = true,
                    Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) },
                    2, 0);

                
                for (int i = 3; i < karta.getPocetDnuVMesici() + 3; i++) // vytvoření hlavičky čísel dnů v měsíci
                {

                    table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / karta.getPocetDnuVMesici())));
                    table.Controls.Add(new Label() {
                        Anchor = AnchorStyles.Top,
                        Margin = new Padding(0, 7, 0, 0),
                        Text = i - 2 + "",
                        BackColor = Color.Transparent,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                        ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) },
                        i, 0);


                }



                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
                table.Controls.Add(new Label() {
                    Margin = new Padding(5, 9, 0, 0),
                    Text = "Počet dnů",
                    AutoSize = true,
                    Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 
                    table.ColumnCount - 1, 0);


                //----- vykreslení osob

                posledniRadek = 1;
                for (int i = 0; i < karta.indexyOsob.Count; i++)
                {
                    vykresliOsobu(i); // i = index osoby 
                }

                //table.Refresh();
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
                table.ResumeLayout();
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



        /**
         * Metoda přidá do tabulky řádek pro jednoho člověka
         * Vstupní parametr int I = index osoby do pole v main.Osoby kterou chceme vykreslit
         * 
         **/
        private void vykresliOsobu(int i) {

            //--- přidání dvou řádků stylově do tabulky
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));

            //--- přidání labelů s ID a jménem
            Label id = new Label() {
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))),
                Margin = new Padding(-5, 6, 0, 0),
                Text = " " + (i + 1) + ".",
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))),
                BackColor = this.BackColor };

            Label name = new Label() {
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))),
                Margin = new Padding(-5, 6, 0, 0),
                Text = " " + main.Osoby[karta.indexyOsob[i]].jmeno + " " + main.Osoby[karta.indexyOsob[i]].prijmeni + " ",
                AutoSize = true,
                Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))),
                BackColor = this.BackColor };

            table.Controls.Add(id, 0, posledniRadek);
            table.SetRowSpan(id,2); // merge řádků
            table.Controls.Add(name, 1, posledniRadek);
            table.SetRowSpan(name, 2);

            //--- labely pro počet odpracovaých hodin

            table.Controls.Add(new Label() { // label odpracovano hodin
                Margin = new Padding(5, 5, 0, 0),
                AutoSize = true,
                Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) },
                2, posledniRadek);

            table.Controls.Add(new Label(){ // label odpracovano hodin
                Margin = new Padding(5, 5, 0, 0),
                AutoSize = true,
                Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))))},
                2, posledniRadek+1);


            //--- labely pro počet odpracovaných dní


            table.Controls.Add(new Label(){ // label odpracovano dní
                Margin = new Padding(5, 5, 0, 0),
                AutoSize = true,
                Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))))},
                table.ColumnCount-1, posledniRadek);

            table.Controls.Add(new Label(){ // label odpracovano dní přesčas
                Margin = new Padding(5, 5, 0, 0),
                AutoSize = true,
                Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))))},
                table.ColumnCount - 1, posledniRadek + 1);

            posledniRadek = posledniRadek + 2;
        }

        private void buttonNastavit_Click(object sender, EventArgs e)
        {
            Editace_Karty k = new Editace_Karty(karta, main);
            k.ShowDialog();

            table.Controls.Clear();
            vykresliTabulku();
            
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        private void table_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {


            for (int i = 3; i < karta.getPocetDnuVMesici() + 3; i++) {

            
                int day = (int)new DateTime(karta.getIntRok(), karta.getIntMesic(), i - 2).DayOfWeek;
                if (day > 5 && e.Column == i || day > 5 && e.Column == i+1)
                    e.Graphics.FillRectangle(Brushes.Yellow, e.CellBounds);
            }

            if (e.Row == table.RowCount-1)
                e.Graphics.FillRectangle(Brushes.Gray, e.CellBounds);
        }
    }
}
