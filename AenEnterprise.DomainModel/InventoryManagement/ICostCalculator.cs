using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public interface ICostCalculator
    {
        decimal CalculateInitialProductionCost(ProductionOrder order);
        decimal CalculateAdjustedProductionCost(ProductionOrder order);
        decimal CalculateFinalProductionCost(ProductionOrder order);
    }
}
