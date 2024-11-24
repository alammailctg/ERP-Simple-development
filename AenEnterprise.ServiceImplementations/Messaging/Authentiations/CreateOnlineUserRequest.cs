using AenEnterprise.DomainModel.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.Authentiations
{
    public class CreateOnlineUserRequest
    {
        public string Username { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
