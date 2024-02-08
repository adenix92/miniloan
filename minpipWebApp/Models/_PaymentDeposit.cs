using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class _PaymentDeposit
    {
        public int Id { get; set; }
        public Nullable<int> PersonalDataId { get; set; }
        public string LoanAmount { get; set; }
        public string LoanType { get; set; }
        public string FrequentlyPayment { get; set; }
        public Nullable<int> Instalment { get; set; }
        public string Interest { get; set; }
        public string Repayment { get; set; }
        public string PayableAmount { get; set; }
        public string BalanceAmount { get; set; }
        public string PaymentDate { get; set; }
        public Nullable<int> Active { get; set; }

        public virtual PersonalData PersonalData { get; set; }

    }
}