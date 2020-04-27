using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Docházka
{

    public partial class Main : Form
    {
        public String[] mesice = new String[12] { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };
        private String[] dnyEn = new String[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private String[] dnyCz = new String[7] { "PONDĚLÍ", "ÚTERÝ", "STŘEDA", "ČTVRTEK", "PÁTEK", "SOBOTA", "NEDĚLE" };

        public List<Osoba> Osoby;
        public List<Karta> poleKaret;
        public OsobniTabulka UniversalniTabulka;

        //-- Nastavení

        public String pracovnik = "";
        public String spolecnost = "";
        public String pathExterniZaloha = "";
        public Boolean zalohovat = false;
        public String PDFPath = "";

        public Boolean loadZaloha = false;

        public String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public Random random;

        public string pathSave = @"Save\\Data.txt";
        string pathZaloha = @"Save\\DataZaloha.txt";

        public Main()
        {
            InitializeComponent();
            random = new Random();
            UniversalniTabulka = new OsobniTabulka();
            Osoby = new List<Osoba>();
            poleKaret = new List<Karta>();
            UniversalniTabulka.Reset();
        }

        private void pridat_Click(object sender, EventArgs e)
        {
            Editace_osob pridat = new Editace_osob("NEW", this);
            pridat.ShowDialog();

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
         * Metoda Nastaví čas jméno svátku dnes, a datum
         * vykreslí okno ve středu obrazovky
         **/
        private void Main_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Size.Height / 2));

            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute);
            datum.Text = DateTime.Now.Day + ". " + mesice[DateTime.Now.Month - 1];
            den.Text = "" + dnyCz[IndexOf(dnyEn, "" + DateTime.Now.DayOfWeek)];

            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            try
            {
                jmeno.Text = (webClient.DownloadString("http://svatky.adresa.info/txt").Split(';'))[1];
            }
            catch (Exception)
            {

                jmeno.Text = "";
            }

            LoadData(this.pathSave, false);
            labelPracovnik.Text = pracovnik;
            checkZalohy();

            // random naplnění
            //for (int i = 0; i < 5; i++)
            //    Osoby.Add(new Osoba() {jmeno = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((RandomString(random.Next(2, 8)).ToLower())), prijmeni = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((RandomString(random.Next(2, 8)).ToLower())) });

            timer.Start();
        }

        private void checkZalohy()
        {


            
            try
            {
                string[] files = Directory.GetFiles(pathExterniZaloha);
                foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddMonths(-3))
                    fi.Delete();
            }

            files = Directory.GetFiles(PDFPath);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddMonths(-1))
                    fi.Delete();
            }
            }
            catch
            {
   
            }
        }

        public void Save() {

            try
            {

                if (File.Exists(pathSave))
                {
                    if (File.Exists(pathZaloha))
                    {
                        File.Delete(pathZaloha);
                        File.Move(pathSave, pathZaloha);
                        File.Delete(pathSave);
                    }
                    else
                    {
                        File.Move(pathSave, pathZaloha);
                        File.Delete(pathSave);
                    }
                }


                using (StreamWriter sr = File.AppendText(pathSave))
                {
                    sr.WriteLine("DIMOS");

                    sr.WriteLine(pracovnik);
                    sr.WriteLine(spolecnost);
                    sr.WriteLine(pathExterniZaloha);
                    sr.WriteLine(PDFPath);
                    sr.WriteLine(zalohovat);


                    //-- Zapisování všech osob


                    foreach (Osoba osoba in Osoby)
                    {
                        sr.WriteLine("OOO");
                        sr.WriteLine(osoba.jmeno);
                        sr.WriteLine(osoba.prijmeni);
                        sr.WriteLine(osoba.osobnicislo);
                        int pocet = osoba.osobniTabulka.HashList.Count;

                        String x = "" + osoba.kartyToString();
                        sr.WriteLine(osoba.kartyToString());


                        for (int i = 0; i < osoba.karty.Count; i++)
                        {
                            String a = "" + osoba.getDochazkaLine(i);
                            sr.WriteLine(osoba.getDochazkaLine(i));
                        }


                        sr.WriteLine(pocet);
                        for (int i = 0; i < pocet; i++)
                        {
                            String b = "" + osoba.osobniTabulka.getLine(i);
                            sr.WriteLine(osoba.osobniTabulka.getLine(i));
                        }

                    }
                    //--Zapisování info o kartě


                    foreach (Karta karta in poleKaret)
                    {
                        sr.WriteLine("KKK");
                        sr.WriteLine(karta.nazev);
                        sr.WriteLine(karta.getColor());
                        sr.WriteLine(karta.mesic);
                        sr.WriteLine(karta.rok);
                        sr.WriteLine(karta.Finally);
                        sr.WriteLine(karta.getListOsob());
                        
                    }


                    sr.Close();
                }

                try
                {

                
                if (zalohovat && !pathExterniZaloha.Equals(""))
                File.Copy(pathSave, pathExterniZaloha + "\\" + getNowString() + ".txt");
                }
                catch
                {

                    MessageBox.Show("Nastala chyba vytváření zálohy, zkontrolujte umístění ukládání zálohy v nastavení", "CHYBA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch 
            {
                MessageBox.Show("Nastala chyba při ukládání dat, je možné, že při načtení nebudou data k dispozici", "CHYBA",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void LoadData(String dataPath, Boolean zaloha) {


            try
            {
                using (StreamReader sr = new StreamReader(dataPath))
                {
                    String line = sr.ReadLine(); // Načte se první řádek slouží při načítání zálohy pro ověření správnosti souboru s daty

                    pracovnik = sr.ReadLine().Trim();
                    spolecnost = sr.ReadLine().Trim();
                    pathExterniZaloha = sr.ReadLine().Trim();
                    PDFPath = sr.ReadLine().Trim();
                    zalohovat = sr.ReadLine().Trim().Equals("True") ? true : false;


                    try
                    {
                        line = sr.ReadLine();

                        while (line.Equals("OOO"))
                        {

                            String jmeno = sr.ReadLine().Trim();
                            String prijmeni = sr.ReadLine().Trim();
                            String osobnicislo = sr.ReadLine().Trim();

                            String h = sr.ReadLine().Trim();

                            List<int> kartyy = h.Equals("") ? new List<int>() : h.Trim().Remove(h.Length - 1).Split('_').Select(Int32.Parse).ToList();

                            List<String> dochazky = new List<string>();
                            for (int i = 0; i < kartyy.Count; i++)
                            {
                                String s = sr.ReadLine();
                                dochazky.Add(s.Trim().Remove(s.Length - 1));
                            }

                            Osoba O = new Osoba(kartyy, dochazky, jmeno, prijmeni, osobnicislo);
                            Osoby.Add(O);


                            int pocet = Int32.Parse(sr.ReadLine().Trim());
                            for (int i = 0; i < pocet; i++)
                            {
                                String[] linka = sr.ReadLine().Trim().Split('_');
                                String hash = linka[0];
                                String hodina = linka[1];
                                String a = linka[2];
                                String b = linka[3];
                                String c = linka[4];
                                String d = linka[5];

                                O.osobniTabulka.addLine(hash, hodina, a, b, c, d);
                            }

                            line = sr.ReadLine();
                            if (line == null)
                                break;

                        }
                    }
                    catch
                    {

                        DialogResult dialogResult = MessageBox.Show("Nastala chyba při načítání osob, přejete si zkusit načíst zálohu ?", "CHYBA", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (!zaloha)
                                LoadData(pathZaloha, true);
                            else
                                MessageBox.Show("Bohužel se nepodařilo načíst ani zálohu, kontaktujte administrátora.", "CHYBA",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Při dalším startu je možné, že program nebude fungovat správně, kontaktujte administrátora.", "INFO",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    try
                    {
                        if (line != null)
                            while (line.Equals("KKK"))
                            {

                                String nazev = sr.ReadLine();
                                String barva = sr.ReadLine();
                                String mesic = sr.ReadLine();
                                String rok = sr.ReadLine();
                                String finnaly = sr.ReadLine();
                                String listOsob = sr.ReadLine();

                                poleKaret.Add(new Karta(this, listOsob, finnaly, rok, mesic, barva, nazev));

                                line = sr.ReadLine();
                                if (line == null)
                                    break;
                            }
                    }
                    catch {

                        DialogResult dialogResult = MessageBox.Show("Nastala chyba při načítání karet, přejete si zkusit načíst zálohu ?", "CHYBA", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if(!zaloha)
                            LoadData(pathZaloha, true);
                            else
                                MessageBox.Show("Bohužel se nepodařilo načíst ani zálohu, kontaktujte administrátora.", "CHYBA",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Při dalším startu je možné, že program nebude fungovat správně, kontaktujte administrátora.", "INFO",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
            catch
            {

                DialogResult dialogResult = MessageBox.Show("Nastala chyba při načítání hlavních dat, přejete si zkusit načíst zálohu ?", "CHYBA", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!zaloha)
                        LoadData(pathZaloha, true);
                    else
                        MessageBox.Show("Bohužel se nepodařilo načíst ani zálohu, kontaktujte administrátora.", "CHYBA",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Při dalším startu je možné, že program nebude fungovat správně, kontaktujte administrátora.", "INFO",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }


        private String getNowString() {

            return DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "  " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;

        }


        public List<int> StringArrayToList(String[] arr) {

            List<int> l = new List<int>();


            foreach (String s in arr)
            {
                l.Add(Int32.Parse(s));
            }

            return l;
        }

        /**
         * Debug metoda na naplnění náhodnýma lidma
         **/
        string RandomString(int length)
        {

            string characters = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int r = random.Next(characters.Length);
                result.Append(characters[r]);
            }
            return result.ToString();
        }


        /**
         * Metoda vrací index stringu ve stringovém poli
         **/
        public int IndexOf(String[] arr, String value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        private void Seznam_Click(object sender, EventArgs e)
        {
            Seznam seznam = new Seznam(this);
            this.Hide();
            seznam.ShowDialog();
            this.Show();
        }

        private void Seznam_MouseEnter(object sender, EventArgs e)
        {
            Seznam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));

        }

        private void Seznam_MouseLeave(object sender, EventArgs e)
        {
            Seznam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));

        }

        private void Seznam_MouseEnter_1(object sender, EventArgs e)
        {
            this.Seznam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
        }

        private void Seznam_MouseLeave_1(object sender, EventArgs e)
        {
            this.Seznam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));

        }

        private void Karty_MouseEnter(object sender, EventArgs e)
        {
            this.Karty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
        }

        private void Karty_MouseLeave(object sender, EventArgs e)
        {
            this.Karty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));

        }

        private void Karty_Click(object sender, EventArgs e)
        {
            Karty k = new Karty(this);
            Hide();
            k.ShowDialog();
            Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            cas.Text = String.Format("{0:00}", DateTime.Now.Hour) + ":" + String.Format("{0:00}", DateTime.Now.Minute);

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!loadZaloha)
            Save();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));

        }

        private void nastaveni_Click(object sender, EventArgs e)
        {
            Nastaveni nastaveni = new Nastaveni(this);
            this.Hide();
            nastaveni.ShowDialog();
            labelPracovnik.Text = pracovnik;
            this.Show();
        }
    }
}
