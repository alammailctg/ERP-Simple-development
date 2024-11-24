using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel
{
    public class MenuGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuList> MenuLists { get; set; }

    }
}
