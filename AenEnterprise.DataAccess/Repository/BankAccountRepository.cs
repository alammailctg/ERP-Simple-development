using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel;

namespace AenEnterprise.DataAccess.Repository
{
    public class BankAccountRepository : GenericRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
