using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services;
using Imi.Project.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages.Base
{
    public class UsersBase: ComponentBase
    {
        public UserListItem[] userListItem;
        public UserItem CurrentUser;
        public IEnumerable<GameItem> Games;
        private string error;
        public bool showStats = false;

        [Inject]
        ICRUDService<UserListItem, UserItem> service { get; set; }
        [Inject]
        IGameService gameService { get; set; }

        protected async Task ViewUserStats(UserListItem item)
        {
            showStats = true;
            await EditUser(item);
            this.Games = await gameService.GetGamesByUserId(item.Id);
        }

        protected override async Task OnInitializedAsync()
        {
            await ShowList();
        }

        public async Task ShowList()
        {
            userListItem = await service.GetList();
            this.CurrentUser = null;
        }

        public async Task EditUser(UserListItem item)
        {
            this.CurrentUser = await service.Get(item.Id);
        }

        public async Task DeleteUser(UserListItem item)
        {
            try
            {
                await service.Delete(item.Id);
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }

        public async Task SaveUser()
        {
            try
            {
                if (CurrentUser.Id == null)
                {
                    await service.Create(CurrentUser);
                }
                else
                {
                    await service.Update(CurrentUser);
                }
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }
    }
}
