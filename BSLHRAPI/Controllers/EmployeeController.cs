using BSLHRAPI.DAL;
using BSLHRAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BSLHRAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee

        DALEmployee _DALEmployee = new DALEmployee();

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Employee/Fn_Add_Employee")]
        public clsEmployee Fn_Add_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            objResp = _DALEmployee.Fn_Add_Employee(objReq);
            return objResp;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Employee/Fn_Update_Employee")]
        public clsEmployee Fn_Update_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            objResp = _DALEmployee.Fn_Update_Employee(objReq);
            return objResp;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Employee/Fn_Delete_Employee")]
        public clsEmployee Fn_Delete_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            objResp = _DALEmployee.Fn_Delete_Employee(objReq);
            return objResp;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Employee/Fn_LogIn_Employee")]
        public clsEmployee Fn_LogIn_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            objResp = _DALEmployee.Fn_LogIn_Employee(objReq);
            return objResp;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Employee/Fn_Get_All_Employee")]
        public List<clsEmployee> Fn_Get_All_Employee(clsEmployee objReq)
        {
            var objResp = new List<clsEmployee>();
            objResp = _DALEmployee.Fn_Get_All_Employee(objReq);
            return objResp;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Employee/Fn_Get_EmployeeByID")]
        public clsEmployee Fn_Get_EmployeeByID(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            objResp = _DALEmployee.Fn_Get_EmployeeByID(objReq);
            return objResp;
        }
    }
}