using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool rucno = true;
        public Form1()
        {
            InitializeComponent();
            button1.Width = this.Width;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            rucno = false;

            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            this.Height = (int)(0.8* this.Height);
            


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (rucno)
                button1.Height = (int)(0.5 * button1.Height);

            rucno = true;
        }
    }
}
