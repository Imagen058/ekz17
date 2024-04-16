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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }
        int status ;
        private void Administrator_Load(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query = "select * from data_abiturient";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connect);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "Идентификатор";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Уровень образования";
                dataGridView1.Columns[5].HeaderText = "Баллы ЕГЭ, средний балл аттестата или диплома";
                dataGridView1.Columns[6].HeaderText = "СНИЛС";
                dataGridView1.Columns[7].HeaderText = "Серия";
                dataGridView1.Columns[8].HeaderText = "Номер паспорта";
                dataGridView1.Columns[9].HeaderText = "Дата выдачи";
                dataGridView1.Columns[10].HeaderText = "Кем выдан";
                dataGridView1.Columns[11].HeaderText = "Номер телефона";
                dataGridView1.Columns[12].HeaderText = "Электронная почта";
                dataGridView1.Columns[13].HeaderText = "Документ об образовании";
                dataGridView1.Columns[14].HeaderText = "Прописка";
                dataGridView1.Columns[15].HeaderText = "Учебное заведение, которое окончил абитуриент";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        // Нажатие на кнопку "Готово"
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query = "insert into status_letter (id,status,commentary) values(@id,@status,@commentary)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@id", status);
                cmd.Parameters.AddWithValue("@status", button1.Text);
                cmd.Parameters.AddWithValue("@commentary", textBox1.Text);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            status = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        // Нажатие на кнопку "В доработку"

        private void button2_Click(object sender, EventArgs e)
        {
            
            try{
               
            NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
            string query = "insert into status_letter(id,status,commentary) values(@id,@status,@commentary)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", status);
            cmd.Parameters.AddWithValue("@status", button2.Text);
            cmd.Parameters.AddWithValue("@commentary", textBox1.Text);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Редактирование списка направлений
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
    }

