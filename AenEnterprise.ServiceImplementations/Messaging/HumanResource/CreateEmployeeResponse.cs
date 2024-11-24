using AenEnterprise.ServiceImplementations.ViewModel.HumanResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class CreateEmployeeResponse
    {
        public int Id { get; set; }
        public IEnumerable<EmployeeView> Employees { get; set; }
        public EmployeeView Employee { get; set; }
    }
}
