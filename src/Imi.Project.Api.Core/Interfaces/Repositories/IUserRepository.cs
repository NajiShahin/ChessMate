using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SearchByNameAsync(string username);
        Task<User> GetByIdAsync(Guid id);
        IQueryable<User> GetAllAsync();
        Task<IEnumerable<User>> ListAllAsync();
        IQueryable<User> GetFiltered(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> ListFiltered(Expression<Func<User, bool>> predicate);
        Task<User> AddAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task<User> DeleteAsync(User entity);
        Task<User> DeleteAsync(Guid id);
    }
}
