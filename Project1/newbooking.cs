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
    public partial class newbooking : Form
    {
        public newbooking()
        {
            InitializeComponent();
        }
        public static int courtid = 0; 
        private void court1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Name.Contains("_"))
            {
                int buttonname = Convert.ToInt32(button.Name.ToString().Split('_')[1]);
                courtid = buttonname;
                booking form3 = new booking();
                form3.Show();
                Hide();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
