namespace Docházka
{
    partial class Seznam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seznam));
            this.nastaveni = new System.Windows.Forms.Label();
            this.pridat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxHledat = new System.Windows.Forms.TextBox();
            this.buttonHledat = new System.Windows.Forms.Button();
            this.labelZadneVysledkyHledani = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nastaveni
            // 
            this.nastaveni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.nastaveni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nastaveni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nastaveni.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nastaveni.Location = new System.Drawing.Point(3, 3);
            this.nastaveni.Name = "nastaveni";
            this.nastaveni.Size = new System.Drawing.Size(79, 20);
            this.nastaveni.TabIndex = 5;
            this.nastaveni.Text = "Nastavení";
            this.nastaveni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nastaveni.MouseEnter += new System.EventHandler(this.nastaveni_MouseEnter);
            this.nastaveni.MouseLeave += new System.EventHandler(this.nastaveni_MouseLeave);
            // 
            // pridat
            // 
            this.pridat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.pridat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pridat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pridat.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pridat.Location = new System.Drawing.Point(88, 3);
            this.pridat.Name = "pridat";
            this.pridat.Size = new System.Drawing.Size(79, 20);
            this.pridat.TabIndex = 6;
            this.pridat.Text = "Přidat osobu";
            this.pridat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pridat.Click += new System.EventHandler(this.pridat_Click);
            this.pridat.MouseEnter += new System.EventHandler(this.pridat_MouseEnter);
            this.pridat.MouseLeave += new System.EventHandler(this.pridat_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(854, 26);
            this.label1.TabIndex = 4;
            // 
            // table
            // 
            this.table.AutoScroll = true;
            this.table.ColumnCount = 4;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 26);
            this.table.Margin = new System.Windows.Forms.Padding(3, 300, 3, 3);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(0, 70, 0, 0);
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(854, 424);
            this.table.TabIndex = 7;
            this.table.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.table_CellPaint);
            // 
            // textBoxHledat
            // 
            this.textBoxHledat.Location = new System.Drawing.Point(114, 47);
            this.textBoxHledat.Name = "textBoxHledat";
            this.textBoxHledat.Size = new System.Drawing.Size(178, 20);
            this.textBoxHledat.TabIndex = 8;
            // 
            // buttonHledat
            // 
            this.buttonHledat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.buttonHledat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHledat.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHledat.ForeColor = System.Drawing.Color.White;
            this.buttonHledat.Location = new System.Drawing.Point(17, 41);
            this.buttonHledat.Name = "buttonHledat";
            this.buttonHledat.Size = new System.Drawing.Size(86, 32);
            this.buttonHledat.TabIndex = 18;
            this.buttonHledat.TabStop = false;
            this.buttonHledat.Text = "Hledat";
            this.buttonHledat.UseVisualStyleBackColor = false;
            this.buttonHledat.Click += new System.EventHandler(this.buttonHledat_Click);
            // 
            // labelZadneVysledkyHledani
            // 
            this.labelZadneVysledkyHledani.AutoSize = true;
            this.labelZadneVysledkyHledani.BackColor = System.Drawing.Color.Transparent;
            this.labelZadneVysledkyHledani.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZadneVysledkyHledani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.labelZadneVysledkyHledani.Location = new System.Drawing.Point(32, 109);
            this.labelZadneVysledkyHledani.Name = "labelZadneVysledkyHledani";
            this.labelZadneVysledkyHledani.Size = new System.Drawing.Size(390, 23);
            this.labelZadneVysledkyHledani.TabIndex = 19;
            this.labelZadneVysledkyHledani.Text = "Nebyly nalezeny žádné výsledky hledání";
            this.labelZadneVysledkyHledani.Visible = false;
            // 
            // Seznam
            // 
            this.AcceptButton = this.buttonHledat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.labelZadneVysledkyHledani);
            this.Controls.Add(this.buttonHledat);
            this.Controls.Add(this.textBoxHledat);
            this.Controls.Add(this.table);
            this.Controls.Add(this.nastaveni);
            this.Controls.Add(this.pridat);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(870, 489);
            this.Name = "Seznam";
            this.Text = "DIMOS | Docházka - Seznam osob";
            this.Load += new System.EventHandler(this.Seznam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label nastaveni;
        public System.Windows.Forms.Label pridat;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.TextBox textBoxHledat;
        private System.Windows.Forms.Button buttonHledat;
        private System.Windows.Forms.Label labelZadneVysledkyHledani;
    }
}