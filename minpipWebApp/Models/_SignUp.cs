using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _SignUp
    {
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
       
        public string UserName { get; set; }

        [Display(Description = "Password", Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Title", Description = "Optional")]
        public string Title { get; set; }
        [Display(Name = "Surname", Description = "Surname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is Required")]
        [DataType(DataType.Text)]
        public string SurName { get; set; }

        [Display(Name = "Firstname", Description = "Firstname")]
        [Required(ErrorMessage = "Firstname is Required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [Display(Name = "Othername", Description = "Othername")]
        [DataType(DataType.Text, ErrorMessage = "Other name is Required")]
        [Required(AllowEmptyStrings = false)]
        public string OtherName { get; set; }

        [Display(Name = "Email", Description = "Valid Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Valid Email Required")]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        //public string Passwords { get; set; }

        [Display(Name = "Phone No.", Description = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }


        public System.DateTime DateRegister { get; set; }
        public int Active { get; set; }

      
    }
}