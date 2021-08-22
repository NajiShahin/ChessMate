using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.Pages;
using Moq;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Security.Claims;
using Imi.Project.Mobile.Domain.Models;
using System.Linq;
using System.Collections.ObjectModel;

namespace Imi.Project.Mobile.UnitTests
{
    public class MainTabbedVmTests
    {
        
        [Fact]
        public void AddNewGameWithoutInput_Returns_Error()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            var mockGameService = new Mock<IGamesService>();
            var mockOpeningService = new Mock<IOpeningsService>();
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(repo => repo.GetClaims().Result)
                .Returns(new List<Claim> { new Claim("id", Guid.Empty.ToString()) });
            var tabbedVm = new MainTabbedViewModel(mockGameService.Object, mockOpeningService.Object, mockEventService.Object, mockAuthService.Object);

            // Act
            tabbedVm.AddNewGame.Execute(null);

            // Assert
            Assert.NotNull(tabbedVm.ErrorMessage);
        }



        [Fact]
        public void ClearGameMovesToAdd_ClearsGameMovesToAdd()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            var mockGameService = new Mock<IGamesService>();
            var mockOpeningService = new Mock<IOpeningsService>();
            var mockAuthService = new Mock<IAuthService>();
            var tabbedVm = new MainTabbedViewModel(mockGameService.Object, mockOpeningService.Object, mockEventService.Object, mockAuthService.Object);
            tabbedVm.GameMovesToAdd = "e4 e5";
            var expected = "";

            // Act
            tabbedVm.ClearGameMovesToAdd.Execute(null);

            // Assert
            Assert.Equal(expected, tabbedVm.GameMovesToAdd);
        }


        [Fact]
        public void FilterGames_FilterCorrectly()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            var mockGameService = new Mock<IGamesService>();
            var mockOpeningService = new Mock<IOpeningsService>();
            var mockAuthService = new Mock<IAuthService>();

            var games = new List<Game>() { new Game
            {
                Id = Guid.NewGuid(),
                Name = "Game"
            },
            new Game {
                Id = Guid.NewGuid(),
                Name = "l"
            },
            new Game {
            Id = Guid.NewGuid(),
            Name = "p"
            } };

            mockGameService.Setup(repo => repo.GetGameListsForUser(Guid.Empty).Result)
                .Returns(games.AsQueryable());

            var tabbedVm = new MainTabbedViewModel(mockGameService.Object, mockOpeningService.Object, mockEventService.Object, mockAuthService.Object);
            tabbedVm.LoadedGames = new ObservableCollection<Game>(games);
            tabbedVm.GamesSearch = "gam";
            var expectedCount = 1;

            // Act
            tabbedVm.GameFilter.Execute(null);

            // Assert
            Assert.Equal(expectedCount, tabbedVm.Games.Count);
        }
    }
}
