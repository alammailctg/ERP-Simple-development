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
    public static class UserRoleMapper
    {
        public static UserRoleView ConvertToUserRoleView(this UserRole userRole, IMapper mapper)
        {
            return mapper.Map<UserRole, UserRoleView>(userRole);
        }

        public static IEnumerable<UserRoleView> ConvertToUserRoleViews(this IEnumerable<UserRole> userRoles, IMapper mapper)
        {
            return mapper.Map<IEnumerable<UserRole>, IEnumerable<UserRoleView>>(userRoles);
        }
    }
}

