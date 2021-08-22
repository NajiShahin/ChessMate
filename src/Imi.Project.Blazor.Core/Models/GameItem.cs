using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class GameItem
    {
        public Guid Id { get; set; }
        public Guid OpeningId { get; set; }
        public string OpeningName { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string PlayedAs { get; set; } //"White" or "Black"
        public string Outcome { get; set; }
        public Guid UserId { get; set; }
        public UserItem User { get; set; }
        public bool IsBugged { get; set; }
        public List<Move> Moves { get; set; }
        public string BugMessage { get; set; }
    }
}
