using AenEnterprise.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.GeneralLedger
{
    public class GetAllAccountResponse
    {
        public AccountView Account { get; set; }
        public IEnumerable<AccountView> Accounts { get; set; }
    }
}
