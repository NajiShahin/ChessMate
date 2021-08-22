using AutoMapper.Configuration;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "User")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGameService _gameService;


        public UsersController(IUserService userService,
            IGameService gameService)
        {
            _userService = userService;
            _gameService = gameService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string username)
        {
            if (username != null)
            {
                var tracks = await _userService.SearchByNameAsync(username);
                if (tracks.Any())
                {
                    return Ok(tracks);
                }
                return NotFound($"There were no users found that contain {username} in their username");
            }
            else
            {
                var tracks = await _userService.ListAllAsync();
                return Ok(tracks);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} does not exist");
            }
            return Ok(user);
        }

        [HttpGet("{id}/games")]
        public async Task<IActionResult> GetGames(Guid id)
        {
            var user = await _gameService.GetByUserId(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} does not exist");
            }
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserEditRequest usersRequest)
        {
            if (!CanChange(usersRequest.Id))
                return Forbid();
            var userResponseDto = await _userService.UpdateAsync(usersRequest);
            return Ok(userResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!CanChange(id))
                return Forbid();
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} does not exist");
            }
            await _userService.DeleteAsync(id);
            return Ok();
        }

        private bool CanChange(Guid id)
        {
            if (User.Claims.ToList().FirstOrDefault(c => c.Type == "id").Value == id.ToString() ||
                User.Claims.ToList().FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value == "Admin")
                return !false;
            return !true;
        }
    }
}
