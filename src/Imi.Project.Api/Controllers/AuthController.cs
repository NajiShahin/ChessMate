using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserRequestDto login)
        {
            var loginResponse = await _authService.Login(login);

            if (loginResponse.Token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(loginResponse);
            }
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsersRequestDto registration)
        {
            registration.Id = Guid.NewGuid();
            var registrationResponse = await _authService.Register(registration);

            if (registrationResponse != null)
            {
                foreach (var error in registrationResponse)
                {
                    ModelState.AddModelError("Error", error);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
