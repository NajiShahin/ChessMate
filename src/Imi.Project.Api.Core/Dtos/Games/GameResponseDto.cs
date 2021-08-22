using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Games
{
    public class GameResponseDto : DtoBase
    {
        public string Name { get; set; }
        public string Outcome { get; set; } //"Win" or "Loss" or "Draw"
        public string OpeningName { get; set; }
        public DateTime DateAdded { get; set; }
        public string PlayedAs { get; set; } //"White" or "Black"
        public string UserName { get; set; }
        public bool IsBugged { get; set; }
        public string BugMessage { get; set; }
        public int MoveCount { get; set; }
    }
}
