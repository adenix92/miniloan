using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace minpipWebApp.Models
{
    public class _SignIn
    {
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is Required",AllowEmptyStrings =false)]
        public string UserName { get; set; }

        [Display(Description = "Password", Name = "Password")]
        [Required(ErrorMessage = "Password Required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        

    }
}