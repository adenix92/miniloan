using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _GuarantorForm
    {
        public int Id { get; set; }
        public string ApplicationNumber { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string ResidentialAddress { get; set; }
        public Nullable<int> LocalId { get; set; }
        public string ZipCode { get; set; }
        public string MobileNumber { get; set; }
        public string DOB { get; set; }
        public Nullable<int> OccupationId { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficePhone { get; set; }
        public string Department { get; set; }
        public decimal NetIncome { get; set; }
        public decimal BasicSalary { get; set; }
        public string IdentificationName { get; set; }
        public string IdentificationNumber { get; set; }
        public string IssueDate { get; set; }
        public string ExpireDated { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string BVN { get; set; }
        public string Agreement { get; set; }
        public string DateRegister { get; set; }
        public Nullable<int> Active { get; set; }

        public virtual ICollection<GuarantorFormUploading> GuarantorFormUploadings { get; set; }
        public virtual LocalGovt LocalGovt { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}