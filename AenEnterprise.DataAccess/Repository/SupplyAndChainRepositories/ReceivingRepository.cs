using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class ReceivingRepository : GenericRepository<Receiving>, IReceivingRepository
    {
        public ReceivingRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
