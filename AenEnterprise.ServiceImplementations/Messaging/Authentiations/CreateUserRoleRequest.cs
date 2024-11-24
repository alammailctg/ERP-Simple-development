using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.Authentiations
{
    public class CreateUserRoleRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
