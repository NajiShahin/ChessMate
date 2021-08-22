using Imi.Project.Api.Core.Dtos.Comments;
using Imi.Project.Api.Core.Dtos.Post;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Post> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Post> GetAllAsync()
        {
            return _dbContext.Posts.AsNoTracking()
                .Include(p => p.Group)
                .Include(p => p.Comments);
        }

        public async Task<Comment> AddComment(Comment request)
        {
            var comment = new Comment()
                {
                    Content = request.Content,
                    DateAdded = request.DateAdded,
                    PostId = request.PostId
                };

            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<Post>> ListAllByGroupId(Guid groupId)
        {
            return await GetAllAsync().Where(g => g.GroupId == groupId).ToListAsync();
        }
    }
}
