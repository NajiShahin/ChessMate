using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class EventItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
    }
}
