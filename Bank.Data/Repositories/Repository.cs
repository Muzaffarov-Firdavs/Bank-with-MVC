using Bank.Data.DbContexts;
using Bank.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bank.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;


        public Repository(AppDbContext dbContext, DbSet<TEntity> dbSet)
        {
            this.dbContext = dbContext;
            this.dbContext.Set<TEntity>();
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
