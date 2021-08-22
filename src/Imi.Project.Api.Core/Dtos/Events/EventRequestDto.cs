using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Events
{
    public class EventRequestDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
    }
}
