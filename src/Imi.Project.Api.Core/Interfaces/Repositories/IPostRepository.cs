using Imi.Project.Api.Core.Dtos.Comments;
using Imi.Project.Api.Core.Dtos.Post;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Comment> AddComment(Comment request);
        Task<IEnumerable<Post>> ListAllByGroupId(Guid groupId);
    }
}
