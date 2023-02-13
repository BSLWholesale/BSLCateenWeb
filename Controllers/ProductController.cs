using BSLWeb.Models;
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

        
    }
}