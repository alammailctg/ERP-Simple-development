using AenEnterprise.ServiceImplementations.ViewModel;

namespace AenEnterprise.ServiceImplementations.Messaging.SalesManagement.Invoice
{
    public class GetAllInvoiceReponse
    {
        public InvoiceView Invoice { get; set; }
        public IEnumerable<InvoiceView> Invoices { get; set; }
    }
}