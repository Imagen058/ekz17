using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekz
{
    public partial class Print : Form
    {
        string surname;
        string name;
        string patronymic;
        string nap1;
        string nap2;
        string nap3;
        string nap4;
        string nap5;
        public Print(string surname, string name, string patronymic, 
            string nap1, string nap2, string nap3, string nap4, string nap5)
        {
            InitializeComponent();
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.nap1 = nap1;
            this.nap2 = nap2;
            this.nap3 = nap3;
            this.nap4 = nap4;
            this.nap5 = nap5;
        }

        private void Print_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            richTextBox1.Text = $"\nЗАЯВЛЕНИЕ\n  \nЯ, {surname} {name} {patronymic}, подал документы в ВУЗ" +
                $"\nНа направления подготовки:" +
                $"\n{nap1}\n{nap2}\n{nap3}\n{nap4}\n{nap5}\n  \n   \n{date.ToString()}";
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(0, 0));
        }

        private void printBut_Click(object sender, EventArgs e)
        {
            PrintDialog letter = new PrintDialog();
            letter.Document = printDocument1;
            DialogResult result = letter.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }
    }
}
