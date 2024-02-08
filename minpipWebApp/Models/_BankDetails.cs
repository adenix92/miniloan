using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _BankDetails
    {
        public int Id { get; set; }
        public Nullable<int> PersonalDataId { get; set; }

        //Account name
        [Display(Name="Account Name")]
        [Required(ErrorMessage ="Account Name Required",AllowEmptyStrings =false)]
        public string AccountName { get; set; }

        //Account Number 
        [Display(Name ="Account Number")]
        [Required(ErrorMessage ="Account Number Required",AllowEmptyStrings =false)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{10}",ErrorMessage ="Input Valid Account Number/n 10 Digit")]
        public string AccountNumber { get; set; }


        //bankname 
        [Required(ErrorMessage ="Bank Name Required",AllowEmptyStrings =false)]
        public string BankName { get; set; }

        //BVN 
        [Display(Name ="BVN")]
        [Required(ErrorMessage ="BVN Required",AllowEmptyStrings =false)]
        [RegularExpression(@"[0-9]{11}")]
        public string BVN { get; set; }


        //Account Type 
        [Required(ErrorMessage ="Account Type Required", AllowEmptyStrings =false)]
        public string AccountType { get; set; }


        //EFT 
        [Required(ErrorMessage ="EFT Account Number Required",AllowEmptyStrings =false)]
        [RegularExpression(@"[0-9]{10}")]
        public string EFT_ACC_Number { get; set; }


        //EFT Bank Name
        [Required(ErrorMessage ="EFT Bank Name Required", AllowEmptyStrings =false)]
        [Display(Name ="EFT Bank Name")]
        public string EFT_Bank_Name { get; set; }

        public string OrderId { get; set; }
        public string BankDraft { get; set; }
        public string RegisterDate { get; set; }
        public Nullable<int> Active { get; set; }

        public virtual PersonalData PersonalData { get; set; }
    }
}