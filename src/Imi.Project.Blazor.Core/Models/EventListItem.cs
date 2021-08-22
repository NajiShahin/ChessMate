using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class EventListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
    }
}
