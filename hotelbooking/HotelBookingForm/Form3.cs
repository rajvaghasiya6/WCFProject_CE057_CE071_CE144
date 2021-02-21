using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hotelbooking;

namespace HotelBookingForm
{
    public partial class Form3 : Form
    {

        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            userr u = new userr()
            {
                name = textBox1.Text,
                email = textBox2.Text,
                mobileno = textBox3.Text,
                password = textBox4.Text,
            };
            if (service.adduser(u))
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "Error while Register";
            }

        }
    }
}
