using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Score { get; set; }
        public string Feedback { get; set; }
        public Employee Employee { get; set; }
    }
}
