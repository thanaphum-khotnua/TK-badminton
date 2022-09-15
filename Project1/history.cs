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
    public partial class history : Form
    {
        MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
        public static string name1 = "";
        public static string phone1 = "";
        public static string time = "";
        
        public history()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void show()
        {
            DataSet ds = new DataSet();
            connect.Open();
            MySqlCommand cmd;
            cmd = connect.CreateCommand();
            if (checkBox1.Checked)
            {
                if (x == false)
                {
                    cmd.CommandText = "SELECT * FROM history";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM history WHERE phone like '%" + textBox1.Text + "%'";
                }
            } else
            {
                if (x == false)
                {
                    cmd.CommandText = "SELECT * FROM history WHERE booking_date = '"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM history WHERE booking_date = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND phone like '%" + textBox1.Text + "%'";
                }
            }
            

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            connect.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private bool x = false;
        

        private void history_Load(object sender, EventArgs e)
        {
            show();
            x = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                show();
            } else
            {
                dateTimePicker1.Enabled = true;
                show();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            show();
        }
    }
}
