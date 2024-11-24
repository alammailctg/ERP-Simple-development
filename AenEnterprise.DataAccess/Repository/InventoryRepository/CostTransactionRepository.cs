using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class CostTransactionRepository : GenericRepository<CostTransaction>, ICostTransactionRepository
    {
        public CostTransactionRepository(AenEnterpriseDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CostTransaction>> GetByProductionOrderIdAsync(int productionOrderId)
        {
            return await _context.CostTransactions
                .Where(ct => ct.ProductionOrderId == productionOrderId)
                .ToListAsync();
        }
    }
}
