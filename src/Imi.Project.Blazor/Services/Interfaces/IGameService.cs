using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameListItem[]> GetList();
        Task<GameItem> Get(Guid id);
        Task Update(GameItem item);
        Task<IEnumerable<GameItem>> GetGamesByUserId(Guid id);
    }
}
