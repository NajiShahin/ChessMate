using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Winrate
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public Winrate(string xValue, int yValue)
        {
            Name = xValue;
            Amount = yValue;
        }
    }
}
