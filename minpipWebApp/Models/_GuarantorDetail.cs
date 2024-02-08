using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _GuarantorDetail
    {
        public int Id { get; set; }
        public Nullable<int> PersonalDataId { get; set; }
        [Required(ErrorMessage ="Surname Require",AllowEmptyStrings =false)]
        [Display(Name ="SurName")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Firstname require",AllowEmptyStrings =false)]
        [Display(Name ="FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Lastname require",AllowEmptyStrings =false)]
        [Display(Name ="LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Require", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Address Require")]
        [DataType(DataType.Text)]
        public string Address { get; set; }
        [Required(ErrorMessage ="Phone number require")]
        [Display(Name ="Phone Number")]
        public string Phonenumber { get; set; }
        public string RegisterDate { get; set; }
        public Nullable<int> Active { get; set; }

        public virtual PersonalData PersonalData { get; set; }

    }
}