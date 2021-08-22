using Imi.Project.Api.Core.Dtos.Groups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupResponseDto>> ListAllAsync();
        Task<GroupDetailResponseDto> GetByIdAsync(Guid id);
        Task<GroupResponseDto> AddAsync(GroupRequestDto eventRequest);
        Task<GroupResponseDto> UpdateAsync(GroupRequestDto eventRequest);
        Task DeleteAsync(Guid id);
        Task<bool> AddUserToGroup(Guid id, Guid userId);
    }
}
