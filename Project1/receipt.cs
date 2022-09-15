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
    public partial class receipt : Form
    {
        public receipt()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void receipt_Load(object sender, EventArgs e)
        {
            string name = booking.name2;
            string phone = booking.phone2;
            string time = booking.time;
            int hr = booking.hour;
            int court = booking.court2;
            int price = booking.price;

            label6.Text = time;
            label8.Text = name;
            label10.Text = phone;
            label17.Text = court.ToString();
            label17.Text = hr.ToString();
            label19.Text = price.ToString();  
            label20.Text = (hr*price).ToString();
            label23.Text = hr.ToString();
            label22.Text = (hr * price).ToString();
            label25.Text = (hr * price).ToString();

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}
