using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IEventService
    {
        Task<Event> GetEvent(Guid id);
        Task<IQueryable<Event>> GetEventList();
        Task<Event> UpdateEvent(Event eventToUpdate);
        Task<Event> AddEvent(Event eventToAdd);
        Task<Event> DeleteEvent(Guid id);
    }
}
