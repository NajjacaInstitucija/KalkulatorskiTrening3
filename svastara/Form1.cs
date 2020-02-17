using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forme18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //contextMenuStrip1.Show(this.PointToClient(MousePosition).X, this.PointToClient(MousePosition).Y);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                // contextMenuStrip1.Show(this.PointToScreen(MousePosition).X, this.PointToScreen(MousePosition).Y);
                //contextMenuStrip1.Show(e.X,e.Y);
                contextMenuStrip1.Show(Cursor.Position);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            radioButton4.Checked = false;
            if (!radioButton3.Checked)
                radioButton3.Checked = true;

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = false;
            if (!radioButton4.Checked)
                radioButton4.Checked = true;
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            if (!radioButton1.Checked)
                radioButton1.Checked = true;

        }

        private void žToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            if (!radioButton2.Checked)
                radioButton2.Checked = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Exit();
        }

        private void openColorDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
        }
    }
}
