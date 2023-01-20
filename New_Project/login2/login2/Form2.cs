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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();

        private void Form2_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            //table.Columns.Add("Addrees", typeof(string));
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Age", typeof(string));

            table.Rows.Add("plaa", "pla", 23, 20);
            table.Rows.Add("adum", "phang", 36, 20);
            table.Rows.Add("mark", "fb", 25, 20);

            Mygridname.DataSource = table;
        }


        


        //อยู่ในปุ่ม save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBox.Show("Your Name not correct!!", "Warning", MessageBoxButtons.OK);
                this.txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtLastName.Text.Trim()))
            {
                MessageBox.Show("Your LastName not correct!!", "Warning", MessageBoxButtons.OK);
                this.txtLastName.Focus();
                return;

            }

            if (string.IsNullOrEmpty(this.txtID.Text.Trim()))
            {
                MessageBox.Show("Your ID not correct!!", "Warning", MessageBoxButtons.OK);
                this.txtID.Focus();
                return;
            }

            //วิธีนี้รันไม่ผ่าน
            //int age = Convert.ToInt32(txtAge.Text);
            //table.Rows.Add(txtName.Text, txtLastName.Text, Convert.ToInt32(txtID.Text), Convert.ToInt32(txtAge.Text));

            //หรืออีกวิธี
            table.Rows.Add(txtName.Text, txtLastName.Text, Convert.ToInt32(txtID.Text), txtAge.Text);
        }
    }
}
