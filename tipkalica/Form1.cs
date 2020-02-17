using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tipkalica
{
    public partial class Form1 : Form
    {
        int ukupno, tocno, netocno;
        double postotak;
        public Form1()
        {
            InitializeComponent();
            tocno = 0;
            ukupno = 0;
            netocno = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            timer1.Enabled = true; 
            timer1.Start();
            timer1.Interval = 1000;
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(listBox1.Items.Contains(e.KeyChar.ToString().ToUpper()))
            {
                listBox1.Items.Remove(e.KeyChar.ToString().ToUpper());
                tocno++;
                ukupno++;
                postotak = (double)tocno / ukupno;

                if (timer1.Interval > 500)
                    timer1.Interval -= 10;

                else if (timer1.Interval > 250)
                    timer1.Interval -= 7;

                else if (timer1.Interval > 100)
                    timer1.Interval -= 2;

                if(toolStripProgressBar1.Value >= 1)
                toolStripProgressBar1.Value -= 1;
            }

            else
            {
                netocno++;
                ukupno++;
                postotak = (double)tocno / ukupno;
            }

            toolStripStatusLabel1.Text = "tocno: " + tocno.ToString();
            toolStripStatusLabel2.Text = "netocno: " + netocno.ToString();
            toolStripStatusLabel3.Text = "ukupno: " + ukupno.ToString();
            toolStripStatusLabel4.Text = "postotak: " + postotak.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            char znak = (char)rnd.Next(65, 91);
            if(listBox1.Items.Count <= 6)
                listBox1.Items.Add(znak.ToString().ToUpper());

            if (toolStripProgressBar1.Value != toolStripProgressBar1.Maximum)
            {
                toolStripProgressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Poraz", "Neuspjeh", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            
        }
    }
}
