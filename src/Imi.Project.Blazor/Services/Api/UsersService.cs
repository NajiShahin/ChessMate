using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using Imi.Project.Blazor.Services.Interfaces;

namespace Imi.Project.Blazor.Services.Api
{
    public class UsersService : ICRUDService<UserListItem, UserItem>
    {
        private string baseUrl = "https://localhost:5001/api/users";

        private string token = null;
        private readonly IAuthService _authService;

        private readonly HttpClient _httpClient = null;

        public UsersService(HttpClient httpClient,
            IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task Create(UserItem item)
        {
            await AddToken();

            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            await AddToken();

            await _httpClient.DeleteAsync(baseUrl + $"/{id}");
        }

        public async Task<UserItem> Get(Guid id)
        {
            await AddToken();

            return JsonConvert.DeserializeObject<UserItem>(await _httpClient.GetAsync(baseUrl + $"/{id}").Result.Content.ReadAsStringAsync());

        }

        public async Task<UserListItem[]> GetList()
        {
            await AddToken();

            return JsonConvert.DeserializeObject<UserListItem[]>(await _httpClient.GetAsync(baseUrl).Result.Content.ReadAsStringAsync());
        }

        public Task<UserItem> GetNew()
        {
            throw new NotImplementedException();
        }

        public async Task Update(UserItem item)
        {
            await AddToken();

            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(baseUrl, content);

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
