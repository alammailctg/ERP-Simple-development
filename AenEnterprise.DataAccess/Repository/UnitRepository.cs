
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        public UnitRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
