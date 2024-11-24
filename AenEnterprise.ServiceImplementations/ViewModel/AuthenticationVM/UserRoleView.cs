using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM
{
    public class UserRoleView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public List<string> RoleNames { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
