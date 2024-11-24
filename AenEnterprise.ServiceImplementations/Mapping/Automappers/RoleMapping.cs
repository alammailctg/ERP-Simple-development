using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.ServiceImplementations.ViewModel;
using AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers
{
    public static class RoleMapping
    {
            public static RoleView ConvertToRoleView(this Role role, IMapper mapper)
            {
                return mapper.Map<Role, RoleView>(role);
            }

            public static IEnumerable<RoleView> ConvertToRoleViews(this IEnumerable<Role> roles, IMapper mapper)
            {
                return mapper.Map<IEnumerable<Role>, IEnumerable<RoleView>>(roles);
            }
        
    }
}
