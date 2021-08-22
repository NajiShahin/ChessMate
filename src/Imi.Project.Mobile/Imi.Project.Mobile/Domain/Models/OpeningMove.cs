using Imi.Project.Mobile.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class OpeningMove : MoveBase
    {
        public Guid OpeningId { get; set; }
        public Game Opening { get; set; }
    }
}
