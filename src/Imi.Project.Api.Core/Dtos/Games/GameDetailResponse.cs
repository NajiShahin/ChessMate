using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Games
{
    public class GameDetailResponse : DtoBase
    {
        public string Name { get; set; }
        public string Outcome { get; set; } //"Win" or "Loss" or "Draw"
        public Guid OpeningId { get; set; }
        public string OpeningName { get; set; }
        public DateTime DateAdded { get; set; }
        public string PlayedAs { get; set; } //"White" or "Black"
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsBugged { get; set; }
        public string BugMessage { get; set; }
        public ICollection<MoveResponseDto> Moves { get; set; }
    }
}
