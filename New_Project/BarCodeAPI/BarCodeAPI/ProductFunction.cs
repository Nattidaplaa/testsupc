using BarCodeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BarCodeAPI
{
    public class ProductFunction
    {
        static string connection = "Data source = spcn1681; database = test;  User ID= SA;Password= Ca999999";

        #region แสดงข้อมูลเฉยๆ
        public static DataTable GetProduct()
        {

            string sql = $@"  SELECT   TOP(20)   T1.[ITEMBARCODE], 
                                                    T1.[ITEMID], 
                                                    T1.[INVENTDIMID], 
                                                    T1.[UNITID], 
                                                    T1.[SPC_PRICEGROUP3],
	                                                T1.[SPC_ITEMNAME],  
                                                    T1.[SPC_IMAGEPATH] AS SPC_IMAGEPATH, 
                                                    T1.[SPC_ITEMBUYERGROUPID],           
                                                    T2.[PRIMARYVENDORID], 
                                                    T3.[NAME], 
                                                    T4.[DESCRIPTION]
                                FROM  [Test_INVENTITEMBARCODE] T1
                                LEFT JOIN [Test_INVENTTABLE] T2 ON  T1.[ITEMID] = T2.[ITEMID]
                                AND     T1.[DATAAREAID] = 'spc'
                                LEFT JOIN [Test_VENDTABLE] T3 ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
                                AND     T2.[DATAAREAID] = 'spc'
                                LEFT JOIN [Test_DIMENSIONS] T4 ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
                                AND     T3.[DATAAREAID] = 'spc'
                                AND     T4.[DATAAREAID] = 'spc' ";

            DataTable data = new DataTable();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data.Clear();
                    data.Load(reader);
                }
                return data;
            }
        }
        #endregion


        //search
        public static DataTable SearchProduct(string ITEMBARCODE)
        {
            string sql1 = string.Empty;

            sql1 = $@";WITH CTE AS
                                (
	                                SELECT [ITEMID], [INVENTDIMID]
	                                FROM   [Test_INVENTITEMBARCODE]
                                    WHERE [ITEMBARCODE] = COALESCE(NULLIF('{ITEMBARCODE}',''), [ITEMBARCODE])
                                    
	                                
                                )
                                    SELECT    T1.[ITEMBARCODE], 
				                                      T1.[ITEMID], 
				                                      T1.[INVENTDIMID], 
				                                      T1.[UNITID], 
				                                      T1.[SPC_PRICEGROUP3] ,
	                                                  T1.[SPC_ITEMNAME] , 
				                                      T1.[SPC_IMAGEPATH] AS SPC_IMAGEPATH, 
				                                      T1.[SPC_ITEMBUYERGROUPID] ,
                                                      T1.[SPC_ITEMACTIVE] ,
	                                                  T2.[PRIMARYVENDORID], 
				                                      T3.[NAME], 
				                                      T4.[DESCRIPTION] 

                                    FROM        [Test_INVENTITEMBARCODE] T1 WITH(NOLOCK)
                                    RIGHT JOIN  [Test_INVENTTABLE] T2 WITH(NOLOCK) ON  T1.[ITEMID] = T2.[ITEMID]
                                    AND         T1.[DATAAREAID] = 'spc'
                                    RIGHT JOIN  [Test_VENDTABLE] T3 WITH(NOLOCK) ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
                                    AND         T2.[DATAAREAID] = 'spc'
                                    RIGHT JOIN  [Test_DIMENSIONS] T4 WITH(NOLOCK) ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
                                    AND         T3.[DATAAREAID] = 'spc'
                                    AND         T4.[DATAAREAID] = 'spc'
                                    RIGHT JOIN  CTE WITH(NOLOCK) ON CTE.[ITEMID] = T1.[ITEMID] 
                                    AND         CTE.[INVENTDIMID] = T1.[INVENTDIMID] ";

            DataTable data = new DataTable();

            SqlConnection connect1 = new SqlConnection(connection);
            connect1.Open();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = connect1;
            command1.CommandType = CommandType.Text;
            command1.CommandText = sql1;
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows)
            {
                data.Clear();
                data.Load(reader);
            }
            return data;

        }

        //function update
        public static bool UpdateProduct(ProductModel dat)
        {
            var result = 0;

            using (SqlConnection connect1 = new SqlConnection(connection))
            {

                string sql2 = $@"UPDATE  [Test_INVENTITEMBARCODE]
                            SET		[ITEMBARCODE] = COALESCE(NULLIF('{dat.ITEMBARCODE}',''), ITEMBARCODE),
                                    [ITEMID] = COALESCE(NULLIF('{dat.ITEMID}',''), ITEMID),
                                    [UNITID] = COALESCE(NULLIF(N'{dat.UNITID}',''), UNITID),
                                    [SPC_PRICEGROUP3] = COALESCE(NULLIF('{dat.SPC_PRICEGROUP3}',''), SPC_PRICEGROUP3) ,
                                    [SPC_ITEMNAME] = COALESCE(NULLIF(N'{dat.SPC_ITEMNAME}',''), SPC_ITEMNAME),                                  
                                    [SPC_IMAGEPATH] = COALESCE(NULLIF('{dat.SPC_IMAGEPATH}',''), SPC_IMAGEPATH),
                                    [SPC_ITEMBUYERGROUPID] = COALESCE(NULLIF('{dat.SPC_ITEMBUYERGROUPID}',''), SPC_ITEMBUYERGROUPID),
                                    [SPC_ITEMACTIVE] = COALESCE(NULLIF('{dat.SPC_ITEMACTIVE}',''), SPC_ITEMACTIVE)

                            WHERE   [ITEMBARCODE] = '{dat.ITEMBARCODE}'
                            AND	    [ITEMID] = '{dat.ITEMID}'
                            AND     [INVENTDIMID] = '{dat.INVENTDIMID}'";


                connect1.Open();

                SqlCommand command1 = new SqlCommand();

                command1.Connection = connect1;
                command1.CommandType = CommandType.Text;
                command1.CommandText = sql2;

                result = command1.ExecuteNonQuery(); //มีแค่นี้พอแล้ว

            }
            return result == 1;
        }

        //function add
        public static bool InsertProduct(ProductModelAdd dat)
        {
            var result = 0;

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

                SqlCommand command1 = new SqlCommand();
                command1.Connection = connect1;
                command1.CommandType = CommandType.Text;
                command1.CommandText = sql;

                {
                    command1.Parameters.AddWithValue("@ITEMBARCODE", dat.ITEMBARCODE);
                    command1.Parameters.AddWithValue("@ITEMID", dat.ITEMID);
                    command1.Parameters.AddWithValue("@INVENTDIMID", dat.INVENTDIMID);
                    command1.Parameters.AddWithValue("@UNITID", dat.UNITID);
                    command1.Parameters.AddWithValue("@SPC_PRICEGROUP3", dat.SPC_PRICEGROUP3);
                    command1.Parameters.AddWithValue("@SPC_ITEMNAME", dat.SPC_ITEMNAME);
                    command1.Parameters.AddWithValue("@SPC_IMAGEPATH", dat.SPC_IMAGEPATH);
                    command1.Parameters.AddWithValue("@SPC_ITEMBUYERGROUPID", dat.SPC_ITEMBUYERGROUPID);
                    command1.Parameters.AddWithValue("@SPC_ITEMACTIVE", 1);
                    command1.Parameters.AddWithValue("@DATAAREAID", "spc");
                }

                result = command1.ExecuteNonQuery();

            }

            return result == 1;
        }

        public static bool DeleteProduct(string ITEMBARCODE)
        {

            var result = 0;
            string sql3 = string.Empty;
            sql3 = $@"  DELETE [Test_INVENTITEMBARCODE]
                        WHERE [ITEMBARCODE] = '{ITEMBARCODE}'";

            using (SqlConnection connect1 = new SqlConnection(connection))
            {

                connect1.Open();

                SqlCommand command1 = new SqlCommand();

                command1.Connection = connect1;
                command1.Connection = connect1;
                command1.CommandType = CommandType.Text;
                command1.CommandText = sql3;
                result = command1.ExecuteNonQuery();

            }
            return result == 1;
        }

        public static DataTable SelectNum()
        {
            DataTable table = new DataTable();
            string sqlNUMS = $@"    SELECT [NUM], 
                                    [NUM]+ ' : ' +[DESCRIPTION] AS NewNum
                                    FROM [Test_DIMENSIONS]
                                    WHERE DIMENSIONCODE = 0 AND DESCRIPTION  LikE N'จัดซื้อ%'";

            SqlConnection connect1 = new SqlConnection(connection);

            connect1.Open();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = connect1;
            command1.Connection = connect1;
            command1.CommandType = CommandType.Text;
            command1.CommandText = sqlNUMS;

            var result = command1.ExecuteReader();
            if (result.HasRows)
            {
                table.Load(result);
            }
            return table;

        }


        #region ฟังก์ชัน login
        //public static bool Login(LoginModel dat)
        //{
        //    var result1 = 0;

        //    string sqlLogin = string.Empty;
        //    sqlLogin = $@"SELECT [EMPLOYEE],
        //                         [PASSWORD]
        //                  FROM   [Test_LoginEmployee]
        //                  WHERE  [EMPLOYEE] = @EMPLOYEE
        //                  AND    [PASSWORD] = @PASSWORD
        //                 ";

        //    using (SqlConnection connect1 = new SqlConnection(connection))
        //    {
        //        connect1.Open();

        //        SqlCommand command1 = new SqlCommand();
        //        command1.Connection = connect1;
        //        command1.CommandType = CommandType.Text;
        //        command1.CommandText = sqlLogin;
        //        {
        //            command1.Parameters.AddWithValue("@EMPLOYEE", dat.EMPLOYEE);
        //            command1.Parameters.AddWithValue("@PASSWORD", dat.PASSWORD);
        //        }
        //        result1 = command1.ExecuteNonQuery();
        //    }
        //    return result1 == 1;
        //}

        #endregion

        public static DataTable Login(string EMPLOYEE, string PASSWORD)
        {
            string sqlLogin = string.Empty;

            sqlLogin = $@"SELECT [EMPLOYEE],
                               [PASSWORD]
                        FROM [Test_LoginEmployee]
                        WHERE [EMPLOYEE] = '{EMPLOYEE}'
                        AND   [PASSWORD] = '{PASSWORD}' ";

            DataTable data = new DataTable();

            SqlConnection connect1 = new SqlConnection(connection);
            connect1.Open();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = connect1;
            command1.CommandType = CommandType.Text;
            command1.CommandText = sqlLogin;
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows)
            {
                data.Clear();
                data.Load(reader);
            }
            return data;

        }



    }

}



