using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ProductionOrderItem
    {
        public ProductionOrderItem()
        {
            
        }
        public ProductionOrderItem(ProductionOrder productionOrder, int productId, decimal quantityRequested, decimal quantityProduce,int unitId)
        {
            ProductionOrder = productionOrder;
            ProductId = productId;
            QuantityRequested = quantityRequested;
            QuantityProduced = quantityProduce;
            CostPerUnit = 1;
            Status = "Pending"; 
            IsSubmitted = false;
            ApprovalStatusId = 1;
            UnitId = unitId;
            IsActive = false;
        }
        public int ProductionOrderItemId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public decimal QuantityRequested { get; set; }
        public decimal QuantityProduced { get; set; }
        public decimal CostPerUnit { get; set; }
        public bool IsSubmitted { get; set; }
        public decimal TotalCost => CalculateTotalCost();
        public int ProductionOrderId { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
        public string Status { get; set; }
        public Status ApprovalStatus { get; set; }
        public int ApprovalStatusId { get; set; }
        public bool IsActive { get; set; }
        

        private decimal CalculateTotalCost()
        {
            return QuantityProduced * CostPerUnit;
        }
       

        
        // Method to update quantity produced
        public void UpdateQuantityProduced(decimal quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity produced cannot be negative.");

            QuantityProduced += quantity;

            UpdateStatus(); // Separate method to handle status updates
        }

        // Private method for encapsulation
        private void UpdateStatus()
        {
            if (QuantityProduced >= QuantityRequested)
            {
                Status = "Completed"; // All requested quantity has been produced
            }
            else
            {
                Status = "In Progress"; // Still in production
            }
        }
    }

}

