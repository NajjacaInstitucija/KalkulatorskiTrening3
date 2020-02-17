using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text + " " + textBox2.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text + " " + textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var result = MessageBox.Show("Odaberi opciju:", "MBox", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes) Application.Exit();
            else if(result == DialogResult.No)
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
