using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Base
{
    public abstract class MoveBase
    {
        public Guid Id { get; set; }
        public int Turn { get; set; }
        public string MovePGN { get; set; } //Uploaded PGN move. example: Nc3
        public string MovePath { get; set; } //Path made by a chess piece. example: b1c3
    }
}
