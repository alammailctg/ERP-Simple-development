using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class InventoryTransferItem
    {
        public int Id { get; set; }         
        public int TransferId { get; set; }            
        public int ProductId { get; set; }              
        public Product Product { get; set; }        
        public decimal TransferQuantity { get; set; }        
        public int UnitId { get; set; }      
        public Unit? Unit { get; set; }

        // Navigation property to parent InventoryTransfer
        public InventoryTransfer? InventoryTransfer { get; set; }
    }
}
