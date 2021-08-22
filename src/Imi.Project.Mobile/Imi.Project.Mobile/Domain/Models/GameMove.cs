using Imi.Project.Mobile.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class GameMove : MoveBase
    {
        public string Annotation { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
