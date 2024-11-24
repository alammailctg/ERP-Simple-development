using AenEnterprise.ServiceImplementations.Implementation.AccountsService;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using AenEnterprise.ServiceImplementations.Messaging.GeneralLedger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IGeneralLedgerService
    {
        Task<GetAllAccountResponse> GetAllAccountAsync();
        Task<CreateJournalEntryResponse> CreateJournalEntryAsync(CreateJournalEntryRequest request);
    }
}
