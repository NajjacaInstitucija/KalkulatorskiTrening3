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
    public partial class Form4 : Form
    {
        //OleDbConnection connection4 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Desktop\T\T\Artikli.mdb");
        OleDbConnection connection4 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\stvar\OneDrive\Desktop\T\T\Artikli.mdb");

        string item = "Prazno";

        public Form4()
        {
            InitializeComponent();

            listBox1.Items.Clear();

            

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT KodArtikla from Artikli";

            cmd.Connection = connection4;
            connection4.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader.GetString(0));
            }
                reader.Close();
                connection4.Close();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Ime from Artikli where KodArtikla = @KodArtikla"; 
            cmd.Parameters.AddWithValue("@KodArtikla", listBox1.GetItemText(listBox1.SelectedItem));
            cmd.Connection = connection4;
            connection4.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                item = reader.GetString(0);
            }
            reader.Close();
            connection4.Close();
            label2.Text = item;
            //label2.Text = listBox1.SelectedIndex.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult uvjet = MessageBox.Show("Primjena popusta će utjecati na stanje u dućanu", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (uvjet == DialogResult.Yes)
            {

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Artikli set Popust = @Popust where KodArtikla = @KodArtikla";

                cmd.Parameters.AddWithValue("@Popust", Convert.ToInt32(numericUpDown1.Value));
                cmd.Parameters.AddWithValue("@KodArtikla", listBox1.GetItemText(listBox1.SelectedItem));


                cmd.Connection = connection4;
                connection4.Open();
                cmd.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("Popust promijenjen.", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                connection4.Close();

                if (result == DialogResult.OK)
                    this.Close();

            }

            else this.Close();

        }
    }
}
