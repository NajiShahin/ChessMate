using AutoMapper;
using Imi.Project.Api.Core.Dtos.Comments;
using Imi.Project.Api.Core.Dtos.Post;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostResponseDto> AddAsync(PostRequestDto postRequest)
        {
            var postEntity = _mapper.Map<Post>(postRequest);

            var result = await _postRepository.AddAsync(postEntity);
            var dto = _mapper.Map<PostResponseDto>(result);
            return dto;
        }

        public async Task<CommentResponseDto> AddComment(CommentRequestDto commentRequest)
        {
            var commentEntity = _mapper.Map<Comment>(commentRequest);

            var result = await _postRepository.AddComment(commentEntity);
            var dto = _mapper.Map<CommentResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PostResponseDto>> GetByGroupId(Guid id)
        {
            var result = await _postRepository.ListAllByGroupId(id);
            var dto = _mapper.Map<IEnumerable<PostResponseDto>>(result);
            return dto;
        }

        public async Task<PostResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _postRepository.GetByIdAsync(id);

            var dto = _mapper.Map<PostResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<PostResponseDto>> ListAllAsync()
        {
            var result = await _postRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<PostResponseDto>>(result);
            return dto;
        }

        public async Task<PostResponseDto> UpdateAsync(PostRequestDto postRequest)
        {
            var postEntity = _mapper.Map<Post>(postRequest);
            var result = await _postRepository.UpdateAsync(postEntity);
            var dto = _mapper.Map<PostResponseDto>(result);
            return dto;
        }
    }
}
