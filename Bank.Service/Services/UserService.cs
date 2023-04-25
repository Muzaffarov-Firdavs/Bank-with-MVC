using AutoMapper;
using Bank.Data.IRepositories;
using Bank.Domain.Configuration;
using Bank.Domain.Entites;
using Bank.Service.DTOs;
using Bank.Service.Exceptions;
using Bank.Service.Extensions;
using Bank.Service.Interfaces;
using System.Linq.Expressions;

namespace Bank.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;
        public UserService(IMapper mapper, IRepository<User> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            User user = await this.repository.SelectAsync(
                u => u.FirstaName == dto.FirstaName && u.LastaName == dto.LastaName);
            if (user is not null)
                throw new CustomException(403, "User already exist with this username");

            User mappedUser = mapper.Map<User>(dto);
            mappedUser.CreatedAt = DateTime.UtcNow;
            var result = await this.repository.InsertAsync(mappedUser);
            await this.repository.SaveAsync();
            return this.mapper.Map<UserForResultDto>(result);
        }

        public async Task<UserForResultDto> ModifyAsync(UserForResultDto dto)
        {
            var updatingUser = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
            if (updatingUser is null)
                throw new CustomException(404, "User not found");

            this.mapper.Map(dto,updatingUser);
            updatingUser.UpdatedAt = DateTime.UtcNow;
            await this.repository.SaveAsync();

            return  mapper.Map<UserForResultDto>(updatingUser);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var user = await this.repository.SelectAsync(u => u.Id.Equals(id));
            if (user is null)
                throw new CustomException(404, "User not found");

            await this.repository.DeleteAsync(u => u.Id == id);
            await this.repository.SaveAsync();
            
            return true;
        }

        public async Task<List<UserForResultDto>> RetriewAllAsync(
            PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            if (expression is null)
            {
                expression = (x => true);
            }

            var entities = this.repository.SelectAll();

            entities = entities.Where(expression).ToPagedList<User>(@params);

            var filteredUsers = entities.ToList();

            var result = mapper.Map<List<UserForResultDto>>(entities);

            return await Task.FromResult(result);
        }

        public async Task<UserForResultDto> RetriewAsync(long id)
        {
            User user = await this.repository.SelectAsync(
                u => u.Id == id);
            if (user is not null)
                throw new CustomException(404, "User not found");

            return mapper.Map<UserForResultDto>(user);
        }
    }
}
