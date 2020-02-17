using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int r = 0, g = 0, b = 0;
            if (checkBox1.Checked)
                r = 255;
            if (checkBox2.Checked)
                g = 255;
            if (checkBox3.Checked)
                b = 255;

            this.BackColor = Color.FromArgb(r, g, b);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int r = 0, g = 0, b = 0;
            if (checkBox1.Checked)
                r = 255;
            if (checkBox2.Checked)
                g = 255;
            if (checkBox3.Checked)
                b = 255;

            this.BackColor = Color.FromArgb(r, g, b);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int r = 0, g = 0, b = 0;
            if (checkBox1.Checked)
                r = 255;
            if (checkBox2.Checked)
                g = 255;
            if (checkBox3.Checked)
                b = 255;

            this.BackColor = Color.FromArgb(r, g, b);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, 10);
            textBox1.Text = listBox1.GetItemText(listBox1.SelectedItem);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, 14);
            textBox1.Text = listBox1.GetItemText(listBox1.SelectedItem);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, 18);
            textBox1.Text = listBox1.GetItemText(listBox1.SelectedItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int size = 16;
            if (radioButton1.Checked)
                size = 10;
            else if (radioButton2.Checked)
                size = 14;
            else if (radioButton3.Checked)
                size = 18;

            textBox1.Font = new Font(textBox1.Font.FontFamily, size);
            textBox1.Text = listBox1.GetItemText(listBox1.SelectedItem);
        }
    }
}
