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
    public partial class Form6 : Form
    {
        OleDbConnection connection6 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\stvar\OneDrive\Desktop\T\T\Zaposlenici.mdb");

        public Form6()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ovdje obaviti provjeru postoji li taj username vec i poklapaju li se passwordovi
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                errorProvider1.SetError(button1, "Sva polja moraju biti popunjena");
                return;
            }

            errorProvider1.Clear();
            if(textBox2.Text.CompareTo(textBox3.Text) != 0)
            {
                errorProvider1.SetError(textBox3, "Password se ne poklapa.");
                return;
            }

            errorProvider1.Clear();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Username from Zaposlenici";

            cmd.Connection = connection6;
            connection6.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            bool kont = false;
            while(reader.Read())
            {
                if(reader.GetString(0) == textBox1.Text)
                {
                    kont = true;
                    errorProvider1.SetError(textBox1, "User već postoji");
                    break;
                }
            }
            reader.Close();
            connection6.Close();
            
            if(kont) return;
            
            else
            {
                OleDbCommand cmdInsert = new OleDbCommand();
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "INSERT INTO Zaposlenici (Username, Password, IsManager) " +
                    "VALUES (@Username, @Password, @IsManager)";

                cmdInsert.Parameters.AddWithValue("@Username", textBox1.Text);
                cmdInsert.Parameters.AddWithValue("@Password", textBox2.Text);
                cmdInsert.Parameters.AddWithValue("@IsManager", checkBox1.Checked);
                cmdInsert.Connection = connection6;

                connection6.Open();
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("A new member has been successfully added", "Hired", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connection6.Close();

                this.Close();
                Form2 form2 = new Form2();
                form2.Show();

            }




            
        }
    }
}
