using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IPaymentReceiptService
    {
        Task<PaymentReceipt> GetPaymentReceiptByIdAsync(int id);
        Task<CreatePaymentReceiptResponse> AddPaymentReceiptAsync(CreatePaymentReceiptRequest request);
        Task UpdatePaymentReceiptAsync(PaymentReceipt paymentReceipt);
        Task RemovePaymentReceiptAsync(int id);
        Task<CreatePaymentReceiptResponse> AddPaymentToInvoiceAsync(CreatePaymentReceiptRequest request);
        Task<CreateJournalEntryResponse> DepositCustomerPaymentAsync(CreatePaymentReceiptRequest request);
        Task<string> GetRedisJournalEntryId();
        Task<string> GetRedisPaymentId();
        Task<GetJournalEntryResponse> GetJournalEntryById();
    }
}
