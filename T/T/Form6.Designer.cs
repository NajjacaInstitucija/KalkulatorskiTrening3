namespace T
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwirdTB = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.confirmPassTB = new System.Windows.Forms.TextBox();
            this.confirmPassLabel = new System.Windows.Forms.Label();
            this.managerCheckBox = new System.Windows.Forms.CheckBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.promijeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bojuPozadineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(71, 69);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(89, 24);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "&Username: ";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(166, 69);
            this.usernameTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(201, 30);
            this.usernameTB.TabIndex = 1;
            // 
            // passwirdTB
            // 
            this.passwirdTB.Location = new System.Drawing.Point(166, 158);
            this.passwirdTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwirdTB.Name = "passwirdTB";
            this.passwirdTB.Size = new System.Drawing.Size(201, 30);
            this.passwirdTB.TabIndex = 3;
            this.passwirdTB.MouseLeave += new System.EventHandler(this.TB_MouseLeave);
            this.passwirdTB.MouseHover += new System.EventHandler(this.TB_MouseHover);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(71, 158);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(86, 24);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "&Password: ";
            // 
            // confirmPassTB
            // 
            this.confirmPassTB.Location = new System.Drawing.Point(166, 214);
            this.confirmPassTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmPassTB.Name = "confirmPassTB";
            this.confirmPassTB.Size = new System.Drawing.Size(201, 30);
            this.confirmPassTB.TabIndex = 5;
            this.confirmPassTB.MouseLeave += new System.EventHandler(this.TB_MouseLeave);
            this.confirmPassTB.MouseHover += new System.EventHandler(this.TB_MouseHover);
            // 
            // confirmPassLabel
            // 
            this.confirmPassLabel.AutoSize = true;
            this.confirmPassLabel.Location = new System.Drawing.Point(12, 214);
            this.confirmPassLabel.Name = "confirmPassLabel";
            this.confirmPassLabel.Size = new System.Drawing.Size(148, 24);
            this.confirmPassLabel.TabIndex = 4;
            this.confirmPassLabel.Text = "&Confirm password: ";
            // 
            // managerCheckBox
            // 
            this.managerCheckBox.AutoSize = true;
            this.managerCheckBox.Location = new System.Drawing.Point(141, 286);
            this.managerCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.managerCheckBox.Name = "managerCheckBox";
            this.managerCheckBox.Size = new System.Drawing.Size(93, 28);
            this.managerCheckBox.TabIndex = 6;
            this.managerCheckBox.Text = "manager";
            this.managerCheckBox.UseVisualStyleBackColor = true;
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.RoyalBlue;
            this.Confirm.Font = new System.Drawing.Font("Segoe Print", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm.Location = new System.Drawing.Point(41, 358);
            this.Confirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(314, 111);
            this.Confirm.TabIndex = 7;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
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
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(527, 522);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.managerCheckBox);
            this.Controls.Add(this.confirmPassTB);
            this.Controls.Add(this.confirmPassLabel);
            this.Controls.Add(this.passwirdTB);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.usernameLabel);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form6";
            this.Text = "Form6";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form6_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.TextBox passwirdTB;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox confirmPassTB;
        private System.Windows.Forms.Label confirmPassLabel;
        private System.Windows.Forms.CheckBox managerCheckBox;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem promijeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bojuPozadineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}