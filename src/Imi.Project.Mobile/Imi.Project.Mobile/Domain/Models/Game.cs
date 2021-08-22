using Imi.Project.Mobile.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Game : EntityBase
    {
        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public string PlayedAs { get; set; }
        public string Outcome { get; set; }
        public Opening Opening { get; set; }
        public Guid OpeningId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsBugged { get; set; }
        public string BugMessage { get; set; }
        public ICollection<GameMove> Moves { get; set; }
    }
}
