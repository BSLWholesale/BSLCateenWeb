using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BSLWeb.Models
{
    public class clsLogin
    {
        public int Id { get; set; }
        public int IsActive { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string UPassword { get; set; }
    }
}