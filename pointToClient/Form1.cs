using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button btn = new Button();

            btn.Location = new Point(200, 200);
            btn.Text = "Gumb";
            btn.Size = new Size(100, 40);

            this.Controls.Add(btn);
            btn.Click += new EventHandler(btn_Click);
        }

        protected void btn_Click (object sender, EventArgs e) 
        {

            label1.Text = "(" + this.PointToClient(new Point(MousePosition.X, MousePosition.Y)).X + ", "
                + this.PointToClient(MousePosition).Y + ")";
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
            label1.Text = "(" + this.PointToClient(new Point(MousePosition.X, MousePosition.Y)).X + ", "
                + this.PointToClient(MousePosition).Y + ")";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "(" + this.PointToClient(new Point(MousePosition.X, MousePosition.Y)).X + ", "
               + this.PointToClient(MousePosition).Y + ")";
        }
    }
}
