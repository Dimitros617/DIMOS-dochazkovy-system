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
        public TableLayoutPanel tabulka;
        public Seznam(Main main)
        {
            InitializeComponent();
            this.main = main;
            tabulka = table;
            this.table.CellPaint += table_CellPaint;
        }
        private void table_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            e.Graphics.DrawLine(Pens.LightGray, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
        }

        private void Seznam_Load(object sender, EventArgs e)
        {
            vykresliTabulku();
        }

        public void vykresliTabulku() {

            if (main.Osoby.Count == 0 || main.Osoby == null)
            {
                table.Controls.Add(new Label() { Margin = new Padding(10, 6, 0, 0), Text = "Seznam je prázdný", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73))))) }, 1, 0);
            }
            else
            {
                for (int i = 0; i < main.Osoby.Count; i++)
                {

                    addFromOsobyToTable(i);
                }
            }

        }

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
            //--- Vykreslit tlačítko smazat
            var remove = new Button() { Text = "Smazat" };
            remove.Click += new EventHandler(remove_Click);
            remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            remove.Cursor = System.Windows.Forms.Cursors.Hand;
            remove.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            remove.ForeColor = System.Drawing.Color.White;
            remove.Size = new System.Drawing.Size(142, 32);
            remove.TabIndex = i;
            table.Controls.Add(remove, 3, i);
            //--- Vykreslení ID
            table.Controls.Add(new Label() { Margin = new Padding(5, 9, 0, 0), Text = "" + (i+1) + ".", AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 0, i);
            //--- Vykreslení Jména
            table.Controls.Add(new Label() { Margin = new Padding(10, 9, 0, 0), Text = main.Osoby[i].jmeno + " " + main.Osoby[i].prijmeni, AutoSize = true, Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))), ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) }, 1, i);



        }

        private void edit_Click(object sender, EventArgs e) {

            int index = ((Button)sender).TabIndex;
            new Editace_osob("EDIT", main.Osoby[index],this).ShowDialog();
            table.GetControlFromPosition(1, index).Text = main.Osoby[index].jmeno + " " + main.Osoby[index].prijmeni;

        }

        private void remove_Click(object sender, EventArgs e)
        {

            int index = ((Button)sender).TabIndex;
            DialogResult dialogResult = MessageBox.Show( "Opravdu si přejete odstranit osobu: " + main.Osoby[index].jmeno + " " + main.Osoby[index].prijmeni, "ODSTRANIT", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                main.Osoby.RemoveAt(index);
                table.Controls.Clear();
                vykresliTabulku();
            }
            

        }

        private void pridat_Click(object sender, EventArgs e)
        {
            Osoba o = new Osoba();
            main.Osoby.Add(o);
            Editace_osob eo = new Editace_osob("NEW", o);
            eo.seznam = this;
            Editace_osob pridat = eo;

            pridat.ShowDialog();

            table.Controls.Clear();
            vykresliTabulku();
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

        private void buttonHledat_Click(object sender, EventArgs e)
        {
            if (!textBoxHledat.Text.Trim().Equals("") && main.Osoby != null)
            {
                List<Osoba> list = new List<Osoba>();
                int count = 0;
                for (int i = 0; i < main.Osoby.Count; i++)
                    if (!(main.Osoby[i].jmeno + main.Osoby[i].prijmeni).Contains(textBoxHledat.Text.Trim()))
                    {
                        table.GetControlFromPosition(0, i).Visible = false;
                        table.GetControlFromPosition(1, i).Visible = false;
                        table.GetControlFromPosition(2, i).Visible = false;
                        table.GetControlFromPosition(3, i).Visible = false;
                        count++;
                    }
                if (count == main.Osoby.Count)
                    labelZadneVysledkyHledani.Visible = true;
            }
            else if (textBoxHledat.Text.Trim().Equals("") && main.Osoby != null)
            {
                labelZadneVysledkyHledani.Visible = false;
                for (int i = 0; i < main.Osoby.Count; i++)
                {
                    table.GetControlFromPosition(0, i).Visible = true;
                    table.GetControlFromPosition(1, i).Visible = true;
                    table.GetControlFromPosition(2, i).Visible = true;
                    table.GetControlFromPosition(3, i).Visible = true;
                }
            }

            table.RowStyles[0].Height = 0;

        }


        /*  private void table_MouseClick(object sender, MouseEventArgs e)
          {
              int row = 0;
              int verticalOffset = 0;
              foreach (int h in table.GetRowHeights())
              {
                  int column = 0;
                  int horizontalOffset = 0;
                  foreach (int w in table.GetColumnWidths())
                  {
                      Rectangle rectangle = new Rectangle(horizontalOffset, verticalOffset, w, h);
                      if (rectangle.Contains(e.Location))
                      {
                          Console.WriteLine(String.Format("row {0}, column {1} was clicked", row, column));
                          return;
                      }
                      horizontalOffset += w;
                      column++;
                  }
                  verticalOffset += h;
                  row++;
              }
          }*/

    }
}
