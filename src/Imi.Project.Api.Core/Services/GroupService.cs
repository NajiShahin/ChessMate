using AutoMapper;
using Imi.Project.Api.Core.Dtos.Groups;
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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GroupResponseDto> AddAsync(GroupRequestDto groupRequest)
        {
            var groupEntity = _mapper.Map<Group>(groupRequest);

            var result = await _groupRepository.AddAsync(groupEntity);
            var dto = _mapper.Map<GroupResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _groupRepository.DeleteAsync(id);
        }

        public async Task<GroupDetailResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _groupRepository.GetByIdAsync(id);

            var dto = _mapper.Map<GroupDetailResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<GroupResponseDto>> ListAllAsync()
        {
            var result = await _groupRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<GroupResponseDto>>(result);
            return dto;
        }

        public async Task<GroupResponseDto> UpdateAsync(GroupRequestDto groupRequest)
        {
            var groupEntity = _mapper.Map<Group>(groupRequest);
            var result = await _groupRepository.UpdateAsync(groupEntity);
            var dto = _mapper.Map<GroupResponseDto>(result);
            return dto;
        }

        public async Task<bool> AddUserToGroup(Guid id, Guid userId)
        {
            var result = await _groupRepository.GetByIdAsync(id);
            var user = await _userRepository.GetByIdAsync(userId);
            if (result.GroupUsers.Any(ue => ue.Group.Id == result.Id && ue.User.Id == user.Id))
            {
                return false;
            }

            return await _groupRepository.AddUserToGroup(id, userId);
        }

    }
}
