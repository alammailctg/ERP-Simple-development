using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface ICreditMemoService
    {
        Task<CreditMemo> GetCreditMemoByIdAsync(int id);
        Task<CreateCreditMemoResponse> AddCreditMemoAsync(CreateCreditMemoRequest request);
        Task UpdateCreditMemoAsync(CreditMemo creditMemo);
        Task RemoveCreditMemoAsync(int id);
    }
}
