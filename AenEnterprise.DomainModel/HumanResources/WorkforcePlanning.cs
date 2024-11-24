using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class WorkforcePlanning
    {
        public int WorkforcePlanID { get; set; }
        public string Department { get; set; }
        public int RequiredHeadcount { get; set; }
        public int PlannedHiring { get; set; }
        public decimal ForecastedGrowth { get; set; }
        public List<Employee> Employees { get; set; } // Navigation property
    }
}
