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
            cmd.CommandText = "SELECT RokUpotrebe, KodArtikla from Artikli";

            cmd.Connection = connection5;
            connection5.Open();

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                poRokuUpotrebeCB.Items.Add(reader.GetString(0));
                poKoduArtiklaCB.Items.Add(reader.GetString(1));
            }

            reader.Close();
            connection5.Close();

        }

        private void PoRokuUpotrebe_SelectedIndexChanged(object sender, EventArgs e)
        {
            kriterijLabel.Text = "Po roku upotrebe:";

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Ime from Artikli where RokUpotrebe = @ru";
            cmd.Parameters.AddWithValue("@ru", poRokuUpotrebeCB.GetItemText(poRokuUpotrebeCB.SelectedItem));

            cmd.Connection = connection5;
            connection5.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                imeOdabranogArtiklaLabel.Text = reader.GetString(0);

            reader.Close();
            connection5.Close();

           
        }

        private void PoKoduArtikla_SelectedIndexChanged(object sender, EventArgs e)
        {
            kriterijLabel.Text = "Po kodu artikla:";

            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Ime from Artikli where KodArtikla = @ka";
            cmd.Parameters.AddWithValue("@ka", poKoduArtiklaCB.GetItemText(poKoduArtiklaCB.SelectedItem));

            cmd.Connection = connection5;
            connection5.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                imeOdabranogArtiklaLabel.Text = reader.GetString(0);

            reader.Close();
            connection5.Close();
        }

        private void Apply_Click(object sender, EventArgs e)
        {

            if(poKoduArtiklaCB.SelectedIndex < 0 && poRokuUpotrebeCB.SelectedIndex < 0)
            {
                errorProvider1.SetError(Apply, "Barem jedan od comboBoxeva treba biti označen.");
                return;
            }

            errorProvider1.Clear();

            string uvjet = kriterijLabel.Text;

            DialogResult warning = MessageBox.Show("Ovim ćete ukloniti artikl iz ponude.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (warning == DialogResult.Yes)
            {

                if (uvjet == "Po kodu artikla:")
                {
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE * from Artikli where KodArtikla = @KodArtikla";
                    cmd.Parameters.AddWithValue("@KodArtikla", poKoduArtiklaCB.GetItemText(poKoduArtiklaCB.SelectedItem));

                    cmd.Connection = connection5;
                    connection5.Open();

                    cmd.ExecuteNonQuery();
                    connection5.Close();

                    MessageBox.Show("Artikl uklonjen.", "Info", MessageBoxButtons.OK);


                    this.Hide();
                }

                else if (uvjet == "Po roku upotrebe:")
                {
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE * from Artikli where (RokUpotrebe = @RokUpotrebe and Ime = @Ime)";
                    cmd.Parameters.AddWithValue("@RokUpotrebe", poRokuUpotrebeCB.GetItemText(poRokuUpotrebeCB.SelectedItem));
                    cmd.Parameters.AddWithValue("@Ime", imeOdabranogArtiklaLabel.Text);

                    cmd.Connection = connection5;
                    connection5.Open();

                    cmd.ExecuteNonQuery();
                    connection5.Close();

                    MessageBox.Show("Artikl uklonjen.", "Info", MessageBoxButtons.OK);

                    this.Hide();
                }

                else MessageBox.Show("Morate odabrati nešto.", "Upozorenje", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                
            }

            else this.Hide();
        }

        private void ZatvoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void BojuPozadineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
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
