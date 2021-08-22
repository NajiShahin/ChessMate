using AutoMapper;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository authRepository,
            IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<LoginUserResponseDto> Login(LoginUserRequestDto login)
        {
            var token = await _authRepository.Login(login.UserName, login.Password);
            return new LoginUserResponseDto
            {
                Token = token
            };
        }

        public async Task<IEnumerable<string>> Register(UsersRequestDto registration)
        {
            var user = _mapper.Map<User>(registration);

            return await _authRepository.Register(user, registration.Username, registration.Password);
        }
    }
}
