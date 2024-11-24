using AenEnterprise.DataAccess.Repository;
using AenEnterprise.DomainModel.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface
{
    public interface ICostTransactionRepository : IGenericRepository<CostTransaction>
    {
        // Add specific methods for CostTransaction if needed
        Task<IEnumerable<CostTransaction>> GetByProductionOrderIdAsync(int productionOrderId);
    }
}
