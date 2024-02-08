using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _PersonalData
    {

        [Required(ErrorMessage ="Residential Address Required",AllowEmptyStrings =false)]
        public string ResidentialAddress { get; set; }
        public int StateId { get; set; }
        public Nullable<int> LocalId { get; set; }
        [Required(ErrorMessage ="ZipCode Required",AllowEmptyStrings =false)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage ="Mobile Number Required",AllowEmptyStrings =false)]
        [StringLength(maximumLength:11,MinimumLength =11)]
        public string MobileNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Invalid DOB", AllowEmptyStrings =false)]
        public string DOB { get; set; }
        public int OccupId { get; set; }


       
    }
}