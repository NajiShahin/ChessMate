using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class GameListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsBugged { get; set; }
    }
}
