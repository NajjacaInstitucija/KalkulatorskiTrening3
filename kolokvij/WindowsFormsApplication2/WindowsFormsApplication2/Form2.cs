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
    public partial class Form2 : Form
    {
        Color l1, l2, l3, l4;

        
       
        public Form2(Color c1, Color c2, Color c3, Color c4)
        {
            InitializeComponent();
            l1 = c1;
            l2 = c2;
            l3 = c3;
            l4 = c4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vis = Convert.ToInt32(textBox1.Text);
            int sir = Convert.ToInt32(textBox2.Text);

            Form3 form3 = new Form3(vis, sir, l1, l2, l3, l4);
            this.Hide();
            form3.ShowDialog();
            
        }



    }
}
