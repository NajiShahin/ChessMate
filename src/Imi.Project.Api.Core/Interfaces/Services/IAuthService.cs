using Imi.Project.Api.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> Login(LoginUserRequestDto login);
        Task<IEnumerable<string>> Register(UsersRequestDto registration);
    }
}
