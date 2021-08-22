using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Games
{
    public class GameRequestDto : DtoBase
    {
        public string Name { get; set; }
        public string Outcome { get; set; } //"Win" or "Loss" or "Draw"
        public Guid OpeningId { get; set; }
        public DateTime DateAdded { get; set; }
        public string PlayedAs { get; set; } //"White" or "Black"
        public Guid UserId { get; set; }
        public bool IsBugged { get; set; }
        public string BugMessage { get; set; }
        public ICollection<MoveRequestDto> Moves { get; set; }
    }
}/*
{
    "name": "Nice game!",
        "dateAdded": "2021-03-10T21:26:30.008795",
        "playedAs": "Black",
        "UserId": "00000000-0000-0000-0000-000000000002",
        "moves": [
        {
        "turn": 1,
            "movePGN": "b3"
        },
        {
        "turn": 2,
            "movePGN": "d5"
        },
        {
        "turn": 3,
            "movePGN": "c4"
        },
        {
        "turn": 4,
            "movePGN": "dxc4"
        },
        {
        "id": "00000000-0000-0000-0000-000000000011",
            "turn": 5,
            "movePGN": "bxc4"
        }
        ]
}*/