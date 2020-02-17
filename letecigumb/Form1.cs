using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkCyan;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Pink;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // button1.Location = new Point(this.PointToClient(MousePosition).X, this.PointToClient(MousePosition).Y);

        }

        bool dragging = false;
        Point mouseDown;
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            //mouseDown = new Point(this.PointToClient(MousePosition).X, this.PointToClient(MousePosition).Y);
            // mouseDown = new Point(this.PointToScreen(MousePosition).X, this.PointToScreen(MousePosition).Y);
            mouseDown = new Point(e.X, e.Y);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                button1.Location += new Size(e.X - mouseDown.X, e.Y - mouseDown.Y);
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
