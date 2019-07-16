using FMUtils.Screenshot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
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

            Location = new Point(0, 0);
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            ActiveControl = panel1;
            this.Text = this.Text + karta.nazev;
            labelRok.Text = karta.rok;
            labelMesic.Text = karta.mesic;

            this.WindowState = FormWindowState.Maximized;
            SetDoubleBuffered(table);

            vykresliTabulku();

        }

        private void KartaTabulka_Load(object sender, EventArgs e)
        {



            labelNazevKarty.Text = karta.nazev;
            //ResizeTable();


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
                UpdateCountPole();
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
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))),
                Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68))))) },
                2, posledniRadek);

            table.Controls.Add(new Label(){ // label odpracovano hodin
                Margin = new Padding(5, 5, 0, 0),
                AutoSize = true,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))),
                Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))))},
                2, posledniRadek+1);


            //--- labely pro počet odpracovaných dní


            table.Controls.Add(new Label(){ // label odpracovano dní
                Margin = new Padding(5, 5, 0, 0),
                AutoSize = true,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))),
                Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))))},
                table.ColumnCount-1, posledniRadek);

            table.Controls.Add(new Label(){ // label odpracovano dní přesčas
                Margin = new Padding(5, 5, 0, 0),
                AutoSize = true,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))),
                Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))))},
                table.ColumnCount - 1, posledniRadek + 1);

            int idKarty = main.poleKaret.IndexOf(karta);
            int idDochazky = main.Osoby[karta.indexyOsob[i]].karty.IndexOf(idKarty);

            List<String> radek = main.Osoby[karta.indexyOsob[i]].dochazka[idDochazky];

            for (int j = 3; j < karta.getPocetDnuVMesici() + 3; j++) {
                int day = (int)new DateTime(karta.getIntRok(), karta.getIntMesic(), j - 2).DayOfWeek;
                //--- prvni radek

                TextBox t = new TextBox()
                {
                    BackColor = day > 5 || day == 0 ? Color.Yellow : BackColor,
                    Text = radek.Count != (karta.getPocetDnuVMesici() * 2) ? "" : radek[j - 3], //POZOR UPRAVA ----------------------- -1
                    BorderStyle = System.Windows.Forms.BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    TabIndex = karta.getPocetDnuVMesici() * posledniRadek + j,
                    Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)))
                };
                t.Leave += new System.EventHandler(pole_Leave);
                
                table.Controls.Add(t, j, posledniRadek);

                //--- druhy radek
                TextBox t2 = new TextBox()
                {
                    BackColor = day > 5 || day == 0 ? Color.Yellow : BackColor,
                    Text = radek.Count != (karta.getPocetDnuVMesici() * 2) ? "" : radek[(j - 3) + karta.getPocetDnuVMesici()],
                    BorderStyle = System.Windows.Forms.BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    TabIndex = karta.getPocetDnuVMesici() * (posledniRadek + 1) + j,
                    Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)))
                };
                t2.Leave += new System.EventHandler(pole_Leave);

                table.Controls.Add(t2, j, posledniRadek+1);

            }


                posledniRadek = posledniRadek + 2;
        }

        private void UpdateCountPole()
        {



            for (int i = 1; i < table.RowCount-1; i++)
            {
                double pocetHodin = 0;
                int pocetDnu = 0;
                for (int j = 3; j < karta.getPocetDnuVMesici() + 3; j++)
                {

                    String hodnota = table.GetControlFromPosition(j, i).Text;



                    int index = i % 2 != 0 ? i / 2 : (i - 1) / 2;
                    OsobniTabulka o = main.Osoby[karta.indexyOsob[index]].osobniTabulka;
                    int dayOfWeek = (int)new DateTime(karta.getIntRok(), karta.getIntMesic(), j - 2).DayOfWeek;
                    dayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;

                    // Pocet odpracovanych dni
                    double pocethod = 0;
                    if (i % 2 == 0)
                    {
                        pocetDnu = hodnota.Equals("") ? pocetDnu : pocetDnu + 1;
                    }
                    else if (hodnota.Equals(""))
                    {

                    }
                    else if (!o.Obsahuje(hodnota))
                    {

                        if (!o.Obsahuje(hodnota + "/" + dayOfWeek))
                        {
                            MessageBox.Show("Tato hodnota není obsažena v osobní tabulce Osoby");
                            pocetDnu--;
                        }
                        else
                        {
                            pocethod = Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota + "/" + dayOfWeek)][0]);
                            pocetDnu = pocethod == 0 ? pocetDnu : pocetDnu + 1;
                        }
                    }
                    else
                    {
                        pocethod = Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota.ToUpper())][0]);
                        pocetDnu = pocethod == 0 ? pocetDnu : pocetDnu + 1;
                    }

                    //NAstaveni poctu hodin odpracovanych

                    if (i % 2 == 0)
                    {
                        try
                        {
                            pocetHodin = hodnota.Equals("") ? pocetHodin : pocetHodin + Double.Parse(hodnota);
                        }
                        catch
                        {
                            MessageBox.Show("Zadávejte pouze číselné hodnoty");
                        }
                    }
                    else if (hodnota.Equals(""))
                    {

                    }
                    else if (!o.Obsahuje(hodnota))
                    {
                        if (!o.Obsahuje(hodnota + "/" + dayOfWeek))
                        {
                            MessageBox.Show("Tato hodnota není obsažena v osobní tabulce Osoby");
                            pocetDnu--;
                        }
                        else
                        {
                            pocetHodin = pocetHodin + Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota + "/" + dayOfWeek)][0]);
                        }
                    }
                    else
                    {
                        pocetHodin = pocetHodin + Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota.ToUpper())][0]);
                    }

                }

                table.GetControlFromPosition(2, i).Text = pocetHodin + "";
                table.GetControlFromPosition(table.ColumnCount - 1, i).Text = pocetDnu + "";
            }

        }


        private void pole_Leave(object sender, EventArgs e)
        {

            double pocetHodin = 0;
            int pocetDnu = 0;

            for (int j = 3; j < karta.getPocetDnuVMesici() + 3; j++)
            {
                int row = table.GetPositionFromControl(((TextBox)sender)).Row;
                String hodnota = table.GetControlFromPosition(j, row).Text;



                int index = row % 2 != 0 ? row / 2 : (row - 1) / 2;
                OsobniTabulka o = main.Osoby[karta.indexyOsob[index]].osobniTabulka;
                int dayOfWeek = (int)new DateTime(karta.getIntRok(), karta.getIntMesic(), j - 2).DayOfWeek;
                dayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;


                // vypocet počtu dnů pro pracovní dobu a přesčasy
                double pocethod = 0;
                if (row % 2 == 0)
                {
                    pocetDnu = hodnota.Equals("") ? pocetDnu : pocetDnu + 1;
                }
                else if (hodnota.Equals(""))
                {

                }
                else if (!o.Obsahuje(hodnota))
                {
                   
                    if (!o.Obsahuje(hodnota + "/" + dayOfWeek))
                    {
                        MessageBox.Show("Tato hodnota není obsažena v osobní tabulce Osoby");
                        ((TextBox)sender).Text = "";
                        pocetDnu--;
                    }
                    else
                    {
                        pocethod = Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota + "/" + dayOfWeek)][0]);
                        pocetDnu = pocethod == 0 ? pocetDnu : pocetDnu+1;
                    }
                }
                else
                {
                    pocethod = Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota.ToUpper())][0]);
                    pocetDnu = pocethod == 0 ? pocetDnu : pocetDnu+1;
                }


                // vypocet počtu hodin pro pracovní dobu a přesčasy
                if (row % 2 == 0)
                {
                    try
                    {
                        pocetHodin = hodnota.Equals("") ? pocetHodin : pocetHodin + Double.Parse(hodnota);
                    }
                    catch {
                        MessageBox.Show("Zadávejte pouze číselné hodnoty");
                    }
                }
                else if (hodnota.Equals(""))
                {
                    
                }
                else if (!o.Obsahuje(hodnota))
                {
                    if (!o.Obsahuje(hodnota + "/" + dayOfWeek))
                    {
                        MessageBox.Show("Tato hodnota není obsažena v osobní tabulce Osoby");
                        ((TextBox)sender).Text = "";
                        pocetDnu--;
                    }
                    else
                    {
                        pocetHodin = pocetHodin + Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota + "/" + dayOfWeek)][0]);
                    }
                }
                else
                {
                    pocetHodin = pocetHodin + Double.Parse(o.Tabulka[o.HashList.IndexOf(hodnota.ToUpper())][0]);
                }

            }

            table.GetControlFromPosition(2, table.GetPositionFromControl(((TextBox)sender)).Row).Text = pocetHodin + "";
            table.GetControlFromPosition(table.ColumnCount-1, table.GetPositionFromControl(((TextBox)sender)).Row).Text = pocetDnu + "";

        }

        private void buttonNastavit_Click(object sender, EventArgs e)
        {
            Editace_Karty k = new Editace_Karty(karta, main);
            k.ShowDialog();

            table.Controls.Clear();
            vykresliTabulku();
            labelNazevKarty.Text = karta.nazev;
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

        private void buttonUlozit_Click(object sender, EventArgs e)
        {
            ScreenShot();
            posledniRadek = 1;
            for (int i = 0; i < karta.indexyOsob.Count; i++)
            {
                List<String> radek = new List<string>(karta.getPocetDnuVMesici()*2);

                for (int j = 3; j < karta.getPocetDnuVMesici() + 3; j++)
                {
                    radek.Add(table.GetControlFromPosition(j,posledniRadek).Text);
                }

                for (int j = 3; j < karta.getPocetDnuVMesici() + 3; j++)
                {

                    radek.Add(table.GetControlFromPosition(j, posledniRadek + 1).Text);

                }
                posledniRadek = posledniRadek + 2;

                main.Osoby[karta.indexyOsob[i]].dochazka[main.Osoby[karta.indexyOsob[i]].karty.IndexOf(main.poleKaret.IndexOf(karta))] = radek;

            }
            Close();
        }


        //------------- Tisk Formuláře


        public void ScreenShot()
        {

            ScreenShot(main.poleKaret.IndexOf(karta));

        }

        public void ScreenShot(int i) {

            buttonNastavit.Visible = false;
            buttonTisk.Visible = false;
            buttonUlozit.Visible = false;

            labelNazevKarty.Visible = true;
            System.IO.Directory.CreateDirectory(main.path + "\\DIMOS");
            try
            {
                new ComposedScreenshot(new Rectangle(0, 30, Size.Width, panel1.Size.Height + table.Size.Height + 15)).ComposedScreenshotImage.Save(main.path + "\\DIMOS\\" + i + ".png", ImageFormat.Png);
            }
            catch
            {
                MessageBox.Show("Došlo k problému při vytváření tiskové kopie, zavřete a znovu otevřete kartu");
            }
            buttonNastavit.Visible = true;
            buttonTisk.Visible = true;
            buttonUlozit.Visible = true;
        }

        PrintDocument pd;

        private void buttonTisk_Click(object sender, EventArgs e)
        {
            buttonNastavit.Focus();

            printDocument1.DefaultPageSettings.Landscape = true;

            pd = new PrintDocument();

            Margins margins = new Margins(5, 5, 5, 5);
            pd.DefaultPageSettings.Margins = margins;
            ScreenShot();

            pd.PrintPage += PrintPage;
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = pd;

            Image img = Image.FromFile(main.path + "\\DIMOS\\" + main.poleKaret.IndexOf(karta) + ".png");

            if ((double)img.Width > (double)img.Height) // obrazek je širší
                pd.DefaultPageSettings.Landscape = true;
            else
                pd.DefaultPageSettings.Landscape = false;
           


            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
              
                pd.Print();
            }

        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                    Image img = Image.FromFile(main.path + "\\DIMOS\\" + main.poleKaret.IndexOf(karta) + ".png");
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


    }
}
