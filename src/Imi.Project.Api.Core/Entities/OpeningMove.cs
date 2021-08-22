using Imi.Project.Api.Core.Entities.Base;
using System;

namespace Imi.Project.Api.Core.Entities
{
    public class OpeningMove : MoveBase
    {
        public Guid OpeningId { get; set; }
        public Opening Opening { get; set; }
    }
}