using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Windows.Markup;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BAZI;

    public partial class Form1 : Form
    {
        List<Person> Personlist1 = new List<Person>();
        List<Person> Personlist2 = new List<Person>();
        List<Person> Personlist3 = new List<Person>();
        List<BirthPlace> BirthPlaceList = new List<BirthPlace>();
        
        public Form1()
        {
            InitializeComponent();
            string conS = @"Data Source = LAPTOP-A7ELJVR8\SQLEXPRESS; Initial Catalog = FamilyTre; Integrated Security = True";
            SqlConnection connection = new SqlConnection(conS);
            connection.Open();

            MessageBox.Show("Соединение успешно");

            string command1 = "select *from People";
            SqlCommand cmd = new SqlCommand(command1, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {                   
                    string s1 = reader.GetValue(0).ToString();                   
                    string s2 = reader.GetValue(1).ToString();                    
                    string s3 = reader.GetValue(2).ToString();
                    string s4 = reader.GetValue(3).ToString();
                    string s5 = reader.GetValue(4).ToString();
                    string s6 = reader.GetValue(5).ToString();
                    Person p = new Person(int.Parse(s1), s2, s3, s4, s5, int.Parse(s6));
                    Personlist1.Add(p);
                    Personlist2.Add(p);
                    Personlist3.Add(p);

                }
            }
            reader.Close();

            comboBox2.DataSource = Personlist1;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";

            comboBox3.DataSource = Personlist2;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";

            comboBox4.DataSource = Personlist3;
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "Id";

            string command2 = "select *from BirthPlace";
            SqlCommand cmd2 = new SqlCommand(command2, connection);
            SqlDataReader reader1 = cmd2.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {                   
                    string s1 = reader1.GetValue(0).ToString();                    
                    string s2 = reader1.GetValue(1).ToString();
                    BirthPlace b = new BirthPlace(int.Parse(s1),s2);
                    BirthPlaceList.Add(b);
                }
            }
            reader1.Close();

            comboBox5.DataSource = BirthPlaceList;
            comboBox5.DisplayMember = "Name";
            comboBox5.ValueMember = "Id";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string conS = @"Data Source = LAPTOP-A7ELJVR8\SQLEXPRESS; Initial Catalog = FamilyTre; Integrated Security = True";
            SqlConnection connection = new SqlConnection(conS);
            connection.Open();

            

            if (comboBox1.SelectedIndex == 0)
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                dgvData.Columns.Add("ID", "id");
                dgvData.Columns.Add("Name", "Name");
                dgvData.Columns.Add("SurName", "Surname");
                dgvData.Columns.Add("Birthday", "Birthday");
                dgvData.Columns.Add("Deathday", "Deathday");
                dgvData.Columns.Add("Birthplace", "Birthplace");

                int i = 0;

                string command1 = "select *from People";
                SqlCommand cmd = new SqlCommand(command1, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvData.Rows.Add();
                        string s1 = reader.GetValue(0).ToString();
                        dgvData.Rows[i].Cells[0].Value = s1;
                        string s2 = reader.GetValue(1).ToString();
                        dgvData.Rows[i].Cells[1].Value = s2;
                        string s3 = reader.GetValue(2).ToString();
                        dgvData.Rows[i].Cells[2].Value = s3;
                        string s4 = reader.GetValue(3).ToString();
                        dgvData.Rows[i].Cells[3].Value = s4;
                        string s5 = reader.GetValue(4).ToString();
                        dgvData.Rows[i].Cells[4].Value = s5;
                        string s6 = reader.GetValue(5).ToString();
                        string n = BirthPlaceList[int.Parse(s6) - 1].Name; 
                        dgvData.Rows[i].Cells[5].Value = n;
                        i++;
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                dgvData.Columns.Add("ID", "id");
                dgvData.Columns.Add("Father", "Father");
                dgvData.Columns.Add("Mother", "Mother");
                dgvData.Columns.Add("Chidren", "Children");


                int i = 0;

                string command1 = "select *from Family";
                SqlCommand cmd = new SqlCommand(command1, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvData.Rows.Add();
                        string s1 = reader.GetValue(0).ToString();                        
                        dgvData.Rows[i].Cells[0].Value = s1;
                        string s2 = reader.GetValue(1).ToString();
                        string n2 = Personlist1[int.Parse(s2) - 1].Name;
                        dgvData.Rows[i].Cells[1].Value = n2;
                        string s3 = reader.GetValue(2).ToString();
                        string n3 = Personlist1[int.Parse(s3) - 1].Name;
                        dgvData.Rows[i].Cells[2].Value = n3;
                        string s4 = reader.GetValue(3).ToString();
                        string n4 = Personlist1[int.Parse(s4) - 1].Name;
                        dgvData.Rows[i].Cells[3].Value = n4;
                        i++;
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                dgvData.Columns.Add("ID", "id");
                dgvData.Columns.Add("Name", "Name");


                int i = 0;

                string command1 = "select *from BirthPlace";
                SqlCommand cmd = new SqlCommand(command1, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvData.Rows.Add();
                        string s1 = reader.GetValue(0).ToString();
                        dgvData.Rows[i].Cells[0].Value = s1;
                        string s2 = reader.GetValue(1).ToString();
                        dgvData.Rows[i].Cells[1].Value = s2;
                        i++;
                    }
                }
            }

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox2.SelectedValue.ToString());
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string conS = @"Data Source = LAPTOP-A7ELJVR8\SQLEXPRESS; Initial Catalog = FamilyTre; Integrated Security = True";
            SqlConnection connection = new SqlConnection(conS);
            connection.Open();

            int idFather = int.Parse(comboBox2.SelectedValue.ToString());
            int idMother = int.Parse(comboBox3.SelectedValue.ToString());
            int idChild = int.Parse(comboBox4.SelectedValue.ToString());


            string command1 = "insert into Family (idFather,idMother,idChildren) values ( '" + idFather + "','" + idMother + "','" + idChild + "' )";
            SqlCommand com1 = new SqlCommand(command1, connection);
            com1.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string conS = @"Data Source = LAPTOP-A7ELJVR8\SQLEXPRESS; Initial Catalog = FamilyTre; Integrated Security = True";
            SqlConnection connection = new SqlConnection(conS);
            connection.Open();

            string place = textBox1.Text;


            string command2 = "insert into BirthPlace values ( '" + place + "')";
            SqlCommand com2 = new SqlCommand(command2, connection);
            com2.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conS = @"Data Source = LAPTOP-A7ELJVR8\SQLEXPRESS; Initial Catalog = FamilyTre; Integrated Security = True";
            SqlConnection connection = new SqlConnection(conS);
            connection.Open();

            string Name = textBox2.Text;
            string Surname = textBox3.Text;
            string BirtDay = textBox4.Text;
            string DeathDay = textBox5.Text;
            int idBirthPlace = int.Parse(comboBox5.SelectedValue.ToString());

            string command3 = "insert into People (Name, Surname, Birthday, Deathday, idBirthPlace) values ('" + Name + "','" + Surname + "','" + BirtDay + "','" + DeathDay + "','" + idBirthPlace + "')";
            SqlCommand com3 = new SqlCommand(command3, connection);
            com3.ExecuteNonQuery();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string conS = @"Data Source = LAPTOP-A7ELJVR8\SQLEXPRESS; Initial Catalog = FamilyTre; Integrated Security = True";
            SqlConnection connection = new SqlConnection(conS);
            connection.Open();



            if (comboBox6.SelectedIndex == 0)
            {

                int? id = int.Parse(textBox6.Text);
                string command1 = "delete from People where id = '" + id + "'";                
                SqlCommand cmd = new SqlCommand(command1, connection);
                cmd.ExecuteNonQuery();

            }
            else if (comboBox6.SelectedIndex == 2)
            {
                int? id = int.Parse(textBox6.Text);
                string command1 = "delete from Family where id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(command1, connection);
                cmd.ExecuteNonQuery();

            }
            else if (comboBox6.SelectedIndex == 1)
            {
                int? id = int.Parse(textBox6.Text);
                string command1 = "delete from BirthPlace where id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(command1, connection);
                cmd.ExecuteNonQuery();

            }
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Deathday { get; set; }
        public int idBirthPlace { get; set; }

        public Person (int id,string name,string surname,string birthday,string deathday,int idbirthplace)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Deathday = deathday;
            idBirthPlace = idbirthplace;
        }
    }
    class BirthPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BirthPlace (int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
