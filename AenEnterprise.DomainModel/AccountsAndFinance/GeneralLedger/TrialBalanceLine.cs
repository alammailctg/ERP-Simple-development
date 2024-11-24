using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class TrialBalanceLine
    {
        public string AccountName { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
    }

}
