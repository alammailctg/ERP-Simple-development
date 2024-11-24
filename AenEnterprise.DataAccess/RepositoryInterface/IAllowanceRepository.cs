using AenEnterprise.DomainModel.HumanResources.Benefits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IAllowanceRepository : IGenericRepository<Allowances>
    {
        Task<List<Allowances>> GetAllAllowances();
    }
}
