using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Docházka
{
    public partial class Karty : Form
    {
        public Main main;
        List<int> tiskovaFronta = new List<int>();


        public Karty(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Karty_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Size.Height / 2));

            this.ActiveControl = null;
            vykreslitKarty();

            if (main.poleKaret.Count == 0)
            labelZadneVysledkyHledani.Visible = true;
        }

        private void buttonPridatKartu_Click(object sender, EventArgs e)
        {
            main.poleKaret.Add(new Karta(main));
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
                ToolStripMenuItem kopirovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                ToolStripMenuItem tisknoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                ToolStripMenuItem smazatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

                nastaveniToolStripMenuItem.MergeIndex = i;
                nastaveniToolStripMenuItem.Text = "Nastavení";
                nastaveniToolStripMenuItem.Click += new System.EventHandler(this.nastaveniToolStripMenuItem_Click);

                kopirovatToolStripMenuItem.MergeIndex = i;
                kopirovatToolStripMenuItem.Text = "Duplikovat";
                kopirovatToolStripMenuItem.Click += new System.EventHandler(this.kopirovatToolStripMenuItem_Click);

                tisknoutToolStripMenuItem.MergeIndex = i;
                tisknoutToolStripMenuItem.Text = "Přidat k tisku";
                tisknoutToolStripMenuItem.Click += new System.EventHandler(this.pridatTiskToolStripMenuItem_Click);

                smazatToolStripMenuItem.MergeIndex = i;
                smazatToolStripMenuItem.Text = "Smazat";
                smazatToolStripMenuItem.Click += new System.EventHandler(this.smazatToolStripMenuItem_Click);

                c.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                 nastaveniToolStripMenuItem,
                 kopirovatToolStripMenuItem,
                 tisknoutToolStripMenuItem,
                 smazatToolStripMenuItem});


                var add = new Button() { Text = main.poleKaret[i].nazev + (main.poleKaret[i].Finally ? (System.Environment.NewLine + main.poleKaret[i].rok + " " + main.poleKaret[i].mesic) : "" )};
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
            table.GetControlFromPosition(index % 3, index / 3).Text = main.poleKaret[index].nazev + (main.poleKaret[index].Finally ? (System.Environment.NewLine + main.poleKaret[index].rok + " " + main.poleKaret[index].mesic) : "");
            table.GetControlFromPosition(index % 3, index / 3).BackColor = main.poleKaret[index].color;

            Refresh();
        }

        private void pridatTiskToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = ((ToolStripMenuItem)sender).MergeIndex;
            if (tiskovaFronta.IndexOf(index) == -1)
            {
                ((ToolStripMenuItem)sender).Text = "Odebrat z tisku";
                tiskovaFronta.Add(index);
                buttonTisk.Text = "Vytisknout " + tiskovaFronta.Count + (tiskovaFronta.Count == 1 ? " kartu" : tiskovaFronta.Count > 1 && tiskovaFronta.Count < 5 ? " karty" : " karet");
            }
            else
            {
                ((ToolStripMenuItem)sender).Text = "Přidat k tisku";
                tiskovaFronta.RemoveAll(x => x == index);
                buttonTisk.Text = "Vytisknout " + tiskovaFronta.Count + (tiskovaFronta.Count == 1 ? " kartu" : tiskovaFronta.Count > 1 && tiskovaFronta.Count < 5 ? " karty" : " karet");

            }
        }

        private void smazatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = ((ToolStripMenuItem)sender).MergeIndex;

            DialogResult result = MessageBox.Show("Opravdu si přejete smazat kartu: " + main.poleKaret[index].nazev, "SMAZAT ?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for (int item = 0; item < main.Osoby.Count; item++)
                {
                    if (main.Osoby[item].karty.IndexOf(index) != -1)
                    {
                        main.Osoby[item].dochazka.RemoveAt(main.Osoby[item].karty.IndexOf(index));
                        main.Osoby[item].karty.RemoveAll(p => p == index);
                    }

                    for (int i = 0; i < main.Osoby[item].karty.Count; i++)
                    {
                        if (main.Osoby[item].karty[i] > index)
                            main.Osoby[item].karty[i] = main.Osoby[item].karty[i] - 1;
                    }
                }

                if (File.Exists(main.path + "\\DIMOS\\" + index + ".png"))
                    System.IO.File.Delete(main.path + "\\DIMOS\\" + index + ".png");

                for (int i = index + 1; i < main.poleKaret.Count; i++)
                {
                    if (File.Exists(main.path + "\\DIMOS\\" + i + ".png"))
                    {
                        System.IO.File.Move(main.path + "\\DIMOS\\" + i + ".png", main.path + "\\DIMOS\\" + (i-1) + ".png");
                    }
                }

                main.poleKaret.RemoveAt(index);
                table.Controls.Clear();
                vykreslitKarty();
            }
        }

        private void kopirovatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = ((ToolStripMenuItem)sender).MergeIndex;

            Karta k = Clone(main.poleKaret[index]);
            main.poleKaret.Add(k);

            foreach (int i in k.indexyOsob)
            {
                main.Osoby[i].dochazka.Add(new List<string>(31));
                main.Osoby[i].karty.Add(main.poleKaret.IndexOf(k));

                for (int j = 0; j < 32; j++)
                    main.Osoby[i].dochazka[main.Osoby[i].dochazka.Count - 1].Add(null);
            }

            table.Controls.Clear();
            vykreslitKarty();

        }

        private Karta Clone(Karta k) {

            return new Karta(main) { color = k.color, nazev = k.nazev, mesic = k.mesic, rok = k.rok, indexyOsob = new List<int>(k.indexyOsob) };

        }

        /**
         * Klinutí na kartu
         **/
        private void add_Click(object sender, EventArgs e)
        {

            int index = ((Button)sender).TabIndex;
            KartaTabulka k = new KartaTabulka(main,main.poleKaret[index]);
            k.ShowDialog();
            table.Controls.Clear();
            vykreslitKarty();
        }

        private void Karty_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
        }

        private void Karty_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));

        }

        PrintDocument pd;

        private void buttonTisk_Click(object sender, EventArgs e)
        {
            if (tiskovaFronta.Count == 0)
            {
                MessageBox.Show("Vyberte karty tak, že na některou kliknete pravým tlačítkem myši a kliknete na Přidat k tisku");
            }
            else
            {
                String jpg3 = main.path + "\\DIMOS\\tisk.png";
                int sirka = 0;
                int vyska = 0;
                List<Image> obrazky = new List<Image>();

                for (int i = 0; i < tiskovaFronta.Count; i++)
                {
                    if (File.Exists(main.path + "\\DIMOS\\" + tiskovaFronta[i] + ".png"))
                    {
                        obrazky.Add(Image.FromFile(main.path + "\\DIMOS\\" + tiskovaFronta[i] + ".png"));
                        sirka = obrazky[obrazky.Count - 1].Width;
                        vyska = vyska + obrazky[obrazky.Count - 1].Height;
                    }
                    else
                    {
                        MessageBox.Show("Není vytvořena tisková grafika pro kartu " + main.poleKaret[i].nazev + " Otevřete tuto kartu a uložte ji.");
                    }
                }



                    Bitmap img3 = new Bitmap(sirka, vyska);
                    Graphics g = Graphics.FromImage(img3);

                    Point p = new Point(0, 0);
                    g.Clear(Color.White);
                    for (int j = 0; j < obrazky.Count; j++)
                    {
                        g.DrawImage(obrazky[j], p);
                        p = new Point(0, p.Y + obrazky[j].Height);
                    }


                    g.Dispose();

                    img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
                    img3.Dispose();



                pd = new PrintDocument();

                pd.DefaultPageSettings.Landscape = true;

                Margins margins = new Margins(5, 5, 5, 5);
                pd.DefaultPageSettings.Margins = margins;

                pd.PrintPage += PrintPage;
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = pd;
               



                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pd.Print();
                }
            }
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(main.path + "\\DIMOS\\tisk.png");
                Rectangle m = e.MarginBounds;

                if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // obrazek je širší
                {
                    pd.DefaultPageSettings.Landscape = true;
                    m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
                }
                else
                {
                    pd.DefaultPageSettings.Landscape = false;
                    m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
                }
                e.Graphics.DrawImage(img, m);

            }
            catch
            {

            }
        }


        private void vymazatTisknovouFrontuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tiskovaFronta = new List<int>();
            buttonTisk.Text = "Vytisknout 0 karet";
        }
    }
}
