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
    public partial class Checking : Form
    {
        MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
        public Checking()
        {
            InitializeComponent();
        }

        string[] timelist = { "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00","13:00 - 14:00","14:00 - 15:00","15:00 - 16:00","16:00 - 17:00","17:00 - 18:00","18:00 - 19:00","19:00 - 20:00","20:00 - 21:00" };
        string[] court = { "1", "2", "3", "4", "5" };

        private void load()
        {

        }

        private string[] checkcourt(int court, string date) //เช็ควคอร์ทกับวันว่ามีคนจองเวลาไหนและออกเวลาไหน
        {
            string sql = "SELECT court_time_booking, out_time FROM court_booking WHERE court_date_booking = '" + date + "' AND court_num = '" + court + "' ";
            connect.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> starttime = new List<string>();
            //List<string> outtime = new List<string>();
            while (reader.Read())
            {
                starttime.Add(reader.GetString("court_time_booking"));
                //outtime.Add(reader.GetString("out_time"));
            }
            connect.Close();
            return starttime.ToArray();

        }

        private string[] getdata(int court, string starttime, string date) //ดึงข้อมูลของผู้ใช้มาใส่ในตาราง ชื่อ เบอร์
        {
            string sql = "SELECT name,phone FROM court_booking WHERE court_date_booking = '" + date + "' AND court_num = '" + court + "' AND court_time_booking = '"+starttime+"' ";
            connect.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> data = new List<string>();
            while (reader.Read())
            {
                string combine = reader.GetString("name") + "_" + reader.GetString("phone"); // name_phone
                data.Add(combine);
            }
            connect.Close();


            return data.ToArray();

        }

        private int[] checkhr(int court, string date)
        {
            string sql = "SELECT court_time_booking, out_time FROM court_booking WHERE court_date_booking = '" + date + "' AND court_num = '" + court + "' ";
            connect.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> starttime = new List<string>();
            List<string> outtime = new List<string>();
            while (reader.Read())
            {
                starttime.Add(reader.GetString("court_time_booking"));
                outtime.Add(reader.GetString("out_time"));
            }
            connect.Close();

            List<int> hr = new List<int>();
            for (int i = 0; i < outtime.Count; i++)
            {
                DateTime endtime = Convert.ToDateTime(outtime[i]);
                DateTime dateNow = DateTime.Now.Date;
                DateTime start = Convert.ToDateTime(starttime[i]);
                TimeSpan hour = endtime.Subtract(start);
                DateTime end = dateNow + hour;
                hr.Add(end.Hour);
            }


            return hr.ToArray();

        }

        private int timeCell(string time) //เช็คเวลาเอามาเทรีบกับช่องcellว่าอยู่ช่องไหน
        {
            string hr = time.Split(':')[0];
            switch (hr)
            {
                case "09":
                    return 0;
                    break;
                case "10":
                    return 1;
                    break;
                case "11":
                    return 2;
                    break;
                case "12":
                    return 3;
                    break;
                case "13":
                    return 4;
                    break;
                case "14":
                    return 5;
                    break;
                case "15":
                    return 6;
                    break;
                case "16":
                    return 7;
                    break;
                case "17":
                    return 8;
                    break;
                case "18":
                    return 9;
                    break;
                case "19":
                    return 10;
                    break;
                case "20":
                    return 11;
                    break;

                default:
                    return -1; //ถ้ารีเทิร์นค่าก็ลบไปหนึ่ง
                    break;
            }
            return -1;
        }

        private void checkavailable() //เช็คว่าเซลล์นั้นว่างมั้ย
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            dt.Columns.Add("Time");
            foreach (string item in court)
            {
                dt.Columns.Add(item); //สนาม
            }
            foreach (string item in timelist)
            {

                dt.Rows.Add(item); //เวลา
            }

            dataGridView1.DataSource = dt; //เอาไปโชว์ในดาต้ากริด

            for (int i = 0; i < 12; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    dt.Rows[i][j] = "\n";
                }
            }

            for (int c = 1; c <= 5; c++) //เช็คเวลาของคอร์ทแต่ละคอร์ท
            {
                string[] time = checkcourt(c, date);
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Yellow; //ถ้าไม่ว่าก็เป็นสีเหลือง
                for (int i = 0; i < time.Length; i++)
                {
                    for (int j = 0; j < checkhr(c, date)[i]; j++)
                    {
                        dataGridView1.Rows[timeCell(time[i]) + j].Cells[c].Style = style; //ถ้าไม่ว่าก็เปลี่ยนเป็นสีเหลือง
                        string userdata = getdata(c, time[i], date)[0]; //ดึงข้อมูลผู้ใช้มาจาก คอร์ท วัน เวลา
                        string[] datasplit = userdata.Split('_');
                        dt.Rows[timeCell(time[i]) + j][c] = datasplit[0] + "\n" + datasplit[1]; //เซตค่าตามช่องว่าในช่องนั้นเป็นข้อมูลของใคร
                    }

                }
            }

            //dt.Rows[time]["court"] = text;

            // dataGridView1.Rows[time].Cells[court].Style = style;
        }

        private void Checking_Load(object sender, EventArgs e)
        {
            checkavailable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            checkavailable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
