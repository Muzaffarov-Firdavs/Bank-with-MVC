using Bank.Data.DbContexts;
using Bank.Data.IRepository;
using Bank.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bank.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<User> dbSet;
        public UserRepository(AppDbContext dbContext, DbSet<User> dbSet)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<User>();
        }

        public async Task Delete(Expression<Func<User, bool>> expression)
        {
            var entity = await this.dbSet.FirstOrDefaultAsync(expression);
            if (entity is null)
                return;

            this.dbSet.Remove(entity);
        }

        public Task<User> InsertAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> SelectAsync(Expression<Func<User, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
