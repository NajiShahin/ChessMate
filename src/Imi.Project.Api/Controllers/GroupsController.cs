using Imi.Project.Api.Core.Dtos.Groups;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ThirteenPlus")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IPostService _postService;

        public GroupsController(IGroupService groupService,
            IPostService postService)
        {
            _groupService = groupService;
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await _groupService.ListAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var groups = await _groupService.GetByIdAsync(id);
            if (groups == null)
            {
                return NotFound($"Group with ID {id} does not exist");
            }
            return Ok(groups);
        }

        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetGames(Guid id)
        {
            var posts = await _postService.GetByGroupId(id);
            if (posts == null)
            {
                return NotFound($"Posts with ID {id} does not exist");
            }
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GroupRequestDto groupRequest)
        {

            var groupResponseDto = await _groupService.AddAsync(groupRequest);
            return CreatedAtAction(nameof(Get), new { id = groupResponseDto.Id }, groupResponseDto);
        }


        [HttpPut]
        [Authorize(Policy = "ForumRights")]
        public async Task<IActionResult> Put(GroupRequestDto groupRequest)
        {
            var groupResponseDto = await _groupService.UpdateAsync(groupRequest);
            return Ok(groupResponseDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "ForumRights")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var group = await _groupService.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound($"Group with ID {id} does not exist");
            }
            await _groupService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("{id}/users")]
        public async Task<IActionResult> Post(Guid id, Guid userId)
        {
            var isAdded = await _groupService.AddUserToGroup(id, userId);
            if (isAdded)
            {
                return Ok($"User with id {userId} has been added to group with id {id}");
            }
            return StatusCode(405, $"User with id {userId} is already part of group with id {id}"); //Method not allowed
        }
    }
}
