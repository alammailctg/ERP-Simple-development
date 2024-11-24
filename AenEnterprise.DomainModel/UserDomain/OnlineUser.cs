using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.UserDomain
{
    public class OnlineUser
    {
        public OnlineUser()
        {
            LoginTime = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
