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
    public class EventRepository : EfRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Event> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Event> GetAllAsync()
        {
            return _dbContext.Events.AsNoTracking()
                .Include(u => u.UserEvents)
                .ThenInclude(u => u.User);
        }

        public async Task<bool> AddUserToEvent(Guid id, Guid userId)
        {
            _dbContext.UserEvents.Add(
                new UserEvent() 
                {
                    EventId = id,
                    UserId = userId.ToString()
                });
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
