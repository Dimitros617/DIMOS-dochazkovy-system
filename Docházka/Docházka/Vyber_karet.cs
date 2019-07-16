using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Docházka
{
    public partial class Vyber_karet : Form
    {
        Main main;
        Seznam seznam;
        int index;
        public String pracovnik = "Mgr. Hana Matuštíková";
        public String instituce = "Základní škola Obrnice, okres Most, příspěvková organizace";

        public Vyber_karet(Main m, Seznam s, int i)
        {
            InitializeComponent();
            seznam = s;
            index = i;
            main = m;
            setBox();

        }

        private void setBox() {

            checkBox1.Checked = seznam.zavrit;

            List<int> kartyOsoby = main.Osoby[index].karty;

            for(int i = 0; i < kartyOsoby.Count; i++)
            {
                comboBox1.Items.Add(new ComboboxValue(kartyOsoby[i], main.poleKaret[kartyOsoby[i]].nazev + " - " + main.poleKaret[kartyOsoby[i]].mesic));
                comboBox2.Items.Add(new ComboboxValue(kartyOsoby[i], main.poleKaret[kartyOsoby[i]].nazev + " - " + main.poleKaret[kartyOsoby[i]].mesic));
                comboBox3.Items.Add(new ComboboxValue(kartyOsoby[i], main.poleKaret[kartyOsoby[i]].nazev + " - " + main.poleKaret[kartyOsoby[i]].mesic));

            }

            //--První kombobox
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString().Equals(seznam.karta1))
                {
                    comboBox1.SelectedItem = comboBox1.Items[i];
                    break;
                }
            }

            //-- Druhý kombobox
            if(!seznam.karta2.Equals(""))
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i].ToString().Equals(seznam.karta2))
                {
                    comboBox2.SelectedItem = comboBox2.Items[i];
                    break;
                }
            }

            //-- Třetí kombobox
            if (!seznam.karta3.Equals(""))
            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                if (comboBox3.Items[i].ToString().Equals(seznam.karta3))
                {
                    comboBox3.SelectedItem = comboBox3.Items[i];
                    break;
                }
            }



            //comboBox1.SelectedItem = new ComboboxValue(kartyOsoby[kartyOsoby.Count], main.poleKaret[kartyOsoby[i]].nazev + " - " + main.poleKaret[kartyOsoby[i]].mesic);
            //comboBox2.SelectedItem = seznam.karta2;
            //comboBox3.SelectedItem = seznam.karta3;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Metoda Vytvoří PDF se zadanými datami
        private void buttonHledat_Click(object sender, EventArgs e)
        {

            //Index 1 až 3 jsou indexy 3 karet z mainu které jsou aktuálně používané
            int index1 = (ComboboxValue)comboBox1.SelectedItem == null ? -1 : ((ComboboxValue)comboBox1.SelectedItem).Id;
            int index2 = (ComboboxValue)comboBox2.SelectedItem == null ? -1 : ((ComboboxValue)comboBox2.SelectedItem).Id;
            int index3 = (ComboboxValue)comboBox3.SelectedItem == null ? -1 : ((ComboboxValue)comboBox3.SelectedItem).Id;

            if (index1 == -1) {
                MessageBox.Show("Prosím vyplňtě alespoň první políčko");
            }

            seznam.karta1 = main.poleKaret[index1].nazev + " - " + main.poleKaret[index1].mesic;
            seznam.karta2 = index2 == -1? "" : main.poleKaret[index2].nazev + " - " + main.poleKaret[index2].mesic;
            seznam.karta3 = index3 == -1? "" : main.poleKaret[index3].nazev + " - " + main.poleKaret[index3].mesic;


            string nazev = main.Osoby[index].jmeno + " - " +  index1 + index2 + index3 + "X" + DateTime.Now.Millisecond;
            System.IO.FileStream fs = new FileStream("Save" + "\\" + nazev + ".pdf", FileMode.Create);

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();
            document.AddCreator("DIMOS | Docházkový systém - by Dominik Frolík");

            string sylfaenpath = "";
            try
            {
                sylfaenpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\gothic.ttf";
            }
            catch
            {
                MessageBox.Show("Nastala chyba při načítání fontu, prosím je potřeba mít nainstalovaný font Century Gothic.");
            }

            BaseFont sylfaen = BaseFont.CreateFont(sylfaenpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font Nadpis = new iTextSharp.text.Font(sylfaen, 13f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font Normal = new iTextSharp.text.Font(sylfaen, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font NormalSmall = new iTextSharp.text.Font(sylfaen, 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font Bold = new iTextSharp.text.Font(sylfaen, 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            document.Add(new Paragraph("EVIDENCE DOCHÁZKY - " + main.poleKaret[index1].rok + "\n", Nadpis));
            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("Zařízení: " + instituce, Normal));
            document.Add(Chunk.NEWLINE); 
            document.Add(Chunk.NEWLINE);

            PdfPTable radek = new PdfPTable(4);
            radek.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            radek.AddCell(new Paragraph("Jméno pracovníka: ", Normal));
            radek.AddCell(new Paragraph(main.Osoby[index].jmeno + " " + main.Osoby[index].prijmeni, Bold));
            radek.AddCell(new Paragraph("Osobní číslo: ", Normal));
            radek.AddCell(new Paragraph(main.Osoby[index].osobnicislo, Bold));
            document.Add(radek);

            document.Add(Chunk.NEWLINE);


            PdfPTable table = new PdfPTable(13);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100;

            float[] widths = new float[] { 8f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f };
            table.SetWidths(widths);

            //table.AddCell(new PdfPCell(new Phrase("1", Normal)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
            //table.AddCell(new PdfPCell(new Phrase("1", Normal)) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });

            //První řádek s měsícema
            table.AddCell("");
            table.AddCell(new PdfPCell(new Phrase("Měsíc: ", Normal)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase(main.poleKaret[index1].mesic, Bold)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Měsíc: ", Normal)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase(index2 == -1? "" : main.poleKaret[index2].mesic, Bold)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Měsíc: ", Normal)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase(index3 == -1 ? "" : main.poleKaret[index3].mesic, Bold)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER });

            //Druhý řádek Příchody Odchody popisky
            table.AddCell("");
            for (int i = 0; i < 6; i++)
            {
                table.AddCell(new PdfPCell(new Phrase("Příchod", NormalSmall)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Odchod", NormalSmall)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
            }

            for (int i = 0; i < 31; i++)
            {
                table.AddCell(new PdfPCell(new Phrase((i+1) + "" , Normal)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
                int dayOfWeek1;
                try
                {
                    dayOfWeek1 = (int)new DateTime(main.poleKaret[index1].getIntRok(), main.poleKaret[index1].getIntMesic(), i + 1).DayOfWeek;

                }
                catch
                {
                    dayOfWeek1 = 3;
                }
                dayOfWeek1 = dayOfWeek1 == 0 ? 7 : dayOfWeek1;

                if (dayOfWeek1 < 6)
                {
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 1, dayOfWeek1))) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 2, dayOfWeek1))) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 3, dayOfWeek1))) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 4, dayOfWeek1))) { HorizontalAlignment = Element.ALIGN_CENTER });
                }
                else
                {
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 1, dayOfWeek1))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 2, dayOfWeek1))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 3, dayOfWeek1))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i], 4, dayOfWeek1))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });

                }


                if (index2 != -1)
                {
                    int dayOfWeek2;
                    try
                    {
                        dayOfWeek2 = (int)new DateTime(main.poleKaret[index2].getIntRok(), main.poleKaret[index2].getIntMesic(), i + 1).DayOfWeek;

                    }
                    catch
                    {

                        dayOfWeek2 = 3;
                    }
                    dayOfWeek2 = dayOfWeek2 == 0 ? 7 : dayOfWeek2;

                    if (dayOfWeek2 < 6)
                    {
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 1, dayOfWeek2))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 2, dayOfWeek2))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 3, dayOfWeek2))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 4, dayOfWeek2))) { HorizontalAlignment = Element.ALIGN_CENTER });
                    }
                    else
                    {
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 1, dayOfWeek2))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 2, dayOfWeek2))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 3, dayOfWeek2))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i], 4, dayOfWeek2))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });

                    }

                }
                else
                {
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell("");
                }


                if(index3 != -1) {
                    int dayOfWeek3;
                    try
                    {
                        dayOfWeek3 = (int)new DateTime(main.poleKaret[index3].getIntRok(), main.poleKaret[index3].getIntMesic(), i + 1).DayOfWeek;

                    }
                    catch 
                    {
                        dayOfWeek3 = 3;

                    }
                    dayOfWeek3 = dayOfWeek3 == 0 ? 7 : dayOfWeek3;


                        if (dayOfWeek3 < 6)
                        {
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 1, dayOfWeek3))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 2, dayOfWeek3))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 3, dayOfWeek3))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 4, dayOfWeek3))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        }
                        else
                        {
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 1, dayOfWeek3))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 2, dayOfWeek3))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 3, dayOfWeek3))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i] == null || main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i].Equals("") ? "" : main.Osoby[index].osobniTabulka.getDecodedString(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i], 4, dayOfWeek3))) { BackgroundColor = BaseColor.YELLOW, HorizontalAlignment = Element.ALIGN_CENTER });

                        }
                    }
                else
                {
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell("");
                }

            }

            int odpracovanoHod1 = 0;
            int odpracovanoHod2 = 0;
            int odpracovanoHod3 = 0;

            for (int i = 0; i < main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)].Count; i++)
            {
                odpracovanoHod1 += Int32.Parse(main.Osoby[index].osobniTabulka.getDecodedPocetHodin(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index1)][i]));
            }

            if(index2 != -1)
            for (int i = 0; i < main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)].Count; i++)
            {
                odpracovanoHod2 += Int32.Parse(main.Osoby[index].osobniTabulka.getDecodedPocetHodin(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index2)][i]));
            }

            if (index3 != -1)
            for (int i = 0; i < main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)].Count; i++)
            {
                odpracovanoHod3 += Int32.Parse(main.Osoby[index].osobniTabulka.getDecodedPocetHodin(main.Osoby[index].dochazka[main.Osoby[index].karty.IndexOf(index3)][i]));
            }

            table.AddCell("");
            table.AddCell(new PdfPCell(new Phrase("Odpracováno hodin : ", Bold)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase(odpracovanoHod1 + "", Normal)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Odpracováno hodin : ", Bold)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase(odpracovanoHod2 + "", Normal)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Odpracováno hodin : ", Bold)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase(odpracovanoHod3 + "", Normal)) { HorizontalAlignment = Element.ALIGN_CENTER });


            document.Add(table);

            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("Sestavil/a : " + pracovnik, Normal));
            document.Add(new Paragraph("Pracovník : .......................... ", Normal) { Alignment = 2 });



                    document.Close();
                    writer.Close();
                    fs.Close();

            seznam.zavrit = checkBox1.Checked;

            if (seznam.zavrit) {
                this.Close();
            }

        }

        private PdfPCell getCell(string v, int alignment)
        {
            return null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

class ComboboxValue
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ComboboxValue(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
