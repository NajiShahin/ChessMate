using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Openings
{
    public class OpeningsRequestDto : DtoBase
    {
        public string Name { get; set; }
        public string FenString { get; set; }
        public ICollection<MoveRequestDto> Moves { get; set; }
    }
}
