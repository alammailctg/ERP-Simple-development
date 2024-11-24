using AenEnterprise.ServiceImplementations.ViewModel.AccountsReceivable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable
{
    public class CreatePaymentReceiptResponse
    {
        public PaymentReceiptView PaymentReceipt { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
