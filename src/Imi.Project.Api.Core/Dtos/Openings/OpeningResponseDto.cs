using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Openings
{
    public class OpeningResponseDto : DtoBase
    {
        public string Name { get; set; }
        public string FenString { get; set; }
    }
}
