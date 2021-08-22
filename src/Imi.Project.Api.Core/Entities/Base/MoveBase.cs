using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities.Base
{
    public abstract class MoveBase : EntityBase
    {
        public int Turn { get; set; }
        public string MovePGN { get; set; }
        public string MovePath { get; set; }
    }
}
