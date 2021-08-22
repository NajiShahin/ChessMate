using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class GameService : IGameService
    {
        private string baseUrl = "https://localhost:5001/api/games";
        private string userUrl = "https://localhost:5001/api/users";
        private string token = null;

        private readonly HttpClient _httpClient = null;
        private readonly IAuthService _authService;

        public GameService(HttpClient httpClient,
            IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<GameListItem[]> GetList()
        {
            await AddToken();

            return JsonConvert.DeserializeObject<GameListItem[]>(await _httpClient.GetAsync(baseUrl).Result.Content.ReadAsStringAsync());
        }


        public async Task<GameItem> Get(Guid id)
        {
            await AddToken();

            return JsonConvert.DeserializeObject<GameItem>(await _httpClient.GetAsync(baseUrl + $"/{id}").Result.Content.ReadAsStringAsync());
        }

        public async Task Update(GameItem item)
        {
            await AddToken();

            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(baseUrl, content);
        }

        public async Task<IEnumerable<GameItem>> GetGamesByUserId(Guid id)
        {
            token = await _authService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            /*

            var aze = await _httpClient.GetAsync(userUrl + $"/{id}/games");
            var efoze = await aze.Content.ReadAsStringAsync();*/
            var a = JsonConvert.DeserializeObject<GameItem[]>(await _httpClient.GetAsync(userUrl + $"/{id}/games").Result.Content.ReadAsStringAsync());
            return a;
        }

        private async Task AddToken()
        {
            if (token == null)
            {
                token = await _authService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                await Task.CompletedTask;
            }
        }
    }
}
