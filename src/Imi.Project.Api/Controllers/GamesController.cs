using Imi.Project.Api.Core.Dtos.Games;
using Imi.Project.Api.Core.Dtos.Moves;
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
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameService.ListAllAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var games = await _gameService.GetByIdAsync(id);
            if (games == null)
            {
                return NotFound($"Game with ID {id} does not exist");
            }
            return Ok(games);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GameRequestDto gameRequest)
        {

            var gameResponseDto = await _gameService.AddAsync(gameRequest);
            return CreatedAtAction(nameof(Get), new { id = gameResponseDto.Id }, gameResponseDto);
        }


        [HttpPut]
        public async Task<IActionResult> Put(GameRequestDto gameRequest)
        {
            var gameResponseDto = await _gameService.UpdateAsync(gameRequest);
            return Ok(gameResponseDto);
        }

        [HttpPut("{id}/moves")]
        public async Task<IActionResult> PutMoves(Guid id, IEnumerable<MoveRequestDto> moveRequests)
        {
            var gameResponseDto = await _gameService.UpdateGameMoves(id,moveRequests);
            return Ok(gameResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound($"Game with ID {id} does not exist");
            }
            await _gameService.DeleteAsync(id);
            return Ok();
        }


    }
}
