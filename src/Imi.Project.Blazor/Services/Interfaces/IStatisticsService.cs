using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<decimal> GetWinRate(Guid userId, string outcome, string playedAs);
        Task<decimal> GetOpeningWinRate(Guid userId, Guid openingId, string outcome, string playedAs);
        Task<IEnumerable<Guid>> GetMostPlayedOpenings(Guid userId, int amount, string playedAs);
    }
}
