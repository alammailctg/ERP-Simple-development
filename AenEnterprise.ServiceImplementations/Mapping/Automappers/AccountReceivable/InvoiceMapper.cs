using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.AccountReceivable
{
    public static class InvoiceMapper
    {
        public static InvoiceView ConvertToInvoiceView(this Invoice invoice, IMapper mapper, int statusId, bool isActive)
        {
            var invoiceView = mapper.Map<Invoice, InvoiceView>(invoice);

            // Filter and map InvoiceItems based on statusId and isActive
            invoiceView.InvoiceItems = invoice.InvoiceItems
                .Where(item => item.StatusId == statusId && item.IsActive == isActive)
                .Select(item => mapper.Map<InvoiceItem, InvoiceItemView>(item))
                .ToList();

            return invoiceView;
        }

        public static IEnumerable<InvoiceView> ConvertToInvoiceViews(this IEnumerable<Invoice> invoices, IMapper mapper, int statusId, bool isActive)
        {
            return invoices.Select(invoice => invoice.ConvertToInvoiceView(mapper, statusId, isActive));
        }
    }
}
