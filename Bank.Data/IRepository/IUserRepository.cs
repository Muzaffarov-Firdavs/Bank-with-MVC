using Bank.Domain.Entites;
using System.Linq.Expressions;

namespace Bank.Data.IRepository
{
    public interface IUserRepository
    {
        IQueryable<User> SelectAll();
        Task<User> SelectAsync(Expression<Func<User, bool>> expression = null);
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(User user);
        Task Delete(Expression<Func<User, bool>> expression);
        Task SaveChangesAsync();
    }
}
