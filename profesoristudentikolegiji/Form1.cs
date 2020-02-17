using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace profesoristudentikolegiji
{
    
    public partial class Form1 : Form
    {

        List<Profesor> profesori;
        List<string> kolegiji;
        List<Student> studenti;
        static int broj = 0;
        static int jmbagovi = 0;


        

        private void osvjeziDrvo(int studentovJMBAG, string imeProfesora)
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();


            int i = 0;
            foreach (Profesor p in profesori)
            {
                treeView1.Nodes.Add(p.Ime);
                foreach (string kol in p.getPredmeti())
                {
                   
                    Student st = studenti[studentovJMBAG];
                    UpisaniPredmet up = st.getUpisaniPredmetByIme(kol);


                    //popraviti bug da se premjesta kod drugog profesora
                    //if (p.Ime == imeProfesora && up != null)
                    if(up !=  null)
                        treeView1.Nodes[i].Nodes.Add(up.ToString());

                    else treeView1.Nodes[i].Nodes.Add(kol);

                }
                ++i;
            }
            treeView1.EndUpdate();
        }
        
        public Form1()
        {
            InitializeComponent();
            profesori = new List<Profesor>();
            kolegiji = new List<string>();
            studenti = new List<Student>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && !listBox1.Items.Contains(textBox1.Text))
                listBox1.Items.Add(textBox1.Text);

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && !comboBox1.Items.Contains(textBox2.Text))
            {
                Profesor p = new Profesor(textBox2.Text, broj++);
                comboBox1.Items.Add(textBox2.Text);
                profesori.Add(p);

            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach(string kol in profesori[comboBox1.SelectedIndex].getPredmeti())
            {
                listBox2.Items.Add(kol);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string kol in listBox1.SelectedItems)
               if(!profesori[comboBox1.SelectedIndex].getPredmeti().Contains(kol))
                profesori[comboBox1.SelectedIndex].dodajPredmet(kol);

            listBox2.Items.Clear();
            foreach (string kol in profesori[comboBox1.SelectedIndex].getPredmeti())
            {
                listBox2.Items.Add(kol);
            }

            // dodati kao novo dijete predmet odredenom profesoru u tree viewu
            if(comboBox2.SelectedIndex > -1)
            osvjeziDrvo(comboBox2.SelectedIndex, comboBox1.GetItemText(comboBox1.SelectedItem));

            listBox1.SelectedItems.Clear();

        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && !comboBox2.Items.Contains(textBox3 + " " + textBox4))
            {
                Student st = new Student(textBox3.Text, textBox4.Text, jmbagovi++);
                studenti.Add(st);
                comboBox2.Items.Add(st.ToString());


            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        // preko treeViewa treba odabrati profesora => predmet(kao dijete u stablu), i onda unijeti ocjenu i datum
        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Parent != null)
            {
                string kol = treeView1.SelectedNode.Text;
                string imeProfesora = treeView1.SelectedNode.Parent.Text;
                int ocjena = (int)numericUpDown1.Value;
                bool status = true;
                DateTime datum = dateTimePicker1.Value;

                UpisaniPredmet up = new UpisaniPredmet(kol, status, ocjena, datum, imeProfesora);
                int studentovJMBAG = comboBox1.SelectedIndex;
                //MessageBox.Show(studentovJMBAG.ToString());
                if (comboBox1.SelectedIndex > -1)
                {
                    Student st = studenti[studentovJMBAG];

                    if (!st.naziviUpisanih().Contains(up.Kol))
                    {
                        st.upisiPredmet(up);
                        osvjeziDrvo(studentovJMBAG, imeProfesora);
                    }

                    //MessageBox.Show(st.sviPredmeti());
                }
            }

            else MessageBox.Show("Treba odabrati predmet.", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            osvjeziDrvo(comboBox2.SelectedIndex, comboBox1.GetItemText(comboBox1.SelectedItem));
        }
    }

    class Profesor
    {
        string ime;
        int indeks;
        List<string> predmeti;
        
        public Profesor(string ime, int indeks)
        {
            this.ime = ime;
            this.indeks = indeks;
            predmeti = new List<string>();
            
        }

        public string Ime
        {
            get { return this.ime; }
            set { this.ime = value; }
        }

        public List<string> getPredmeti() => this.predmeti;

        public override string ToString()
        {
            return this.ime.ToString();
        }

        public void dodajPredmet(string kol) => this.predmeti.Add(kol);

    }

    class UpisaniPredmet
    {
        string kol;
        bool status;
        int ocjena;
        DateTime datum;
        string imeProfesora;

        public UpisaniPredmet(string kol, bool status, int ocjena, DateTime datum, string imeProfesora)
        {
            this.kol = kol;
            this.status = status;
            this.ocjena = ocjena;
            this.datum = datum;
            this.imeProfesora = imeProfesora;
        }

        public string Kol
        {
            get { return this.kol; }
        }

        public int Ocjena { get => ocjena; set => ocjena = value; }
        public string ImeProfesora { get => imeProfesora; set => imeProfesora = value; }

        public override string ToString()
        {
            return this.kol + "(ocjena: " + this.ocjena + ", status: " + this.status + ", datum: " + this.datum.ToString() + ", ime profesora: " + this.imeProfesora + ")";
        }
    }

    class Student
    {
        string ime;
        string prezime;
        int JMBAG;
        List<UpisaniPredmet> upisaniPredmeti;

        public Student(string ime, string prezime, int JMBAG)
        {
            upisaniPredmeti = new List<UpisaniPredmet>();
            this.ime = ime;
            this.prezime = prezime;
            this.JMBAG = JMBAG;
        }

        public string Ime
        {
            get { return this.ime; }
            set { this.ime = value; }
        }

        public string Prezime
        {
            get { return this.prezime; }
            set { this.Prezime = value; }
        }

        public void upisiPredmet(UpisaniPredmet u) => this.upisaniPredmeti.Add(u);

        public UpisaniPredmet getUpisaniPredmetByIme(string kol)
        {
            foreach (UpisaniPredmet up in this.upisaniPredmeti)
                if (up.Kol == kol)
                    return up;

            return null;
        }

        public List<UpisaniPredmet> getUpisaniPredmeti() => this.upisaniPredmeti;

        public List<string> naziviUpisanih()
        {
            List<string> nu = new List<string>();

            foreach (UpisaniPredmet up in upisaniPredmeti)
                nu.Add(up.Kol);

            return nu;
        }

        public override string ToString()
        {
            return this.ime.ToString() + " " + this.prezime.ToString();
        }

        public string sviPredmeti()
        {
            string str = "";
            foreach(UpisaniPredmet up in this.upisaniPredmeti)
                str+= (up.Kol + ", ");

            return str;
        }
    }
}
