using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class SalesOrderStatusRepository : GenericRepository<SalesOrderStatus>, ISalesOrderStatusRepository
    {
        public SalesOrderStatusRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
