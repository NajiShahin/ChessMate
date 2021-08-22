using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Moves
{
    public class MoveOpeningResponse : DtoBase
    {
        public int Turn { get; set; }
        public string MovePGN { get; set; }
        public string MovePath { get; set; }

    }
}
