using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Groups
{
    public class GroupRequestDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateMade { get; set; }
    }
}
