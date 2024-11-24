using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class InventorySummary
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal TotalProduced { get; set; }
        public decimal TotalPurchased { get; set; }
        public decimal TotalSold { get; set; }
        public decimal TotalInStock { get; set; }
        public decimal TotalReturn { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
