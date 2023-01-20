using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            show();
            //search.Click += Search_Click1; 
            //new Customer().GetBarCode();
        }



        public void show()
        {
            var x = Customer.GetBarCode();
            this.radGridView1.DataSource = x;
            //var y = Search.Searchs(txtsearch.Text);
            //this.gridsearch.DataSource = y;

        }


    }
}
