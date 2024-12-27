using AenEnterprise.DataAccess;
using AenEnterprise.DomainModel.CookieStorage;
using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.Authentiations;
using AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation
{
    public class EFQueryingService:IEFQueryingService
    {
        private AenEnterpriseDbContext _context;
        public EFQueryingService()
        {
            _context=new AenEnterpriseDbContext();
        }

        public IEnumerable<Employee> GetEmployeesByNameGroup()
        {
           IEnumerable<Employee> employees=_context.Employees.ToList();

            var empGroup = employees.GroupBy(e => e.Name).Select(g => new 
            {
                Name = g.Key,
                employees=g.ToList()
            }).ToList();

            foreach (var item in empGroup)
            {
                
               return item.employees.ToList();
            }

            return null;
        }
 

    }
}
