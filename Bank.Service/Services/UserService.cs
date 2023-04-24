using Bank.Domain.Configuration;
using Bank.Domain.Entites;
using Bank.Service.DTOs;
using Bank.Service.Interfaces;
using System.Linq.Expressions;

namespace Bank.Service.Services
{
    public class UserService : IUserService
    {


        public Task<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<UserForResultDto> ModifyAsync(UserForResultDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserForResultDto>> SelectAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null, string search = null)
        {
            throw new NotImplementedException();
        }

        public Task<UserForResultDto> SelectAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
