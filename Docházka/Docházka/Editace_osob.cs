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
    public partial class Editace_osob : Form
    {
        public Editace_osob(String p)
        {
            InitializeComponent();

            if (p.Equals("NEW"))
                labelNadpis.Text = "Přidat osobu";
            else
                labelNadpis.Text = "Upravit osobu";


            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tabulka.Padding = new Padding(0, 0, vertScrollWidth, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RowStyle temp = tabulka.RowStyles[tabulka.RowCount - 1];
            tabulka.RowCount++;
            tabulka.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            int index = tabulka.RowCount == 2 ? 4 : (tabulka.RowCount - 2 )* 5 + 4;
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { ForeColor = System.Drawing.Color.White, TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++, BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))))}, 0, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 1, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 2, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 3, tabulka.RowCount);
            tabulka.Controls.Add(new System.Windows.Forms.TextBox() { TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))), Size = new System.Drawing.Size(68, 20), TabIndex = index++ }, 4, tabulka.RowCount);
            //this.Refresh();
        }

        private void Editace_osob_Load(object sender, EventArgs e)
        {

        }
    }
}
