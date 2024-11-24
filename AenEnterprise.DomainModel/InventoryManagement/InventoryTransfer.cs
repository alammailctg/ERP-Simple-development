using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class InventoryTransfer
    {
        public InventoryTransfer()
        {
            TransferDate = DateTime.Now;
            InventoryTransferItems = new List<InventoryTransferItem>();
        }
        public int Id { get; set; }           // Unique identifier for the transfer
        public string TransferCode { get; set; }
        public DateTime TransferDate { get; set; }     // Date when the transfer was made
        public int SourceWarehouseId { get; set; }    // Source warehouse location
        public Warehouse SourceWarehouse { get; set; }
        public string Status { get; set; }             // Status of transfer (e.g., "Pending", "Completed")
        public int DestinationWarehouseId { get; set; }    // Source warehouse location
        public Warehouse DestinationWarehouse { get; set; }
        
        public List<InventoryTransferItem> InventoryTransferItems { get; set; }
        public int QualityInspectionId { get; set; }
        public QualityInspection Inspection { get; set; }

        //This is for if I avoid inspection
        public int ProductionStockId { get; set; }
        public ProductionStock ProudctionStock { get; set; }

    }
}
