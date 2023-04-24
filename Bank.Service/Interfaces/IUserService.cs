using Bank.Domain.Configuration;
using Bank.Domain.Entites;
using Bank.Service.DTOs;
using System.Linq.Expressions;

namespace Bank.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserForResultDto> AddAsync(UserForCreationDto dto);
        Task<UserForResultDto> ModifyAsync(UserForResultDto dto);
        Task<bool> RemoveAsync(long id);
        Task<UserForResultDto> SelectAsync(long id);
        Task<List<UserForResultDto>> SelectAllAsync(
            PaginationParams @params, Expression<Func<User, bool>> expression = null);
    }
}
