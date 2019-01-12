namespace Docházka
{
    partial class Editace_osob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editace_osob));
            this.labelJmeno = new System.Windows.Forms.Label();
            this.textBoxJmeno = new System.Windows.Forms.TextBox();
            this.textBoxPrijmeni = new System.Windows.Forms.TextBox();
            this.labelPrijmeni = new System.Windows.Forms.Label();
            this.textBoxOC = new System.Windows.Forms.TextBox();
            this.labelOC = new System.Windows.Forms.Label();
            this.labelNadpis = new System.Windows.Forms.Label();
            this.tabulka = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabulka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelJmeno
            // 
            this.labelJmeno.AutoSize = true;
            this.labelJmeno.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelJmeno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.labelJmeno.Location = new System.Drawing.Point(29, 88);
            this.labelJmeno.Name = "labelJmeno";
            this.labelJmeno.Size = new System.Drawing.Size(63, 21);
            this.labelJmeno.TabIndex = 0;
            this.labelJmeno.Text = "Jméno";
            // 
            // textBoxJmeno
            // 
            this.textBoxJmeno.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxJmeno.Location = new System.Drawing.Point(98, 89);
            this.textBoxJmeno.Name = "textBoxJmeno";
            this.textBoxJmeno.Size = new System.Drawing.Size(212, 22);
            this.textBoxJmeno.TabIndex = 1;
            // 
            // textBoxPrijmeni
            // 
            this.textBoxPrijmeni.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.textBoxPrijmeni.Location = new System.Drawing.Point(98, 134);
            this.textBoxPrijmeni.Name = "textBoxPrijmeni";
            this.textBoxPrijmeni.Size = new System.Drawing.Size(212, 22);
            this.textBoxPrijmeni.TabIndex = 2;
            // 
            // labelPrijmeni
            // 
            this.labelPrijmeni.AutoSize = true;
            this.labelPrijmeni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPrijmeni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.labelPrijmeni.Location = new System.Drawing.Point(29, 133);
            this.labelPrijmeni.Name = "labelPrijmeni";
            this.labelPrijmeni.Size = new System.Drawing.Size(68, 21);
            this.labelPrijmeni.TabIndex = 2;
            this.labelPrijmeni.Text = "Příjmení";
            // 
            // textBoxOC
            // 
            this.textBoxOC.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.textBoxOC.Location = new System.Drawing.Point(135, 180);
            this.textBoxOC.Name = "textBoxOC";
            this.textBoxOC.Size = new System.Drawing.Size(175, 22);
            this.textBoxOC.TabIndex = 3;
            // 
            // labelOC
            // 
            this.labelOC.AutoSize = true;
            this.labelOC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.labelOC.Location = new System.Drawing.Point(29, 179);
            this.labelOC.Name = "labelOC";
            this.labelOC.Size = new System.Drawing.Size(100, 21);
            this.labelOC.TabIndex = 4;
            this.labelOC.Text = "Osobní číslo";
            // 
            // labelNadpis
            // 
            this.labelNadpis.AutoSize = true;
            this.labelNadpis.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNadpis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.labelNadpis.Location = new System.Drawing.Point(27, 23);
            this.labelNadpis.Name = "labelNadpis";
            this.labelNadpis.Size = new System.Drawing.Size(297, 32);
            this.labelNadpis.TabIndex = 6;
            this.labelNadpis.Text = "Přidat / Upravit osobu";
            // 
            // tabulka
            // 
            this.tabulka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabulka.AutoScroll = true;
            this.tabulka.BackColor = System.Drawing.Color.White;
            this.tabulka.ColumnCount = 5;
            this.tabulka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tabulka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tabulka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tabulka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tabulka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tabulka.Controls.Add(this.textBox1, 0, 0);
            this.tabulka.Controls.Add(this.textBox2, 1, 0);
            this.tabulka.Controls.Add(this.textBox3, 2, 0);
            this.tabulka.Controls.Add(this.textBox5, 4, 0);
            this.tabulka.Controls.Add(this.textBox4, 3, 0);
            this.tabulka.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tabulka.Location = new System.Drawing.Point(383, 26);
            this.tabulka.Name = "tabulka";
            this.tabulka.RowCount = 1;
            this.tabulka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tabulka.Size = new System.Drawing.Size(405, 436);
            this.tabulka.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(69, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(153, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(69, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(228, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 20);
            this.textBox4.TabIndex = 0;
            this.textBox4.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(303, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(69, 20);
            this.textBox5.TabIndex = 0;
            this.textBox5.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Docházka.Properties.Resources.DIMOS_LOGO_Transparent_75_percent;
            this.pictureBox1.Location = new System.Drawing.Point(33, 221);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 217);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(614, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 32);
            this.button1.TabIndex = 16;
            this.button1.TabStop = false;
            this.button1.Text = "Přidat řádek";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Editace_osob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabulka);
            this.Controls.Add(this.labelNadpis);
            this.Controls.Add(this.textBoxOC);
            this.Controls.Add(this.labelOC);
            this.Controls.Add(this.textBoxPrijmeni);
            this.Controls.Add(this.labelPrijmeni);
            this.Controls.Add(this.textBoxJmeno);
            this.Controls.Add(this.labelJmeno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editace_osob";
            this.Text = "DIMOS | Docházka - Editace osob";
            this.Load += new System.EventHandler(this.Editace_osob_Load);
            this.tabulka.ResumeLayout(false);
            this.tabulka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelJmeno;
        private System.Windows.Forms.TextBox textBoxJmeno;
        private System.Windows.Forms.TextBox textBoxPrijmeni;
        private System.Windows.Forms.Label labelPrijmeni;
        private System.Windows.Forms.TextBox textBoxOC;
        private System.Windows.Forms.Label labelOC;
        private System.Windows.Forms.Label labelNadpis;
        private System.Windows.Forms.TableLayoutPanel tabulka;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}