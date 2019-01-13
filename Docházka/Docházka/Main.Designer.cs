namespace Docházka
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Seznam = new System.Windows.Forms.Button();
            this.den = new System.Windows.Forms.Label();
            this.datum = new System.Windows.Forms.Label();
            this.cas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Karty = new System.Windows.Forms.Button();
            this.labelCopiright = new System.Windows.Forms.Label();
            this.SvatekLabel = new System.Windows.Forms.Label();
            this.jmeno = new System.Windows.Forms.Label();
            this.nastaveni = new System.Windows.Forms.Label();
            this.pridat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Seznam
            // 
            this.Seznam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Seznam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.Seznam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Seznam.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.Seznam.ForeColor = System.Drawing.Color.White;
            this.Seznam.Location = new System.Drawing.Point(44, 324);
            this.Seznam.Name = "Seznam";
            this.Seznam.Size = new System.Drawing.Size(194, 94);
            this.Seznam.TabIndex = 14;
            this.Seznam.TabStop = false;
            this.Seznam.Text = "Seznam";
            this.toolTip.SetToolTip(this.Seznam, "Zobrazit seznam všech osob.");
            this.Seznam.UseVisualStyleBackColor = false;
            this.Seznam.Click += new System.EventHandler(this.Seznam_Click);
            this.Seznam.MouseEnter += new System.EventHandler(this.Seznam_MouseEnter_1);
            this.Seznam.MouseLeave += new System.EventHandler(this.Seznam_MouseLeave_1);
            // 
            // den
            // 
            this.den.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.den.AutoSize = true;
            this.den.Font = new System.Drawing.Font("Century Gothic", 24F);
            this.den.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.den.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.den.Location = new System.Drawing.Point(725, 231);
            this.den.Margin = new System.Windows.Forms.Padding(0);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(132, 39);
            this.den.TabIndex = 13;
            this.den.Text = "Pondělí";
            this.den.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datum
            // 
            this.datum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datum.AutoSize = true;
            this.datum.Font = new System.Drawing.Font("Century Gothic", 24F);
            this.datum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.datum.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.datum.Location = new System.Drawing.Point(713, 192);
            this.datum.Margin = new System.Windows.Forms.Padding(0);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(144, 39);
            this.datum.TabIndex = 12;
            this.datum.Text = "1.Ledna";
            this.datum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cas
            // 
            this.cas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cas.AutoSize = true;
            this.cas.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.cas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cas.Location = new System.Drawing.Point(601, 79);
            this.cas.Margin = new System.Windows.Forms.Padding(0);
            this.cas.Name = "cas";
            this.cas.Size = new System.Drawing.Size(287, 115);
            this.cas.TabIndex = 11;
            this.cas.Text = "00:00";
            this.cas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 30F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(325, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 49);
            this.label2.TabIndex = 10;
            this.label2.Text = "Vítejte";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Docházka.Properties.Resources.DIMOS_LOGO_Text_Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(36, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Karty
            // 
            this.Karty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Karty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.Karty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Karty.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.Karty.ForeColor = System.Drawing.Color.White;
            this.Karty.Location = new System.Drawing.Point(278, 324);
            this.Karty.Name = "Karty";
            this.Karty.Size = new System.Drawing.Size(194, 94);
            this.Karty.TabIndex = 15;
            this.Karty.TabStop = false;
            this.Karty.Text = "Karty";
            this.Karty.UseVisualStyleBackColor = false;
            this.Karty.MouseEnter += new System.EventHandler(this.Karty_MouseEnter);
            this.Karty.MouseLeave += new System.EventHandler(this.Karty_MouseLeave);
            // 
            // labelCopiright
            // 
            this.labelCopiright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCopiright.AutoSize = true;
            this.labelCopiright.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.labelCopiright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.labelCopiright.Location = new System.Drawing.Point(760, 442);
            this.labelCopiright.Margin = new System.Windows.Forms.Padding(0);
            this.labelCopiright.Name = "labelCopiright";
            this.labelCopiright.Size = new System.Drawing.Size(137, 16);
            this.labelCopiright.TabIndex = 16;
            this.labelCopiright.Text = "© Dominik FROLÍK | 2019";
            this.labelCopiright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SvatekLabel
            // 
            this.SvatekLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SvatekLabel.AutoSize = true;
            this.SvatekLabel.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.SvatekLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.SvatekLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SvatekLabel.Location = new System.Drawing.Point(615, 324);
            this.SvatekLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SvatekLabel.Name = "SvatekLabel";
            this.SvatekLabel.Size = new System.Drawing.Size(224, 33);
            this.SvatekLabel.TabIndex = 17;
            this.SvatekLabel.Text = "Dnes má svátek";
            this.SvatekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // jmeno
            // 
            this.jmeno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jmeno.AutoSize = true;
            this.jmeno.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.jmeno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.jmeno.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.jmeno.Location = new System.Drawing.Point(615, 359);
            this.jmeno.Margin = new System.Windows.Forms.Padding(0);
            this.jmeno.Name = "jmeno";
            this.jmeno.Size = new System.Drawing.Size(99, 33);
            this.jmeno.TabIndex = 18;
            this.jmeno.Text = "jméno";
            this.jmeno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nastaveni
            // 
            this.nastaveni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(219)))));
            this.nastaveni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nastaveni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nastaveni.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nastaveni.Location = new System.Drawing.Point(5, 3);
            this.nastaveni.Name = "nastaveni";
            this.nastaveni.Size = new System.Drawing.Size(79, 20);
            this.nastaveni.TabIndex = 2;
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
            this.pridat.Location = new System.Drawing.Point(90, 3);
            this.pridat.Name = "pridat";
            this.pridat.Size = new System.Drawing.Size(79, 20);
            this.pridat.TabIndex = 3;
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
            this.label1.Size = new System.Drawing.Size(900, 26);
            this.label1.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 461);
            this.Controls.Add(this.nastaveni);
            this.Controls.Add(this.pridat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jmeno);
            this.Controls.Add(this.SvatekLabel);
            this.Controls.Add(this.labelCopiright);
            this.Controls.Add(this.Karty);
            this.Controls.Add(this.Seznam);
            this.Controls.Add(this.den);
            this.Controls.Add(this.datum);
            this.Controls.Add(this.cas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(916, 500);
            this.MinimumSize = new System.Drawing.Size(916, 500);
            this.Name = "Main";
            this.Text = "DIMOS | Docházka - Menu";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Seznam;
        private System.Windows.Forms.Label den;
        private System.Windows.Forms.Label datum;
        private System.Windows.Forms.Label cas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Karty;
        private System.Windows.Forms.Label labelCopiright;
        private System.Windows.Forms.Label SvatekLabel;
        private System.Windows.Forms.Label jmeno;
        public System.Windows.Forms.Label nastaveni;
        public System.Windows.Forms.Label pridat;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}