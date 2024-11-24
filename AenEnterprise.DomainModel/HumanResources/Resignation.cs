using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class Resignation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Status { get; set; }
    }
}
