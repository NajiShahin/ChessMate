using Imi.Project.Mobile.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Opening : EntityBase
    {
        public string Name { get; set; }
        public ICollection<OpeningMove> Moves { get; set; }
    }
}
