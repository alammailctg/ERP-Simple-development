using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<Invoice> GetInvoiceByIncludeId(int invoiceId);
    }
}
