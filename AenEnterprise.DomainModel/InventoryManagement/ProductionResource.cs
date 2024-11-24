using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ProductionResource
    {
        public int ProductionResourceId { get; set; }
        public int ProductionId { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
        public string ResourceName { get; set; }
        public decimal Cost { get; set; }
    }
}
