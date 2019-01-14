namespace Docházka
{
    partial class Editace_Karty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editace_Karty));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxMesic = new System.Windows.Forms.ComboBox();
            this.comboBoxRok = new System.Windows.Forms.ComboBox();
            this.labelZadneVysledkyHledani = new System.Windows.Forms.Label();
            this.buttonBarva = new System.Windows.Forms.Button();
            this.textBoxNazev = new System.Windows.Forms.TextBox();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonUlozit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxMesic);
            this.panel1.Controls.Add(this.comboBoxRok);
            this.panel1.Controls.Add(this.labelZadneVysledkyHledani);
            this.panel1.Controls.Add(this.buttonBarva);
            this.panel1.Controls.Add(this.textBoxNazev);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 56);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxMesic
            // 
            this.comboBoxMesic.FormattingEnabled = true;
            this.comboBoxMesic.Location = new System.Drawing.Point(428, 10);
            this.comboBoxMesic.Name = "comboBoxMesic";
            this.comboBoxMesic.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMesic.TabIndex = 23;
            // 
            // comboBoxRok
            // 
            this.comboBoxRok.FormattingEnabled = true;
            this.comboBoxRok.Location = new System.Drawing.Point(291, 10);
            this.comboBoxRok.Name = "comboBoxRok";
            this.comboBoxRok.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRok.TabIndex = 22;
            // 
            // labelZadneVysledkyHledani
            // 
            this.labelZadneVysledkyHledani.AutoSize = true;
            this.labelZadneVysledkyHledani.BackColor = System.Drawing.Color.Transparent;
            this.labelZadneVysledkyHledani.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZadneVysledkyHledani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.labelZadneVysledkyHledani.Location = new System.Drawing.Point(287, 30);
            this.labelZadneVysledkyHledani.Name = "labelZadneVysledkyHledani";
            this.labelZadneVysledkyHledani.Size = new System.Drawing.Size(228, 23);
            this.labelZadneVysledkyHledani.TabIndex = 21;
            this.labelZadneVysledkyHledani.Text = "Seznam osob je prázný ";
            this.labelZadneVysledkyHledani.Visible = false;
            // 
            // buttonBarva
            // 
            this.buttonBarva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBarva.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBarva.ForeColor = System.Drawing.Color.White;
            this.buttonBarva.Location = new System.Drawing.Point(669, 12);
            this.buttonBarva.Name = "buttonBarva";
            this.buttonBarva.Size = new System.Drawing.Size(119, 37);
            this.buttonBarva.TabIndex = 1;
            this.buttonBarva.Text = "Barva karty";
            this.buttonBarva.UseVisualStyleBackColor = true;
            this.buttonBarva.Click += new System.EventHandler(this.buttonBarva_Click);
            // 
            // textBoxNazev
            // 
            this.textBoxNazev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNazev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNazev.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNazev.Location = new System.Drawing.Point(12, 9);
            this.textBoxNazev.Name = "textBoxNazev";
            this.textBoxNazev.Size = new System.Drawing.Size(282, 36);
            this.textBoxNazev.TabIndex = 0;
            // 
            // table
            // 
            this.table.AutoScroll = true;
            this.table.ColumnCount = 3;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.19973F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.80027F));
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 56);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(20);
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(800, 394);
            this.table.TabIndex = 1;
            this.table.Paint += new System.Windows.Forms.PaintEventHandler(this.table_Paint);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonUlozit);
            this.panel2.Location = new System.Drawing.Point(603, 406);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 36);
            this.panel2.TabIndex = 2;
            // 
            // buttonUlozit
            // 
            this.buttonUlozit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUlozit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.buttonUlozit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUlozit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUlozit.ForeColor = System.Drawing.Color.White;
            this.buttonUlozit.Location = new System.Drawing.Point(3, 4);
            this.buttonUlozit.Name = "buttonUlozit";
            this.buttonUlozit.Size = new System.Drawing.Size(142, 32);
            this.buttonUlozit.TabIndex = 20;
            this.buttonUlozit.TabStop = false;
            this.buttonUlozit.Text = "Uložit";
            this.buttonUlozit.UseVisualStyleBackColor = false;
            this.buttonUlozit.Click += new System.EventHandler(this.buttonUlozit_Click);
            // 
            // Editace_Karty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.table);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editace_Karty";
            this.Text = "DIMOS | Docházka - Editace karty";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editace_Karty_FormClosing);
            this.Load += new System.EventHandler(this.Editace_Karty_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonBarva;
        private System.Windows.Forms.TextBox textBoxNazev;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonUlozit;
        private System.Windows.Forms.Label labelZadneVysledkyHledani;
        private System.Windows.Forms.ComboBox comboBoxMesic;
        private System.Windows.Forms.ComboBox comboBoxRok;
    }
}