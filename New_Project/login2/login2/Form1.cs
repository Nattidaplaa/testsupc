using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace login2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string Yourname = "crem";
            string Password = "123456";

            if (txtname.Text == Yourname && txtpassword.Text == Password)
            {
                new Form2().Show();
                //MessageBox.Show(Yourname);
                this.Hide();
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาด", "ERROR", MessageBoxButtons.OK); 
                txtname.Clear();
                txtpassword.Clear();
                txtname.Focus();


            }
        }














        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
