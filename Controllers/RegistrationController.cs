using BSLWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BSLWeb.Controllers
{
    public class RegistrationController : Controller
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSL"].ConnectionString);
        
        // GET: Registration
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Registration

        [HttpPost]
        public JsonResult Fn_Registration(clsRegistration _Register)
        {
            using (var client = new HttpClient())
            {

                //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["UID"] + ":" + ConfigurationManager.AppSettings["PWD"]);

                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(_Register);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/CustomizeAPI/Fn_Customer_Register", content).Result;
                if (responsePost.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = responsePost.Content.ReadAsStringAsync().Result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Faild to register." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}