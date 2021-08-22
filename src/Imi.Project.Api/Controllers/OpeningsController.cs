using Imi.Project.Api.Core.Dtos.Openings;
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
    public class OpeningsController : ControllerBase
    {
        private readonly IOpeningService _openingService;

        public OpeningsController(IOpeningService openingService)
        {
            _openingService = openingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            if (name != null)
            {
                var openings = await _openingService.SearchByNameAsync(name);
                if (openings.Any())
                {
                    return Ok(openings);
                }
                return NotFound($"There were no openings found that contain {name} in their name");
            }
            else
            {
                var tracks = await _openingService.ListAllAsync();
                return Ok(tracks);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var opening = await _openingService.GetByIdAsync(id);
            if (opening == null)
            {
                return NotFound($"Opening with ID {id} does not exist");
            }
            return Ok(opening);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post(OpeningsRequestDto openingsRequest)
        {

            var openingResponseDto = await _openingService.AddAsync(openingsRequest);
            return CreatedAtAction(nameof(Get), new { id = openingResponseDto.Id }, openingResponseDto);
        }


        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(OpeningsRequestDto openingsRequest)
        {
            var openingResponseDto = await _openingService.UpdateAsync(openingsRequest);
            return Ok(openingResponseDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var opening = await _openingService.GetByIdAsync(id);
            if (opening == null)
            {
                return NotFound($"Opening with ID {id} does not exist");
            }
            await _openingService.DeleteAsync(id);
            return Ok();
        }
    }
}
