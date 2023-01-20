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
            table.Columns.Add("Addrees", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("ID", typeof(int));

            table.Rows.Add("plaa", "pla", "80 M.1", 20, 22210032);
            table.Rows.Add("adum", "phang", "162/89 M.5", 25, 22210045);
            table.Rows.Add("mark", "fb", "256 M.10", 30, 0000001);

            Mygridname.DataSource = table;
        }
    }
}
