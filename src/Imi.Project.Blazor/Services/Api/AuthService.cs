using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class AuthService : IAuthService
    {
        private string baseUrl = "https://localhost:5001/api/auth/login";

        private readonly HttpClient _httpClient = null;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> GetToken()
        {
            //Mag normaal niet in code en plain text.
            var userLogin = new LoginRequest()
            {
                UserName = "Admin",
                Password = "Test123?"
            };

            var response = _httpClient.PostAsJsonAsync<LoginRequest>($"{baseUrl}", userLogin);

            var token = JsonConvert.DeserializeObject<LoginResponse>(await response.Result.Content.ReadAsStringAsync());

            return token.Token;

        }
    }
}
