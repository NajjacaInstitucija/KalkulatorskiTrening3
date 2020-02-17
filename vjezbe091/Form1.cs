using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vjezbe091
{
    public partial class Form1 : Form
    {

        List<Profesor> profesori;
        List<Student> studenti;
        Dictionary<Profesor, List<Student>> mentoriINjihoviStudenti;

        bool checkNodes(string s)
        {

            for (int i = 0; i < treeView1.Nodes.Count; ++i)
            {
                for(int j = 0; j < treeView1.Nodes[i].Nodes.Count; ++j)
                if (treeView1.Nodes[i].Nodes[j].Text == s) return true;
            }

            return false;
        }

        public Form1()
        {
            InitializeComponent();
            profesori = new List<Profesor>();
            studenti = new List<Student>();
            mentoriINjihoviStudenti = new Dictionary<Profesor, List<Student>>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profesor p = new Profesor(textBox1.Text, textBox2.Text);
            if (!profesori.Contains(p) && !comboBox1.Items.Contains(p.ToString()))
            {
                profesori.Add(p);
                comboBox1.Items.Add(p.ToString());
            }

            textBox1.Text = "";
            textBox2.Text = "";

            treeView1.Nodes.Add(p.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s = new Student(textBox3.Text, textBox4.Text);
            if (!studenti.Contains(s) && !comboBox2.Items.Contains(s.ToString()))
            {
                studenti.Add(s);
                comboBox2.Items.Add(s.ToString());
            }

            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if( checkNodes("qw ert")) MessageBox.Show("pogodak");

           // Profesor p1 = new Profesor("ivo", "ivic");
            //Profesor p2 = new Profesor("ivo", "ivic");
            //MessageBox.Show((p1.Equals(p2)).ToString());

            if (treeView1.SelectedNode.Parent == null  && comboBox2.SelectedIndex > -1)
            {
                string pp = treeView1.SelectedNode.Text;
                string imeP = pp.Substring(0, pp.IndexOf(" "));
                string prezimeP = pp.Substring(pp.IndexOf(" ")+1);

                Profesor p = new Profesor(imeP, prezimeP);

                if(!mentoriINjihoviStudenti.ContainsKey(p))
                {
                    
                    List<Student> sts = new List<Student>();
                    string ss = comboBox2.GetItemText(comboBox2.SelectedItem);
                    string imeS = ss.Substring(0, ss.IndexOf(" "));
                    string prezimeS = ss.Substring(ss.IndexOf(" ") + 1);
                    sts.Add(new Student(imeS, prezimeS));
                    mentoriINjihoviStudenti.Add(p, sts);
                    treeView1.SelectedNode.Nodes.Add(comboBox2.GetItemText(comboBox2.SelectedItem));
                }

                else
                {
                    
                    string ss = comboBox2.GetItemText(comboBox2.SelectedItem);
                    string imeS = ss.Substring(0, ss.IndexOf(" "));
                    string prezimeS = ss.Substring(ss.IndexOf(" ") + 1);

                    Student s = new Student(imeS, prezimeS);
                    //if (treeView1.Nodes.Cast<TreeNode>().Any(item => item.ToString() == s.ToString()))
                    if (!mentoriINjihoviStudenti[p].Contains(s) && !checkNodes(s.ToString()))
                    {
                        mentoriINjihoviStudenti[p].Add(s);
                        treeView1.SelectedNode.Nodes.Add(s.ToString());
                    }

                    

                }
                /*treeView1.Nodes.Clear();
                int i = 0;
                foreach(string pkey in mentoriINjihoviStudenti.Keys)
                {
                    treeView1.Nodes.Add(pkey.ToString());
                    foreach (Student sss in mentoriINjihoviStudenti[pkey])
                        treeView1.Nodes[i].Nodes.Add(sss.ToString());
                       // MessageBox.Show(pkey.ToString() + " => " + sss.ToString());
                    ++i;
                }*/
                
               

            }
        }
    }

    class Osoba : IComparable<Osoba>, IEquatable<Osoba>
    {
        string ime;
        string prezime;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }

        public Osoba(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }

        

        public override string ToString()
        {
            return this.ime + " " + this.prezime;
        }

        public override bool Equals(object obj)
        {
            Osoba isOsoba = obj as Osoba;
            if (isOsoba == null) return false;

            return this.ime == isOsoba.Ime && this.prezime == isOsoba.Prezime;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Osoba other)
        {
            if (this.Prezime.CompareTo(other.Prezime) == 0) return this.ime.CompareTo(other.Ime);
            else return this.Prezime.CompareTo(other.Prezime);
        }

        public bool Equals(Osoba other)
        {
            return this.ime == other.Ime && this.prezime == other.Prezime;
        }
    }

    class Student : Osoba
    {
        public Student(string ime, string prezime) : base(ime, prezime)
        { }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Profesor : Osoba
    {
        public Profesor(string ime, string prezime) : base(ime, prezime)
        { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        

        
    }





}
