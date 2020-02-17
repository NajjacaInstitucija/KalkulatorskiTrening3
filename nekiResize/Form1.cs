using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Peru;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.DarkViolet;
            button1.FlatAppearance.BorderSize = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "Resize: On")
                textBox1.Text = "Resize: Off";

            else textBox1.Text = "Resize: On";

            if (textBox1.Text == "Resize: On")
                this.FormBorderStyle = FormBorderStyle.FixedSingle;

            else this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            
        }
    }
}
