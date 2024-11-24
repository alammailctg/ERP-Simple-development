using AenEnterprise.DataAccess.RepositoryInterface.Blogs;
using AenEnterprise.DomainModel.BlogsDomain;

namespace AenEnterprise.DataAccess.Repository.BlogsRepository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
