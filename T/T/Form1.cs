using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T
{
       
    public partial class Form1 : Form
    {
       
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Desktop\T\T\Artikli.mdb");

        List<Artikl> racun = new List<Artikl>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'artikliDataSet2.Artikli' table. You can move, or remove it, as needed.
            this.artikliTableAdapter.Fill(this.artikliDataSet2.Artikli);
            
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            if (textBox1.Text != "")
            {

                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Ime from Artikli where Ime like '" + textBox1.Text + "%'";
                //cmd.Parameters.AddWithValue("@Ime", textBox1.Text);
                cmd.Connection = connection;

                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader.GetString(0));
                }
                reader.Close();
                connection.Close();
            }
        }

        /*private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            
            listBox1.Items.Clear();

            if (textBox2.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Ime, KodArtikla from Artikli where KodArtikla like '" + textBox2.Text + "%'";
                cmd.Connection = connection;

                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader.GetString(0) + " (" + reader.GetString(1) + ")");
                }
                reader.Close();
                connection.Close();
            }
             

           }*/



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            OleDbCommand cmd = new OleDbCommand();

            /*string text;
            int found = listBox1.GetItemText(listBox1.SelectedItem).IndexOf(" ") + 1;
            if (found != -1)
            {

                text = listBox1.GetItemText(listBox1.SelectedItem).Substring(0, found);
                MessageBox.Show(text);
            }

            else text = listBox1.GetItemText(listBox1.SelectedItem);*/
            

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Cijena, Kategorija, KodArtikla from Artikli where Ime = '" + listBox1.GetItemText(listBox1.SelectedItem) + "'";
            cmd.Connection = connection;
           
            

            connection.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if(reader.GetString(1) == "Dairy" || reader.GetString(1) == "Candy")
                    textBox3.Text = reader.GetString(0) + " kn/pak";

                else if(reader.GetString(1) == "Fruit")
                    textBox3.Text = reader.GetString(0) + " kn/kg";

                else textBox3.Text = reader.GetString(0) + " kn/kom";

                textBox2.Text = reader.GetString(2);
            }
            reader.Close();
            connection.Close();


        }

        //provjera postoji li artikl s uspisanim kodom
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Cijena, Kategorija, KodArtikla from Artikli where KodArtikla = '" + textBox5.Text + "'";
            cmd.Connection = connection;

            connection.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (reader.GetString(1) == "Dairy" || reader.GetString(1) == "Candy")
                    textBox3.Text = reader.GetString(0) + " kn/pak";

                else if (reader.GetString(1) == "Fruit")
                    textBox3.Text = reader.GetString(0) + " kn/kg";

                else textBox3.Text = reader.GetString(0) + " kn/kom";

                textBox2.Text = reader.GetString(2);
            }

            else MessageBox.Show("Nema artikla s upisanim kodom");

            reader.Close();
            connection.Close();
        }

        //dodavanje artikla
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * from Artikli where KodArtikla = '" + textBox2.Text + "'";
                cmd.Connection = connection;

                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Artikl artikl = new Artikl(reader.GetString(1), Convert.ToDouble(reader.GetString(2)), reader.GetString(3), 
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), Convert.ToInt32(reader.GetString(7)), Convert.ToInt32(numericUpDown1.Value));


                    racun.Add(artikl);
                    
                }

                else MessageBox.Show("Nema artikla s upisanim kodom");

                reader.Close();
                connection.Close();

                listBox2.Items.Clear();
                listBox2.Items.Add("Kod artikla\t" + "Naziv\t\t" + "Cijena\t" + "Kolicina\t" + "Popust\t" + "Iznos");
                listBox2.Items.Add("------------------------------------------------------------------------------------------------------------------------");

                foreach (Artikl a in racun)
                    listBox2.Items.Add(a);

                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Text = "";
                textBox5.Text = "";
                numericUpDown1.Value = 1;

            }

        }

        //brisanje artikla s racuna
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Želite li sigurno maknuti označeni artikl?", "Brisanje artikla s računa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (res == DialogResult.Yes)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);

                foreach (Artikl a in racun)
                    if (a.ToString() == listBox2.GetItemText(listBox2.SelectedItem))
                        racun.Remove(a);
            }
        }

        // ispis racuna
        private void button2_Click(object sender, EventArgs e)
        {
            string text = "Kod artikla\t" + "Naziv\t\t" + "Cijena\t" + "Kolicina\t" + "Popust\t" + "Iznos";
            text += Environment.NewLine;
            text += "------------------------------------------------------------------------------";
            text += Environment.NewLine;

            double ukupno = 0;
            foreach (Artikl item in racun)
            {
                text += item.ToString();
                text += Environment.NewLine;
                ukupno += (item.Cijena - ((double)item.Popust / 100) * item.Cijena) * item.Kolicina;

            }

            text += "-------------------------------------------------------------------------------";
            text += Environment.NewLine;
            text += Environment.NewLine;
            text += "Nacin placanja:\t";

            string nacinPLacanja = "";
            if (radioButton1.Checked)
                nacinPLacanja = "gotovina";

            else if (radioButton2.Checked)
                nacinPLacanja = "cekovi";

            else if (radioButton3.Checked)
                nacinPLacanja = "kartica";

            else if (radioButton4.Checked)
                nacinPLacanja = "bonovi";

            else nacinPLacanja = "gotovina";

            text += nacinPLacanja;
            text += Environment.NewLine;
            text += Environment.NewLine;
            text += "Ukupno: \t\t";
            text += ukupno + " kn";


            DialogResult res = MessageBox.Show(text, "Trgovina", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if(res == DialogResult.OK)
            {
                //ispisi racun
            }





        }
    }

    public class Artikl
    {
        string ime;
        double cijena;
        string kategorija;
        string rokUpotrebe;
        string datumNabave;
        string kodArtikla;
        int kolicina;
        int popust;

        public Artikl(string ime, double cijena, string kategorija, string rokUpotrebe, string datumNabave, string kodArtikla, int popust, int kolicina)
        {
            this.ime = ime;
            this.cijena = cijena;
            this.kategorija = kategorija;
            this.rokUpotrebe = rokUpotrebe;
            this.datumNabave = datumNabave;
            this.kodArtikla = kodArtikla;
            this.popust = popust;
            this.kolicina = kolicina;
        }

        public string Ime
        {
            get { return this.ime; }
            set { this.ime = value; }
        }

        public double Cijena
        {
            get { return this.cijena; }
            set { this.cijena = value; }
        }

        public string Kategorija
        {
            get { return this.kategorija; }
            set { this.kategorija = value; }
        }

        public string RokUpotrebe
        {
            get { return this.rokUpotrebe; }
            set { this.rokUpotrebe = value; }
        }

        public string DatumNabave
        {
            get { return this.datumNabave; }
            set { this.datumNabave = value; }
        }

        public string KodArtikla
        {
            get { return this.kodArtikla; }
            set { this.kodArtikla = value; }
        }
        public int Kolicina
        {
            get { return this.kolicina; }
            set { this.kolicina = value; }
        }

        public int Popust
        {
            get { return this.popust; }
            set { this.popust = value; }
        }

        public override string ToString()
        {
            if(this.Ime.Length < 10)
                return this.kodArtikla + "\t" + this.ime + "\t\t" + this.cijena + "\t" + this.kolicina + "\t" + this.popust + "%\t" + (this.cijena - ((double)this.popust/100)*this.cijena)*this.kolicina; 

            else return this.kodArtikla + "\t" + this.ime + "\t" + this.cijena + "\t" + this.kolicina + "\t" + this.popust + "%\t" + (this.cijena - (double)(this.popust / 100) * this.cijena) * this.kolicina;
        }




    }
}
