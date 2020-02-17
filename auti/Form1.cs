using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auti
{
    public partial class Form1 : Form
    {
        List<string> tvrtke;
        List<Auto> modeli;
        Font previuosFont;
        Color previousColor;
        int promjena;
        public Form1()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            tvrtke = new List<string>();
            modeli = new List<Auto>();
            promjena = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                errorProvider1.SetError(textBox1, "Treba postaviti vrijednost");

            else
            {
                
                errorProvider1.Clear();
                if (tvrtke.Contains(textBox1.Text)) return;

                treeView1.Nodes.Add(textBox1.Text);
                tvrtke.Add(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked) ||
                textBox2.Text == "" || textBox3.Text == "" || treeView1.SelectedNode.Parent != null || treeView1.SelectedNode == null)
            {
                errorProvider1.SetError(button2, "Neka vrijednost nije postavljena");
                return;
            }

            else
            {
                errorProvider1.Clear();
                string tip = "";
                if (radioButton1.Checked) tip = "benzin";
                else if (radioButton2.Checked) tip = "dizel";
                else if (radioButton3.Checked) tip = "struja";


                Auto a = new Auto(textBox2.Text, Convert.ToInt32(textBox3.Text), tip, dateTimePicker1.Value.ToShortDateString());

                if (modeli.Contains(a)) return;

                treeView1.SelectedNode.Nodes.Add(textBox2.Text);
                treeView1.SelectedNode.LastNode.Nodes.Add(a.specifikacije());
                modeli.Add(a);
            }
        }

        private void zatvoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bojaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();


            if(res == DialogResult.OK)
            {
                promjena = 1;
                previousColor = this.BackColor;
                this.BackColor = colorDialog1.Color;
                
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (promjena == 0) return;
            else if (promjena == 1) this.BackColor = previousColor;
            else if (promjena == 2) this.Font = previuosFont;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = fontDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                promjena = 2;
                previuosFont = treeView1.Font;
                treeView1.Font = fontDialog1.Font;
            }
        }
    }


    class Auto : IComparable<Auto>, IEquatable<Auto>
    {
        string model;
        int brzina;
        string tip;
        string datum;

        

        public Auto(string model, int br, string tip, string datum)
        {
            this.model = model;
            this.brzina = br;
            this.tip = tip;
            this.datum = datum;
        }

        public string Model { get => model; set => model = value; }

        public int CompareTo(Auto other)
        {
            return this.model.CompareTo(other.Model);
        }

        public bool Equals(Auto other)
        {
            return this.model == other.Model;
        }

        public string specifikacije()
        {
            return "tip: " + this.tip + ", brzina: " + this.brzina.ToString() + "km/h, datum proizvodnje: " + this.datum; 
        }
    }

}
