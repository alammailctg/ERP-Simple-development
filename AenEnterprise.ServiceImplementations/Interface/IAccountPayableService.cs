using AenEnterprise.ServiceImplementations.Implementation.AccountsService;
using AenEnterprise.ServiceImplementations.Messaging.AccountPayable;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IAccountPayableService
    {
        Task<CreateJournalEntryResponse> RecordPurchaseExpense(CreatePurchaseJournalEntryRequest request);
    }
}