using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vjezbe09
{
    public partial class Form1 : Form
    {
        internal List<Osoba> Osobe;

        
        internal Form1()
        {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "(999)-000-0000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Poruka o kliku");
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show("(" + Cursor.Position.X.ToString() + ", " + Cursor.Position.Y.ToString() + ")");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text + " " + textBox2.Text + Environment.NewLine + textBox3.Text + Environment.NewLine + maskedTextBox1.Text, "Prozor", MessageBoxButtons.OK);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             Osoba o = new Osoba(textBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox1.Text);
             Osobe.Add(o);
            
        }

        
    }
}
