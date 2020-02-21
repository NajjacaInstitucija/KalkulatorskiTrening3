namespace T
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.poRokuUpotrebeCB = new System.Windows.Forms.ComboBox();
            this.poRokuUpotrebeLabel = new System.Windows.Forms.Label();
            this.Apply = new System.Windows.Forms.Button();
            this.imeOdabranogArtiklaLabel = new System.Windows.Forms.Label();
            this.poKoduArtiklaCB = new System.Windows.Forms.ComboBox();
            this.poKoduArtiklaLabel = new System.Windows.Forms.Label();
            this.kriterijLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.promijeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bojuPozadineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // poRokuUpotrebeCB
            // 
            this.poRokuUpotrebeCB.FormattingEnabled = true;
            this.poRokuUpotrebeCB.Location = new System.Drawing.Point(29, 104);
            this.poRokuUpotrebeCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.poRokuUpotrebeCB.Name = "poRokuUpotrebeCB";
            this.poRokuUpotrebeCB.Size = new System.Drawing.Size(330, 31);
            this.poRokuUpotrebeCB.TabIndex = 1;
            this.poRokuUpotrebeCB.SelectedIndexChanged += new System.EventHandler(this.PoRokuUpotrebe_SelectedIndexChanged);
            // 
            // poRokuUpotrebeLabel
            // 
            this.poRokuUpotrebeLabel.AutoSize = true;
            this.poRokuUpotrebeLabel.Location = new System.Drawing.Point(10, 49);
            this.poRokuUpotrebeLabel.Name = "poRokuUpotrebeLabel";
            this.poRokuUpotrebeLabel.Size = new System.Drawing.Size(440, 24);
            this.poRokuUpotrebeLabel.TabIndex = 2;
            this.poRokuUpotrebeLabel.Text = "Izaberi artikl koji treba ukloniti iz ponude(po roku upotrebe)";
            // 
            // Apply
            // 
            this.Apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Apply.Location = new System.Drawing.Point(29, 467);
            this.Apply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(330, 93);
            this.Apply.TabIndex = 3;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = false;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // imeOdabranogArtiklaLabel
            // 
            this.imeOdabranogArtiklaLabel.AutoSize = true;
            this.imeOdabranogArtiklaLabel.Location = new System.Drawing.Point(148, 404);
            this.imeOdabranogArtiklaLabel.Name = "imeOdabranogArtiklaLabel";
            this.imeOdabranogArtiklaLabel.Size = new System.Drawing.Size(87, 24);
            this.imeOdabranogArtiklaLabel.TabIndex = 4;
            this.imeOdabranogArtiklaLabel.Text = "Ime artikla";
            // 
            // poKoduArtiklaCB
            // 
            this.poKoduArtiklaCB.FormattingEnabled = true;
            this.poKoduArtiklaCB.Location = new System.Drawing.Point(29, 279);
            this.poKoduArtiklaCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.poKoduArtiklaCB.Name = "poKoduArtiklaCB";
            this.poKoduArtiklaCB.Size = new System.Drawing.Size(330, 31);
            this.poKoduArtiklaCB.TabIndex = 5;
            this.poKoduArtiklaCB.SelectedIndexChanged += new System.EventHandler(this.PoKoduArtikla_SelectedIndexChanged);
            // 
            // poKoduArtiklaLabel
            // 
            this.poKoduArtiklaLabel.AutoSize = true;
            this.poKoduArtiklaLabel.Location = new System.Drawing.Point(12, 213);
            this.poKoduArtiklaLabel.Name = "poKoduArtiklaLabel";
            this.poKoduArtiklaLabel.Size = new System.Drawing.Size(426, 24);
            this.poKoduArtiklaLabel.TabIndex = 6;
            this.poKoduArtiklaLabel.Text = "Izaberi artikl koji treba ukloniti iz ponude(po kodu artikla)";
            // 
            // kriterijLabel
            // 
            this.kriterijLabel.AutoSize = true;
            this.kriterijLabel.Location = new System.Drawing.Point(86, 356);
            this.kriterijLabel.Name = "kriterijLabel";
            this.kriterijLabel.Size = new System.Drawing.Size(71, 24);
            this.kriterijLabel.TabIndex = 7;
            this.kriterijLabel.Text = "Kriterij: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.promijeniToolStripMenuItem,
            this.zatvoriToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 52);
            // 
            // promijeniToolStripMenuItem
            // 
            this.promijeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bojuPozadineToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.promijeniToolStripMenuItem.Name = "promijeniToolStripMenuItem";
            this.promijeniToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.promijeniToolStripMenuItem.Text = "Promijeni";
            // 
            // bojuPozadineToolStripMenuItem
            // 
            this.bojuPozadineToolStripMenuItem.Name = "bojuPozadineToolStripMenuItem";
            this.bojuPozadineToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.bojuPozadineToolStripMenuItem.Text = "Boju pozadine";
            this.bojuPozadineToolStripMenuItem.Click += new System.EventHandler(this.BojuPozadineToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // zatvoriToolStripMenuItem
            // 
            this.zatvoriToolStripMenuItem.Name = "zatvoriToolStripMenuItem";
            this.zatvoriToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.zatvoriToolStripMenuItem.Text = "Zatvori";
            this.zatvoriToolStripMenuItem.Click += new System.EventHandler(this.ZatvoriToolStripMenuItem_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(483, 615);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.kriterijLabel);
            this.Controls.Add(this.poKoduArtiklaLabel);
            this.Controls.Add(this.poKoduArtiklaCB);
            this.Controls.Add(this.imeOdabranogArtiklaLabel);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.poRokuUpotrebeLabel);
            this.Controls.Add(this.poRokuUpotrebeCB);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form5_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox poRokuUpotrebeCB;
        private System.Windows.Forms.Label poRokuUpotrebeLabel;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Label imeOdabranogArtiklaLabel;
        private System.Windows.Forms.ComboBox poKoduArtiklaCB;
        private System.Windows.Forms.Label poKoduArtiklaLabel;
        private System.Windows.Forms.Label kriterijLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem promijeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bojuPozadineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriToolStripMenuItem;
    }
}