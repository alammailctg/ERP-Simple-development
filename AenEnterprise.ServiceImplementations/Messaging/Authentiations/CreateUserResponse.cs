using AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.Authentiations
{
    public class CreateUserResponse
    {
        public UserView User { get; set; }
        public IEnumerable<UserView> Users { get; set; }
    }
}
