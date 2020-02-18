using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jednostavanKalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double b1 = Convert.ToDouble(textBox1.Text);
            double b2 = Convert.ToDouble(textBox2.Text);

            textBox3.Text = (b1 + b2).ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            double b1 = Convert.ToDouble(textBox1.Text);
            double b2 = Convert.ToDouble(textBox2.Text);

            textBox3.Text = (b1 - b2).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double b1 = Convert.ToDouble(textBox1.Text);
            double b2 = Convert.ToDouble(textBox2.Text);

            textBox3.Text = (b1 / b2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double b1 = Convert.ToDouble(textBox1.Text);
            double b2 = Convert.ToDouble(textBox2.Text);

            textBox3.Text = (b1 * b2).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text += button6.Text;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox4.Text += button12.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox4.Text += button11.Text;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox4.Text += button8.Text;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox4.Text += button10.Text;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Text += button9.Text;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Text += button7.Text;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Text += button5.Text;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox4.Text += button13.Text;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox4.Text += button18.Text;

        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox4.Text += (" " + button17.Text + " ");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox4.Text += (" " + button16.Text + " ");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox4.Text += (" " + button14.Text + " ");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox4.Text += (" " + button15.Text + " ");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox4.Text += "=";
            int count = textBox4.Text.Count(f => f == ' ');

            int brojFaktora = (count / 2) + 1;

            List<int> faktori = new List<int>();
            List<string> op = new List<string>();
            int next = 0;
            int prev = 0;
            int len;
            for(int i = 0; i < brojFaktora-1; ++i)
            {
                next = textBox4.Text.IndexOf(" ", next);
                op.Add(textBox4.Text.Substring(next+1, 1));
                len = next - prev;
                string fak = textBox4.Text.Substring(prev, len);
                faktori.Add(Convert.ToInt32(fak));
                next += 3;
                prev = next;


            }

            next = textBox4.Text.IndexOf("=", next);
            len = next - prev;
            string zadnji = textBox4.Text.Substring(prev, len);
            faktori.Add(Convert.ToInt32(zadnji));



            string isp = "";
            foreach (int fakt in faktori)
                isp += fakt.ToString() + " ";

            string ispOp = "";
            foreach (string o  in op)
                ispOp += o.ToString() + " ";

            //MessageBox.Show(ispOp);

            List<double> faktori2 = new List<double>();
            List<string> op2 = new List<string>();
            bool evaluirano = false;
            for(int i = 0; i < op.Count; ++i)
            {
                if (op[i] == "+" || op[i] == "-")
                {
                    op2.Add(op[i]);

                    if (!evaluirano) faktori2.Add((double)faktori[i]);
                       

                    //else faktori2.Add((double)faktori[i + 1]);

                   evaluirano = false;
                }

                else if(op[i] == "*")
                {
                    double rez = (double)faktori[i] * (double)faktori[i + 1];
                    faktori2.Add(rez);
                    evaluirano = true;
                }

                else if (op[i] == "/")
                {
                    double rez = (double)faktori[i] / (double)faktori[i + 1];
                    faktori2.Add(rez);
                    evaluirano = true;
                }

               

            }

            string isp2 = "";
            foreach (int fakt in faktori2)
                isp2 += fakt.ToString() + " ";

            string ispOp2 = "";
            foreach (string o in op2)
                ispOp2 += o.ToString() + " ";

            MessageBox.Show(isp2);

        }
    }
}
