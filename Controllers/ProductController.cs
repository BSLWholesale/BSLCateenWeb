using BSLWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static BSLWeb.Models.clsProduct;

namespace BSLWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSL"].ConnectionString);

        public ActionResult Yarn()
        {
            return View();
        }

        public ActionResult Fabric()
        {
            return View();
        }

        public ActionResult Garments()
        {
            return View();
        }

        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult Cart()
        {
            try
            {
                int vCustomerId = Convert.ToInt32(Session["UserId"]);
                string strSql = "Select * from Temp_Cart where CustomerId='" + Convert.ToString(vCustomerId) + "'";
                SqlDataAdapter da = new SqlDataAdapter(strSql, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                var _productmodel = new List<clsProductCart>();
                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    while (ds.Tables[0].Rows.Count > i)
                    {
                        var cart_item = new clsProductCart();
                        cart_item.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                        cart_item.vCategory = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                        cart_item.nProductId = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductId"]);
                        cart_item.vProductName = Convert.ToString(ds.Tables[0].Rows[i]["ProductName"]);
                        cart_item.vGround = Convert.ToString(ds.Tables[0].Rows[i]["Ground"]);
                        cart_item.vBorder = Convert.ToString(ds.Tables[0].Rows[i]["Border"]);
                        cart_item.vSize = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                        cart_item.nQuantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                        cart_item.vPrice = Convert.ToString(ds.Tables[0].Rows[i]["Price"]);
                        cart_item.vCustomerId = Convert.ToString(ds.Tables[0].Rows[i]["CustomerId"]);
                        cart_item.vOrderId = Convert.ToString(ds.Tables[0].Rows[i]["OrderId"]);

                        //01 March 2023

                        //01 March 2023

                        _productmodel.Add(cart_item);
                        i++;
                    }
                    return View(_productmodel);
                }
                else
                {
                    ViewBag.ErrMessage = "No Record found";
                    return View();
                }
            }
            catch (Exception exp)
            {
                exp.Message.ToString();
            }
            return View();
        }

        [HttpPost]
        public JsonResult Fn_Get_Count_Cart_Item(clsRequestProduct obj)
        {
            string strCount = "0";
            try
            {
                if (con.State == ConnectionState.Broken)
                { con.Close(); }
                if (con.State == ConnectionState.Closed)
                { con.Open(); }

                string strSql = "Select Count(*) as RC from Temp_Cart where CustomerId='" + obj.vCustomerId + "'";
                SqlCommand cmd = new SqlCommand(strSql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    strCount = dr["RC"].ToString();
                    return Json(new { success = true, message = strCount }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, message = strCount }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception exp)
            {
                exp.Message.ToString();
                return Json(new { success = true, message = strCount }, JsonRequestBehavior.AllowGet); ;
            }
        }

        // Delete Cart Items
        [HttpPost]
        public JsonResult Fn_Delete_Cart_Item(clsDeleteProduct obj)
        {
            string strDelCount = "0";
            try
            {
                if (con.State == ConnectionState.Broken)
                { con.Close(); }
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                // obj.vCustomerId = Convert.ToString(Session["UserId"]);
                string strSql = "Delete from Temp_Cart where CustomerId='" + obj.vCustomerId + "' and ProductId=" + obj.nProductId;
                SqlCommand cmd = new SqlCommand(strSql, con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                    return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "Faild" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json(new { success = false, message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet); ;
            }
        }
        // End Delete Cart Items


        // Get Product Details
        [HttpPost]
        public JsonResult Fn_Get_Product_Details(clsProductDetails obj)
        {
            string strCount = "0";
            try
            {
                if (con.State == ConnectionState.Broken)
                { con.Close(); }
                if (con.State == ConnectionState.Closed)
                { con.Open(); }

                string strSql = "Select * from MaterialMast";
                SqlCommand cmd = new SqlCommand(strSql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    return Json(new { success = true, message = "Product Details" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Product Details Not Found" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json(new { success = true, message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet); ;
            }
        }
        // End Product Details

        [HttpPost]
        public JsonResult Fn_Save_CustomizeData(clsCustomize cs)
        {
            using (var client = new HttpClient())
            {

                //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["UID"] + ":" + ConfigurationManager.AppSettings["PWD"]);

                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(cs);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/CustomizeAPI/Fn_Save_CustomizeData", content).Result;
                if (responsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = responsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No data found." }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        // Insert Cart

        [HttpPost]
        public JsonResult Fn_Insert_Cart(clsRequestProduct cs)
        {
            clsProduct.clsResponseProduct objResp = new clsProduct.clsResponseProduct();
            using (var client = new HttpClient())
            {
                cs.vCustomerId = Session["UserId"].ToString();
                //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["UID"] + ":" + ConfigurationManager.AppSettings["PWD"]);
                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(cs);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/ProductAPI/Fn_Insert_Cart", content).Result;
                if (responsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = responsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No data found." }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        // Insert Cart Yarn Products 01 March 2023
        [HttpPost]
        public JsonResult Fn_Yarn_Insert_Cart(clsRequestProduct cs)
        {
            clsProduct.clsResponseProduct yresponse = new clsProduct.clsResponseProduct();
            using (var client = new HttpClient())
            {
                cs.vCustomerId = Session["UserId"].ToString();
                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string Data = Newtonsoft.Json.JsonConvert.SerializeObject(cs);

                HttpContent content = new StringContent(Data, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/ProductAPI/Fn_Yarn_Insert_Cart", content).Result;

                //HttpResponseMessage responsePost = client.PostAsync("api/YarnProductAPI/Fn_Yarn_Insert_Cart", content).Result;

                if (responsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = responsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No data found." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        // Insert Cart Yarn Products 01 March 2023

        // Insert Cart Garments Products 08 March 2023
        [HttpPost]
        public JsonResult Fn_RMG_Insert_Cart(clsRequestProduct cs)
        {
            clsProduct.clsResponseProduct rmgresponse = new clsProduct.clsResponseProduct();
            using (var client = new HttpClient())
            {
                cs.vCustomerId = Session["UserId"].ToString();
                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(cs);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/ProductAPI/Fn_RMG_Insert_Cart", content).Result;

                if (responsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = responsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No data found." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        // Insert Cart Garments Products 08 March 2023

        public ActionResult Product()
        {
            return View();
        }
        // Get All data
        [HttpPost]
        public JsonResult Fn_Get_All_MaterialMaster(clsRequestProduct cs)
        {
            // clsProduct.clsResponseProduct objResp = new clsProduct.clsResponseProduct();
            using (var client = new HttpClient())
            {
                cs.vCustomerId = Session["UserId"].ToString();
                //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["UID"] + ":" + ConfigurationManager.AppSettings["PWD"]);
                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(cs);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/ProductAPI/Fn_Get_All_MaterialMaster", content).Result;
                if (responsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = responsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No data found." }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        // Retreive all data of Yarn Master 02 March 2023
        [HttpPost]
        public JsonResult Fn_Get_All_YarnMaster(clsRequestProduct cs)
        {
            using (var client = new HttpClient())
            {
                cs.vCustomerId = Session["UserId"].ToString();
                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(cs);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/ProductAPI/Fn_Get_All_YarnMaster", content).Result;
                if (responsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = responsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No data found." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        // Retreive all data of Yarn Master 02 March 2023


        // Retreive all data of Garments Master 08 March 2023
        [HttpPost]
        public JsonResult Fn_Get_All_RMGMaster(clsRequestProduct cs)
        {
            using (var client = new HttpClient())
            {
                cs.vCustomerId = Session["UserId"].ToString();
                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(cs);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage respnsePost = client.PostAsync("api/ProductAPI/Fn_Get_All_RMGMaster", content).Result;
                if (respnsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = respnsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No data found." }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        // Retreive all data of Garments Master 08 March 2023
    }
}
