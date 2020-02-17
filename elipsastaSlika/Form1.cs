using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void imeIPrezimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Ivan Knezić";
        }

        private void brojTelefonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "012 345 6789";
        }

        private void poštanskiBrojToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10 000 Zagreb";
        }
    }
}
