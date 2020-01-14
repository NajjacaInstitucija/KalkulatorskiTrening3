using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> profesoriIKolegiji = new Dictionary<string, List<string>>();

        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Documents\Database1.mdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
                listBox1.Items.Add(textBox1.Text);

            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                comboBox1.Items.Add(textBox2.Text);
                profesoriIKolegiji.Add(textBox2.Text, new List<string>());
            }

            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(string selectedItem in listBox1.SelectedItems)
            {
                profesoriIKolegiji[comboBox1.Text].Add(selectedItem);

                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO profesoriIKolegiji (Ime, Kolegij)" + "VALUES (@Ime, @Kolegij)";
                cmd.Parameters.AddWithValue("@Ime", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Kolegij", selectedItem);

                cmd.Connection = connection;
                connection.Open();

                cmd.ExecuteNonQuery();
                connection.Close();

                profesoriIKolegijiTableAdapter.Fill(this.database1DataSet.profesoriIKolegiji);


            }

            listBox2.Items.Clear();
            foreach (string kolegij in profesoriIKolegiji[comboBox1.Text])
            {
                listBox2.Items.Add(kolegij);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (string kolegij in profesoriIKolegiji[comboBox1.Text])
            {
                listBox2.Items.Add(kolegij);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.profesoriIKolegiji' table. You can move, or remove it, as needed.
            this.profesoriIKolegijiTableAdapter.Fill(this.database1DataSet.profesoriIKolegiji);

           

            OleDbCommand command = new OleDbCommand("SELECT DISTINCT Ime, Kolegij from profesoriIKolegiji", connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if(!comboBox1.Items.Contains(reader[0].ToString()))
                    comboBox1.Items.Add(reader[0].ToString());

                if (!listBox1.Items.Contains(reader[1].ToString()))
                    listBox1.Items.Add(reader[1].ToString());

                if (profesoriIKolegiji.ContainsKey(reader[0].ToString()))
                    profesoriIKolegiji[reader[0].ToString()].Add(reader[1].ToString());

                else
                {
                    List<string> novaLista = new List<string>();
                    novaLista.Add(reader[1].ToString());
                    profesoriIKolegiji.Add(reader[0].ToString(), novaLista);
                }
            }
            reader.Close();
            connection.Close();

            


        }
    }
}
