using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Balloon Tip Title";
            notifyIcon1.BalloonTipText = "Balloon Tip Text.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bojuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = fontDialog1.ShowDialog();
            if (res == DialogResult.OK)
               listBox1.Font = fontDialog1.Font;
        }

        private void listBox1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void listBox2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                domainUpDown1.Items.Add(textBox1.Text);
                listBox1.Items.Add(textBox1.Text);
            }

            if (textBox2.Text != "")
                listBox2.Items.Add(textBox2.Text);

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                errorProvider1.SetError(textBox2, "Nista nije uneseno u tb2");

            else errorProvider1.Clear();
            
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(1000);

           
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();

            string filename = openFileDialog1.FileName;
            textBox1.Text = filename;
            
        }
    }
}
