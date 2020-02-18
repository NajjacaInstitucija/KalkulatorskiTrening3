using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        Color l1, l2, l3, l4;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int v, s;
        public Form3(int vis, int sir, Color c1, Color c2, Color c3, Color c4)
        {
            InitializeComponent();
            l1 = c1;
            l2 = c2;
            l3 = c3;
            l4 = c4;
            v = vis;
            s = sir;
            this.Height = v;
            this.Width = s;


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.BackColor = l1;
            label2.BackColor = l2;
            label3.BackColor = l3;
            label4.BackColor = l4;
        }
    }
}
