using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Moves
{
    public class MoveResponseDto
    {
        public Guid Id { get; set; } //Id of game/openingMove
        public int Turn { get; set; }
        public string MovePGN { get; set; }
        public string MovePath { get; set; }
        public string Annotation { get; set; }
    }
}
