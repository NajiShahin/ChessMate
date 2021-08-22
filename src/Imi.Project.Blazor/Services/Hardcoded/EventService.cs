using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Hardcoded
{
    public class EventService : ICRUDService<EventListItem, EventItem>
    {
        static List<EventItem> events = new List<EventItem>
        {
            new EventItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Tournament",
                Description = "Description of the tournament",
                DateTimeOfEvent = DateTime.Parse("12/04/2021")
            },
            new EventItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Chess tournament 2",
                Description = "Description of the second edition of the chess tournament",
                DateTimeOfEvent = DateTime.Parse("08/06/2021"),
            },
            new EventItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "FIDE World Cup",
                Description = "The FIDE World Cup ",
                DateTimeOfEvent = DateTime.Parse("19/08/2021"),
            }
        };

        public Task Create(EventItem item)
        {
            events.Add(item);
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            var eventItem = events.SingleOrDefault(x => x.Id == id);
            if (eventItem == null) throw new ArgumentException("Event not found!");
            events.Remove(eventItem);
            return Task.CompletedTask;
        }

        public Task<EventItem> Get(Guid id)
        {
            return Task.FromResult(
                events.SingleOrDefault(x => x.Id == id)
            );
        }

        public Task<EventListItem[]> GetList()
        {
            return Task.FromResult(
                events.Select(x => new EventListItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateTimeOfEvent = x.DateTimeOfEvent
                }).ToArray()
            );
        }

        public Task<EventItem> GetNew()
        {
            return Task.FromResult(
                new EventItem()
            );
        }

        public Task Update(EventItem item)
        {
            var evenItem = events.SingleOrDefault(x => x.Id == item.Id);
            if (evenItem == null) throw new ArgumentException("Event not found!");
            evenItem.Name = item.Name;
            evenItem.Description = item.Description;
            evenItem.DateTimeOfEvent = item.DateTimeOfEvent;
            return Task.CompletedTask;
        }
    }
}
