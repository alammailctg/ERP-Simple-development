using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM
{
    public class OnlineUserView
    {
        public string Username { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
