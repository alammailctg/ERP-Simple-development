using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class BillOfMaterial
    {
        private List<BillOfMaterialItem> _billOfMaterialItems;
        public BillOfMaterial()
        {
            _billOfMaterialItems = new List<BillOfMaterialItem>();
        }
        public int Id { get; set; } // Primary Key
        public int ProductionOrderId { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
        public string ProductName { get; set; } // Name of the product
        public DateTime CreationDate { get; set; } // Date the BOM was created
        public string Status { get; set; } // Status of the BOM (Pending, Approved, Rejected)
        public int CreatedById { get; set; } // Foreign Key for the user who created the BOM
        public int ApprovedById { get; set; } // Foreign Key for the user who approved the BOM

        public int CreatedEmplyeeId { get; set; }
        public int ApprovedByEmployeeId { get; set; }
        // Navigation properties
        public Employee Employee { get; set; } // User who created the BOM

       

        
        public List<BillOfMaterialItem> BillOfMaterialItems { get => _billOfMaterialItems; set => _billOfMaterialItems = value; }
    }
}
