using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            label1.ForeColor = colorDialog1.Color;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            label2.ForeColor = colorDialog1.Color;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            label4.ForeColor = colorDialog1.Color;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            label3.ForeColor = colorDialog1.Color;
        }

        

        private void prikaziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(label1.ForeColor, label2.ForeColor, label4.ForeColor, label3.ForeColor);
            form2.ShowDialog();
        }
    }
}
