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
    public partial class Entrance : Form
    {
        public Entrance()
        {
            InitializeComponent();
        }


         // Нажатие на кнопку "Регистрация"
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 registry = new Form1();
            registry.ShowDialog();
            this.Hide();
        }

        private void entranceBut_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;" +
                    "Database=vgtubug");
                string query = "select status from login_password where password=@password and login=@login";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@login", textBox1.Text);
                con.Open();
                string status = (string)cmd.ExecuteScalar();
                con.Close();

                if (status == "Абитуриент")
                {
                    Abiturient abiturient = new Abiturient(textBox1.Text, textBox2.Text);
                    abiturient.ShowDialog();
                    this.Hide();
                }
                if(status=="Администратор")
                {
                    Administrator administrator = new Administrator();
                    administrator.ShowDialog();
                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
