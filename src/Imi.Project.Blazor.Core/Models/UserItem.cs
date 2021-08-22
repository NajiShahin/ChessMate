using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class UserItem
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
