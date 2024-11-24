namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        Task<int> SaveAsync();
    }
}
