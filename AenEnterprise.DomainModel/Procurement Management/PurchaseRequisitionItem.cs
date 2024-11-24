using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.Procurement_Management
{
    public class PurchaseRequisitionItem
    {
        public int Id { get; set; } 

        public string ItemCode { get; set; } 

        public string ItemDescription { get; set; } 

        public int Quantity { get; set; } 

        public decimal EstimatedUnitPrice { get; set; } 

        public decimal TotalItemCost
        {
            get { return Quantity * EstimatedUnitPrice; }
        } // Total cost of the item based on quantity

        public string SpecificationDetails { get; set; } 

        public string SupplierPartNumber { get; set; } 

    }
}
