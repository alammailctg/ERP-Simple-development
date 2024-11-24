
using AenEnterprise.DomainModel.HumanResources.Benefits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IBenefitRepository : IGenericRepository<Benefit>
    {
       Task<List<Benefit>> GetAllBenefits();
    }
}
