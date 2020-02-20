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
using System.Security.Cryptography;

namespace T
{
    public partial class Form6 : Form
    {
        OleDbConnection connection6 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\stvar\OneDrive\Desktop\T\T\Zaposlenici.mdb");


        static string encryptPassword(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public Form6(Color bc, Font f)
        {
            InitializeComponent();

            this.BackColor = bc;
            this.Font = f;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ovdje obaviti provjeru postoji li taj username vec i poklapaju li se passwordovi

            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
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
            cmd.CommandText = "Select * from Zaposlenici";

            cmd.Connection = connection6;
            connection6.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            bool kont = false;
            while(reader.Read())
            {
               // MessageBox.Show(reader.GetString(1).ToString(), reader.GetBoolean(3).ToString());
                if(reader.GetString(1) == textBox1.Text)
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
                cmdInsert.CommandText = "INSERT INTO Zaposlenici (Username, Password, IsManager)" +
                    "VALUES (@Username, @Password, @IsManager)";

                cmdInsert.Parameters.AddWithValue("@Username", textBox1.Text);
                cmdInsert.Parameters.AddWithValue("@Password", encryptPassword(textBox2.Text));
                cmdInsert.Parameters.AddWithValue("@IsManager", checkBox1.CheckState);
                cmdInsert.Connection = connection6;


                connection6.Open();
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("A new member has been successfully added", "Hired", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connection6.Close();

                this.Hide();
                Form2 form2 = new Form2(this.BackColor, this.Font);
                form2.Show();

            }




            
        }

        private void zatvoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Form2 form2 = new Form2(this.BackColor, this.Font);
            form2.Show();
        }

        private void bojuPozadineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = fontDialog1.ShowDialog();
            if (res == DialogResult.OK)
                this.Font = fontDialog1.Font;
        }

        private void Form6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }
    }
}
