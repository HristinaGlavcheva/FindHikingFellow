namespace FindHikingFellow.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllAsNoTracking<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task RemoveByIdAsync<T>(object id) where T : class;

        Task RemoveEntityAsync<T>(T entity) where T : class;

        Task RemoveRangeAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(object id) where T : class;
    }
}
