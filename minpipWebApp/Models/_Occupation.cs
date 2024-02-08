using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuarantorForm> GuarantorForms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UploadingDescription> UploadingDescriptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalData> PersonalDatas { get; set; }
    }
}