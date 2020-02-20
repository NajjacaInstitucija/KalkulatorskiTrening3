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

        //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Desktop\T\T\Artikli.mdb");
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\stvar\OneDrive\Desktop\T\T\Artikli.mdb");

        public bool manager = false;
        public string imePosluzitelja;

        List<Artikl> racun = new List<Artikl>();
        Dictionary<string, int> najtrazenijiArtikli = new Dictionary<string, int>();
        int ukupanBrojIzadnihRacuna, ukupanBrojProdanihArtikala;
        double ukupnaZarada, prosječanIznosRacuna;
        int najtrazenijiArtiklKolicina;
        string najtrazenijiArtiklIme;
        public Form1(bool isManager, string ime, Color bc, Font f)
        {
            InitializeComponent();
            manager = isManager;
            imePosluzitelja = ime;
            this.Font = f;
            this.BackColor = bc;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            toolStripStatusLabel6.Text = "Trenutni poslužitelj: " + imePosluzitelja;

            if(!manager)
            {
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                upravljanjeToolStripMenuItem.Visible = false;
                dodajNoviArtiklToolStripMenuItem.Visible = false;
                izbaciArtiklIzPonudeToolStripMenuItem.Visible = false;
                promijeniPopustToolStripMenuItem.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'artikliDataSet2.Artikli' table. You can move, or remove it, as needed.
            this.artikliTableAdapter.Fill(this.artikliDataSet2.Artikli);

            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Kategorija from Artikli";

            cmd.Connection = connection;

            connection.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                if(!comboBox1.Items.Contains(reader[0].ToString()))
                comboBox1.Items.Add(reader[0].ToString());
            }
            reader.Close();
            connection.Close();
            


        }

        private void promjenaUpisaImenaArtikla_TextChanged(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();

            if (!string.IsNullOrEmpty(textBox1.Text))
            {

                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Ime from Artikli where Ime like '" + textBox1.Text + "%' or Ime like '% " + textBox1.Text + "%'" ;
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



        private void promjenaOznacenogArtikla_SelectedIndexChanged(object sender, EventArgs e)
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
        private void provjeraKoda_Click(object sender, EventArgs e)
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

        //dodavanje artikla u kosaricu
        private void dodajNaRacun_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
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

                    if (racun.Contains(artikl))
                    {
                        for (int i = 0; i < racun.Count; ++i)
                            if (racun[i].CompareTo(artikl) == 0)
                                racun[i] += artikl;


                    }

                    else
                    {
                        DateTime t1 = DateTime.Parse(artikl.RokUpotrebe);
                        DateTime t2 = DateTime.Parse("20.3.2020");
                        if (t1 < t2)
                        {
                            DialogResult res = MessageBox.Show("Odabranom artiklu uskoro istice rok trajanja! Jeste li sigurni da ga želite dodati u košaricu?",
                              "Upozorenje", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                            if (res == DialogResult.Yes) racun.Add(artikl);
                        }



                        else
                        racun.Add(artikl); 
                    }
                    
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
        private void makniSRacuna_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Želite li sigurno maknuti označeni artikl?", "Brisanje artikla s računa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (res == DialogResult.Yes)
            {
                

               /* foreach (Artikl a in racun)
                    if (a.ToString() == listBox2.GetItemText(listBox2.SelectedItem))
                        racun.Remove(a);*/

                racun.RemoveAt(listBox2.SelectedIndex-2);
                //listBox2.Items.Remove(listBox2.SelectedItem);
            }

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

        // ispis racuna
        private void izradiRacun_Click(object sender, EventArgs e)
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
            text += "Ukupno: \t";
            text += ukupno + " kn";

            text += Environment.NewLine;
            text += Environment.NewLine;
            text += "Ime poslužitelja: " + imePosluzitelja;


            DialogResult res = MessageBox.Show(text, "Trgovina", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if(res == DialogResult.OK)
            {
                //ispisi racun

                ukupanBrojIzadnihRacuna++;
                ukupnaZarada += ukupno;

                foreach (Artikl a in racun)
                {
                    ukupanBrojProdanihArtikala += a.Kolicina;
                    if (najtrazenijiArtikli.ContainsKey(a.Ime))
                     najtrazenijiArtikli[a.Ime] += a.Kolicina;

                    else
                     najtrazenijiArtikli.Add(a.Ime, a.Kolicina);
                    
                    
                }

                prosječanIznosRacuna = ukupnaZarada / ukupanBrojIzadnihRacuna;

                 najtrazenijiArtiklKolicina = najtrazenijiArtikli.Values.Max();
                 najtrazenijiArtiklIme = najtrazenijiArtikli.Aggregate(
                    (imeArtikla, imeNajtrazenijegArtikla) =>
                    imeArtikla.Value > imeNajtrazenijegArtikla.Value ? imeArtikla : imeNajtrazenijegArtikla).Key;



                toolStripStatusLabel1.Text = "Ukupan broj izdanih računa: " + ukupanBrojIzadnihRacuna.ToString();
                toolStripStatusLabel2.Text = "Ukupan broj prodanih artikala: " + ukupanBrojProdanihArtikala.ToString();
                toolStripStatusLabel3.Text = "Najtraženiji artikl: " + najtrazenijiArtiklIme + "(" + najtrazenijiArtiklKolicina.ToString() + ")";
                toolStripStatusLabel4.Text = "Ukupna zarada: " + ukupnaZarada.ToString();
                toolStripStatusLabel5.Text = "Prosječan iznos računa: " + prosječanIznosRacuna.ToString();


                listBox2.Items.Clear();
                listBox1.Items.Clear();
                racun.Clear();
            }





        }

        private void dodajArtikl_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this.BackColor, this.Font);
            form3.ShowDialog();
        }

        private void promijeniPopust_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(this.BackColor, this.Font);
            form4.ShowDialog();

        }

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 1;

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Ime from Artikli where Kategorija = @kat";
            cmd.Parameters.AddWithValue("@kat", comboBox1.GetItemText(comboBox1.SelectedItem));

            cmd.Connection = connection;
            connection.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                listBox1.Items.Add(reader.GetString(0));
            }
            reader.Close();
            connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //postaviti progressbar na 21600 = 6 sati
            if (toolStripProgressBar1.Value != toolStripProgressBar1.Maximum)
                toolStripProgressBar1.Value++;


            else
            {
                Form2 form2 = new Form2(this.BackColor, this.Font);

                timer1.Stop();
                toolStripProgressBar1.Value = 0;
                //ovdje ispis svih vrijednosti iz status stripa prilikom odjave i resetirat ih

                string ispis = "";
                ispis += "Broj izdanih računa: " + ukupanBrojIzadnihRacuna + Environment.NewLine;
                ispis += "Broj prodanih artikala: " + ukupanBrojProdanihArtikala + Environment.NewLine;
                ispis += "Najtraženiji artikl: " + najtrazenijiArtiklIme + ", u količini: " + najtrazenijiArtiklKolicina + Environment.NewLine;
                ispis += "Ukupno zarađeno: " + ukupnaZarada + Environment.NewLine;
                ispis += "Prosječan iznos računa: " + prosječanIznosRacuna + Environment.NewLine;

                ukupanBrojIzadnihRacuna = 0;
                ukupanBrojProdanihArtikala = 0;
                ukupnaZarada = 0;
                prosječanIznosRacuna = 0;
                najtrazenijiArtiklKolicina = 0;
                najtrazenijiArtiklIme = "";
                racun.Clear();
                najtrazenijiArtikli.Clear();

                MessageBox.Show(ispis, "Info o sesiji", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                form2.ShowDialog();
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }

        private void gotovinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            if (!radioButton1.Checked)
                radioButton1.Checked = true;
        }

        private void cekoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            if (!radioButton2.Checked)
                radioButton2.Checked = true;
        }

        private void karticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            radioButton1.Checked = false;
            radioButton4.Checked = false;
            if (!radioButton3.Checked)
                radioButton3.Checked = true;
        }

        private void bonoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton1.Checked = false;
            if (!radioButton4.Checked)
                radioButton4.Checked = true;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = fontDialog1.ShowDialog();
            if (res == DialogResult.OK)
                this.Font = fontDialog1.Font;
        }

        private void bojaPozadineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
        }

        private void izbrisiArtikl_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(this.BackColor, this.Font);
            form5.ShowDialog();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this.BackColor, this.Font);

            timer1.Stop();
            toolStripProgressBar1.Value = 0;
            //ovdje ispis svih vrijednosti iz status stripa prilikom odjave i resetirat ih

            string ispis = "";
            ispis += "Broj izdanih računa: " + ukupanBrojIzadnihRacuna + Environment.NewLine;
            ispis += "Broj prodanih artikala: " + ukupanBrojProdanihArtikala + Environment.NewLine;
            ispis += "Najtraženiji artikl: " + najtrazenijiArtiklIme + ", u količini: " + najtrazenijiArtiklKolicina + Environment.NewLine;
            ispis += "Ukupno zarađeno: " + ukupnaZarada  + Environment.NewLine;
            ispis += "Prosječan iznos računa: " + prosječanIznosRacuna  + Environment.NewLine;

            MessageBox.Show(ispis, "Info o sesiji", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            form2.ShowDialog();

        }

        
    }

    public class Artikl : IComparable<Artikl>, IEquatable<Artikl>
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

        public int CompareTo(Artikl other)
        {
            return this.kodArtikla.CompareTo(other.kodArtikla);
        }

        public override bool Equals(object obj)
        {
            Artikl isArtikl = obj as Artikl;
            if (isArtikl == null) return false;
            
            return this.kodArtikla.Equals(isArtikl.kodArtikla);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public static Artikl operator +(Artikl a1, Artikl a2)
        {
            if(a1.Equals(a2))
            {
                a1.kolicina += a2.kolicina;
            }

            return a1;
        }

        public override string ToString()
        {
            if(this.Ime.Length < 10)
                return this.kodArtikla + "\t" + this.ime + "\t\t" + this.cijena + "\t" + this.kolicina + "\t" + this.popust + "%\t" + (this.cijena - ((double)this.popust/100)*this.cijena)*this.kolicina; 

            else return this.kodArtikla + "\t" + this.ime + "\t" + this.cijena + "\t" + this.kolicina + "\t" + this.popust + "%\t" + (this.cijena - ((double)this.popust / 100) * this.cijena) * this.kolicina;
        }

        public bool Equals(Artikl other)
        {
            return this.kodArtikla == other.KodArtikla;
        }
    }
}
