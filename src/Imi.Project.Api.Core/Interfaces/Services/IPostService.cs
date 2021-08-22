using Imi.Project.Api.Core.Dtos.Comments;
using Imi.Project.Api.Core.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostResponseDto>> ListAllAsync();
        Task<PostResponseDto> GetByIdAsync(Guid id);
        Task<PostResponseDto> AddAsync(PostRequestDto usersRequest);
        Task<CommentResponseDto> AddComment(CommentRequestDto commentEntity);
        Task<PostResponseDto> UpdateAsync(PostRequestDto postRequest);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<PostResponseDto>> GetByGroupId(Guid id);
    }
}
