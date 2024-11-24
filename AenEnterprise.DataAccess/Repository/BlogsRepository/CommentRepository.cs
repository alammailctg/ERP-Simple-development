using AenEnterprise.DataAccess.RepositoryInterface.Blogs;
using AenEnterprise.DomainModel.BlogsDomain;

namespace AenEnterprise.DataAccess.Repository.BlogsRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
