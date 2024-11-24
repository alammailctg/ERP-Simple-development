using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        private readonly IList<ProductionOrderItem> _productionOrderItems;
        private IProductionOrderItemValidator _itemValidator;
        public ProductionOrder()
        {
            _productionOrderItems= new List<ProductionOrderItem>();
            CreatedDate = DateTime.Today;
        }
        //Stretegy pattern
        public void SetItemValidator(IProductionOrderItemValidator itemValidator)
        {
            _itemValidator = itemValidator;
        }

        // Add ProductionOrderItem using Factory Creational Pattern
        public void AddProductOrderItem(int productId, decimal quantityRequested, decimal quantityProduce, int unitId)
        {
           var newItem=ProductionOrderFactory.CreateNewProductOrderItem(this, productId, quantityRequested, quantityProduce, unitId);
            _itemValidator.Validate(_productionOrderItems, newItem,this);
        }



        // Public Property
      
        public string ProductionOrderNo { get; set; }
        public int InitiatorId { get; set; }
        public int AssignedToId { get; set; }
        public int BranchId { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public int OrderPriorityId { get; set; }
        public string Remarks { get; set; }
        public DateTime LastDateOfUpdate { get; set; }
        public int ResourceId { get; set; }
        

        // Production Cost Property
        public decimal InitialProductCost { get; set; }
        [NotMapped]//this is use for readonly
        public decimal AdjustProductionCost => ProudctionCost.Sum(pc => pc.CostAmount); 
        [NotMapped]
        public decimal FinalProductionCost => (InitialProductCost + AdjustProductionCost);
        public decimal PurchaseCost { get; set; }
        public decimal DirectLaborCost { get; set; }
        public decimal OtherInitialCosts { get; set; }
        public DateTime CreatedDate { get; private set; }

        // navigation property
        public Employee Initiator { get; set; }
        public Employee AssignedTo { get; set; }
        public Branch Branch { get; set; }
        public ProductionPriority OrderPriority { get; set; }
        public List<CostTransaction> CostTransactions { get; set; }
        
        public List<ProductionCost> ProudctionCost { get; set; }
        public List<BillOfMaterial> BillOfMaterials { get; set; }
        public List<ProductionStock> ProductionStocks { get; set; }

        public IEnumerable<ProductionOrderItem> ProductionOrderItems => _productionOrderItems;

        public bool AllItemsSubmitted()
        {
          
            return ProductionOrderItems.All(item => item.IsSubmitted);   
        }

        public void AddCostTransaction(CostTransaction costTransaction)
        {
           CostTransactions.Add(costTransaction);
        }

    }
}
