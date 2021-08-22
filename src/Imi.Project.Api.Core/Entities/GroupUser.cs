using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class GroupUser
    {
        public string UserId { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }
    }
}
