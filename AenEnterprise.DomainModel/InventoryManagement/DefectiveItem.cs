using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class DefectiveItem
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int DefectiveQuantity { get; set; } 
        public string? Comments { get; set; } 
        public int DefectiveId { get; set; } 
        public Defective? Defective { get; set; }
    }
}
