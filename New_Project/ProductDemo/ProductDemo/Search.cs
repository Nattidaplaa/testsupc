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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        static string connection = "server = spcn1681; database = test ; User Id =sa ; Password = Ca999999";

        public static DataTable Searchs(string Itembarcode)
        {
            DataTable dt = new DataTable();
            SqlConnection connect1 = new SqlConnection(connection);
            connect1.Open();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = connect1;
            command1.CommandType = CommandType.Text;
            string sql = $@"DECLARE @ITEMBARCODE nvarchar(MAX) = '' ;
                            SELECT [ITEMID], [INVENTDIMID], [SPC_IMAGEPATH]
                            FROM [Test_INVENTITEMBARCODE]
                            WHERE [ITEMBARCODE] = COALESCE(NULLIF(@ITEMBARCODE , '' ) , [ITEMBARCODE] )
                            AND  [ITEMBARCODE] = '{Itembarcode}'";

            SqlDataReader Texts1 = command1.ExecuteReader();
            if (Texts1.HasRows)
            {
                dt.Load(Texts1);
            }
            return dt;

        }
    }
}
