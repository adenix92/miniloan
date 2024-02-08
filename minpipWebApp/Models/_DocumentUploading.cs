using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _DocumentUploading
    {
        public int Id { get; set; }
        public Nullable<int> PersonalDataId { get; set; }
        public string ImageName { get; set; }
        [Required(ErrorMessage ="Browse to select file",AllowEmptyStrings =false)]
        public byte[] Images { get; set; }
        public string ImageStatus { get; set; }
        public string RegisterDate { get; set; }
        public Nullable<int> DeleteId { get; set; }
        [Required(ErrorMessage ="Select type of document",AllowEmptyStrings =false)]
        public int OccupationId { get; set; }

        public virtual PersonalData PersonalData { get; set; }
    }
}