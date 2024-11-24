using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.Authentiations
{
    public class GetAllRolesResponse
    {
        public IEnumerable<RoleView> Roles { get; set; }
    }
}
