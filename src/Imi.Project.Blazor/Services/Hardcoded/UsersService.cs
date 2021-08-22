using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Hardcoded
{
    public class UsersService : ICRUDService<UserListItem, UserItem>
    {

        static List<UserItem> users = new List<UserItem>
        {
            new UserItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Username = "Billy",
                FirstName = "Bill",
                LastName = "Billson",
                Email = "Bill.Billson@Gmail.com"
            },
            new UserItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Username = "Timmy",
                FirstName = "Tim",
                LastName = "Aat",
                Email = "Tim.Aat@Gmail.com"
            },
            new UserItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Username = "Tommy",
                FirstName = "Tom",
                LastName = "Aat",
                Email = "Tom.Aat@Gmail.com"
            }
        };

        public Task Create(UserItem item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            var user = users.SingleOrDefault(x => x.Id == id);
            if (user == null) throw new ArgumentException("user not found!");
            users.Remove(user);
            return Task.CompletedTask;
        }

        public Task<UserItem> Get(Guid id)
        {
            return Task.FromResult(
                users.SingleOrDefault(x => x.Id == id)
            );
        }

        public Task<UserListItem[]> GetList()
        {
            return Task.FromResult(
                users.Select(x => new UserListItem()
                {
                    Id = x.Id,
                    UserName = x.Username
                }).ToArray()
            );
        }

        public Task<UserItem> GetNew()
        {
            throw new NotImplementedException();
        }

        public Task Update(UserItem item)
        {
            var user = users.SingleOrDefault(x => x.Id == item.Id);
            if (user == null) throw new ArgumentException("User not found!");
            user.Username = item.Username;
            user.FirstName = item.FirstName;
            user.LastName = item.LastName;
            user.Email = item.Email;
            return Task.CompletedTask;
        }
    }
}
