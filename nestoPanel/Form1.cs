using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int i = 1;
        static int x = 50;
        static int y = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = new Button();

            button.Location = new System.Drawing.Point(x, y);
            button.Name = "button"+i;
            button.Size = new System.Drawing.Size(104, 40);
            button.TabIndex = 1;
            button.Text = "Gumb " + i;
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(button_Click);

            flowLayoutPanel1.Controls.Add(button);
            y += 45;
            i++;
        }
        private void button_Click(object sender, EventArgs e)
        {
           
             this.BackColor = Color.Cyan;
        }
    }
}
