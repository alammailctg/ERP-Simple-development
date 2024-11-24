using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class TalentAcquisition
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string CandidateName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Status { get; set; } // Interviewed, Offered, Hired
        public List<Employee> Employees { get; set; } // Navigation property
    }

}
