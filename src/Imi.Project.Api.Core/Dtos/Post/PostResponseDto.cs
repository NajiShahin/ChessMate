using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Post
{
    public class PostResponseDto : DtoBase
    {
        public string groupName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<CommentResponseDto> Comments { get; set; }
    }
}
