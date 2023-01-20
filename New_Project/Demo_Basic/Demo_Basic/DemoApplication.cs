using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo_Basic
{
    public partial class DemoApplication : Form
    {
        public DemoApplication()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = lstCity.GetItemText(lstCity.SelectedItem);
            MessageBox.Show(text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastname = txtLastName.Text;
            string address = txtAddress.Text;
            string id = txtID.Text;
            string age = txtAge.Text;
            DialogResult message;
            message = MessageBox.Show("Welcome ja manud","Application <->",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (message == DialogResult.Yes )
            {
                Close();
            }
        }

        private void GridView_Click(object sender, EventArgs e)
        {
            
        }
    }
}
