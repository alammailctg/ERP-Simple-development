using AenEnterprise.DomainModel.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.HumanResource
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string DepartmentName { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; }
        public decimal BaseSalary { get; set; }
        public string TalentAcquisitionName { get; set; }
    }
}
