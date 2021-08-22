using Imi.Project.Api.Core.Entities.Base;
using System;

namespace Imi.Project.Api.Core.Entities
{
    public class GameMove : MoveBase
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public string Annotation { get; set; }
    }
}