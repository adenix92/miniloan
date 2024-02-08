using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _OfficeAndIdentification
    {
      
       
        [Display(Name= "Employer")]
        [Required(ErrorMessage ="Employer Field Required",AllowEmptyStrings =false)]
        public string Employer { get; set; }
        [Display(Name ="Office Address")]
        [Required(ErrorMessage ="Office Address Required")]
        [DataType(DataType.Text)]
        public string OfficeAddress { get; set; }
        [Display(Name ="Office Phone Number")]
        [Required(ErrorMessage ="Office Phone Number Required",AllowEmptyStrings =false)]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength:15,MinimumLength =11)]
        public string OfficePhone { get; set; }
        [Display(Name ="Department")]
        [Required(ErrorMessage ="Department",AllowEmptyStrings =false)]
        [DataType(DataType.Text)]
        public string Department { get; set; }
        [Display(Name ="NetIncome/Month")]
        [Required(ErrorMessage ="NetIncome/Month is Required",AllowEmptyStrings =false)]
        [DataType(DataType.Currency)]
        public Nullable<decimal> NetIncome { get; set; }
        [Display(Name = "Basic Salary")]
        [Required(ErrorMessage = "Basic Salary is Required", AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        public Nullable<decimal> BasicSalary { get; set; }
        [Display(Name ="Mean of Identification")]
        [Required(ErrorMessage ="Mean of Identification",AllowEmptyStrings =false)]
        public string IdentificationName { get; set; }
        [Display(Name ="Identification Number")]
        [Required(ErrorMessage ="Identification Number Required",AllowEmptyStrings =false)]
        [DataType(DataType.Text)]
        public string IdentificationNumber { get; set; }
        [Display(Name ="Issue Date")] 
        [Required(ErrorMessage ="Issue Date Required",AllowEmptyStrings =false)]
        [DataType(DataType.Date)]
        public string IssueDate { get; set; }
        [Display(Name = "Expired Date")]
        [Required(ErrorMessage = "Expired Date Required", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public string ExpireDated { get; set; }
        [Display(Name = "Nationality")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nationality Required", AllowEmptyStrings = false)]
        public string Nationality { get; set; }

        [Required(ErrorMessage ="Spouse Required",AllowEmptyStrings =false)]
        public string Spouse { get; set; }
     

   
    }
}