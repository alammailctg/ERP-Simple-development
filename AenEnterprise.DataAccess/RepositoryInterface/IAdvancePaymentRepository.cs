using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IAdvancePaymentRepository:IGenericRepository<AdvancePayment>
    {
        Task<List<AdvancePayment>> GetAdvancePaymentByEmployeeId(int employeeId);
        Task<List<AdvancePayment>> GetAllAdvancePayments();
         
    }
}
