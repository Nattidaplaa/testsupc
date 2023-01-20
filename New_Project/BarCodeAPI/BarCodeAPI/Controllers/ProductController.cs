using BarCodeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCodeAPI.Controllers
{
    [ApiController]

    public class ProductController : ControllerBase
    {


        [HttpGet, Route("api/[controller]/GetBarAll")]
        public ActionResult<List<ProductModel>> GetBarAll()
        {
            //เรียกใช้ฟังก์ชัน
            try
            {
                var x = ProductFunction.GetProduct(); //เรียกใช้ class กับ function

                List<ProductModel> product = new List<ProductModel>();
                for (int i = 0; i < x.Rows.Count; i++) //check จำนวนแถวใน datatable
                {
                    product.Add(new ProductModel()
                    {
                        ITEMBARCODE = x.Rows[i]["ITEMBARCODE"].ToString(),
                        ITEMID = x.Rows[i]["ITEMID"].ToString(),
                        INVENTDIMID = x.Rows[i]["INVENTDIMID"].ToString(),
                        UNITID = x.Rows[i]["UNITID"].ToString(),
                        SPC_PRICEGROUP3 = x.Rows[i]["SPC_PRICEGROUP3"].ToString(),
                        SPC_ITEMNAME = x.Rows[i]["SPC_ITEMNAME"].ToString(),
                        SPC_IMAGEPATH = x.Rows[i]["SPC_IMAGEPATH"].ToString(),
                        SPC_ITEMBUYERGROUPID = x.Rows[i]["SPC_ITEMBUYERGROUPID"].ToString(),
                        SPC_ITEMACTIVE = Convert.ToInt32(1),
                        PRIMARYVENDORID = x.Rows[i]["PRIMARYVENDORID"].ToString(),
                        NAME = x.Rows[i]["NAME"].ToString(),
                        DESCRIPTION = x.Rows[i]["DESCRIPTION"].ToString()
                    });
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }


        #region
        /*
        [HttpGet, Route("api/[controller]/GetBarCode")]
        public ActionResult<List<ProductModel>> GetBarCode(string ITEMBARCODE)
        {
            //เรียกใช้ฟังก์ชัน
            try
            {
                var x = ProductFunction.SearchProduct(ITEMBARCODE); //เรียกใช้ class กับ function
                
                List<ProductModel> product = new List<ProductModel>();
                for (int i = 0; i < x.Rows.Count; i++) //check จำนวนแถวใน datatable
                {
                    product.Add(new ProductModel()
                    {
                        ITEMBARCODE = x.Rows[i]["ITEMBARCODE"].ToString(),
                        ITEMID = x.Rows[i]["ITEMID"].ToString(),
                        INVENTDIMID = x.Rows[i]["INVENTDIMID"].ToString(),
                        UNITID = x.Rows[i]["UNITID"].ToString(),
                        SPC_PRICEGROUP3 = x.Rows[i]["SPC_PRICEGROUP3"].ToString(),
                        SPC_ITEMNAME = x.Rows[i]["SPC_ITEMNAME"].ToString(),
                        SPC_IMAGEPATH = x.Rows[i]["SPC_IMAGEPATH"].ToString(),
                        SPC_ITEMBUYERGROUPID = x.Rows[i]["SPC_ITEMBUYERGROUPID"].ToString(),
                        SPC_ITEMACTIVE = Convert.ToInt32(1),
                        PRIMARYVENDORID = x.Rows[i]["PRIMARYVENDORID"].ToString(),
                        NAME = x.Rows[i]["NAME"].ToString(),
                        DESCRIPTION = x.Rows[i]["DESCRIPTION"].ToString()
                    });
                }
               
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
        */
        #endregion


        [HttpGet, Route("api/[controller]/SearchBarCode1")]
        public ActionResult<List<ProductModel>> SearchBarCode1(string ITEMBARCODE)
        {
            //เรียกใช้ฟังก์ชัน
            try
            {
                var x = ProductFunction.SearchProduct(ITEMBARCODE); //เรียกใช้ class กับ function

                List<ProductModel> product = new List<ProductModel>();
                for (int i = 0; i < x.Rows.Count; i++) //check จำนวนแถวใน datatable
                {
                    product.Add(new ProductModel()
                    {
                        ITEMBARCODE = x.Rows[i]["ITEMBARCODE"].ToString(),
                        ITEMID = x.Rows[i]["ITEMID"].ToString(),
                        INVENTDIMID = x.Rows[i]["INVENTDIMID"].ToString(),
                        UNITID = x.Rows[i]["UNITID"].ToString(),
                        SPC_PRICEGROUP3 = x.Rows[i]["SPC_PRICEGROUP3"].ToString(),
                        SPC_ITEMNAME = x.Rows[i]["SPC_ITEMNAME"].ToString(),
                        SPC_IMAGEPATH = x.Rows[i]["SPC_IMAGEPATH"].ToString(),
                        SPC_ITEMBUYERGROUPID = x.Rows[i]["SPC_ITEMBUYERGROUPID"].ToString(),
                        SPC_ITEMACTIVE = Convert.ToInt32(1),
                        PRIMARYVENDORID = x.Rows[i]["PRIMARYVENDORID"].ToString(),
                        NAME = x.Rows[i]["NAME"].ToString(),
                        DESCRIPTION = x.Rows[i]["DESCRIPTION"].ToString()
                    });
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }


        //update
        [HttpPost, Route("api/[controller]/UpdateBarCode")]
        public ActionResult<List<ProductModel>> UpdateBarCode([FromBody] ProductModel data)
        {
            //เรียกใช้ฟังก์ชัน
            try
            {
                bool x = ProductFunction.UpdateProduct(data);       //เรียกใช้ class กับ function
                ResponesModel result = new ResponesModel();

                result.Secces = true;               
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }


        //insert
        [HttpPost, Route("api/[controller]/InsertBarCode")]
        public ActionResult<List<ProductModelAdd>> InsertBarCode([FromBody] ProductModelAdd data)
        {
            //เรียกใช้ฟังก์ชัน
            try
            {

                ProductModelAdd result = new ProductModelAdd();
                result.ITEMBARCODE = data.ITEMBARCODE;
                result.ITEMID = data.ITEMID;
                result.INVENTDIMID = data.INVENTDIMID;
                result.UNITID = data.UNITID;
                result.SPC_PRICEGROUP3 = data.SPC_PRICEGROUP3;
                result.SPC_ITEMNAME = data.SPC_ITEMNAME;
                result.SPC_IMAGEPATH = data.SPC_IMAGEPATH;
                result.SPC_ITEMBUYERGROUPID = data.SPC_ITEMBUYERGROUPID;


                bool x = ProductFunction.InsertProduct(result); //เรียกใช้ class กับ function

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        //dalete function

        [HttpGet, Route("api/[controller]/DeleteBarCode")]
        public ActionResult DeleteBarCode(string ITEMBARCODE)
        {
            //เรียกใช้ฟังก์ชัน
            try
            {
                bool x = ProductFunction.DeleteProduct(ITEMBARCODE); //เรียกใช้ class กับ function
                //ProductModel result = new ProductModel();
                //result.ITEMBARCODE = ITEMBARCODE;
                //result.SPC_ITEMACTIVE = SPC_ITEMACTIVE;
               

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        //ดึงรหัสแผนกมาเพื่อเลือก
        [HttpGet, Route("api/[controller]/NUMS")]
        public ActionResult NUMS()
        {
            //เรียกใช้ฟังก์ชัน
            try
            {
                var x = ProductFunction.SelectNum(); //เรียกใช้ class กับ function
                List<NUMSModel1> NUM = new List<NUMSModel1>();
                for (int i = 0; i< x.Rows.Count; i++)
                {
                    NUM.Add(new NUMSModel1()
                    {
                        Num = x.Rows[i]["NUM"].ToString(),
                        Name = x.Rows[i]["NewNum"].ToString(),
                    });            
                }

                return Ok(NUM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        #region
        //[HttpPost, Route("api/[controller]/LoingEmployee")]
        //public ActionResult<List<LoginModel>> LoingEmployee([FromBody] LoginModel data)
        //{
        //    //เรียกใช้ฟังก์ชัน
        //    try
        //    {

        //        LoginModel result1 = new LoginModel();
        //        result1.EMPLOYEE = data.EMPLOYEE;
        //        result1.PASSWORD = data.PASSWORD;

        //        bool x = ProductFunction.Login(result1); //เรียกใช้ class กับ function

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.ToString());
        //    }
        //}
        #endregion



        //function login api
        [HttpGet, Route("api/[controller]/LoginEmployee")] 
        public ActionResult<List<LoginModel>> LoginEmployee(string EMPLOYEE, string PASSWORD)
        {
            //เรียกใช้ฟังก์ชัน
            try
            {
                var x = ProductFunction.Login(EMPLOYEE, PASSWORD); //เรียกใช้ class กับ function

                List<LoginModel> Employee = new List<LoginModel>();
                for (int i = 0; i < x.Rows.Count; i++) //check จำนวนแถวใน datatable
                {
                    Employee.Add(new LoginModel()
                    {
                        EMPLOYEE = x.Rows[i]["EMPLOYEE"].ToString(),
                        PASSWORD = x.Rows[i]["PASSWORD"].ToString(),
                    });
                }
                return Ok(Employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }








    }
}
