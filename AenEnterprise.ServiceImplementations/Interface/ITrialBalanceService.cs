using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface ITrialBalanceService
    {
        Task<TrialBalance> GenerateTrialBalance(DateTime asOfDate);
    }
}
