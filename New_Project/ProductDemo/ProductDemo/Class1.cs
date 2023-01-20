using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProductDemo
{
    class Customer
    {
        static string connection = "server = spcn1681; database = test ; User Id =sa ; Password = Ca999999";

        
        public static  DataTable GetBarCode()
        {
            DataTable data = new DataTable();
            SqlConnection connect = new SqlConnection(connection);
            connect.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connect;
            command.CommandType = CommandType.Text;
            command.CommandText = $@"SELECT T1.[ITEMBARCODE], T1.[ITEMID], T1.[INVENTDIMID], T1.[UNITID], T1.[SPC_PRICEGROUP3]
	                                        ,T1.[SPC_ITEMNAME], T1.[SPC_IMAGEPATH], T1.[SPC_ITEMBUYERGROUPID] 
	                                        ,T2.[PRIMARYVENDORID], T3.[NAME], T4.[DESCRIPTION]
                                    FROM  [Test_INVENTITEMBARCODE] T1
                                    INNER JOIN [Test_INVENTTABLE] T2 ON  T1.[ITEMID] = T2.[ITEMID]
                                    AND T1.[DATAAREAID] = 'spc'
                                    INNER JOIN [Test_VENDTABLE] T3 ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
                                    AND T2.[DATAAREAID] = 'spc'
                                    INNER JOIN [Test_DIMENSIONS] T4 ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
                                    AND T3.[DATAAREAID] = 'spc'
                                    AND T4.[DATAAREAID] = 'spc'";

            SqlDataReader Texts = command.ExecuteReader();
            if (Texts.HasRows)
            {
                data.Load(Texts);
            }
            return data;

        }

        
        



        
    }
}
