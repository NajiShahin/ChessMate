using System;

namespace Imi.Project.Blazor.Core.Models
{
    public class Move
    {
        public Guid GameId { get; set; }
        public GameItem Game { get; set; }
        public int Turn { get; set; }
        public string MovePGN { get; set; }
    }
}