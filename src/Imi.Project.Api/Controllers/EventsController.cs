using Imi.Project.Api.Core.Dtos.Events;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "User")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventService.ListAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var events = await _eventService.GetByIdAsync(id);
            if (events == null)
            {
                return NotFound($"Event with ID {id} does not exist");
            }
            return Ok(events);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post(EventRequestDto eventRequest)
        {

            var eventResponseDto = await _eventService.AddAsync(eventRequest);
            return CreatedAtAction(nameof(Get), new { id = eventResponseDto.Id }, eventResponseDto);
        }


        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(EventRequestDto eventRequest)
        {
            var eventResponseDto = await _eventService.UpdateAsync(eventRequest);
            return Ok(eventResponseDto);
        }

        [HttpPost("{id}/users")]
        public async Task<IActionResult> Post(Guid id, Guid userId)
        {
            var isAdded = await _eventService.AddUserToEvent(id, userId);
            if (isAdded)
            {
                return Ok($"User with id{id} has been added to event with userId {userId}");
            }
            return StatusCode(405,$"User with id {userId} is already part of event with id {id}"); //Method not allowed
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var eventDto = await _eventService.GetByIdAsync(id);
            if (eventDto == null)
            {
                return NotFound($"Event with ID {id} does not exist");
            }
            await _eventService.DeleteAsync(id);
            return Ok();
        }
    }
}
