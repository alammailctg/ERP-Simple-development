using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.ViewModel;
using AenEnterprise.ServiceImplementations.ViewModel.AccountsReceivable;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.AccountReceivable
{
    public static class PaymentReceiptMapper
    {
        // Convert a single PaymentReceipt to PaymentReceiptView
        public static PaymentReceiptView ConvertToPaymentReceiptView(this PaymentReceipt paymentReceipt, IMapper mapper)
        {
            return mapper.Map<PaymentReceipt, PaymentReceiptView>(paymentReceipt);
        }

        // Convert a collection of PaymentReceipts to PaymentReceiptViews
        public static IEnumerable<PaymentReceiptView> ConvertToPaymentReceiptViews(this IEnumerable<PaymentReceipt> paymentReceipts, IMapper mapper)
        {
            return mapper.Map<IEnumerable<PaymentReceipt>, IEnumerable<PaymentReceiptView>>(paymentReceipts);
        }
    }

}
