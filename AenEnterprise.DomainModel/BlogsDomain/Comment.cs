using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.BlogsDomain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
