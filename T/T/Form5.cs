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
    public partial class Form5 : Form
    {
        OleDbConnection connection5 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\stvar\OneDrive\Desktop\T\T\Artikli.mdb");

        public Form5(Color bc, Font f)
        {
            InitializeComponent();

            this.BackColor = bc;
            this.Font = f;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

 

        private void Form5_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT RokUpotrebe, KodArtikla from Artikli order by RokUpotrebe";

            cmd.Connection = connection5;
            connection5.Open();

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                comboBox2.Items.Add(reader.GetString(0));
                comboBox1.Items.Add(reader.GetString(1));
            }

            reader.Close();
            connection5.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = "Po roku upotrebe:";

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Ime from Artikli where RokUpotrebe = @ru";
            cmd.Parameters.AddWithValue("@ru", comboBox2.GetItemText(comboBox2.SelectedItem));

            cmd.Connection = connection5;
            connection5.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                label2.Text = reader.GetString(0);

            reader.Close();
            connection5.Close();

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = "Po kodu artikla:";

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Ime from Artikli where KodArtikla = @ka";
            cmd.Parameters.AddWithValue("@ka", comboBox1.GetItemText(comboBox1.SelectedItem));

            cmd.Connection = connection5;
            connection5.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                label2.Text = reader.GetString(0);

            reader.Close();
            connection5.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(comboBox1.SelectedIndex < 0 && comboBox2.SelectedIndex < 0)
            {
                errorProvider1.SetError(button1, "Barem jedan od comboBoxeva treba biti označen.");
                return;
            }

            errorProvider1.Clear();

            string uvjet = label4.Text;

            DialogResult warning = MessageBox.Show("Ovim ćete ukloniti artikl iz ponude.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (warning == DialogResult.Yes)
            {

                if (uvjet == "Po kodu artikla:")
                {
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE * from Artikli where KodArtikla = @KodArtikla";
                    cmd.Parameters.AddWithValue("@KodArtikla", comboBox1.GetItemText(comboBox1.SelectedItem));

                    cmd.Connection = connection5;
                    connection5.Open();

                    cmd.ExecuteNonQuery();
                    connection5.Close();

                    DialogResult res = MessageBox.Show("Artikl uklonjen.", "Info", MessageBoxButtons.OK);


                    this.Hide();
                }

                else if (uvjet == "Po roku upotrebe:")
                {
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE * from Artikli where (RokUpotrebe = @RokUpotrebe and Ime = @Ime)";
                    cmd.Parameters.AddWithValue("@RokUpotrebe", comboBox2.GetItemText(comboBox2.SelectedItem));
                    cmd.Parameters.AddWithValue("@Ime", label2.Text);

                    cmd.Connection = connection5;
                    connection5.Open();

                    cmd.ExecuteNonQuery();
                    connection5.Close();

                    DialogResult res = MessageBox.Show("Artikl uklonjen.", "Info", MessageBoxButtons.OK);

                    this.Hide();
                }

                else MessageBox.Show("Morate odabrati nešto.", "Upozorenje", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                
            }

            else this.Hide();
        }

        private void zatvoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void Form5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }
    }
}
