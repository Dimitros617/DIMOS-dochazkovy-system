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
    public partial class Seznam : Form
    {

        Main main;
        public TableLayoutPanel tabulka;

        public string karta1 = "";
        public string karta2 = "";
        public string karta3 = "";

        public Boolean zavrit = false;

        public Seznam(Main main)
        {
            InitializeComponent();
            this.main = main;
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

        private void Seznam_Load(object sender, EventArgs e)
        {
            labelPrazdnySeznam.Visible = main.Osoby.Count == 0 ? true : false;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Size.Height / 2));
            vykresliTabulku();
        }

        /**
         * Tabulka pokud je list Osoby prázdný zobrazí text Seznam je prázdný pokud ne nechá vykreslit všechny prvky v listu Osoby do tabulky
         **/
        public void vykresliTabulku() {

            table.SuspendLayout();
                for (int i = 0; i < main.Osoby.Count; i++)
                {

                    addFromOsobyToTable(i);
                }
            table.ResumeLayout();
        }

        /**
         * Metoda vykreslí řádek do tabulky konkrétní osobě vytvoří label s ID label se jménem a příjemním + 2 tlačítka na editaci a smazat
         * Vstupní int i je index Osoby v listu Osoby v Mainu
         **/
        private void addFromOsobyToTable(int i) {

            //--- Vykreslit talčítko přidat
            var edit = new Button() { Text = "Upravit" };
            edit.Click += new EventHandler(edit_Click);
            edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            edit.Cursor = System.Windows.Forms.Cursors.Hand;
            edit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            edit.ForeColor = System.Drawing.Color.White;
            edit.Size = new System.Drawing.Size(142, 32);
            edit.TabIndex = i;
            table.Controls.Add(edit, 2, i);
            //--- Vykreslit talčítko tisk
            var tisk = new Button() { Text = "Tisk" };
            tisk.Click += new EventHandler(tisk_Click);
            tisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            tisk.Cursor = System.Windows.Forms.Cursors.Hand;
            tisk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            tisk.ForeColor = System.Drawing.Color.White;
            tisk.Size = new System.Drawing.Size(142, 32);
            tisk.TabIndex = i;
            table.Controls.Add(tisk, 3, i);
            //--- Vykreslit tlačítko smazat
            Button remove = new Button() { Text = "Smazat" };
            remove.Click += new EventHandler(remove_Click);
            remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            remove.Cursor = System.Windows.Forms.Cursors.Hand;
            remove.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            remove.ForeColor = System.Drawing.Color.White;
            remove.Size = new System.Drawing.Size(142, 32);
            remove.TabIndex = i;
            table.Controls.Add(remove, 4, i);
            //--- Vykreslení ID
            table.Controls.Add(new Label() { Margin = new Padding(5, 9, 0, 0), Text = "" + (i+1) + ".", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 0, i);
            //--- Vykreslení Jména
            table.Controls.Add(new Label() { Margin = new Padding(10, 9, 0, 0), Text = main.Osoby[i].jmeno + " " + main.Osoby[i].prijmeni, AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 1, i);

        }

        /**
         * Instanční třída pro každé tlačítko edit u každé osoby
         * vytvoří instanci okna Editace_osob a načte do něj data konkrétní osoby
         **/
        private void edit_Click(object sender, EventArgs e) {

            int index = ((Button)sender).TabIndex;
            new Editace_osob("EDIT", main.Osoby[index],this).ShowDialog();
            table.GetControlFromPosition(1, index).Text = main.Osoby[index].jmeno + " " + main.Osoby[index].prijmeni;
        }

        /**
         * Instanční třída pro každé tlačítko tisk u každé osoby
         **/
        private void tisk_Click(object sender, EventArgs e)
        {
            int index = ((Button)sender).TabIndex;
            new Vyber_karet(main, this, index).ShowDialog();


            //TODO ------------------------------------------------------------------------------ TODO
        }
        
        /**
         * Instanční třída pro každé tlačítko zmazat u každé osoby
         * vymže tuto osobu z listu a graficky překreslý celou tabulku
         **/
        private void remove_Click(object sender, EventArgs e)
        {

            int index = ((Button)sender).TabIndex; 
            DialogResult dialogResult = MessageBox.Show( "Opravdu si přejete odstranit osobu: " + main.Osoby[index].jmeno + " " + main.Osoby[index].prijmeni + System.Environment.NewLine + System.Environment.NewLine + "Celá tabulka se graficky obnový", "ODSTRANIT", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < main.Osoby[index].karty.Count; i++) {
                    int findIndex = main.poleKaret[main.Osoby[index].karty[i]].indexyOsob.IndexOf(index) ;
                    main.poleKaret[main.Osoby[index].karty[i]].indexyOsob.Remove(index);
                    for (int j = findIndex; j < main.poleKaret[main.Osoby[index].karty[i]].indexyOsob.Count; j++) {
                        main.poleKaret[main.Osoby[index].karty[i]].indexyOsob[j]--;
                    }
                }
                main.Osoby.RemoveAt(index);
                table.SuspendLayout();
                table.Controls.Clear();
                vykresliTabulku();
                table.ResumeLayout();
            }
            labelPrazdnySeznam.Visible = main.Osoby.Count == 0 ? true : false;
        }

        /**
         * Metoda po kliknutí na tlačítko přidat osobu v horní liště vytvoří a zobrazí instanci ona Editace_osob
         * Po zavření okna se tabulka celá překreslí znova
         **/
        private void pridat_Click(object sender, EventArgs e)
        {
            int pocet = main.Osoby.Count();

            Editace_osob eo = new Editace_osob("NEW", main);
            eo.seznam = this;

            eo.ShowDialog();

            if (main.Osoby.Count != 0 && main.Osoby.Count() != pocet)
            {
                labelPrazdnySeznam.Visible = main.Osoby.Count == 0 ? true : false;
                addFromOsobyToTable(main.Osoby.Count - 1);
            }
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

        /**
         * 
         * Metoda prohledá jména a příjmení všech osob v listu Osoby v Mainu a pokud jméno.
         * Pokud alespoň část jeména a příjmení obsahuje string v textboduHledat zobrazí se tato osoba v seznamu
         * Všechny ostatní osoby jsou skryty 
         * Pokud je TextBox prázdný po vyhledání se zobrazí všechny osoby v listu
         **/
        private void buttonHledat_Click(object sender, EventArgs e)
        {
            table.Visible = false;
            table.SuspendLayout();
            if (!textBoxHledat.Text.Trim().ToLower().Equals("") && main.Osoby != null)
            {
                int count = 0;
                for (int i = 0; i < main.Osoby.Count; i++)
                    if (!(main.Osoby[i].jmeno + main.Osoby[i].prijmeni).ToLower().Contains(textBoxHledat.Text.Trim().ToLower()))
                    {
                        table.GetControlFromPosition(0, i).Visible = false;
                        table.GetControlFromPosition(1, i).Visible = false;
                        table.GetControlFromPosition(2, i).Visible = false;
                        table.GetControlFromPosition(3, i).Visible = false;
                        table.GetControlFromPosition(4, i).Visible = false;
                        count++;
                    }
                if (count == main.Osoby.Count)
                    labelZadneVysledkyHledani.Visible = true;
            }
            else if (textBoxHledat.Text.Trim().ToLower().Equals("") && main.Osoby != null)
            {
                labelZadneVysledkyHledani.Visible = false;
                for (int i = 0; i < main.Osoby.Count; i++)
                {
                    table.GetControlFromPosition(0, i).Visible = true;
                    table.GetControlFromPosition(1, i).Visible = true;
                    table.GetControlFromPosition(2, i).Visible = true;
                    table.GetControlFromPosition(3, i).Visible = true;
                    table.GetControlFromPosition(4, i).Visible = true;
                }
            }
            table.ResumeLayout();
            table.Visible = true;
        }

        private void Seznam_Resize(object sender, EventArgs e)
        {
            //table.Size = new System.Drawing.Size(Width + 10, Height - (panel1.Size.Height + label1.Size.Height +70 ) );
            //table.MaximumSize = new System.Drawing.Size(Width+5, table.MaximumSize.Height);
        }

        private void Seznam_ResizeEnd(object sender, EventArgs e)
        {
            table.SuspendLayout();
            table.Visible = false;
            table.Size = new System.Drawing.Size(Width - 15, Height - (panel1.Size.Height + label1.Size.Height + 50));
            table.Visible = true;
            table.ResumeLayout();
        }

        private void nastaveni_Click_1(object sender, EventArgs e)
        {
                Nastaveni nastaveni = new Nastaveni(main);
                this.Hide();
                nastaveni.ShowDialog();
                this.Show();

        }
    }
}
