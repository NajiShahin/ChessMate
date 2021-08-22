using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IGamesService
    {
        Task<Game> GetGame(Guid id);
        Task<IQueryable<Game>> GetGameListsForUser(Guid userid);
        Task<Game> UpdateGame(Game game);
        Task<IEnumerable<GameMove>> UpdateGameMoves(Game game);
        Task<Game> AddGame(Game game);
        Task<Game> DeleteGame(Guid id);
    }
}
