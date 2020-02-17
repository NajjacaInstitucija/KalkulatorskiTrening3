using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        static int i = 1;
        static int x = 10;
        static int y = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            //button.Location = new System.Drawing.Point(100, 100);
            button.Name = "button" + i;
            button.Size = new System.Drawing.Size(100, 40);
            button.TabIndex = 1;
            button.Text = "Novi gumb " + i.ToString();
            button.UseVisualStyleBackColor = true;
            button.Location = new System.Drawing.Point(x, y);

            //button.Click += (s, e) => { this.BackColor = Color.Green; };
            button.Click += new EventHandler(button_Click);

            panel1.Controls.Add(button);
            ++i;
            y += 45;
        }

        protected void button_Click (object sender, EventArgs e) 
        {
            Image myimage = new Bitmap(@"C:\Users\stvar\source\repos\forme7\Resources\cheer.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = myimage;

        }
    }
}
