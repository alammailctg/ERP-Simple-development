using AenEnterprise.ServiceImplementations.Messaging.HumanResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IEmployeeService
    {
        Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request);
    }
}
