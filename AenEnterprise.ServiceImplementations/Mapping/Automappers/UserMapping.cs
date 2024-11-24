using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers
{
    public static class UserMapping
    {
        public static UserView ConvertToUserView(this User user, IMapper mapper)
        {
            return mapper.Map<User, UserView>(user);
        }

        public static IEnumerable<UserView> ConvertToUserViews(this IEnumerable<User> users, IMapper mapper)
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(users);
        }
    }
}
