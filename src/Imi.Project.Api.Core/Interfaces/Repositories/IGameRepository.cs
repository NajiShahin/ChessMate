using Imi.Project.Api.Core.Dtos.Games;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetByUserId(Guid id);
        Task<Game> UpdateGameMoves(Guid id, IEnumerable<GameMove> gameMoves);
    }
}
