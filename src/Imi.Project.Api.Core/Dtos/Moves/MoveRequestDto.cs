using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Moves
{
    public class MoveRequestDto : DtoBase
    {
        public int Turn { get; set; }
        public string MovePGN { get; set; }
        public string Annotation { get; set; }
    }
}
