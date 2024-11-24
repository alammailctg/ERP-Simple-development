using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class CostCalculator:ICostCalculator
    {
        public decimal CalculateInitialProductionCost(ProductionOrder order) => order.PurchaseCost + order.DirectLaborCost + order.OtherInitialCosts;

        //public decimal CalculateAdjustedProductionCost(ProductionOrder order)
        //{
        //    return order.ProductionCosts?.Sum(pc => pc.CostAmount) ?? 0;
        //}

        public decimal CalculateFinalProductionCost(ProductionOrder order)
        {
            decimal additionalCosts = 0;
            decimal discounts = 0;

            return CalculateInitialProductionCost(order) + CalculateAdjustedProductionCost(order) + additionalCosts - discounts;
        }

        public decimal CalculateAdjustedProductionCost(ProductionOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
