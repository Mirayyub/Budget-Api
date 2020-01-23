using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Budget.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        [MaxLength(50, ErrorMessage = "Email can be a maximum of 50 characters")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The password cannot be empty")]
        [MaxLength(100, ErrorMessage = "The password can have a maximum of 100 characters")]
        [MinLength(6, ErrorMessage = "The password can have a minimum of 6 characters")]
        public string Password { get; set; }
    }
}