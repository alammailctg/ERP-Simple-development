using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class Training
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string CourseName { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Certificate { get; set; }
        public Employee Employee { get; set; }
    }
}
