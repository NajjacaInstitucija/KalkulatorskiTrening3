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
        public Form3(Color bc, Font f)
        {
            InitializeComponent();

            this.BackColor = bc;
            this.Font = f;
            textBox5.Text = DateTime.Now.ToShortDateString();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            toolTip1.SetToolTip(cijenaTB, "Cijena mora biti tipa double");
            toolTip1.SetToolTip(popustTB, "Popust mora biti tipa int");
            toolTip1.SetToolTip(textBox5, "Datum mora biti u prikladnom formatu");

        }

        private void Spremi_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(imeTB.Text) || string.IsNullOrEmpty(cijenaTB.Text) || string.IsNullOrEmpty(kategorijaTB.Text) ||
                string.IsNullOrEmpty(popustTB.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(kodArtiklaTB.Text))
            {
                
                errorProvider1.SetError(Spremi, "Jedno od polja je prazno");
                return;
            }

            int res;
            if(!Int32.TryParse(popustTB.Text, out res))
            {
                errorProvider1.SetError(popustTB, "Popust mora biti tipa int.");
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


                cmd.Parameters.AddWithValue("@Ime", imeTB.Text);
                cmd.Parameters.AddWithValue("@Cijena", cijenaTB.Text);
                cmd.Parameters.AddWithValue("@kat", kategorijaTB.Text);
                cmd.Parameters.AddWithValue("@ru", rokUpotrebeDP.Text);
                cmd.Parameters.AddWithValue("@dn", textBox5.Text);
                cmd.Parameters.AddWithValue("@ka", kodArtiklaTB.Text);
                cmd.Parameters.AddWithValue("@p", popustTB.Text);


                cmd.Connection = connection3;
                connection3.Open();
                cmd.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("An Item has been successfully added", "Poruka", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                connection3.Close();

                if (result == DialogResult.OK)
                    this.Hide();
                // zatvori formu 3
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

        private void Form3_MouseClick(object sender, MouseEventArgs e)
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

        private void kategorija_MouseHover(object sender, EventArgs e)
        {
            string kategorijeString = "Dosadasnje kategorije: ";
            List<string> kategorije = new List<string>();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Kategorija from Artikli";

            cmd.Connection = connection3;
            connection3.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (!kategorije.Contains(reader.GetString(0)))
                    kategorije.Add(reader.GetString(0));
            }
            reader.Close();
            connection3.Close();

            int i = 0;
            foreach (string k in kategorije)
            {
                if (i < (kategorije.Count-1))
                    kategorijeString += (k + ", ");

                else
                    kategorijeString += (k + ".");

                i++;
                
            }

            toolTip1.SetToolTip(kategorijaTB, kategorijeString);

        }
    }
}
