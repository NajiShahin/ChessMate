using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Games;
using Imi.Project.Api.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> ListAllAsync();
        Task<UserResponseDto> GetByIdAsync(Guid id);
        Task<UserResponseDto> AddAsync(UsersRequestDto usersRequest);
        Task<UserResponseDto> UpdateAsync(UserEditRequest usersRequest);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<UserResponseDto>> SearchByNameAsync(string username);
    }
}
