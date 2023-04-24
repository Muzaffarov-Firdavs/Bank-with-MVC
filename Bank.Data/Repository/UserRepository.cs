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

        public async Task<User> InsertAsync(User user)
            => (await this.dbSet.AddAsync(user)).Entity;

        public async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<User> SelectAll()
             => this.dbSet;

        public async Task<User> SelectAsync(Expression<Func<User, bool>> expression = null)
            => await this.dbSet.FirstOrDefaultAsync(expression);

        public async Task<User> UpdateAsync(User user)
            => await Task.FromResult(this.dbSet.Update(user).Entity);
    }
}
