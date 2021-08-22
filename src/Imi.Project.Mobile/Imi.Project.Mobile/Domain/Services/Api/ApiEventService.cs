using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class ApiEventService : IEventService
    {
        private readonly string _baseUrl;

        public ApiEventService()
        {
            _baseUrl = Constants.BaseUrl;
        }

        public async Task<Event> AddEvent(Event eventItem)
        {
            await WebApiClient
                .PostCallApi<Event, Event>($"{_baseUrl}api/events", eventItem);
            return new Event() { };
        }

        public async Task<Event> DeleteEvent(Guid id)
        {
            return await WebApiClient
                .DeleteCallApi<Event>($"{_baseUrl}api/events/{id}");
        }

        public async Task<Event> GetEvent(Guid id)
        {
            return await WebApiClient
                .GetApiResult<Event>($"{_baseUrl}api/events/{id}");
        }

        public async Task<IQueryable<Event>> GetEventList()
        {
            var bucketLists = await WebApiClient
                .GetApiResult<IEnumerable<Event>>($"{_baseUrl}api/events");
            return bucketLists.AsQueryable();
        }

        public async Task<Event> UpdateEvent(Event eventItem)
        {
            return await WebApiClient
                .PutCallApi<Event, Event>($"{_baseUrl}api/events/{eventItem.Id}", eventItem);
        }


    }
}
