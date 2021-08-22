using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Comments
{
    public class CommentResponseDto : DtoBase
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
