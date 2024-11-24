using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
