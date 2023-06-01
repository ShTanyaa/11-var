using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _11_вариант
{
    public partial class Form1 :Form
    {
        SqlDataAdapter adptr;
        SqlConnection connect = new SqlConnection(@"Data Source=PC325L11\SQLEXPRESS;Initial Catalog=Shumkova_Pr21_var11;Integrated Security=True");
        DataTable table;
        public Form1 ()
        {
            InitializeComponent( );
            tbl_view("select * from dbo.Корабль");
            dataGridView1.DataSource = table;
            tbl_view("select * from dbo.Порт");
            dataGridView2.DataSource = table;
            tbl_view("select * from dbo.Посещение");
            dataGridView3.DataSource = table;

        }

        private void tbl_view(string mes)
        {
            connect.Open( );
            adptr = new SqlDataAdapter(mes, connect);
            table = new DataTable();
            adptr.Fill(table);
            connect.Close();
        }

        private void tabPage1_Click (object sender, EventArgs e)
        {
            
        }

        private void button1_Click (object sender, EventArgs e)
        {
            string name, portpr, displ,captn,kod;
            name = textBox1.Text;
            portpr = textBox2.Text;
            displ =numericUpDown1.Text;
            captn = textBox3.Text;
            kod = numericUpDown3.Text;

            if ( name == "" || portpr == "" || displ == "0" || captn =="" || kod == "0")
            {
                MessageBox.Show("Не все поля ввода данных заполнены", "error");
            }
            else
            {
                tbl_view($"insert into dbo.Корабль(Код,Название,Водоизмещение,ПортПриписки,Капитан) values ('{kod}','{name}','{displ}','{portpr}','{captn}')");
                tbl_view("select * from dbo.Корабль");
                dataGridView1.DataSource = table;
            }
        }

        private void button2_Click (object sender, EventArgs e)
        {
            string name, country, category,kod;
            name = textBox5.Text;
            country = textBox4.Text;
            category = numericUpDown5.Text;
            kod = numericUpDown4.Text;

            if ( name == "" || country == "" || category == "" || kod=="")
            {
                MessageBox.Show("Не все поля ввода данных заполнены", "error");
            }
            else
            {
                tbl_view($"insert into dbo.Порт(Код,Название,Страна,Категория) values ('{kod}','{name}','{country}','{category}')");
                tbl_view("select * from dbo.Порт");
                dataGridView2.DataSource = table;
            }
        }
        
        private void button3_Click (object sender, EventArgs e)
        {
            string date1, date2, num,purpose,portId,korblId,kod;
            date1 = textBox9.Text;
            date2 = textBox8.Text;
            num = numericUpDown2.Text;
            purpose = textBox7.Text;
            portId = textBox11.Text;
            korblId = textBox10.Text;
            kod = numericUpDown6.Text;

            if ( date1 == "" || date2 == "" || num == "0" || purpose == ""|| portId == "" || korblId == "" || kod=="0")
            {
                MessageBox.Show("Не все поля ввода данных заполнены", "error");
            }
            else
            {
                tbl_view($"insert into dbo.Посещение(Код,Название,Страна,Категория) values ('{kod}','{date1}','{date2}','{num}','{purpose}','{portId}','{korblId}')");
                tbl_view("select * from dbo.Посещение");
                dataGridView3.DataSource = table;
            }
        }
    }
}
