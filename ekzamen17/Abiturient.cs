using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ekz
{
    public partial class Abiturient : Form
    {
        public string login;
        public string password;
        public string surname;
        public string name;
        public string patronymic;
        
        public Abiturient(string login, string password)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Abiturient_Load(object sender, EventArgs e)
        {

            try
            {
                NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query = "select id from login_password where login=@login and password=@password";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                connect.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                connect.Close();

                NpgsqlConnection contact = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query2 = "select surname from data_ab where id=@id";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, contact);
                cmd2.Parameters.AddWithValue("@id", id);
                contact.Open();
                surname = cmd2.ExecuteScalar().ToString();
                contact.Close();

                NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query3 = "select name from data_ab where id=@id";
                NpgsqlCommand cmd3 = new NpgsqlCommand(query3, con);
                cmd3.Parameters.AddWithValue("@id", id);
                con.Open();
                name = cmd3.ExecuteScalar().ToString();
                con.Close();

                NpgsqlConnection connaction = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query4 = "select patronymic from data_ab where id=@id";
                NpgsqlCommand cmd4 = new NpgsqlCommand(query4, connaction);
                cmd4.Parameters.AddWithValue("@id", id);
                connaction.Open();
                patronymic = cmd4.ExecuteScalar().ToString();
                connaction.Close();

                label2.Text = surname + " " + name + " " + patronymic;

                NpgsqlConnection connecting = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query5 = "select status from status_letter where id=@id";
                NpgsqlCommand cmd5 = new NpgsqlCommand(query5, connecting);
                cmd5.Parameters.AddWithValue("@id", id);
                connecting.Open();
                status.Text = cmd5.ExecuteScalar().ToString();
                connecting.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
