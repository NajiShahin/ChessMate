using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponseDto>> ListAllAsync();
        Task<EventResponseDto> GetByIdAsync(Guid id);
        Task<EventResponseDto> AddAsync(EventRequestDto eventRequest);
        Task<EventResponseDto> UpdateAsync(EventRequestDto eventRequest);
        Task DeleteAsync(Guid id);
        Task<bool> AddUserToEvent(Guid id, Guid userId);
    }
}
