using AenEnterprise.DataAccess.RepositoryInterface.Blogs;
using AenEnterprise.DomainModel.BlogsDomain;

namespace AenEnterprise.DataAccess.Repository.BlogsRepository
{
    public class BlogCategoryRepository : GenericRepository<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
