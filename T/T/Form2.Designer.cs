namespace T
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Login = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.Registriraj = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.promijeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bojuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registracijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.ForestGreen;
            this.Login.Font = new System.Drawing.Font("Segoe Print", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(61, 345);
            this.Login.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(467, 124);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.login_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(57, 141);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(89, 24);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "&Username: ";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(57, 252);
            this.passLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(86, 24);
            this.passLabel.TabIndex = 3;
            this.passLabel.Text = "&Password: ";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(159, 141);
            this.usernameTB.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(296, 30);
            this.usernameTB.TabIndex = 2;
            this.usernameTB.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.usernameTB.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(159, 246);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(296, 30);
            this.passwordTB.TabIndex = 4;
            this.passwordTB.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            this.passwordTB.MouseHover += new System.EventHandler(this.tb_MouseHover);
            // 
            // Registriraj
            // 
            this.Registriraj.BackColor = System.Drawing.Color.SteelBlue;
            this.Registriraj.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registriraj.Location = new System.Drawing.Point(469, 34);
            this.Registriraj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Registriraj.Name = "Registriraj";
            this.Registriraj.Size = new System.Drawing.Size(128, 69);
            this.Registriraj.TabIndex = 5;
            this.Registriraj.Text = "Registriraj";
            this.Registriraj.UseVisualStyleBackColor = false;
            this.Registriraj.Click += new System.EventHandler(this.registracija_Click);
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
            this.registracijaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 52);
            // 
            // promijeniToolStripMenuItem
            // 
            this.promijeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bojuToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.promijeniToolStripMenuItem.Name = "promijeniToolStripMenuItem";
            this.promijeniToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.promijeniToolStripMenuItem.Text = "Promijeni";
            // 
            // bojuToolStripMenuItem
            // 
            this.bojuToolStripMenuItem.Name = "bojuToolStripMenuItem";
            this.bojuToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.bojuToolStripMenuItem.Text = "Boju Pozadine";
            this.bojuToolStripMenuItem.Click += new System.EventHandler(this.bojuToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // registracijaToolStripMenuItem
            // 
            this.registracijaToolStripMenuItem.Name = "registracijaToolStripMenuItem";
            this.registracijaToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.registracijaToolStripMenuItem.Text = "Registracija";
            this.registracijaToolStripMenuItem.Click += new System.EventHandler(this.registracija_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(609, 519);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.Registriraj);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.Login);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form2";
            this.Text = "Form2";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Button Registriraj;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem promijeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bojuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registracijaToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}