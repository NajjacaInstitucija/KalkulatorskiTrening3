namespace T
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.Spremi = new System.Windows.Forms.Button();
            this.KodoviArtikala = new System.Windows.Forms.ListBox();
            this.popustNUD = new System.Windows.Forms.NumericUpDown();
            this.popustLabel = new System.Windows.Forms.Label();
            this.imeSelektiranogLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.promijeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bojuPozadineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.popustNUD)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Spremi
            // 
            this.Spremi.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Spremi.Location = new System.Drawing.Point(75, 634);
            this.Spremi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Spremi.Name = "Spremi";
            this.Spremi.Size = new System.Drawing.Size(203, 76);
            this.Spremi.TabIndex = 0;
            this.Spremi.Text = "Spremi";
            this.Spremi.UseVisualStyleBackColor = false;
            this.Spremi.Click += new System.EventHandler(this.Spremi_Click);
            // 
            // KodoviArtikala
            // 
            this.KodoviArtikala.FormattingEnabled = true;
            this.KodoviArtikala.ItemHeight = 23;
            this.KodoviArtikala.Location = new System.Drawing.Point(75, 22);
            this.KodoviArtikala.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.KodoviArtikala.Name = "KodoviArtikala";
            this.KodoviArtikala.Size = new System.Drawing.Size(201, 441);
            this.KodoviArtikala.TabIndex = 1;
            this.KodoviArtikala.SelectedIndexChanged += new System.EventHandler(this.KodoviArtikala_SelectedIndexChanged);
            // 
            // popustNUD
            // 
            this.popustNUD.Location = new System.Drawing.Point(140, 546);
            this.popustNUD.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.popustNUD.Name = "popustNUD";
            this.popustNUD.Size = new System.Drawing.Size(137, 30);
            this.popustNUD.TabIndex = 2;
            // 
            // popustLabel
            // 
            this.popustLabel.AutoSize = true;
            this.popustLabel.Location = new System.Drawing.Point(71, 551);
            this.popustLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.popustLabel.Name = "popustLabel";
            this.popustLabel.Size = new System.Drawing.Size(69, 24);
            this.popustLabel.TabIndex = 3;
            this.popustLabel.Text = "Popust: ";
            // 
            // imeSelektiranogLabel
            // 
            this.imeSelektiranogLabel.AutoSize = true;
            this.imeSelektiranogLabel.Location = new System.Drawing.Point(105, 496);
            this.imeSelektiranogLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.imeSelektiranogLabel.Name = "imeSelektiranogLabel";
            this.imeSelektiranogLabel.Size = new System.Drawing.Size(166, 24);
            this.imeSelektiranogLabel.TabIndex = 4;
            this.imeSelektiranogLabel.Text = "ime odabranog artikla";
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
            this.bojuPozadineToolStripMenuItem.Click += new System.EventHandler(this.bojuPozadineToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // zatvoriToolStripMenuItem
            // 
            this.zatvoriToolStripMenuItem.Name = "zatvoriToolStripMenuItem";
            this.zatvoriToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.zatvoriToolStripMenuItem.Text = "Zatvori";
            this.zatvoriToolStripMenuItem.Click += new System.EventHandler(this.zatvoriToolStripMenuItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form4
            // 
            this.AcceptButton = this.Spremi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(416, 730);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.imeSelektiranogLabel);
            this.Controls.Add(this.popustLabel);
            this.Controls.Add(this.popustNUD);
            this.Controls.Add(this.KodoviArtikala);
            this.Controls.Add(this.Spremi);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form4";
            this.Text = "Form4";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form4_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.popustNUD)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Spremi;
        private System.Windows.Forms.ListBox KodoviArtikala;
        private System.Windows.Forms.NumericUpDown popustNUD;
        private System.Windows.Forms.Label popustLabel;
        private System.Windows.Forms.Label imeSelektiranogLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem promijeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bojuPozadineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}