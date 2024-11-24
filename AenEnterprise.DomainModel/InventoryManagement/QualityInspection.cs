using AenEnterprise.DomainModel.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
   public class QualityInspection
    {
        public QualityInspection()
        {
            InspectionItems=new List<QualityInspectionItem>();
            CreatedDate = DateTime.Today;
        }
        public int Id { get; set; }
        public string InspectionNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int InspectorId { get; set; }
        public Employee Inspector { get; set; }
        public string Comments { get; set; }
        public string ProductionStockId { get; set; }
        public ProductionStock ProductionStock { get; set; }
        public List<QualityInspectionItem> InspectionItems { get; set; }
    }
}
