using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class QuoteComparison
    {
        public Guid ComparisonID { get; set; } 
        public Guid RFQID { get; set; } 
        public DateTime ComparisonDate { get; set; } 
        public List<Quote> Quotes { get; set; } 

        // Evaluation results
        public string BestQuoteSupplier { get; set; } // Supplier name offering the best quote.
        public decimal BestQuoteTotalPrice { get; set; } // Total price of the best quote.
        public string SelectedSupplierID { get; set; } // ID of the selected supplier after comparison.
        public string ComparisonNotes { get; set; } // Notes on the comparison process.

        // Constructor
        public QuoteComparison()
        {
            ComparisonID = Guid.NewGuid();
            ComparisonDate = DateTime.Now;
            Quotes = new List<Quote>();
        }
    }
}
