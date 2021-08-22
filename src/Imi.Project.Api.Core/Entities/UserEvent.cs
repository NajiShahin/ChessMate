using System;

namespace Imi.Project.Api.Core.Entities
{
    public class UserEvent
    {
        public string UserId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
    }
}