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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void zavrit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Opravdu si přejete program ukončit ?", "Zavřít ?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Možnosti_Click(object sender, EventArgs e)
        {

        }

        private void Možnosti_MouseEnter(object sender, EventArgs e)
        {
            Možnosti.BackColor = System.Drawing.Color.White;

        }

        private void Možnosti_MouseLeave(object sender, EventArgs e)
        {
            Možnosti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));

        }


    }
}
