using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Event : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }
    }
}
