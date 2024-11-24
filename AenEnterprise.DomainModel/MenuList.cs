using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel
{
    public class MenuList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public MenuGroup MenuGroup { get; set; }
        public int MenuGroupId { get; set; }
    }
}
