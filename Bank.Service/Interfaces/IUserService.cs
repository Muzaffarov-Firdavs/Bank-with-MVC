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
        Task<UserForResultDto> RetriewAsync(long id);
        Task<List<UserForResultDto>> RetriewAllAsync(
            PaginationParams @params, Expression<Func<User, bool>> expression = null);
    }
}
