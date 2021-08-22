using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.ViewModels
{
    public class EventsDetailViewModel : FreshBasePageModel
    {
        private readonly IEventService eventService;
        private Event currentEvent;

        public EventsDetailViewModel(IEventService eventService)
        {
            this.eventService = eventService;
        }

        private Event eventItem;

        public Event Event
        {
            get { return eventItem; }
            set
            {
                eventItem = value;
                RaisePropertyChanged(nameof(Event));
            }
        }

        private string eventDate;

        public string EventDate
        {
            get { return eventDate; }
            set
            {
                eventDate = value;
                RaisePropertyChanged(nameof(EventDate));
            }
        }

        
        private string hasUrl;

        public string HasUrl
        {
            get { return hasUrl; }
            set
            {
                hasUrl = value;
                RaisePropertyChanged(nameof(HasUrl));
            }
        }

        public async override void Init(object initData)
        {
            base.Init(initData);

            currentEvent = initData as Event;
            Event = await eventService.GetEvent(currentEvent.Id);
            EventDate = Event.DateTimeOfEvent.Date.ToString("dd/MM/yyyy");
            CheckUrl();
        }

        public ICommand VisitWebsite => new Command(
          async () =>
          {
              try
              {
                  await Browser.OpenAsync(Event.Url, BrowserLaunchMode.SystemPreferred);
              }
              catch (Exception ex)
              {
                  
              }
          }
          );

        private void CheckUrl()
        {
            if (Event.Url != null)
            {
                HasUrl = "True";
            }
            else
            {
                HasUrl = "False";
            }
        }
    }
}
