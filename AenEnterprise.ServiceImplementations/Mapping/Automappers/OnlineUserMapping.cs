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
    public static class OnlineUserMapping
    {
        public static OnlineUserView ConvertToOnlineUserView(this OnlineUser onlineUser, IMapper mapper)
        {
            return mapper.Map<OnlineUser, OnlineUserView>(onlineUser);
        }

        public static IEnumerable<OnlineUserView> ConvertToOnlineUserViews(this IEnumerable<OnlineUser> onlineUsers, IMapper mapper)
        {
            return mapper.Map<IEnumerable<OnlineUser>, IEnumerable<OnlineUserView>>(onlineUsers);
        }
    }
}
