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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        public string path;



        private void button3_Click(object sender, EventArgs e)
        {
            Print print = new Print(textBox19.Text, textBox20.Text, textBox21.Text,
                comboBox8.Text, comboBox9.Text, comboBox10.Text, comboBox11.Text, comboBox12.Text);
            print.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            path = file.FileName.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string query = "insert into data_ab(" +
                    "id, surname, name, patronymic,level_edu,coins_edu,snils,seria,number_pass,when_pass," +
                    "how_pass,phone,email,path_edu,address_pass,institut) values " +
                    "(@id, @surname, @name, @patronymic,@level_edu,@coins_edu,@snils,@seria,@number_pass," +
                    "@when_pass,@how_pass,@phone,@email,@path_edu,@address_pass,@institut)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox18.Text));
                cmd.Parameters.AddWithValue("@surname", textBox19.Text);
                cmd.Parameters.AddWithValue("@name", textBox20.Text);
                cmd.Parameters.AddWithValue("@patronymic", textBox21.Text);
                cmd.Parameters.AddWithValue("@level_edu", comboBox7.Text);
                cmd.Parameters.AddWithValue("@coins_edu", Convert.ToInt32(textBox22.Text));
                cmd.Parameters.AddWithValue("@snils", textBox23.Text);
                cmd.Parameters.AddWithValue("@seria", textBox33.Text);
                cmd.Parameters.AddWithValue("@number_pass", textBox24.Text);
                cmd.Parameters.AddWithValue("@when_pass", textBox25.Text);
                cmd.Parameters.AddWithValue("@how_pass", textBox26.Text);
                cmd.Parameters.AddWithValue("@phone", textBox27.Text);
                cmd.Parameters.AddWithValue("@email", textBox28.Text);
                cmd.Parameters.AddWithValue("@path_edu", path);
                cmd.Parameters.AddWithValue("@address_pass", textBox29.Text);
                cmd.Parameters.AddWithValue("@institut", textBox30.Text);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();

                NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=12345;Data=vgtubug");
                string sql = "insert into login_password(" +
                    "id, login, password, status) values " +
                    "(@id, @login, @password, @status)";
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.Parameters.AddWithValue("@id", Convert.ToInt32(textBox18.Text));
                command.Parameters.AddWithValue("@login", textBox31.Text);
                command.Parameters.AddWithValue("@password", textBox32.Text);
                command.Parameters.AddWithValue("@status", "Абитуриент");
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Abiturient abiturient = new Abiturient(textBox31.Text, textBox32.Text);
            abiturient.ShowDialog();
            this.Hide();
        }


        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "СПО")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.Add("Монтажник радиоэлектронной аппаратуры и приборов");
                comboBox8.Items.Add("Строительство и эксплуатация зданий и сооружений");
                comboBox8.Items.Add("Строительство и эксплуатация автомобильных дорог и аэродромов");
                comboBox8.Items.Add("Монтаж и эксплуатация оборудования и систем газоснабжения");
                comboBox8.Items.Add("Монтаж и эксплутация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции");
                comboBox8.Items.Add("Компьютерные системы и комплексы");
            }
            if (comboBox7.Text == "Бакалавриат")
            {
                comboBox8.Items.Add("Архитектура");
                comboBox8.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox8.Items.Add("Дизайн архитектурной среды");
                comboBox8.Items.Add("Градостроительство");
            }
            if (comboBox7.Text == "Специалитет")
            {
                comboBox8.Items.Add("Информационная безопасность телекоммуникационных систем");
                comboBox8.Items.Add("Радиоэлектронные системы и комплексы");
                comboBox8.Items.Add("Проектирование авиационных и ракетных двигателей");
                comboBox8.Items.Add("Самолёто- и вертолётостроение");
            }
            if (comboBox7.Text == "Магистратура")
            {
                comboBox8.Items.Add("Архитектура");
                comboBox8.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox8.Items.Add("Дизайн архитектурной среды");
            }
        }

        private void comboBox8_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "СПО")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.Add("Монтажник радиоэлектронной аппаратуры и приборов");
                comboBox8.Items.Add("Строительство и эксплуатация зданий и сооружений");
                comboBox8.Items.Add("Строительство и эксплуатация автомобильных дорог и аэродромов");
                comboBox8.Items.Add("Монтаж и эксплуатация оборудования и систем газоснабжения");
                comboBox8.Items.Add("Монтаж и эксплутация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции");
                comboBox8.Items.Add("Компьютерные системы и комплексы");
            }
            if (comboBox7.Text == "Бакалавриат")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.Add("Архитектура");
                comboBox8.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox8.Items.Add("Дизайн архитектурной среды");
                comboBox8.Items.Add("Градостроительство");
            }
            if (comboBox7.Text == "Специалитет")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.Add("Информационная безопасность телекоммуникационных систем");
                comboBox8.Items.Add("Радиоэлектронные системы и комплексы");
                comboBox8.Items.Add("Проектирование авиационных и ракетных двигателей");
                comboBox8.Items.Add("Самолёто- и вертолётостроение");
            }
            if (comboBox7.Text == "Магистратура")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.Add("Архитектура");
                comboBox8.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox8.Items.Add("Дизайн архитектурной среды");
            }
        }

        private void comboBox9_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "СПО")
            {
                comboBox9.Items.Clear();
                comboBox9.Items.Add("Монтажник радиоэлектронной аппаратуры и приборов");
                comboBox9.Items.Add("Строительство и эксплуатация зданий и сооружений");
                comboBox9.Items.Add("Строительство и эксплуатация автомобильных дорог и аэродромов");
                comboBox9.Items.Add("Монтаж и эксплуатация оборудования и систем газоснабжения");
                comboBox9.Items.Add("Монтаж и эксплутация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции");
                comboBox9.Items.Add("Компьютерные системы и комплексы");
            }
            if (comboBox7.Text == "Бакалавриат")
            {
                comboBox9.Items.Clear();
                comboBox9.Items.Add("Архитектура");
                comboBox9.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox9.Items.Add("Дизайн архитектурной среды");
                comboBox9.Items.Add("Градостроительство");
            }
            if (comboBox7.Text == "Специалитет")
            {
                comboBox9.Items.Clear();
                comboBox9.Items.Add("Информационная безопасность телекоммуникационных систем");
                comboBox9.Items.Add("Радиоэлектронные системы и комплексы");
                comboBox9.Items.Add("Проектирование авиационных и ракетных двигателей");
                comboBox9.Items.Add("Самолёто- и вертолётостроение");
            }
            if (comboBox7.Text == "Магистратура")
            {
                comboBox9.Items.Clear();
                comboBox9.Items.Add("Архитектура");
                comboBox9.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox9.Items.Add("Дизайн архитектурной среды");
            }
        }

        private void comboBox10_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "СПО")
            {
                comboBox10.Items.Clear();
                comboBox10.Items.Add("Монтажник радиоэлектронной аппаратуры и приборов");
                comboBox10.Items.Add("Строительство и эксплуатация зданий и сооружений");
                comboBox10.Items.Add("Строительство и эксплуатация автомобильных дорог и аэродромов");
                comboBox10.Items.Add("Монтаж и эксплуатация оборудования и систем газоснабжения");
                comboBox10.Items.Add("Монтаж и эксплутация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции");
                comboBox10.Items.Add("Компьютерные системы и комплексы");
            }
            if (comboBox7.Text == "Бакалавриат")
            {
                comboBox10.Items.Clear();
                comboBox10.Items.Add("Архитектура");
                comboBox10.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox10.Items.Add("Дизайн архитектурной среды");
                comboBox10.Items.Add("Градостроительство");
            }
            if (comboBox7.Text == "Специалитет")
            {
                comboBox10.Items.Clear();
                comboBox10.Items.Add("Информационная безопасность телекоммуникационных систем");
                comboBox10.Items.Add("Радиоэлектронные системы и комплексы");
                comboBox10.Items.Add("Проектирование авиационных и ракетных двигателей");
                comboBox10.Items.Add("Самолёто- и вертолётостроение");
            }
            if (comboBox7.Text == "Магистратура")
            {
                comboBox10.Items.Clear();
                comboBox10.Items.Add("Архитектура");
                comboBox10.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox10.Items.Add("Дизайн архитектурной среды");
            }
        }

        private void comboBox11_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "СПО")
            {
                comboBox11.Items.Clear();
                comboBox11.Items.Add("Монтажник радиоэлектронной аппаратуры и приборов");
                comboBox11.Items.Add("Строительство и эксплуатация зданий и сооружений");
                comboBox11.Items.Add("Строительство и эксплуатация автомобильных дорог и аэродромов");
                comboBox11.Items.Add("Монтаж и эксплуатация оборудования и систем газоснабжения");
                comboBox11.Items.Add("Монтаж и эксплутация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции");
                comboBox11.Items.Add("Компьютерные системы и комплексы");
            }
            if (comboBox7.Text == "Бакалавриат")
            {
                comboBox11.Items.Clear();
                comboBox11.Items.Add("Архитектура");
                comboBox11.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox11.Items.Add("Дизайн архитектурной среды");
                comboBox11.Items.Add("Градостроительство");
            }
            if (comboBox7.Text == "Специалитет")
            {
                comboBox11.Items.Clear();
                comboBox11.Items.Add("Информационная безопасность телекоммуникационных систем");
                comboBox11.Items.Add("Радиоэлектронные системы и комплексы");
                comboBox11.Items.Add("Проектирование авиационных и ракетных двигателей");
                comboBox11.Items.Add("Самолёто- и вертолётостроение");
            }
            if (comboBox7.Text == "Магистратура")
            {
                comboBox11.Items.Clear();
                comboBox11.Items.Add("Архитектура");
                comboBox11.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox11.Items.Add("Дизайн архитектурной среды");
            }
        }

        private void comboBox12_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "СПО")
            {
                comboBox12.Items.Clear();
                comboBox12.Items.Add("Монтажник радиоэлектронной аппаратуры и приборов");
                comboBox12.Items.Add("Строительство и эксплуатация зданий и сооружений");
                comboBox12.Items.Add("Строительство и эксплуатация автомобильных дорог и аэродромов");
                comboBox12.Items.Add("Монтаж и эксплуатация оборудования и систем газоснабжения");
                comboBox12.Items.Add("Монтаж и эксплутация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции");
                comboBox12.Items.Add("Компьютерные системы и комплексы");
            }
            if (comboBox7.Text == "Бакалавриат")
            {
                comboBox12.Items.Clear();
                comboBox12.Items.Add("Архитектура");
                comboBox12.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox12.Items.Add("Дизайн архитектурной среды");
                comboBox12.Items.Add("Градостроительство");
            }
            if (comboBox7.Text == "Специалитет")
            {
                comboBox12.Items.Clear();
                comboBox12.Items.Add("Информационная безопасность телекоммуникационных систем");
                comboBox12.Items.Add("Радиоэлектронные системы и комплексы");
                comboBox12.Items.Add("Проектирование авиационных и ракетных двигателей");
                comboBox12.Items.Add("Самолёто- и вертолётостроение");
            }
            if (comboBox7.Text == "Магистратура")
            {
                comboBox12.Items.Clear();
                comboBox12.Items.Add("Архитектура");
                comboBox12.Items.Add("Реконструкция и реставрация архитектурного наследия");
                comboBox12.Items.Add("Дизайн архитектурной среды");
            }
        }
    }
    }

