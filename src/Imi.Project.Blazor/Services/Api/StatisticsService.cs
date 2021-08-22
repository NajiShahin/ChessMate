using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IGameService gameService;

        public StatisticsService(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public async Task<IEnumerable<Guid>> GetMostPlayedOpenings(Guid userId, int amount, string playedAs)
        {

            var games = await gameService.GetGamesByUserId(userId);

            if (playedAs != "")
            {
                return games.GroupBy(g => g.OpeningId).Where(o => o.Select(o => o.PlayedAs).Equals(playedAs))
                      .OrderByDescending(gp => gp.Count())
                      .Take(amount)
                      .Select(a => a.Key);
            }

            return games.GroupBy(g => g.OpeningId)
              .OrderByDescending(gp => gp.Count())
              .Take(amount)
              .Select(a => a.Key);

        }

        public async Task<decimal> GetOpeningWinRate(Guid userId, Guid openingId, string outcome, string playedAs)
        {

            var games = await gameService.GetGamesByUserId(userId);
            games = games.Where(g => g.OpeningId == openingId);
            if (games == null)
                return 0;
            List<GameItem> desiredGames = new List<GameItem>() { };
            if (playedAs != "" && outcome != "")
            {
                desiredGames = games.Where(g => g.Outcome == outcome && g.PlayedAs == playedAs && g.OpeningId == openingId).ToList();
                return Math.Round(Convert.ToDecimal(desiredGames.Count()) / Convert.ToDecimal(games.Count()) * 100, 2);
            }
            else if (playedAs == "" && outcome != "")
            {
                desiredGames = games.Where(g => g.Outcome == outcome && g.OpeningId == openingId).ToList();
                return Math.Round(Convert.ToDecimal(desiredGames.Count()) / Convert.ToDecimal(games.Count()) * 100, 2);
            }
            desiredGames = games.Where(g => g.Outcome == "Win" && g.OpeningId == openingId).ToList();
            return Math.Round(Convert.ToDecimal(desiredGames.Count()) / Convert.ToDecimal(games.Count()) * 100, 2);
        }

        public async Task<decimal> GetWinRate(Guid userId, string outcome, string playedAs)
        {

            var games = await gameService.GetGamesByUserId(userId);
            if (games == null)
                return 0;
            List<GameItem> desiredGames = new List<GameItem>() { };
            if (playedAs != "" && outcome != "")
            {
                desiredGames = games.Where(g => g.Outcome == outcome && g.PlayedAs == playedAs).ToList();
                return Math.Round(Convert.ToDecimal(desiredGames.Count()) / Convert.ToDecimal(games.Count()) * 100, 2);
            }
            else if (playedAs == "" && outcome != "")
            {
                desiredGames = games.Where(g => g.Outcome == outcome).ToList();
                return Math.Round(Convert.ToDecimal(desiredGames.Count()) / Convert.ToDecimal(games.Count()) * 100, 2);
            }
            desiredGames = games.Where(g => g.Outcome == "Win").ToList();
            return Math.Round(Convert.ToDecimal(desiredGames.Count()) / Convert.ToDecimal(games.Count()) * 100, 2);

        }
    }
}
