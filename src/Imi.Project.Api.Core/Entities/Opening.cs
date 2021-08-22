using Imi.Project.Api.Core.Entities.Base;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class Opening : EntityBase
    {
        public string Name { get; set; }
        public string FenString { get; set; }
        public ICollection<OpeningMove> Moves { get; set; }
    }
}