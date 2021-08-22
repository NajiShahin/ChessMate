using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Group : EntityBase
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateMade { get; set; }
        public ICollection<GroupUser> GroupUsers { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
