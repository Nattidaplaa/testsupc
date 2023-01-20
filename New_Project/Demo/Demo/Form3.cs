using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Demo
{
    public partial class Form3 : Form
    {
		static string connection = "Data source = spcn1681; database = test;  User ID= SA;Password= Ca999999";
		
		public Form3()
        {
            InitializeComponent();
        }
	
		//ฟังก์ชันเพิ่มข้อมูลสินค้า
		private void btnsave_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            sql = $@"INSERT INTO [Test_INVENTITEMBARCODE]
							(
								 [ITEMBARCODE],
								 [ITEMID], 
								 [INVENTDIMID], 
								 [UNITID], 
								 [SPC_ITEMACTIVE],
								 [SPC_PRICEGROUP3],
								 [SPC_ITEMNAME],
								 [SPC_IMAGEPATH],
								 [DATAAREAID],
								 [SPC_ITEMBUYERGROUPID]		
							)
					 VALUES
							(
								 @ITEMBARCODE,
								 @ITEMID,
								 @INVENTDIMID,
								 @UNITID,
								 @SPC_ITEMACTIVE,
								 @SPC_PRICEGROUP3,
								 @SPC_ITEMNAME,
								 @SPC_IMAGEPATH,
								 @DATAAREAID,
								 @SPC_ITEMBUYERGROUPID		
							)";

			using (SqlConnection connect1 = new SqlConnection(connection))
			{
				connect1.Open();
				SqlTransaction transaction = connect1.BeginTransaction("Add");
				try
                {					
					using (SqlCommand command1 = new SqlCommand()
					{
						Connection = connect1,
						CommandType = CommandType.Text,
						CommandText = sql,
						Transaction = transaction						
					})
					{
						command1.Parameters.AddWithValue("@ITEMBARCODE", txtbarcode.Text);
						command1.Parameters.AddWithValue("@ITEMID", txtitemid.Text);
						command1.Parameters.AddWithValue("@INVENTDIMID", txtinventdimid.Text);
						command1.Parameters.AddWithValue("@UNITID", txtunitid.Text);
						command1.Parameters.AddWithValue("@SPC_PRICEGROUP3", txtptice3.Text);
						command1.Parameters.AddWithValue("@SPC_ITEMNAME", txtitemname.Text);
						command1.Parameters.AddWithValue("@SPC_IMAGEPATH", txtimage.Text);
						command1.Parameters.AddWithValue("@SPC_ITEMBUYERGROUPID", txtitembyergroup.Text);
						command1.Parameters.AddWithValue("@SPC_ITEMACTIVE", 1);
						command1.Parameters.AddWithValue("@DATAAREAID", "spc");
						command1.ExecuteNonQuery();	
					}

					transaction.Commit();
					this.txtbarcode.Text = "";
					this.txtitemid.Text = "";
					this.txtinventdimid.Text = "";
					this.txtunitid.Text = "";
					this.txtptice3.Text = "";
					this.txtitemname.Text = "";
					this.txtimage.Text = "";
					this.txtitembyergroup.Text = "";

					MessageBox.Show("บันทึกเรียบร้อย", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
                catch (Exception ex)
                {
					MessageBox.Show("Error : " + ex.Message);
					//MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        
    }
}
