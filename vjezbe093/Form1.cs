using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vjezbe093
{
    public partial class Form1 : Form
    {
        List<string> kolegiji;
        public Form1()
        {
            InitializeComponent();
            kolegiji = new List<string>();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if(!kolegiji.Contains(textBox1.Text))
            {
                kolegiji.Add(textBox1.Text);
                listBox1.Items.Add(textBox1.Text);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            int ocjena = 1;
            if (radioButton1.Checked) ocjena = 2;
            else if (radioButton2.Checked) ocjena = 3;
            else if (radioButton3.Checked) ocjena = 4;
            else if (radioButton4.Checked) ocjena = 5;

            string datum = dateTimePicker1.Value.ToShortDateString();

            string kolegij = listBox1.GetItemText(listBox1.SelectedItem);

            bool kontrola = true;
            foreach(string s in listBox2.Items)
            {
                string kol = s.Substring(0, s.IndexOf("("));
                if (kol == kolegij) kontrola = false;
            }

            if (kontrola)
                listBox2.Items.Add(kolegij + "(" + ocjena.ToString() + ", " + datum + ")");

            
        }
    }
}
