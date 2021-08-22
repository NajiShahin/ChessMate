using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Post : EntityBase
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
