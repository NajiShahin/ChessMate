using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public AuthRepository(UserManager<User> userManager,
            SignInManager<User> signInManager,
            Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false,
           lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return null;
            }

            var applicationUser = await _userManager.FindByNameAsync(userName);
            JwtSecurityToken token = await GenerateTokenAsync(applicationUser);
            //defined
            string serializedToken = new JwtSecurityTokenHandler().WriteToken(token); //serialize the token
            return serializedToken;
        }

        private async Task<JwtSecurityToken> GenerateTokenAsync(User user)
        {
            var claims = new List<Claim>();
            // Loading the user Claims
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
            // Loading the roles and put them in a claim of a Role ClaimType
            var roleClaims = await _userManager.GetRolesAsync(user);
            foreach (var roleClaim in roleClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
            }
            var expirationDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
            var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
            var token = new JwtSecurityToken
            (
            issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
            audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey),

           SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public async Task<IEnumerable<string>> Register(User registration, string userName, string password)
        {
            User newUser = new User
            {
                Email = registration.Email,
                UserName = userName,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                StreetName = registration.StreetName,
                CityName = registration.CityName,
                PostalCode = registration.PostalCode,
                Id = registration.Id.ToString(),
                DateOfBirth = registration.DateOfBirth,
                HouseNumber = registration.HouseNumber
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, password);
            if (!result.Succeeded)
            {
                List<string> listErrors = new List<string>();
                foreach (var error in result.Errors)
                {
                    listErrors.Add(error.Description);
                }
                return listErrors;
            }
            newUser = await _userManager.FindByNameAsync(userName);
            await _userManager.AddToRoleAsync(newUser, "User");
            await _userManager.AddClaimAsync(newUser,
           new Claim("registration-date", DateTime.UtcNow.ToString("dd-MM-yy")));
            await _userManager.AddClaimAsync(newUser,
           new Claim("name", userName.ToString()));
            await _userManager.AddClaimAsync(newUser,
                new Claim("id", newUser.Id));
            return null;
        }

    }
}
