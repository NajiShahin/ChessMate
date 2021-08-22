using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Game : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public Opening Opening { get; set; }
        public Guid OpeningId { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public string PlayedAs { get; set; } //"White" or "Black"
        [Required]
        public string Outcome { get; set; } //"Win" or "Loss" or "Draw"
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsBugged { get; set; }
        public string BugMessage { get; set; }
        public ICollection<GameMove> Moves { get; set; }
    }
}
