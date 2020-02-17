namespace forme4
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oMeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imeIPrezimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brojTelefonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poštanskiBrojToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "O meni";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oMeniToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oMeniToolStripMenuItem
            // 
            this.oMeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imeIPrezimeToolStripMenuItem,
            this.brojTelefonaToolStripMenuItem,
            this.poštanskiBrojToolStripMenuItem});
            this.oMeniToolStripMenuItem.Name = "oMeniToolStripMenuItem";
            this.oMeniToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.oMeniToolStripMenuItem.Text = "O meni";
            // 
            // imeIPrezimeToolStripMenuItem
            // 
            this.imeIPrezimeToolStripMenuItem.Name = "imeIPrezimeToolStripMenuItem";
            this.imeIPrezimeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.imeIPrezimeToolStripMenuItem.Text = "Ime i prezime";
            this.imeIPrezimeToolStripMenuItem.Click += new System.EventHandler(this.imeIPrezimeToolStripMenuItem_Click);
            // 
            // brojTelefonaToolStripMenuItem
            // 
            this.brojTelefonaToolStripMenuItem.Name = "brojTelefonaToolStripMenuItem";
            this.brojTelefonaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.brojTelefonaToolStripMenuItem.Text = "Broj telefona";
            this.brojTelefonaToolStripMenuItem.Click += new System.EventHandler(this.brojTelefonaToolStripMenuItem_Click);
            // 
            // poštanskiBrojToolStripMenuItem
            // 
            this.poštanskiBrojToolStripMenuItem.Name = "poštanskiBrojToolStripMenuItem";
            this.poštanskiBrojToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.poštanskiBrojToolStripMenuItem.Text = "Poštanski broj";
            this.poštanskiBrojToolStripMenuItem.Click += new System.EventHandler(this.poštanskiBrojToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(597, 193);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oMeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imeIPrezimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brojTelefonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poštanskiBrojToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

