using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<string> Login(string userName, string password);
        Task<IEnumerable<string>> Register(User registration, string userName, string password);
    }
}
