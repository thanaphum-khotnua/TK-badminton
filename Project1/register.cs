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
    public partial class register : Form
    {
        MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
        public register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstname = this.firstname.Text;
            string lastname = this.lastname.Text;
            string tel = this.tel.Text;
            string password = this.password.Text;
            string conpass = this.conpass.Text;
            if(tel.Length == 10)
            {
                if(password.Length == 8)
                {
                    addData(firstname, lastname, tel, password);
                }
                else
                {
                    MessageBox.Show("รหัสไม่ครบ8ตัว");
                }
                
            }
            else
            {
                MessageBox.Show("เบอร์ไม่ครบ10ตัว");
            }

            login login = new login();
            login.Show();
            this.Hide();
        }

        private void firstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void addData(string firstname, string lastname ,string phone, string password)
        {
            string sql = $"INSERT INTO register1 (firstname,lastname,phone_number,password) VALUES ('{firstname}','{lastname}','{phone}','{password}')";
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            connect.Open();
            int rows = cmd.ExecuteNonQuery();
            connect.Close();

         
            if (rows > 0) //เช็คการเพิ่มข้อมูลว่าเพิ่มข้อมูลแล้วก็จะโชว์ว่าเพิ่มข้อมูลเเล้ว
            {
                MessageBox.Show("ลงทะเบียนเรียบร้อย");
            }
        }

        private void conpass_TextChanged(object sender, EventArgs e)
        {
            if (password.Text != conpass.Text)
            {
                button2.Enabled = false;
                label6.Visible = true;
            }
            else
            {
                button2.Enabled = true;
                label6.Visible = false;
            }
        }

        private void tel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
