using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetToken(string username, string password);
        Task Register(string userName, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string streetName, int houseNumber, string postalCode, string cityName);
        Task<IEnumerable<Claim>> GetClaims();
    }
}
