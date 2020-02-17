using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vjezbe09
{
    public partial class Form2 : Form
    {

        
        Form1 form1 = new Form1();

        public Form2()
        {
            InitializeComponent();
            form1.Osobe = new List<Osoba>();
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            form1.ShowDialog();
            linkLabel1.LinkVisited = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();

            foreach (Osoba o in form1.Osobe)
                listBox1.Items.Add(o.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (radioButton1.Checked)
            {
                foreach (Osoba o in form1.Osobe)
                    if (o.Ime == textBox1.Text)
                        listBox1.Items.Add(o.ToString());
            }

            else if (radioButton2.Checked)
            {
                foreach (Osoba o in form1.Osobe)
                    if (o.Prezime == textBox1.Text)
                        listBox1.Items.Add(o.ToString());
            }

            else if (radioButton3.Checked)
            {
                foreach (Osoba o in form1.Osobe)
                    if (o.Adresa == textBox1.Text)
                        listBox1.Items.Add(o.ToString());
            }

            else if (radioButton4.Checked)
            {
                foreach (Osoba o in form1.Osobe)
                    if (o.BrojTelefona == textBox1.Text)
                        listBox1.Items.Add(o.ToString());
            }

            else MessageBox.Show("Trebate izabrati jednu opciju");
        }
    }

    internal class Osoba
    {
        string ime;
        string prezime;
        string adresa;
        string brojTelefona;

        public Osoba(string ime, string prezime, string adresa, string brojTelefona)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.brojTelefona = brojTelefona;
        }

        public string Ime { get => this.ime; set => this.ime = value; }
        public string Prezime { get => this.prezime; set => this.prezime = value; }
        public string Adresa { get => this.adresa; set => this.adresa = value; }
        public string BrojTelefona { get => this.brojTelefona; set => this.brojTelefona = value; }

        public override string ToString()
        {
            return ime + " " + prezime + "(" + adresa + ": " + brojTelefona + ")";
        }

    }
}
