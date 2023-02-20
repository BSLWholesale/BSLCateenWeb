using BSLWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BSLWeb.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSL"].ConnectionString);
        // GitProject

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("LogIn");
        }


        //
        [HttpPost]
        public JsonResult Fn_Get_LogIn(clsLogin login)
        {
            using (var client = new HttpClient())
            {

                //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["UID"] + ":" + ConfigurationManager.AppSettings["PWD"]);

                client.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BSLWebApiURL"]));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(login);

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage responsePost = client.PostAsync("api/CustomizeAPI/Fn_Get_Login", content).Result;
                if (responsePost.IsSuccessStatusCode)
                {
                    var data = responsePost.Content.ReadAsStringAsync().Result;
                    //string[]  strsp = data.Split(",");
                    //string strUser = strsp[0].ToString();
                    Session["strUser"] = data[2].ToString();
                    string uname = data[1].ToString();
                    Session["UserId"] = data[1].ToString();
                    login.Id = data[1];
                    //HttpCookie cookie = new HttpCookie("Cookie");
                    //cookie["userid"] = rdr["Email"].ToString();
                    //cookie["pass"] = rdr["UPassword"].ToString();
                    //Response.Cookies.Add(cookie);
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