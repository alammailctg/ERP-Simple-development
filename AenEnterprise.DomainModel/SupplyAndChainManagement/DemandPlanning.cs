using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class DemandPlanning
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ForecastedDemand { get; set; }
        public DateTime ForecastDate { get; set; }
        public List<StockLevel> StockLevels { get; set; }
    }
}
