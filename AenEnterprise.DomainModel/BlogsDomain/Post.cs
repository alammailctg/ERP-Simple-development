using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.BlogsDomain
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public BlogCategory Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
