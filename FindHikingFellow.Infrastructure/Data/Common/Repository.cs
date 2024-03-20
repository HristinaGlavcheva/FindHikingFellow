using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(ApplicationDbContext _dbContext)
        {
           dbContext = _dbContext;
        }

        public Task AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllAsNoTracking<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public Task RemoveAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the table coresponding to the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
