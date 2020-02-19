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
    public partial class Form3 : Form
    {
        OleDbConnection connection3 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\stvar\OneDrive\Desktop\T\T\Artikli.mdb");

        //OleDbConnection connection3 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Desktop\T\T\Artikli.mdb");
        public Form3()
        {
            InitializeComponent();
            textBox5.Text = DateTime.Now.ToShortDateString();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" )
            {
                
                errorProvider1.SetError(button1, "Jedno od polja je prazno");
                return;
            }

            int res;
            if(!Int32.TryParse(textBox4.Text, out res))
            {
                errorProvider1.SetError(textBox4, "Popust mora biti tipa int.");
                return;
            }
            //spremanje u bazu
            errorProvider1.Clear();
            DialogResult uvjet = MessageBox.Show("Ubacivanje tog artikla će utjecati na stanje u dućanu!", "Insert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (uvjet == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Artikli (Ime, Cijena, Kategorija, RokUpotrebe, DatumNabave, KodArtikla, Popust)" +
                    "VALUES (@Ime, @Cijena, @kat, @ru, @dn, @ka, @p)";


                cmd.Parameters.AddWithValue("@Ime", textBox1.Text);
                cmd.Parameters.AddWithValue("@Cijena", textBox2.Text);
                cmd.Parameters.AddWithValue("@kat", textBox3.Text);
                cmd.Parameters.AddWithValue("@ru", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@dn", textBox5.Text);
                cmd.Parameters.AddWithValue("@ka", textBox6.Text);
                cmd.Parameters.AddWithValue("@p", textBox4.Text);


                cmd.Connection = connection3;
                connection3.Open();
                cmd.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("An Item has been successfully added", "Poruka", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                connection3.Close();

                if (result == DialogResult.OK)
                    this.Close();
                // zatvori formu 3
            }

            else this.Close();
        }
    }
}
