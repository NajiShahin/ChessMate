using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Users
{
    public class LoginUserRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
