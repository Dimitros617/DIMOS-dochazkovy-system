﻿namespace Docházka
{
    partial class KartaTabulka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KartaTabulka));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTisk = new System.Windows.Forms.Button();
            this.labelZadneVysledkyHledani = new System.Windows.Forms.Label();
            this.buttonNastavit = new System.Windows.Forms.Button();
            this.buttonUlozit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRok = new System.Windows.Forms.Label();
            this.labelMesic = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.labelNazevKarty = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelNazevKarty);
            this.panel1.Controls.Add(this.buttonTisk);
            this.panel1.Controls.Add(this.labelZadneVysledkyHledani);
            this.panel1.Controls.Add(this.buttonNastavit);
            this.panel1.Controls.Add(this.buttonUlozit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelRok);
            this.panel1.Controls.Add(this.labelMesic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 40);
            this.panel1.TabIndex = 0;
            // 
            // buttonTisk
            // 
            this.buttonTisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.buttonTisk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTisk.ForeColor = System.Drawing.Color.White;
            this.buttonTisk.Location = new System.Drawing.Point(612, 7);
            this.buttonTisk.Name = "buttonTisk";
            this.buttonTisk.Size = new System.Drawing.Size(82, 32);
            this.buttonTisk.TabIndex = 23;
            this.buttonTisk.Text = "Tisk";
            this.buttonTisk.UseVisualStyleBackColor = false;
            this.buttonTisk.Click += new System.EventHandler(this.buttonTisk_Click);
            // 
            // labelZadneVysledkyHledani
            // 
            this.labelZadneVysledkyHledani.AutoSize = true;
            this.labelZadneVysledkyHledani.BackColor = System.Drawing.Color.Transparent;
            this.labelZadneVysledkyHledani.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZadneVysledkyHledani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.labelZadneVysledkyHledani.Location = new System.Drawing.Point(12, 15);
            this.labelZadneVysledkyHledani.Name = "labelZadneVysledkyHledani";
            this.labelZadneVysledkyHledani.Size = new System.Drawing.Size(432, 23);
            this.labelZadneVysledkyHledani.TabIndex = 22;
            this.labelZadneVysledkyHledani.Text = "Dosud nebyly do karty přiřazeny žádné osoby";
            this.labelZadneVysledkyHledani.Visible = false;
            // 
            // buttonNastavit
            // 
            this.buttonNastavit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNastavit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.buttonNastavit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNastavit.ForeColor = System.Drawing.Color.White;
            this.buttonNastavit.Location = new System.Drawing.Point(490, 7);
            this.buttonNastavit.Name = "buttonNastavit";
            this.buttonNastavit.Size = new System.Drawing.Size(117, 32);
            this.buttonNastavit.TabIndex = 4;
            this.buttonNastavit.Text = "Nastavení";
            this.buttonNastavit.UseVisualStyleBackColor = false;
            this.buttonNastavit.Click += new System.EventHandler(this.buttonNastavit_Click);
            // 
            // buttonUlozit
            // 
            this.buttonUlozit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUlozit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.buttonUlozit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUlozit.ForeColor = System.Drawing.Color.White;
            this.buttonUlozit.Location = new System.Drawing.Point(696, 7);
            this.buttonUlozit.Name = "buttonUlozit";
            this.buttonUlozit.Size = new System.Drawing.Size(101, 32);
            this.buttonUlozit.TabIndex = 1;
            this.buttonUlozit.Text = "Uložit";
            this.buttonUlozit.UseVisualStyleBackColor = false;
            this.buttonUlozit.Click += new System.EventHandler(this.buttonUlozit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Evidence pracovní doby a práce přesčas -";
            // 
            // labelRok
            // 
            this.labelRok.AutoSize = true;
            this.labelRok.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRok.Location = new System.Drawing.Point(434, 18);
            this.labelRok.Name = "labelRok";
            this.labelRok.Size = new System.Drawing.Size(45, 19);
            this.labelRok.TabIndex = 2;
            this.labelRok.Text = "2019";
            // 
            // labelMesic
            // 
            this.labelMesic.AutoSize = true;
            this.labelMesic.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMesic.Location = new System.Drawing.Point(349, 17);
            this.labelMesic.Name = "labelMesic";
            this.labelMesic.Size = new System.Drawing.Size(88, 21);
            this.labelMesic.TabIndex = 1;
            this.labelMesic.Text = "Červenec";
            // 
            // table
            // 
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table.AutoScroll = true;
            this.table.AutoSize = true;
            this.table.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 766F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.Location = new System.Drawing.Point(0, 40);
            this.table.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(20, 0, 20, 5);
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(808, 7);
            this.table.TabIndex = 1;
            this.table.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.table_CellPaint);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // labelNazevKarty
            // 
            this.labelNazevKarty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNazevKarty.AutoSize = true;
            this.labelNazevKarty.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNazevKarty.Location = new System.Drawing.Point(342, 18);
            this.labelNazevKarty.Name = "labelNazevKarty";
            this.labelNazevKarty.Size = new System.Drawing.Size(137, 19);
            this.labelNazevKarty.TabIndex = 24;
            this.labelNazevKarty.Text = "DOCH - 1.Stupeň";
            // 
            // KartaTabulka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.table);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KartaTabulka";
            this.Text = "DIMOS | Docházka - Karta ";
            this.Load += new System.EventHandler(this.KartaTabulka_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelRok;
        private System.Windows.Forms.Label labelMesic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNastavit;
        private System.Windows.Forms.Button buttonUlozit;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label labelZadneVysledkyHledani;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button buttonTisk;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label labelNazevKarty;
    }
}