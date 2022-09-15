using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class addmin : Form
    {
        public addmin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public static string username = "admin";
        public static string password = "admin";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == username && textBox2.Text == password)
            {
                history history = new history();
                history.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("คุณไม่ใช่แอดมิน");
            }
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
