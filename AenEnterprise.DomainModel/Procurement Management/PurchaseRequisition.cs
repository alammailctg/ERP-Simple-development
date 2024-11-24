using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AenEnterprise.DomainModel.Procurement_Management
{
    public class PurchaseRequisition
    {
        public PurchaseRequisition()
        {
            Items = new List<PurchaseRequisitionItem>();
        }
        public int Id { get; set; } 

        public string Department { get; set; } 

        public int RequestedById { get; set; }
        public Employee RequestedBy { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now; 

        public string Status { get; set; } = "Pending Approval"; // Status of the requisition (e.g., Pending Approval, Approved)

        public DateTime DateRequired { get; set; } 

        public string Justification { get; set; } // Reason for the purchase request

        public List<PurchaseRequisitionItem> Items { get; set; }

        public string VendorPreference { get; set; } // Preferred vendor name or ID

        public string DeliveryInstructions { get; set; } // Specific delivery or packaging instructions

        public string AttachmentPath { get; set; } // Path for any attached documents (e.g., blueprints, specifications)

        // Additional fields for tracking approval workflow
        public int ApprovalStatusId { get; set; }
        public Status ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; } // Date when the requisition was approved
        public DateTime ReviewDate { get; set; }
        public string Comments { get; set; }

        // Optional method to calculate total estimated cost for all items
        public decimal TotalEstimatedCost
        {
            get { return Items.Sum(item => item.TotalItemCost); }
        }
    }
}
