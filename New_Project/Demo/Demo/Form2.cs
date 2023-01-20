using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
//using System.Text;
using System.Windows.Forms;
                                
namespace Demo
{
    public partial class Form2 : Form
    {
        static string connection = "Data source = spcn1681; database = test;  User ID= SA;Password= Ca999999";
        public string _ITEMBARCODE = "";
        public Form2(string ITEMBARCODE)
        {
            _ITEMBARCODE = ITEMBARCODE;
            InitializeComponent();
            this.RadGrid2(_ITEMBARCODE);
            radButton1.Click += RadButton1_Click;
        }

        //ฟังก์ชันแก้ไขข้อมูล
        private void RadButton1_Click(object sender, EventArgs e)
        {
            PARAMITERVALUES dat = new PARAMITERVALUES();
            dat.SPC_PRICEGROUP3 = txtprice1.Text.Trim();
            dat.SPC_IMAGEPATH = txtimagepath1.Text.Trim();
            dat.ITEMBARCODE = txtbarcode1.Text.Trim();
            dat.ITEMID = txtitemid1.Text.Trim();
            dat.INVENTDIMID = txtinventdimid1.Text.Trim();

            using (SqlConnection connect1 = new SqlConnection(connection))
            {
                try
                {
                    string sql2 = $@"UPDATE  [Test_INVENTITEMBARCODE]
                            SET		[SPC_PRICEGROUP3] = '{dat.SPC_PRICEGROUP3}',
                                    [SPC_IMAGEPATH] = '{dat.SPC_IMAGEPATH}'

                            WHERE   [ITEMBARCODE] = '{dat.ITEMBARCODE}'
                            AND	    [ITEMID] = '{dat.ITEMID}'
                            AND     [INVENTDIMID] = '{dat.INVENTDIMID}'";

                    connect1.Open();
                    SqlTransaction transaction = connect1.BeginTransaction("Edit");
                    using (SqlCommand command1 = new SqlCommand()
                    {
                        Connection = connect1,
                        CommandType = CommandType.Text,
                        CommandText = sql2,
                        Transaction = transaction
                    })
                        if (command1.ExecuteNonQuery() > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("อัพเดตข้อมูลแล้ว ", "แก้ไขข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RadGrid2(_ITEMBARCODE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }
        }

        DataTable dt = new DataTable();

        //ฟังก์ชันค้นหาบาร์โค้ด
        public void RadGrid2(string ITEMBARCODE)
        {
            string sql1 = string.Empty;
            sql1 = $@";WITH CTE AS
                                (
	                                SELECT [ITEMID], [INVENTDIMID]
	                                FROM   [Test_INVENTITEMBARCODE]
	                                WHERE  [ITEMBARCODE] = '{ITEMBARCODE}'
                                )
                                    SELECT  T1.[ITEMBARCODE], 
				                                      T1.[ITEMID], 
				                                      T1.[INVENTDIMID], 
				                                      T1.[UNITID], 
				                                      T1.[SPC_PRICEGROUP3],
	                                                  T1.[SPC_ITEMNAME], 
				                                      T1.[SPC_IMAGEPATH], 
				                                      T1.[SPC_ITEMBUYERGROUPID],
                                                      T1.[SPC_ITEMACTIVE],
	                                                  T2.[PRIMARYVENDORID], 
				                                      T3.[NAME], 
				                                      T4.[DESCRIPTION]

                                    FROM        [Test_INVENTITEMBARCODE] T1 WITH(NOLOCK)
                                    INNER JOIN  [Test_INVENTTABLE] T2 WITH(NOLOCK) ON  T1.[ITEMID] = T2.[ITEMID]
                                    AND         T1.[DATAAREAID] = 'spc'
                                    INNER JOIN  [Test_VENDTABLE] T3 WITH(NOLOCK) ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
                                    AND         T2.[DATAAREAID] = 'spc'
                                    INNER JOIN  [Test_DIMENSIONS] T4 WITH(NOLOCK) ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
                                    AND         T3.[DATAAREAID] = 'spc'
                                    AND         T4.[DATAAREAID] = 'spc'
                                    INNER JOIN  CTE WITH(NOLOCK) ON CTE.[ITEMID] = T2.[ITEMID] 
                                    AND         CTE.[INVENTDIMID] = T1.[INVENTDIMID]" ;

            DataTable data1 = new DataTable();

            using (SqlConnection connect1 = new SqlConnection(connection))
            {
                try
                {
                    connect1.Open();
                    using (SqlCommand command1 = new SqlCommand()
                    {
                        Connection = connect1,
                        CommandType = CommandType.Text,
                        CommandText = sql1
                    })         
                    {
                        SqlDataReader reader = command1.ExecuteReader();
                        if (reader.HasRows)
                        {
                            data1.Clear();
                            data1.Load(reader);
                            dt.Clear();
                            this.Gridgreach.DataSource = data1;
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบข้อมูล กรุณาตรวจสอบใหม่อีกครั้ง!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                           
                        }
                    }  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }
        }

        //ส่งค่าไปเพื่อแก้ไขข้อมูล
        private void Gridgreach_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtbarcode1.Text = Gridgreach.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtbarcode1.Enabled = false; //ปิดไม่ให้แก้ไขได้ของ text นั้น
            txtitemid1.Text = Gridgreach.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtitemid1.Enabled = false;
            txtinventdimid1.Text = Gridgreach.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtinventdimid1.Enabled = false;
            txtunitid1.Text = Gridgreach.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtunitid1.Enabled = false;
            txtprice1.Text = Gridgreach.Rows[e.RowIndex].Cells[4].Value.ToString();           
            txtitemname1.Text = Gridgreach.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtitemname1.Enabled = false;          
            txtimagepath1.Text = Gridgreach.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtitemberyergroup1.Text = Gridgreach.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtitemberyergroup1.Enabled = false;
            txtprimarykey1.Text = Gridgreach.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtprimarykey1.Enabled = false;
            txtname1.Text = Gridgreach.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtname1.Enabled = false;
            txtdescription1.Text = Gridgreach.Rows[e.RowIndex].Cells[10].Value.ToString();        
            txtdescription1.Enabled = false;
        }
       
        //ประกาศตัวแปร ส่งไปในฟังก์ชันแก้ไขในตาราง
        public class PARAMITERVALUES
        {
            public string SPC_PRICEGROUP3 { get; set; } = "";
            public string SPC_IMAGEPATH { get; set; } = "";
            public string ITEMBARCODE { get; set; } = "";
            public string ITEMID { get; set; } = "";
            public string INVENTDIMID { get; set; } = "";
            
        }
        
        //ฟังก์ชันลบข้อมูลในตาราง ลบ Row

        private void Gridgreach_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            string message = "ต้องการลบรายการนี้หรือไม่?";
            string title = "ลบรายการ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                string sql3 = string.Empty;
                sql3 = String.Format(@"  DELETE [Test_INVENTITEMBARCODE]
                                         WHERE [ITEMBARCODE] = '{0}'
                                         AND [SPC_ITEMACTIVE] = '{1}'"
                                        , Gridgreach.CurrentRow.Cells["ITEMBARCODE"].Value.ToString()
                                        , Gridgreach.CurrentRow.Cells["SPC_ITEMACTIVE"].Value.ToString());

                using (SqlConnection connect1 = new SqlConnection(connection))
                { 
                    try
                    {
                        connect1.Open();
                        SqlTransaction transaction = connect1.BeginTransaction("Delete");
                        using (SqlCommand command1 = new SqlCommand()
                        {
                            Connection = connect1,
                            CommandType = CommandType.Text,
                            CommandText = sql3,
                            Transaction = transaction
                        })
                        if (command1.ExecuteNonQuery() > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("ลบรายการนี้แล้ว ", "ลบข้อมูล");                        
                        }
                        this.RadGrid2(_ITEMBARCODE);
                    }
                    catch (Exception ex)
                    {
                        SqlTransaction transaction = connect1.BeginTransaction("Delete");
                        transaction.Rollback();
                        MessageBox.Show("Error : " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connect1.State == ConnectionState.Open)
                            connect1.Close();
                    }
                }
            }
            else
            {
                this.RadGrid2(_ITEMBARCODE);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
