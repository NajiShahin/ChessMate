using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Groups
{
    public class GroupDetailResponseDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateMade { get; set; }
        public ICollection<UserResponseDto> Users { get; set; }
    }
}
