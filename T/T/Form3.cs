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
        OleDbConnection connection3 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Desktop\T\T\Artikli.mdb");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //spremanje u bazu
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Artikli (Ime, Cijena, Kategorija, RokUpotrebe, DatumNabave, KodArtikla, Popust)" + 
                "VALUES (@Ime, @Cijena, @kat, @ru, @dn, @ka, @p)";


            cmd.Parameters.AddWithValue("@Ime", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cijena", Convert.ToDouble(textBox2.Text));
            cmd.Parameters.AddWithValue("@kat", textBox3.Text);
            cmd.Parameters.AddWithValue("@p", textBox4.Text);
            cmd.Parameters.AddWithValue("@dn", Convert.ToDateTime(textBox5.Text));
            cmd.Parameters.AddWithValue("@ka", textBox6.Text);
            cmd.Parameters.AddWithValue("@ru", Convert.ToDateTime(dateTimePicker1.Text));

            cmd.Connection = connection3;
            connection3.Open();
            cmd.ExecuteNonQuery();
            DialogResult result = MessageBox.Show("An Item has been successfully added", "Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            connection3.Close();

            if(result == DialogResult.OK)
            this.Hide();
            // zatvori formu 3
        }
    }
}
