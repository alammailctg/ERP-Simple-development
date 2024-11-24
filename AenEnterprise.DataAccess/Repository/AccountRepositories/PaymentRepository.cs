using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
