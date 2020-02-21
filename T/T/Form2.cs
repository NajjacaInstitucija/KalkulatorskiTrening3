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
        public Form2(Color bc, Font f)
        {
            InitializeComponent();

            this.Font = f;
            this.BackColor = bc;
            textBox2.PasswordChar = '*';
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            toolTip1.SetToolTip(textBox1, "Ovdje upisujte username koji ste odabrali za sluzenje aplikacijom.");
            toolTip1.SetToolTip(textBox2, "Password ce biti prikriven iz sigurnosnih razloga.");
        }

        private void login_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(button1, "Obje kućice moraju biti ispunjene.");
                return;
            }

            errorProvider1.Clear();
            string pass = "";

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Username, Password, IsManager from Zaposlenici where Username = @Username";
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            //cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Connection = connection2;

            connection2.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            bool kontrola = false;
            string ime = "";
            if (reader.Read())
            {
                kontrola = true;
                if (reader.GetBoolean(2)) manager = true;

                ime = reader.GetString(0);
                pass = reader.GetString(1);

                
            }
            reader.Close();
            connection2.Close();
            
            
            if (kontrola)
            {

                if(textBox1.Text == "pero" || textBox1.Text == "nikola" || textBox1.Text == "josko")
                {
                    if(pass == textBox2.Text)
                    {
                        form1 = new Form1(manager, ime, this.BackColor, this.Font);
                        MessageBox.Show("Login uspješan za korisnika: " + ime, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        form1.Show();
                        this.Hide();
                    }

                    else
                    {
                        errorProvider1.SetError(textBox2, "Pogresan password ili username");
                        errorProvider1.SetError(textBox1, "Pogresan password ili username");
                    }

                }

                else if(Encrypt_Decrypt.decrypt(pass) == textBox2.Text)
                { 

                    form1 = new Form1(manager, ime, this.BackColor, this.Font);
                    MessageBox.Show("Login uspješan za korisnika: " + ime, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    form1.Show();
                    this.Hide();
                }

                else
                {
                    errorProvider1.SetError(textBox2, "Pogresan password ili username");
                    errorProvider1.SetError(textBox1, "Pogresan password ili username");
                }
                
            }

            else
            {
                errorProvider1.SetError(textBox2, "Pogresan password ili username");
                errorProvider1.SetError(textBox1, "Pogresan password ili username");
            }
        }

        private void registracija_Click(object sender, EventArgs e)
        {
            Form form6 = new Form6(this.BackColor, this.Font);
            form6.ShowDialog();
        }


        private void bojuToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }

        private void tb_MouseHover(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            string text = toolTip1.GetToolTip(tb);
            if (!string.IsNullOrEmpty(text))
                toolTip1.Show(text, tb, tb.PointToClient(new Point(Cursor.Position.X + 5, Cursor.Position.Y)));
        }
        private void tb_MouseLeave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            toolTip1.Hide(tb);
        }
    }
}