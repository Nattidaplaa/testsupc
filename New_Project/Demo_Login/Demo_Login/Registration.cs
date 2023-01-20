using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo_Login
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string your_user_name = "po";
            string your_password = "1234";
            if (texUserName.Text== your_user_name && texPassword.Text == your_password)
            {
                new Form2().Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("The UserName or Password is incorrect, try again!! ");
                texUserName.Clear();
                texPassword.Clear();
                texUserName.Focus();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            texUserName.Clear();
            texPassword.Clear();
            texUserName.Focus();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
