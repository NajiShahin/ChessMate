using Imi.Project.Api.Core.Dtos.Comments;
using Imi.Project.Api.Core.Dtos.Groups;
using Imi.Project.Api.Core.Dtos.Post;
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
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.ListAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var posts = await _postService.GetByIdAsync(id);
            if (posts == null)
            {
                return NotFound($"Group with ID {id} does not exist");
            }
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostRequestDto postRequest)
        {
            var postResponseDto = await _postService.AddAsync(postRequest);
            return CreatedAtAction(nameof(Get), new { id = postResponseDto.Id }, postResponseDto);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(CommentRequestDto commentRequest)
        {
            var postResponseDto = await _postService.AddComment(commentRequest);
            return CreatedAtAction(nameof(Get), new { id = postResponseDto.Id }, postResponseDto);
        }

        [HttpPut]
        [Authorize(Policy = "ForumRights")]
        public async Task<IActionResult> Put(PostRequestDto postRequest)
        {
            var groupResponseDto = await _postService.UpdateAsync(postRequest);
            return Ok(groupResponseDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "ForumRights")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var group = await _postService.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound($"Group with ID {id} does not exist");
            }
            await _postService.DeleteAsync(id);
            return Ok();
        }
    }
}
