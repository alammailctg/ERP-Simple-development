using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.Authentiations
{
    public class LoginUserRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
