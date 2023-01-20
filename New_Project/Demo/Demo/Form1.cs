using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {

        static string connection = "Data source = spcn1681; database = test;  User ID= SA;Password= Ca999999"; //Integrated security = true;
        //static string connection = "Data Source= SPCN2183 ;Initial Catalog= TEST;User ID= SA;Password= Ca999999";
        public Form1()
        {
            InitializeComponent();
            RadGridView1();
            btnsearch.Click += Btnsearch_Click; //ปุ่มคลิ๊กเพื่อค้นหา                
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            //Form2 frm = new Form2(RadGrid2);
            new Form2(txtsearch.Text).Show();
            //แสดงผลข้อมูลในตารางที่ 2
            //Sreach(txtsearch.Text);
        }

        DataTable dt = new DataTable();

        //แสดงข้อมูลทั้งหมดในตารางแรก
        void RadGridView1()
        {
            string sql = $@" SELECT TOP (1000) T1.[ITEMBARCODE], 
                                                T1.[ITEMID], 
                                                T1.[INVENTDIMID], 
                                                T1.[UNITID], 
                                                T1.[SPC_PRICEGROUP3],
                                                T1.[SPC_ITEMNAME], 
                                                T1.[SPC_IMAGEPATH], 
                                                T1.[SPC_ITEMBUYERGROUPID],
                                                T2.[PRIMARYVENDORID], 
                                                T3.[NAME], 
                                                T4.[DESCRIPTION]
                            FROM  [Test_INVENTITEMBARCODE] T1
                            INNER JOIN [Test_INVENTTABLE] T2 ON  T1.[ITEMID] = T2.[ITEMID]
                            AND     T1.[DATAAREAID] = 'spc'
                            INNER JOIN [Test_VENDTABLE] T3 ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
                            AND     T2.[DATAAREAID] = 'spc'
                            INNER JOIN [Test_DIMENSIONS] T4 ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
                            AND     T3.[DATAAREAID] = 'spc'
                            AND     T4.[DATAAREAID] = 'spc' ";
                    
            DataTable data = new DataTable();
       
            using(SqlConnection connect = new SqlConnection(connection))
            {
                    try
                    {
                        connect.Open();
                        using (SqlCommand command = new SqlCommand()
                        {
                            Connection = connect,
                            CommandType = CommandType.Text,
                            CommandText = sql
                        })
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                data.Clear();
                                data.Load(reader);
                                dt.Clear();
                                this.radGridView1.DataSource = data;
                            }
                            else
                            {
                                MessageBox.Show("ERROR","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                    }

                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new Form3().Show(); //ปุ่มเพิ่มข้อมูลของสินค้า เด้งไปตารางที่ 3

        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e) //Enter เพื่อค้นหา ถ้ากด Enter แล้วให้เด้งไปตารางที่ 2
        {
            if (e.KeyCode == Keys.Enter)
            {  
               new Form2(txtsearch.Text).Show();   
            }
        }
    }
}
