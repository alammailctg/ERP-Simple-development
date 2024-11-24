using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AccountType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
 
        // Navigation property
        public List<AccountGroup> AccountGroups { get; set; }
    }

}
