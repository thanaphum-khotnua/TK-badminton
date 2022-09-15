using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project1
{
    public partial class login : Form
    {
        MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
        public static string phone = "";
        public login()
        {
            InitializeComponent();
        }
        private bool check(string username, string password)
        {
            string sql = "SELECT password FROM register1 WHERE phone_number = '" + username + "' ";
            connect.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            MySqlDataReader reader = cmd.ExecuteReader();
            string pass = "";
            while (reader.Read())
            {
                pass = reader.GetString("password");

            }
            connect.Close();

            if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (password == pass)
            {
                return true;
            }
            return false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            phone = textBox1.Text;
            string password = textBox2.Text;
            if (check(phone, password) || (phone == addmin.username && password == addmin.password))
            {
                MessageBox.Show("เข้าสู่ระบบแล้ว");
                newbooking newbooking = new newbooking();
                newbooking.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านผิด");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            register register = new register();
            register.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
