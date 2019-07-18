using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void buttonUlozit_Click(object sender, EventArgs e)
        {
            main.pracovnik = textBoxPracovnik.Text;
            main.spolecnost = textBoxSpolecnost.Text;
            main.pathExterniZaloha = textBoxPath.Text;
            main.zalohovat = checkBoxZaloha.Checked;

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
                textBoxPath.Text = dialog.FileName.Replace("\\","\\\\");
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
                textBoxVybranaZaloha.Text = soubor;
            }

        }
    }
}
