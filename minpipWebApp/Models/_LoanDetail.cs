using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _LoanDetail
    {
        public int Id { get; set; }
        public Nullable<int> PersonalDataId { get; set; }
        [Display(Name="Loan Amount is Require")]
        [Required(ErrorMessage ="Loan Amount is Require",AllowEmptyStrings =false)]
        public string LoanAmount { get; set; }
        [Display(Name ="Loan Type")]
        [Required(ErrorMessage ="Loan Type is Require",AllowEmptyStrings =false)]
        public string LoanType { get; set; }
        [Display(Name ="Frequently Payment")]
        [Required(ErrorMessage ="Select Your Frequently Payment",AllowEmptyStrings =false)]
        public string FrequentlyPayment { get; set; }
        public string Interest { get; set; }
        public string Repayment { get; set; }
        public string PayableAmount { get; set; }
        [Display(Name ="Instalment")]
        [Required(ErrorMessage ="Select Instalment",AllowEmptyStrings =false)]
        public Nullable<int> Instalment { get; set; }
        [Display(Name ="Description Security")]
        [Required(ErrorMessage ="Description Security Require",AllowEmptyStrings =false)]
        public string DescriptionSecurity { get; set; }
        [Display(Name = "Purpose")]
        [Required(ErrorMessage = "Purpose Require", AllowEmptyStrings = false)]
        public string Purpose { get; set; }
        public string RegisterDate { get; set; }
        public string StartDate { get; set; }
        public string Enddate { get; set; }
        public Nullable<int> Active { get; set; }

        public virtual PersonalData PersonalData { get; set; }
    }
}