using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages.Base
{
    public class EventsBase : ComponentBase
    {
        public EventListItem[] eventListItem;
        public EventItem CurrentEvent;
        private string error;

        [Inject]
        ICRUDService<EventListItem, EventItem> service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ShowList();
        }

        public async Task ShowList()
        {
            eventListItem = await service.GetList();
            this.CurrentEvent = null;
        }

        public async Task EditEvent(EventListItem item)
        {
            this.CurrentEvent = await service.Get(item.Id);
        }

        public async Task AddEvent()
        {
            this.CurrentEvent = await service.GetNew();
        }

        public async Task DeleteEvent(EventListItem item)
        {
            try
            {
                await service.Delete(item.Id);
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }

        public async Task SaveEvent(EventItem item)
        {
            try
            {
                if (!service.GetList().Result.Any(e => e.Id == item.Id))
                {
                    await service.Create(CurrentEvent);
                }
                else
                {
                    await service.Update(CurrentEvent);
                }
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }
    }
}
