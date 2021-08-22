using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Events;
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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EventResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _eventRepository.GetByIdAsync(id);

            var dto = _mapper.Map<EventResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<EventResponseDto>> ListAllAsync()
        {
            var result = await _eventRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<EventResponseDto>>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _eventRepository.DeleteAsync(id);
        }

        public async Task<EventResponseDto> AddAsync(EventRequestDto eventRequest)
        {
            var eventEntity = _mapper.Map<Event>(eventRequest);

            var result = await _eventRepository.AddAsync(eventEntity);
            var dto = _mapper.Map<EventResponseDto>(result);
            return dto;
        }

        public async Task<EventResponseDto> UpdateAsync(EventRequestDto eventRequest)
        {
            var eventEntity = _mapper.Map<Event>(eventRequest);
            var result = await _eventRepository.UpdateAsync(eventEntity);
            var dto = _mapper.Map<EventResponseDto>(result);
            return dto;
        }

        public async Task<bool> AddUserToEvent(Guid id, Guid userId)
        {
            var result = await _eventRepository.GetByIdAsync(id);
            var user = await _userRepository.GetByIdAsync(userId);
            if (result.UserEvents.Any(ue => ue.Event.Id == result.Id && ue.User.Id == user.Id))
            {
                return false;
            }
            
            return await _eventRepository.AddUserToEvent(id, userId);
        }
    }
}
