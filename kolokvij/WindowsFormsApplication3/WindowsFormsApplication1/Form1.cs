using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static int i1 = 1;
        static int x1 = 50;
        static int y1 = 50;

        static int i2 = 1;
        static int x2 = 50;
        static int y2 = 50;

        int dodanoUkupno;
        int kliknutoUkupno;

        List<Button> buttons1;
        List<Button> buttons2;
        public Form1()
        {
            InitializeComponent();
            buttons1 = new List<Button>();
            buttons2 = new List<Button>();
            dodanoUkupno = 0;
            kliknutoUkupno = 0;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = new Button();

            button.Location = new System.Drawing.Point(x1, y1);
            button.Name = "button" + i1;
            button.Size = new System.Drawing.Size(104, 40);
            button.TabIndex = 1;
            button.Text = "Gumb " + i1;
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(kliknut_Novi_Lijevo);


            splitContainer1.Panel1.Controls.Add(button);
            buttons1.Add(button);
            dodanoUkupno++;

            toolStripStatusLabel1.Text = "dodano ukupno: " + dodanoUkupno.ToString();

            y1 += 45;
            i1++;

        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            Button button = new Button();

            button.Location = new System.Drawing.Point(x2, y2);
            button.Name = "button" + i2;
            button.Size = new System.Drawing.Size(104, 40);
            button.TabIndex = 1;
            button.Text = "Gumb " + i2;
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(kliknut_Novi_Desno);


            splitContainer1.Panel2.Controls.Add(button);
            buttons2.Add(button);
            dodanoUkupno++;

            toolStripStatusLabel1.Text = "dodano ukupno: " + dodanoUkupno.ToString();

            y2 += 45;
            i2++;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Button b in buttons1)
            splitContainer1.Panel1.Controls.Remove(b);

            i1 = 1;
            x1 = 50;
            y1 = 50;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Button b in buttons2)
                splitContainer1.Panel2.Controls.Remove(b);

            i2 = 1;
            x2 = 50;
            y2 = 50;
        }




        private void kliknut_Novi_Lijevo(object sender, EventArgs e)
        {
            MessageBox.Show("Na lijevoj strani, " + (sender as Button).Text);

            kliknutoUkupno++;
            toolStripStatusLabel2.Text = "kliknuto ukupno: " + kliknutoUkupno; 
        }


        private void kliknut_Novi_Desno(object sender, EventArgs e)
        {
            MessageBox.Show("Na desnoj strani, " + (sender as Button).Text);

            kliknutoUkupno++;
            toolStripStatusLabel2.Text = "kliknuto ukupno: " + kliknutoUkupno;

        }
    }
}
