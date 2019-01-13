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
        }

        private void buttonPridatKartu_Click(object sender, EventArgs e)
        {
            main.poleKaret.Add(new Karta());
            table.Controls.Clear();
            vykreslitKarty();
        }

        private void vykreslitKarty() {

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


                var add = new Button() { Text = "Karta" };
                add.Click += new EventHandler(add_Click);
                add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
                add.Cursor = System.Windows.Forms.Cursors.Hand;
                add.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                add.ForeColor = System.Drawing.Color.White;
                add.Size = new System.Drawing.Size(142, 32);
                add.TabIndex = i;
                add.ContextMenuStrip = c;
                table.Controls.Add(add, i % 3, i / 3);

            }

        }

        private void nastaveniToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = ((ToolStripMenuItem)sender).MergeIndex;
            label1.Text = index + " nastaveni";
            Refresh();
        }

        private void smazatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = ((ToolStripMenuItem)sender).MergeIndex;
            label1.Text = index + " smazat";
        }


        private void add_Click(object sender, EventArgs e)
        {

            int index = ((Button)sender).TabIndex;

        }

        private void nastaveniToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }



        /*private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color c = dlg.Color;
                button1.BackColor = new Color();
                
            }
        }*/// Výber barvy
    }
}
