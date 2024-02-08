using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _GuarantorFormUploading
    {
        public int Id { get; set; }
        public Nullable<int> GuarantorFormId { get; set; }
        public string ImageName { get; set; }
        public byte[] Images { get; set; }
        public string ImageStatus { get; set; }
        public string RegisterDate { get; set; }
        public Nullable<int> DeleteId { get; set; }

        public virtual GuarantorForm GuarantorForm { get; set; }
    }
}