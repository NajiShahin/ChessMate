using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Comment : EntityBase
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
    }
}
