using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel;

namespace AenEnterprise.DataAccess.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AenEnterpriseDbContext context) : base(context)
        {

        }

        //public IEnumerable<Category> GetCategoryWithProducts()
        //{
        //    var categoryWithProducts = _context.Categories.Include(p => p.Products).ToList();
        //    return categoryWithProducts;
        //}


    }
}
