using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<User>> ListAllAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public IQueryable<User> GetFiltered(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<User>().Where(predicate).AsQueryable();
        }

        public async Task<IEnumerable<User>> ListFiltered(Expression<Func<User, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<User> AddAsync(User entity)
        {
            await _dbContext.Set<User>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var user = await GetByIdAsync(Guid.Parse(entity.Id));

            var hasher = new PasswordHasher<User>();

            user.UserName = entity.UserName;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.NormalizedEmail = entity.Email.ToUpper();
            user.NormalizedUserName = entity.UserName.ToUpper();

            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> DeleteAsync(User entity)
        {
            foreach (var game in entity.Games)
            {
                game.Opening = null;
            }
            _dbContext.RemoveRange(entity.Games);
            _dbContext.Set<User>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
            return entity;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id.ToString())) ;
        }
        public IQueryable<User> GetAllAsync()
        {
            return _dbContext.Users.AsNoTracking()
                .Include(u => u.Games)
                .ThenInclude(u => u.Moves)
                .Include(u => u.Games)
                .ThenInclude(u => u.Opening)
                .Include(u => u.UserEvents)
                .ThenInclude(u => u.Event);
        }

        public async Task<IEnumerable<User>> SearchByNameAsync(string username)
        {
            return await GetAllAsync()
            .Where(t => t.UserName.ToUpper().Contains(username.ToUpper()))
            .ToListAsync();
        }

        public Task<User> GetByIdAsync(Guid id, string[] includes)
        {
            throw new NotImplementedException();
        }
    }
}
