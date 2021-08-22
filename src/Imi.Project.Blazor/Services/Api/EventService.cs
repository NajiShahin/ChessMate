using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class EventService : ICRUDService<EventListItem, EventItem>
    {
        private string baseUrl = "https://localhost:5001/api/events";

        private readonly HttpClient _httpClient = null;
        private readonly IAuthService _authService;
        private string token = null;

        public EventService(HttpClient httpClient,
            IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<EventListItem[]> GetList()
        {
            await AddToken();
            return JsonConvert.DeserializeObject<EventListItem[]>(await _httpClient.GetAsync(baseUrl).Result.Content.ReadAsStringAsync());
        }

        public async Task<EventItem> GetNew()
        {
            await AddToken();

            return new EventItem();
            
        }

        public async Task<EventItem> Get(Guid id)
        {
            await AddToken();

            return JsonConvert.DeserializeObject<EventItem>(await _httpClient.GetAsync(baseUrl + $"/{id}").Result.Content.ReadAsStringAsync());
        }

        public async Task Create(EventItem item)
        {
            await AddToken();

            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(baseUrl, content);
        }

        public async Task Update(EventItem item)
        {
            await AddToken();

            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(baseUrl, content);
        }

        public async Task Delete(Guid id)
        {
            await AddToken();

            await _httpClient.DeleteAsync(baseUrl + $"/{id}");
        }

        private async Task AddToken()
        {
            if (token == null)
            {
                token = await _authService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                await Task.CompletedTask;
            }
        }

        /*
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
           Date = x.DateTime
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
   evenItem.DateTime = item.DateTime;
   return Task.CompletedTask;
}*/
    }
}
