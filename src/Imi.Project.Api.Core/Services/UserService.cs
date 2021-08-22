using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Games;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _userRepository.GetByIdAsync(id);

            var dto = _mapper.Map<UserResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<UserResponseDto>> ListAllAsync()
        {
            var result = await _userRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            return dto;
        }



        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserResponseDto> AddAsync(UsersRequestDto usersRequest)
        {
            var userEntity = _mapper.Map<User>(usersRequest);

            var result = await _userRepository.AddAsync(userEntity);
            var dto = _mapper.Map<UserResponseDto>(result);
            return dto;
        }

        public async Task<UserResponseDto> UpdateAsync(UserEditRequest usersRequest)
        {
            var openingEntity = _mapper.Map<User>(usersRequest);
            var result = await _userRepository.UpdateAsync(openingEntity);
            var dto = _mapper.Map<UserResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchByNameAsync(string username)
        {
            var user = await _userRepository.SearchByNameAsync(username);
            return _mapper.Map<IEnumerable<UserResponseDto>>(user);
        }
    }
}
