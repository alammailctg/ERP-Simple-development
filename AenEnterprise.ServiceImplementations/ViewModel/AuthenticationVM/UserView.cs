using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.AuthenticationVM
{
    public class UserView
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public string Password { get; set; }
    }
}
