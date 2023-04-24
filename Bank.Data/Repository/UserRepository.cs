using Bank.Data.DbContexts;
using Bank.Data.IRepository;
using Bank.Domain.Entites;
using System.Linq.Expressions;

namespace Bank.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;


        public Task Delete(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<User> InsertAsync(User user)
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
