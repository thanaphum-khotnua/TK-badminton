using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //เรียกใช้เครื่องมือต่างๆ

namespace Project1
{
    public partial class booking : Form //ประกาศไว้ใช้เพื่อไปใช้เป็นข้อมูลเพื่อเอาไปใช้ในอีกหลายๆฟังก์ชั่น
    {
        MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
        public static string name2 = "";
        public static string phone2 = "";
        public static string time = "";
        public static int court2 = 0;
        public static int hour = 0;
        public static int price = 150;

        //List<string> availableTime = new List<string>();
        string[] availableTime = { "09.00", "10.00", "11.00", "12.00", "13.00", "14.00", "15.00", "16.00", "17.00", "18.00", "19.00", "20.00" };


        public booking()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //เชคข้อมูลตัวเลข เบอร์โทร เช็คค่าตัวแปรที่ไม่ซืำ
        private bool checknum(string str) //เช็คว่ามีตัวเลขมั้ยถ้ามีต้องเช็ค
        {
            if (string.IsNullOrEmpty(str)) return false;

            foreach (char i in str) {
                if (char.IsNumber(i) && char.IsLetter(i) == false)
                {
                    return true;
                }
            }

            return false;
        }

        private void load() //setค่าเข้าไปแสดงในตารางดาต้ากริด
        {
            DataSet ds = new DataSet();
            connect.Open();
            MySqlCommand cmd; 
            cmd = connect.CreateCommand();
            if(login.phone == "admin")
            {
                MessageBox.Show(DateTime.Now.Date.ToString("yyyy-MM-dd"));
                cmd.CommandText = "SELECT * FROM court_booking WHERE court_date_booking = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM court_booking WHERE court_date_booking = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and phone = '"+login.phone+"'";
            }
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            connect.Close();
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        private int[] getdata(string phone)
        {
            string sql = $"SELECT id FROM court_booking";
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            connect.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<int> id = new List<int>();
            while (dr.Read())
            {
                id.Add(dr.GetInt32("id"));
            }
            int lastid = 1;
            if (id.Count != 0)
            {
                lastid = id[id.Count - 1] + 1;
            }
            connect.Close();


            sql = $"SELECT total_time FROM history WHERE phone = '{phone}'";
            cmd = new MySqlCommand(sql, connect);
            connect.Open();
            dr = cmd.ExecuteReader();
            List<int> list = new List<int>();
            while (dr.Read())
            {
                list.Add(dr.GetInt32("total_time"));
            }
            int total = 0;
            if (list.Count != 0)
            {
                total = list[list.Count - 1];
            }
            connect.Close();

            int[] data = new int[] {lastid, total };
            return data;
        }

        private void addData(string name, string phone, int court, string starttime, string endtime) 
        {
            string sql = $"INSERT INTO court_booking (name,phone,court_num,court_time_booking,out_time,court_date_booking) VALUES ('{name}','{phone}','{court}','{starttime}','{endtime}','{DateTime.Now.Date.ToString("yyyy-MM-dd")}')";
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            connect.Open();
            int rows = cmd.ExecuteNonQuery();
            connect.Close();

            int hr = Convert.ToInt32(comboBox2.Text) + getdata(phone)[1];
            DateTime datenow = DateTime.Now;
            string date = datenow.ToString("yyyy-MM-dd");
            string time = datenow.ToString("HH:mm:ss");
            sql = $"INSERT INTO history (id,name,phone,total_time, booking_date, booking_time, time) VALUES ('{getdata(phone)[0]}','{name}','{phone}','{hr}','{date}','{starttime}','{time}')";
            cmd = new MySqlCommand(sql, connect);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            if (rows > 0) //เช็คการเพิ่มข้อมูลว่าเพิ่มข้อมูลแล้วก็จะโชว์ว่าเพิ่มข้อมูลเเล้ว
            {
                name2 = name;
                phone2 = phone;
                court2 = court;
                time = starttime;
                hour = Convert.ToInt32(comboBox2.Text);
                MessageBox.Show("เพิ่มข้อมูลเรียบร้อยแล้ว");
                load();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
                comboBox2.Items.Clear();
                foreach (string i in availableTime)
                {
                    comboBox2.Items.Add(i);
                }
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox2.Visible = false;
                label5.Visible = false;


                reciept form3 = new reciept();
                form3.Show();

            }
        }

        private void editData(string name, string phone, int court, string starttime, string endtime, int id)
        {
            string sql = $"UPDATE court_booking SET name='{name}',phone='{phone}',court_num='{court}',court_time_booking='{starttime}',out_time='{endtime}' WHERE id = '{id}'";
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            connect.Open();
            int rows = cmd.ExecuteNonQuery();
            connect.Close();
            if (rows > 0)
            {
                name2 = name;
                phone2 = phone;
                court2 = court;
                time = starttime;
                hour = Convert.ToInt32(comboBox2.Text);
                MessageBox.Show("เเก้ไขข้อมูลเรียบร้อยแล้ว");
                ShowEquiment();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
                comboBox2.Items.Clear();
                foreach (string i in availableTime)
                {
                    comboBox2.Items.Add(i);
                }
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox2.Visible = false;
                label5.Visible = false;


                reciept form3 = new reciept();
                form3.Show();

            }
    }

        private string getendtime(int id) //ดึงเวลาจากดาต้าเบสที่จองโดยเช็คจากไอดี
        {
            string sql = "SELECT out_time FROM court_booking WHERE id = '" + id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            connect.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            string endtime = "";

            while (reader.Read())
            {
                endtime = reader.GetString("out_time");
            }
            connect.Close();
            return endtime;
        }

        private void booking_Load(object sender, EventArgs e) //รับค่าphoneเพื่อนำมาlogin
        {
            textBox2.Text = login.phone;
            textBox1.Text = username1(login.phone);
            load(); comboBox3.Text = newbooking.courtid.ToString();
            ShowEquiment();
        }

        private string username1(string phone)
        {
             string sql = "SELECT firstname , lastname FROM register1 WHERE phone_number = '" + phone + "'"; //ดึงข้อมูลของชื่อ นาสกุลมาจากphone
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            connect.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            string name = "";

            while (reader.Read())
            {
                string firstname = reader.GetString("firstname");
                string lastname = reader.GetString("lastname");
                name = firstname + " " + lastname;
            }
            connect.Close();
            return name;
        }
        private string timecal() //โชว์ข้อความวันเวลาการจองหลังการกรอกข้อมูลจองสนาม
        {
            int hr = Convert.ToInt32(comboBox2.Text);
            DateTime dateNow = DateTime.Now.Date;
            string timebox = comboBox1.Text.Replace('.', ':') + ":00"; 
            DateTime start = Convert.ToDateTime(timebox);
            MessageBox.Show(start.ToString());
            string endTime = start.AddHours(hr).ToString("HH:mm:ss");
            return endTime;
        }

        private int hourCal(int id, string starttime) //คำนวณจำนวนชั่ว
        {
            DateTime endtime = Convert.ToDateTime(getendtime(id));
            DateTime dateNow = DateTime.Now.Date;
            DateTime start = Convert.ToDateTime(starttime);
            TimeSpan hour = endtime.Subtract(start);
            //DateTime end = dateNow + hour;
            return Convert.ToInt32(hour.TotalHours);
        }

        private void delete(int id)
        {
            DialogResult result = MessageBox.Show("ต้องการลบข้อมูลหรือไม่", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM court_booking WHERE id = '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, connect);
                connect.Open();
                int rows = cmd.ExecuteNonQuery();
                connect.Close();
                if (rows > 0)
                {
                    MessageBox.Show("ลบข้อมูลแล้ว");
                    load();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = textBox1.Text;
            string phone = textBox2.Text;
            string court = comboBox3.Text;
            string timebook = comboBox1.Text.Replace('.', ':') + ":00"; // 10.00 -> 10:00:00
            string hr = comboBox2.Text;
            string endTime = timecal();

            if (checknum(phone) && phone.Length == 10) //เช็คเบอร์โทรว่าครบ10ตัวมั้ย
            {
                addData(name, phone, Convert.ToInt32(court), timebook, endTime);
               
            } else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง");
            }
           

        }
        int d=0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //เลือกข้อมูลในดรอปดาวแล้วมีการอัพเดตข้อมูล //ใช้คำนวนชั่วโมงโดยอิงจากคอร์ทว่าในแต่ละคอร์ทจะว่างช่วงเวลาไหน
        {
            try
            {
                for (int i = 0; i <= 12; i++)
                {
                    comboBox2.Items.RemoveAt(0);
                }
            }
            catch
            {

            }
            
            string a = comboBox1.Text;
            decimal b = Convert.ToDecimal(comboBox1.Text);
            DateTime timebook = Convert.ToDateTime(comboBox1.Text.Replace('.', ':') + ":00");

            int c = Convert.ToInt32(b);
             d = 21 - c;
            for (int i=1; i <= d; i++)
            {
                comboBox2.Items.Add(i);
            }
            label5.Show();
            checkavailablehr(timebook);
            comboBox2.Show();

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e) //ดึงพวกข้อมูลต่างๆในตารางเช่นพวกไอดี เบอร์ ชื่อ เป็นต้น มาเก็บในtextbox
        {
            //dataGridView2.CurrentRow.Selected = true;
            //int selectedRow = dataGridView2.CurrentCell.RowIndex;
            //int id = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["id"].FormattedValue.ToString());
            //label6.Text = id.ToString();
            //string name = textBox1.Text;
            //string phone = textBox2.Text;
            //string court = comboBox3.Text;
            //string timebook = comboBox1.Text.Replace('.', ':') + ":00";
            //string hr = comboBox2.Text;
            //string endTime = timecal();
            //editData(name, phone, Convert.ToInt32(court), timebook, endTime, id);

            //Checking checking = new Checking();
            //checking.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*dataGridView.CurrentRow.Selected = true;
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].FormattedValue.ToString());
            string name = dataGridView1.Rows[selectedRow].Cells["name"].FormattedValue.ToString();
            string phone = dataGridView1.Rows[selectedRow].Cells["phone"].FormattedValue.ToString();
            string court = dataGridView1.Rows[selectedRow].Cells["court_num"].FormattedValue.ToString();
            string timebook = dataGridView1.Rows[selectedRow].Cells["court_time_booking"].FormattedValue.ToString();
            string hr = hourCal(id, timebook).ToString();
            label6.Text = id.ToString();
            textBox1.Text = name;
            textBox2.Text = phone;
            comboBox3.Text = court;
            comboBox2.Text = hr;
            comboBox1.Text = timebook;*/

            
        }

        private void button3_Click(object sender, EventArgs e) //ดึงพวกข้อมูลต่างๆในตารางเช่นพวกไอดี เบอร์ ชื่อ เป็นต้น มาเก็บในtextbox
        {

            dataGridView2.CurrentRow.Selected = true;
            int selectedRow = dataGridView2.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["id"].FormattedValue.ToString());
            string name = dataGridView2.Rows[selectedRow].Cells["name"].FormattedValue.ToString();
            string phone = dataGridView2.Rows[selectedRow].Cells["phone"].FormattedValue.ToString();
            string court = dataGridView2.Rows[selectedRow].Cells["court_num"].FormattedValue.ToString();
            string timebook = dataGridView2.Rows[selectedRow].Cells["court_time_booking"].FormattedValue.ToString();
            string hr = hourCal(id, timebook).ToString();
            label6.Text = id.ToString();
            textBox1.Text = name;
            textBox2.Text = phone;
            comboBox3.Text = court;
            comboBox2.Text = hr;
            comboBox1.Text = timebook;

            delete(id);

            //Checking checking = new Checking();
            //checking.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        private MySqlConnection DatabaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void ShowEquiment() //ดึงข้อมูลจากดาต้าเบสเก็บไว้ในดาต้ากริด
        {

            MySqlConnection conn = DatabaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `court_booking`";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView2.DataSource = ds.Tables[0];



        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView2.CurrentRow.Selected = true;
            //int selectedRow = dataGridView2.CurrentCell.RowIndex;
            //int id = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["id"].FormattedValue.ToString());
            //string name = dataGridView2.Rows[selectedRow].Cells["name"].FormattedValue.ToString();
            //string phone = dataGridView2.Rows[selectedRow].Cells["phone"].FormattedValue.ToString();
            //string court = dataGridView2.Rows[selectedRow].Cells["court_num"].FormattedValue.ToString();
            //string timebook = dataGridView2.Rows[selectedRow].Cells["court_time_booking"].FormattedValue.ToString();
            //string hr = hourCal(id, timebook).ToString();
            //label7.Text = id.ToString();
            //textBox1.Text = name;
            //textBox2.Text = phone;
            //comboBox3.Text = court;
            //comboBox2.Text = hr;
            //comboBox1.Text = timebook;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private string[] checkcourt(int court) //ดึงเวลาจากดาต้าเบสเอาหมุนทุกค่าและนำมาเก็บตามตัวแปร starttime/outtime เช็คตามวัน คอร์ท
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
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
            return starttime.ToArray();

        }

        private int[] checkhr(int court) //จากโค้ดด้านบนแต่เอาาคำนวณต่อ
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
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

            List<int> hr = new List<int>(); //คำนวณเจำนวนชั่วโมงโดยใช้เวลาเข้าออก เวลาเข้า-ออก 
            for (int i = 0; i < outtime.Count; i++)
            {
                DateTime endtime = Convert.ToDateTime(outtime[i]);
                DateTime dateNow = DateTime.Now.Date;
                DateTime start = Convert.ToDateTime(starttime[i]);
                TimeSpan hour = endtime.Subtract(start);
                DateTime end = dateNow + hour;
                hr.Add(end.Hour); //ชั่วโมงที่ได้จะเอามาเก็บในนี้
            }


            return hr.ToArray(); //ส่งค่าเพื่อใช้ต่อ

        }

        private void checkavailablehr(DateTime timechoose) //เช็คจำนวนชั่วโมงที่สามารถเล่นได้
        {
            int court = Convert.ToInt32(comboBox3.Text);
            string[] time = checkcourt(court);
            List<string> timeout = new List<string>();
            for (int i = 0; i < time.Length; i++) //วนตามจำววนค่าในลิส
            {
                for (int j = 0; j < checkhr(court)[i]; j++) //วนตามชั่วโมงเพื่อเช็คค่าว่าในแต่ละคอร์ทที่จองเวลาสามารถเล่นได้กี่ชั่วโมง
                {
                    timeout.Add(Convert.ToDateTime(time[i]).AddHours(j).ToString("HH.mm")); //ได้เวลาที่จะออกจากสนาม
                }
            }
            foreach (string item in timeout) //วนตามไอเท็มที่เก็บในไทม์เอ้าท์
            {
                for (int x = 1; x <= 12; x++)
                {
                    if (timechoose.AddHours(x - 1).ToString("HH.mm") == item) //เช็คว่าช่วงเวลาไหนไม่ว่างก็ลบออกจากคอมโบบ็อก
                    {
                        comboBox2.Items.Remove(x);
                        for (int y = x; y <= 12; y++)
                        { 
                            comboBox2.Items.Remove(y);
                        }
                       
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); //เคลียร์เวลาในคอมโบบ็อกซ์
            foreach (string i in availableTime) //เพิ่มข้อมูลเวลาทั้งหมด
            {
                comboBox1.Items.Add(i);
            }
            int court = Convert.ToInt32(comboBox3.Text);
            string[] time = checkcourt(court);
            for (int i = 0; i < time.Length; i++)
            {
                for (int j = 0; j < checkhr(court)[i]; j++)
                {
                    //Console.WriteLine(Convert.ToDateTime(time[i]).AddHours(j).ToString("HH.mm")); // time check //เช็คว่าเวลาไหนว่างถ้าไม่ว่างก็ลบออกจากคอมโบบ็อกซ์
                    comboBox1.Items.Remove(Convert.ToDateTime(time[i]).AddHours(j).ToString("HH.mm"));
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            newbooking newbooking = new newbooking();
            newbooking.Show();
            this.Hide();


        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            int selectedRow = dataGridView2.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["id"].FormattedValue.ToString());
            string name = dataGridView2.Rows[selectedRow].Cells["name"].FormattedValue.ToString();
            string phone = dataGridView2.Rows[selectedRow].Cells["phone"].FormattedValue.ToString();
            string court = dataGridView2.Rows[selectedRow].Cells["court_num"].FormattedValue.ToString();
            string timebook = dataGridView2.Rows[selectedRow].Cells["court_time_booking"].FormattedValue.ToString();
            string hrtime = timebook.Split(':')[0]; // '10':00:00
            string hr = hourCal(id, timebook).ToString();
            label7.Text = id.ToString();
            textBox1.Text = name;
            textBox2.Text = phone;
            comboBox3.Text = court;
            comboBox2.Text = hr;
            comboBox1.Text = hrtime + ".00";
        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Checking checking =new Checking();
            checking.Show();

        }
    }
}
