using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.CashManagement;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class CashForecastingRepository : GenericRepository<CashForecasting>, ICashForecastingRepository
    {
        public CashForecastingRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
