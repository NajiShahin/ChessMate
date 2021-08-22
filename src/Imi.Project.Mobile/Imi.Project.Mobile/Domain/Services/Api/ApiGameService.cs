using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class ApiGameService : IGamesService
    {
        private readonly string _baseUrl;

        public ApiGameService()
        {
            _baseUrl = Constants.BaseUrl;
        }

        public async Task<Game> AddGame(Game game)
        {
            await WebApiClient
                .PostCallApi<Game, Game>($"{_baseUrl}api/games", game);
            return new Game() { };
        }

        public async Task<Game> DeleteGame(Guid id)
        {
            return await WebApiClient
                .DeleteCallApi<Game>($"{_baseUrl}api/games/{id}");
        }

        public async Task<Game> GetGame(Guid id)
        {
            return await WebApiClient
                .GetApiResult<Game>($"{_baseUrl}api/games/{id}");
        }

        public async Task<IQueryable<Game>> GetGameListsForUser(Guid userid)
        {
            var games = await WebApiClient
                .GetApiResult<IEnumerable<Game>>($"{_baseUrl}api/Users/{userid}/games");
            return games.AsQueryable().OrderByDescending(g => g.DateAdded);
        }

        public async Task<Game> UpdateGame(Game game)
        {
            return await WebApiClient
                .PutCallApi<Game, Game>($"{_baseUrl}api/games/{game.Id}", game);
        }

        public async Task<IEnumerable<GameMove>> UpdateGameMoves(Game game)
        {
            
            return await WebApiClient
                .PutCallApi<IEnumerable<GameMove>, IEnumerable<GameMove>>($"{_baseUrl}api/games/{game.Id}/moves", game.Moves.ToList());
        }
    }
}
