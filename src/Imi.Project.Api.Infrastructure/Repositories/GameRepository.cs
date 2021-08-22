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
    public class GameRepository : EfRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Game> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Game> GetAllAsync()
        {
            return _dbContext.Games.AsNoTracking()
                .Include(g => g.Opening)
                .Include(g => g.Moves)
                .Include(g => g.User);
        }

        public async Task<Game> UpdateGameMoves(Guid id, IEnumerable<GameMove> gameMoves)
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == id);
            game.Moves = gameMoves.ToList();
            await _dbContext.SaveChangesAsync();
            return game;
        }

        public async Task<IEnumerable<Game>> GetByUserId(Guid id)
        {
            return await GetAllAsync().Where(g => g.User.Id.Equals(id.ToString())).OrderByDescending(g => g.DateAdded).ToListAsync();
        }
    }
}
