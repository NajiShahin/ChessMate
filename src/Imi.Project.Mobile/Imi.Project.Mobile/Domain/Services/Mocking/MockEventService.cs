using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public class MockEventService : IEventService
    {
        public MockEventService()
        {

        }

        private static List<Event> eventList = new List<Event>
        {
                new Event { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "FIDE Candidates Tournament (Second Half)", Description = "The second half of the eight-player, double round-robin that will determine the next opponent of Magnus Carlsen. Kirill Alekseenko, Fabiano Caruana, Ding Liren, Anish Giri, Alexander Grischuk, Ian Nepomniachtchi, Maxime-Vachier-Lagrave, and Wang Hao play. (Classical)", DateTimeOfEvent = DateTime.Parse("19/04/2021 00:00") },
                new Event { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "TePe Sigeman & Co Chess Tournament 2021", Description = "The TePe Sigeman & Co Chess Tournament takes place April 24-30, 2021 in Malmo, Sweden and has GMs Le Quang Liem, David Navara, Jorden van Foreest, Nils Grandelius, Alexei Shirov, Nihal Sarin, Anatoly Karpov(!) and Harika Dronavalli. (Classical)", DateTimeOfEvent = DateTime.Parse("24/04/2021 00:00") },
                new Event { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Champions Chess Tour Regular #3", Description = "The fifth leg in the Champions Chess Tour is a 'regular' with 16 players and a $100,000 prize fund.", DateTimeOfEvent = DateTime.Parse("27/04/2021 00:00") },
                new Event { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Norway Chess 2021", Description = "The ninth edition of Norway Chess takes place May 9-21, 2021 at the Clarion Hotel Energy and the Quality Hotel Residence in Stavanger, Norway. The tournament is once again very strong, with the world's number one and two topping the field. So far, only nine of the 10 participants have been announced.", DateTimeOfEvent = DateTime.Parse("12/05/2021 00:00") },
                new Event { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Grand Chess Tour Superbet Chess Classic Romania 2021", Description = "The 2021 Grand Chess Tour will feature two classical and three rapid & blitz events, picking up after the cancellation of the 2020 season. Tour participants will compete for a total prize fund of $1.275 million, including $325,000 per classical tournament and $150,000 in prizes for rapid & blitz events. In addition, a bonus prize fund totaling $175,000 will be awarded to the top three overall GCT finishers.", DateTimeOfEvent = DateTime.Parse("18/05/2021 00:00") }
    };

        public async Task<Event> AddEvent(Event eventToAdd)
        {
            eventList.Add(eventToAdd);
            return await Task.FromResult(eventToAdd);
        }

        public async Task<Event> DeleteEvent(Guid id)
        {
            var oldEvent = eventList.FirstOrDefault(e => e.Id == id);
            eventList.Remove(oldEvent);
            return await Task.FromResult(oldEvent);
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var eventToGet = eventList.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(eventToGet);
        }

        public async Task<IQueryable<Event>> GetEventList()
        {
            var eventsToGet = eventList.AsQueryable();
            return await Task.FromResult(eventsToGet);
        }

        public async Task<Event> UpdateEvent(Event eventToUpdate)
        {
            var oldEvent = eventList.FirstOrDefault(e => e.Id == eventToUpdate.Id);
            eventList.Remove(oldEvent);
            eventList.Add(eventToUpdate);
            return await Task.FromResult(eventToUpdate);
        }
    }
}
