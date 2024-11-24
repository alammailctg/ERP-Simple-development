using AenEnterprise.DomainModel.BlogsDomain;

namespace AenEnterprise.ServiceImplementations.Messaging.BloogMessaging
{
    public class CreatePostRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
    }
}