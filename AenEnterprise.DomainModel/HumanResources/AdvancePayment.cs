using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class AdvancePayment
    {
        public AdvancePayment()
        {
            CreateDate = DateTime.Today;
        }
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string AdvanceAgainst { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ProposalDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PayrollId { get; set; }
        public Payroll Payroll { get; set; }
    }
}
