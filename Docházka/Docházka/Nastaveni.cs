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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Docházka
{
    public partial class Nastaveni : Form

    {
        public Main main;
        private Boolean ukoncit = true; // proměná je true při vytvoření slouží při zavření formuláře aby nedošlo k rekurzy dialogového okna o uložení dat před zavřením


        public Nastaveni(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Nastaveni_Load(object sender, EventArgs e)
        {
            textBoxPath.Text = main.pathExterniZaloha;
            textBoxPracovnik.Text = main.pracovnik;
            textBoxSpolecnost.Text = main.spolecnost;
            checkBoxZaloha.Checked = main.zalohovat;
            textBoxPDFPath.Text = main.PDFPath;
        }

        private void buttonUlozit_Click(object sender, EventArgs e)
        {
            main.pracovnik = textBoxPracovnik.Text;
            main.spolecnost = textBoxSpolecnost.Text;
            main.pathExterniZaloha = textBoxPath.Text;
            main.zalohovat = checkBoxZaloha.Checked;
            main.PDFPath = textBoxPDFPath.Text;

            ukoncit = false;
            Close();
        }

        private void Nastaveni_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ukoncit)
            {
                DialogResult result = MessageBox.Show("Přejete si data nejdříve uložit ?", "Uložit ?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    buttonUlozit_Click(sender, e);
                    this.Close();
                }
                else
                {
                    ukoncit = false;
                    this.Close();
                }
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxPath.Text = dialog.FileName;
            }
        }

        private void buttonVybratZalohu_Click(object sender, EventArgs e)
        {
            String soubor = "";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Otevřít vybranou zálohu";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                soubor = theDialog.FileName.ToString().Replace("\\", "\\\\");
                try
                {
                    using (StreamReader sr = new StreamReader(soubor))
                    {
                        String line = sr.ReadLine();
                        if (line.Equals("DIMOS"))
                        {
                            if (File.Exists(main.pathSave))
                            {
                                File.Delete(main.pathSave);
                                File.Move(soubor, main.pathSave);
                            }
                            else
                            {
                                File.Move(soubor, main.pathSave);
                            }
                                
                                
                        }
                        else
                        {
                            MessageBox.Show("Soubor, který jste vybrali není soubor se zálohovanýmy daty");
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Nastala chyba při načítání zálohy zkusze vybrat jinou zálohu nebo kontaktujte administratora", "CHYBA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void buttonSelectPDF_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxPDFPath.Text = dialog.FileName;
            }
        }
    }
}
