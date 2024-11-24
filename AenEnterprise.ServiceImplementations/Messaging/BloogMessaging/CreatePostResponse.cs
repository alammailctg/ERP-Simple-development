using AenEnterprise.DomainModel.BlogsDomain;
using AenEnterprise.ServiceImplementations.ViewModel.BlogVM;

namespace AenEnterprise.ServiceImplementations.Messaging.BloogMessaging
{
    public class CreatePostResponse
    {
        public PostView Post { get; set; }
        public IEnumerable<PostView> Posts { get; set; }
    }
}