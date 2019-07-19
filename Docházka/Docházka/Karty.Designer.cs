namespace Docházka
{
    partial class Karty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Karty));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTisk = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vymazatTisknovouFrontuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelZadneVysledkyHledani = new System.Windows.Forms.Label();
            this.buttonPridatKartu = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonTisk);
            this.panel1.Controls.Add(this.labelZadneVysledkyHledani);
            this.panel1.Controls.Add(this.buttonPridatKartu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 38);
            this.panel1.TabIndex = 1;
            // 
            // buttonTisk
            // 
            this.buttonTisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.buttonTisk.ContextMenuStrip = this.contextMenuStrip1;
            this.buttonTisk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTisk.ForeColor = System.Drawing.Color.White;
            this.buttonTisk.Location = new System.Drawing.Point(518, 5);
            this.buttonTisk.Name = "buttonTisk";
            this.buttonTisk.Size = new System.Drawing.Size(159, 32);
            this.buttonTisk.TabIndex = 21;
            this.buttonTisk.Text = "Vytisknout 0 karet";
            this.toolTip.SetToolTip(this.buttonTisk, "Kliknutím vytisknete tisknovou frontu");
            this.buttonTisk.UseVisualStyleBackColor = false;
            this.buttonTisk.Click += new System.EventHandler(this.buttonTisk_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vymazatTisknovouFrontuToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 26);
            // 
            // vymazatTisknovouFrontuToolStripMenuItem
            // 
            this.vymazatTisknovouFrontuToolStripMenuItem.Name = "vymazatTisknovouFrontuToolStripMenuItem";
            this.vymazatTisknovouFrontuToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.vymazatTisknovouFrontuToolStripMenuItem.Text = "Vymazat tisknovou frontu";
            this.vymazatTisknovouFrontuToolStripMenuItem.Click += new System.EventHandler(this.vymazatTisknovouFrontuToolStripMenuItem_Click);
            // 
            // labelZadneVysledkyHledani
            // 
            this.labelZadneVysledkyHledani.AutoSize = true;
            this.labelZadneVysledkyHledani.BackColor = System.Drawing.Color.Transparent;
            this.labelZadneVysledkyHledani.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZadneVysledkyHledani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.labelZadneVysledkyHledani.Location = new System.Drawing.Point(276, 14);
            this.labelZadneVysledkyHledani.Name = "labelZadneVysledkyHledani";
            this.labelZadneVysledkyHledani.Size = new System.Drawing.Size(239, 23);
            this.labelZadneVysledkyHledani.TabIndex = 20;
            this.labelZadneVysledkyHledani.Text = "Seznam karet je prázdný";
            this.labelZadneVysledkyHledani.Visible = false;
            // 
            // buttonPridatKartu
            // 
            this.buttonPridatKartu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPridatKartu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.buttonPridatKartu.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPridatKartu.ForeColor = System.Drawing.Color.White;
            this.buttonPridatKartu.Location = new System.Drawing.Point(683, 4);
            this.buttonPridatKartu.Name = "buttonPridatKartu";
            this.buttonPridatKartu.Size = new System.Drawing.Size(139, 32);
            this.buttonPridatKartu.TabIndex = 0;
            this.buttonPridatKartu.Text = "Přidat Kartu";
            this.toolTip.SetToolTip(this.buttonPridatKartu, "Kliknutím přidáte novou kartu");
            this.buttonPridatKartu.UseVisualStyleBackColor = false;
            this.buttonPridatKartu.Click += new System.EventHandler(this.buttonPridatKartu_Click);
            // 
            // table
            // 
            this.table.AutoScroll = true;
            this.table.BackColor = System.Drawing.Color.Transparent;
            this.table.BackgroundImage = global::Docházka.Properties.Resources.DIMOS_LOGO_Transparent_40_procent_Small;
            this.table.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.table.ColumnCount = 3;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(20, 50, 20, 20);
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(834, 450);
            this.table.TabIndex = 0;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // Karty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.table);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Karty";
            this.Text = "DIMOS | Docházka - Karty";
            this.Load += new System.EventHandler(this.Karty_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPridatKartu;
        private System.Windows.Forms.Label labelZadneVysledkyHledani;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonTisk;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vymazatTisknovouFrontuToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}