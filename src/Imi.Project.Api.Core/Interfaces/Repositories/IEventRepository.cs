using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<bool> AddUserToEvent(Guid id, Guid userId);
    }
}
