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
    public class OpeningRepository : EfRepository<Opening>, IOpeningRepository
    {
        public OpeningRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Opening> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Opening> GetAllAsync()
        {
            return _dbContext.Openings.AsNoTracking()
                .Include(o => o.Moves);
        }

        public async Task<IEnumerable<Opening>> SearchByNameAsync(string name)
        {
            return await GetAllAsync()
            .Where(o => o.Name.ToUpper().Contains(name.ToUpper()))
            .Include(o => o.Moves)
            .ToListAsync();
        }

    }
}
