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
    public partial class reciept : Form
    {
        public reciept()
        {
            InitializeComponent();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void reciept_Load(object sender, EventArgs e)
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
            label18.Text = hr.ToString();
            label19.Text = price.ToString();
            label20.Text = (hr * price).ToString();
            label23.Text = hr.ToString();
            label22.Text = (hr * price).ToString();
            label25.Text = (hr * price).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
