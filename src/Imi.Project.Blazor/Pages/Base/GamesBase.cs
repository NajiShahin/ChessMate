using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services.Interfaces;
using Imi.Project.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages.Base
{
    public class GamesBase: ComponentBase
    {
        public GameListItem[] GameListItem;
        public GameItem CurrentGame;
        public char[,] Chessboard;

        [Inject]
        IGameService service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ShowBuggedGameList();
        }

        public async Task ShowList()
        {
            GameListItem = await service.GetList();
            this.CurrentGame = null;
        }

        public async Task ShowBuggedGameList()
        {
            GameListItem = await service.GetList();
            GameListItem = GameListItem?.Where(g => g?.IsBugged == true)?.ToArray();
            this.CurrentGame = null;
        }

        public async Task ViewGame(GameListItem item)
        {
            this.CurrentGame = await service.Get(item.Id);
            ChessConverter converter = new ChessConverter('p', 'r', 'h', 'b', 'q', 'k', 'o', 't', 'j', 'n', 'w', 'l');
            this.Chessboard = converter.GetStartingBoard();
        }
    }
}
