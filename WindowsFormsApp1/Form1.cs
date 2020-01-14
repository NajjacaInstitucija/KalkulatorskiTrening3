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

        List<Student> studenti = new List<Student>();

        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Documents\Database1.mdb");
        OleDbConnection connStudent = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\student\Documents\Database2.mdb");
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
            // TODO: This line of code loads data into the 'database2DataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.database2DataSet.Student);
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

            OleDbCommand commandStudent = new OleDbCommand("SELECT Ime, Prezime from Student", connStudent);
            connStudent.Open();
            OleDbDataReader studentReader = commandStudent.ExecuteReader();

            while(studentReader.Read())
            {
                if (!comboBox2.Items.Contains(studentReader.GetString(0) + " " + studentReader.GetString(1)))
                    comboBox2.Items.Add(studentReader.GetString(0) + " " + studentReader.GetString(1));
            }

            studentReader.Close();
            connStudent.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                comboBox2.Items.Add(textBox3.Text + " " + textBox4.Text);

                Student s = new Student(textBox3.Text, textBox4.Text);
                studenti.Add(s);

                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Student (Ime, Prezime)" + "VALUES (@Ime, @Prezime)";
                cmd.Parameters.AddWithValue("@Ime", s.Ime);
                cmd.Parameters.AddWithValue("@Kolegij", s.Prezime);

                cmd.Connection = connStudent;
                connStudent.Open();

                cmd.ExecuteNonQuery();
                connStudent.Close();

                this.studentTableAdapter.Fill(this.database2DataSet.Student);


            }

            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();
            string student = comboBox2.Text;
            // TREEVIEW

            treeView1.BeginUpdate();

            //Dictionary<string, List<string>>.KeyCollection profesori = profesoriIKolegiji.Keys;
            int i = 0;
            foreach (KeyValuePair<string, List<string>> kvp in profesoriIKolegiji)
            {
                treeView1.Nodes.Add(kvp.Key);
                foreach(string kolegij in kvp.Value)
                {
                    treeView1.Nodes[i].Nodes.Add(kolegij);
                }
                i++;
                
            }
            treeView1.EndUpdate();
        }
    }


    class Student
    {
        string ime;
        string prezime;

        public Student(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }

        public string Ime
        {
            get { return this.ime; }
            set { this.ime = value; }
        }

        public string Prezime
        {
            get { return this.prezime; }
            set { this.prezime = value; }
        }
    }

}
