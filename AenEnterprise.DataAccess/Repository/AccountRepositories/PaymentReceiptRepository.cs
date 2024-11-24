using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class PaymentReceiptRepository : GenericRepository<PaymentReceipt>, IPaymentReceiptRepository
    {
        public PaymentReceiptRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
