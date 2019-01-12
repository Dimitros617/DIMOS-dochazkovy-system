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
            this.label1.Size = new System.Drawing.Size(800, 26);
            this.label1.TabIndex = 4;
            // 
            // Seznam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nastaveni);
            this.Controls.Add(this.pridat);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Seznam";
            this.Text = "DIMOS | Docházka - Seznam osob";
            this.Load += new System.EventHandler(this.Seznam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label nastaveni;
        public System.Windows.Forms.Label pridat;
        public System.Windows.Forms.Label label1;
    }
}