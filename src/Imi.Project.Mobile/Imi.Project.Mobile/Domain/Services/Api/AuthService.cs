using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class AuthService : IAuthService
    {
        private readonly string _baseUrl;
        public AuthService()
        {
            _baseUrl = Constants.BaseUrl;
        }

        public async Task<string> GetToken(string username, string password)
        {
            var loginRequest = new LoginRequest()
            {
                UserName = username,
                Password = password
            };

            var token = await WebApiClient.PostCallApi<LoginResponse, LoginRequest>($"{_baseUrl}api/auth/login", loginRequest);

            return token.Token;
        }

        public async Task<IEnumerable<Claim>> GetClaims()
        {
            var token = await SecureStorage.GetAsync("oauth_token");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var claims = tokenS.Claims;
            return claims;
        }

        public Task Register(string userName, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string streetName, int houseNumber, string postalCode, string cityName)
        {
            var registerRequest = new RegisterRequest()
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                password = password,
                DateOfBirth = dateOfBirth,
                StreetName = streetName,
                HouseNumber = houseNumber,
                PostalCode = postalCode,
                CityName = cityName
            };

            var response = WebApiClient.PostCallApi<RegisterRequest, RegisterRequest>($"{_baseUrl}api/auth/register", registerRequest);
            return Task.CompletedTask;
        }
    }
}
