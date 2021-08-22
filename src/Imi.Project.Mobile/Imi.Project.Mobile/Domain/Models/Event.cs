using Imi.Project.Mobile.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Event : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
    }
}
