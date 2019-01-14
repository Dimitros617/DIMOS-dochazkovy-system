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
    public partial class Karty : Form
    {
        public Main main;
        ContextMenuStrip ContextMenu;

        public Karty(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Karty_Load(object sender, EventArgs e)
        {
            vykreslitKarty();

            if (main.poleKaret.Count == 0)
            labelZadneVysledkyHledani.Visible = true;
        }

        private void buttonPridatKartu_Click(object sender, EventArgs e)
        {
            main.poleKaret.Add(new Karta());
            table.Controls.Clear();
            vykreslitKarty();
        }

        private void vykreslitKarty() {

            if (main.poleKaret.Count == 0)
            labelZadneVysledkyHledani.Visible = true;
            else
            labelZadneVysledkyHledani.Visible = false;


            for (int i = 0; i < main.poleKaret.Count; i++)
            {
                ContextMenuStrip c = new ContextMenuStrip();

                ToolStripMenuItem nastaveniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                ToolStripMenuItem smazatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

                nastaveniToolStripMenuItem.MergeIndex = i;
                nastaveniToolStripMenuItem.Text = "Nastavení";
                nastaveniToolStripMenuItem.Click += new System.EventHandler(this.nastaveniToolStripMenuItem_Click);
                smazatToolStripMenuItem.MergeIndex = i;
                smazatToolStripMenuItem.Text = "Smazat";
                smazatToolStripMenuItem.Click += new System.EventHandler(this.smazatToolStripMenuItem_Click);

                c.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                 nastaveniToolStripMenuItem,
                 smazatToolStripMenuItem});


                var add = new Button() { Text = main.poleKaret[i].nazev };
                add.Click += new EventHandler(add_Click);
                add.BackColor = main.poleKaret[i].color;
                add.Cursor = System.Windows.Forms.Cursors.Hand;
                add.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                add.ForeColor = System.Drawing.Color.White;
                add.Size = new System.Drawing.Size(200, 100);
                add.Anchor = System.Windows.Forms.AnchorStyles.Top;
                add.TabIndex = i;
                //add.MouseEnter += new System.EventHandler(Karty_MouseEnter);
                //add.MouseLeave += new System.EventHandler(Karty_MouseLeave);
                add.ContextMenuStrip = c;
                toolTip.SetToolTip(add, "Kliknutím pravým tlačítkem můžete kartu Nastavit neb Smazat");
                table.Controls.Add(add, i % 3, i / 3);

            }

        }

        private void nastaveniToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = ((ToolStripMenuItem)sender).MergeIndex;
            Editace_Karty kartaNasaveni = new Editace_Karty(index,main);
            kartaNasaveni.ShowDialog();
            table.GetControlFromPosition(index % 3, index / 3).Text = main.poleKaret[index].nazev;
            table.GetControlFromPosition(index % 3, index / 3).BackColor = main.poleKaret[index].color;
            Refresh();
        }

        private void smazatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = ((ToolStripMenuItem)sender).MergeIndex;

            DialogResult result = MessageBox.Show("Opravdu si přejete smazat kartu: " + main.poleKaret[index].nazev, "SMAZAT ?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                main.poleKaret.RemoveAt(index);
                table.Controls.Clear();
                vykreslitKarty();
            }
        }

        /**
         * Klinutí na kartu
         **/
        private void add_Click(object sender, EventArgs e)
        {

            int index = ((Button)sender).TabIndex;

        }

        private void Karty_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
        }

        private void Karty_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));

        }





    }
}
