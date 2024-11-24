using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class PortalAccess
    {
        public int PortalAccessID { get; set; }
        public int EmployeeID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string AccessLevel { get; set; } // Employee, Manager, Admin
        public Employee Employee { get; set; }
    }
}
