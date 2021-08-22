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
    public class GroupRepository : EfRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Group> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Group> GetAllAsync()
        {
            return _dbContext.Groups.AsNoTracking()
                .Include(g => g.GroupUsers)
                .ThenInclude(g => g.User)
                .Include(g => g.Posts);
        }

        public async Task<bool> AddUserToGroup(Guid id, Guid userId)
        {
            _dbContext.GroupUsers.Add(
                new GroupUser()
                {
                    GroupId = id,
                    UserId = userId.ToString()
                });
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
