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
    public partial class Form2 : Form
    {
        //"C:\Users\stvar\OneDrive\Desktop\T\T"
        OleDbConnection connection2 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\stvar\OneDrive\Desktop\T\T\Zaposlenici.mdb");

        public Form1 form1;
        public bool manager = false;
        public Form2()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "" || textBox2.Text == "")
            {
                errorProvider1.SetError(button1, "Obje kućice moraju biti ispunjene.");
                return;
            }

            errorProvider1.Clear();

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Username, Password, IsManager from Zaposlenici where Username = @Username and Password = @Password";
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Connection = connection2;

            connection2.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            bool kontrola = false;
            string ime = "";
            while (reader.Read())
            {
                kontrola = true;
                if (reader.GetBoolean(2)) manager = true;

                ime = reader.GetString(0);
                
            }
            reader.Close();
            connection2.Close();
            
            form1 = new Form1(manager, ime);
            if (kontrola)
            {
                form1.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form6 = new Form6();
            form6.ShowDialog();
        }
    }
}
