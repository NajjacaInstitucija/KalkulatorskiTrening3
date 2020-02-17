using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prostifaktori
{
    
    public partial class Form1 : Form
    {
        //bool gameOver = false;
        public static bool isProst(int n)
        {
            for (int i = 2; i < n/2; ++i)
                if (n % i == 0) return false;
            return true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int broj = rnd.Next(2, 1000);

            label2.Text = broj.ToString();

            timer1.Enabled = true;
            timer1.Start();

            button2.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isProst(Convert.ToInt32(textBox1.Text)))
                MessageBox.Show("Morate unijeti prost broj", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                int br = Convert.ToInt32(label2.Text);
                int d = Convert.ToInt32(textBox1.Text);
                if (br % d == 0) { br /= d; listBox1.Items.Add(d); }
                label2.Text = br.ToString();

                if (br == 1 && progressBar1.Maximum > progressBar1.Value)
                {
                    timer1.Stop();
                    MessageBox.Show("Pobjeda", "Uspjeh", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    //gameOver = true;
                    button2.Visible = true;
                    
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
            }

            if (progressBar1.Value == progressBar1.Maximum)
            { 
                MessageBox.Show("Poraz", "Nesupjeh", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
             //   gameOver = true;
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // gameOver = false;
            listBox1.Items.Clear();
            textBox1.Text = "";

            Random rnd = new Random();
            int broj = rnd.Next(2, 1000);

            label2.Text = broj.ToString();

            timer1.Start();

            progressBar1.Value = 0;

            button2.Visible = false;
        }

        private void button2_VisibleChanged(object sender, EventArgs e)
        {
           

        }
    }
}
