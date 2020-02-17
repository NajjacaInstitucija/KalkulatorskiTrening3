using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int i = 1, x = 50, y = 10;
         private void button1_Click(object sender, EventArgs e)
         {
              Button button = new Button();

              button.Location = new System.Drawing.Point(x, y);
              button.Name = "button"+i;
              button.Size = new System.Drawing.Size(100, 40);
              button.TabIndex = 1;
              button.Text = "Gumb " +i;
              button.UseVisualStyleBackColor = true;
              
              tableLayoutPanel1.Controls.Add(button);


            i++;
            


         }
    }
}
