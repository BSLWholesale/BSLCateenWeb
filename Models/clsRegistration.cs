using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSLWeb.Models
{
    public class clsRegistration
    {
        public int CustId { get; set; }
        public string CFirstName { get; set; }
        public string CLastName { get; set; }
        public string CMobileNo { get; set; }
        public string CEmailId { get; set; }
        public string CAddress { get; set; }
        public int CActive { get; set; }
        public string CUserStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } // Datatype change
        public DateTime CreatedOn { get; set; } // Datatype change
        public string CPassword { get; set; }
        public string CDOB { get; set; }
        public string CCompanyName { get; set; }
        public string ErrorMsg { get; set; }
    }
}