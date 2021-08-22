using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Users
{
    public class UserResponseDto : DtoBase
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int GameCount { get; set; }
        public ICollection<EventResponseDto> Events { get; set; }
    }
}
