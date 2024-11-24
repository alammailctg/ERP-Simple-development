using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable
{
    public class Reconciliation
    {
        public int ReconciliationId { get; set; }
        public DateTime ReconciliationDate { get; set; }

        // One Reconciliation can have many Payments
        public List<Payment> Payments { get; set; }
    }

}
