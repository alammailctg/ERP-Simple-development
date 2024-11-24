using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public interface ICostTransactionManager
    {
        ICollection<CostTransaction> GetCostTransactions();
        //void RecordInitialProductionCost(ProductionOrder order);
    }
}
