using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class MaterialsRequirementRepository : GenericRepository<MaterialsRequirement>, IMaterialsRequirementRepository
    {
        public MaterialsRequirementRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
