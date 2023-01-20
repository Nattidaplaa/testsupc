using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCodeAPI.Models
{
    public class ProductModelAdd
    {
        public string ITEMBARCODE { get; set; } = "";
        public string ITEMID { get; set; } = "";
        public string INVENTDIMID { get; set; } = "";
        public string UNITID { get; set; } = "";
        public string SPC_PRICEGROUP3 { get; set; } = "";
        public string SPC_ITEMNAME { get; set; } = "";
        public string SPC_IMAGEPATH { get; set; } = "";
        public string SPC_ITEMBUYERGROUPID { get; set; } = "";
        public int SPC_ITEMACTIVE { get; set; } = 0;
       

    }

    public class ProductModel
    {
        public  string ITEMBARCODE { get; set; } = "";
        public  string ITEMID { get; set; } = "";
        public  string INVENTDIMID { get; set; } = "";
        public  string UNITID { get; set; } = "";
        public string SPC_PRICEGROUP3 { get; set; } = "";
        public  string SPC_ITEMNAME { get; set; } = "";
        public  string SPC_IMAGEPATH { get; set; } = "";
        public  string SPC_ITEMBUYERGROUPID { get; set; } = "";
        public  int SPC_ITEMACTIVE { get; set; } = 0;
        public string PRIMARYVENDORID { get; set; } = "";
        public string NAME { get; set; } = "";
        public string DESCRIPTION { get; set; } = "";
    }

    //ดัก error 
    public class ResponesModel
    {
        public string Message { get; set; } = "";
        public bool Secces { get; set; } = false;
        public List<ProductModel> Data {get; set;} = new List<ProductModel>();
    }

    public class ResponesModel1
    {
        public string Message { get; set; } = "";
        public bool Secces { get; set; } = false;
        public ProductModel Data { get; set; } = new ProductModel();
    }

    public class NUMSModel1
    {
        public string Num { get; set; } = "";
        public string Name { get; set; } = "";
        
    }


    public class LoginModel
    {
        public string EMPLOYEE { get; set; } = "";
        public string PASSWORD { get; set; } = "";

    }
}
