using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;

namespace AenEnterprise.DataAccess.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
