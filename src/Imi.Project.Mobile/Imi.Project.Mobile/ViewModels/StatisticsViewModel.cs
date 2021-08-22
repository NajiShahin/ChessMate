using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class StatisticsViewModel : FreshBasePageModel
    {


        private readonly IGamesService gamesService;
        private readonly IOpeningsService openingsService;
        private readonly IAuthService authService;

        public StatisticsViewModel(IGamesService gamesService,
            IOpeningsService openingsService,
            IAuthService authService)
        {
            this.gamesService = gamesService;
            this.openingsService = openingsService;
            this.authService = authService;
        }


        private ObservableCollection<Winrate> data;

        public ObservableCollection<Winrate> Data
        {
            get { return data; }
            set
            {
                data = value;
                RaisePropertyChanged(nameof(Data));
            }
        }



        private int winCount;

        public int WinCount
        {
            get { return winCount; }
            set
            {
                winCount = value;
                RaisePropertyChanged(nameof(WinCount));
            }
        }

        private int drawCount;

        public int DrawCount
        {
            get { return drawCount; }
            set
            {
                drawCount = value;
                RaisePropertyChanged(nameof(DrawCount));
            }
        }

        private int lossCount;

        public int LossCount
        {
            get { return lossCount; }
            set
            {
                lossCount = value;
                RaisePropertyChanged(nameof(LossCount));
            }
        }

        private ObservableCollection<WinrateOpenings> winrateOpenings;

        public ObservableCollection<WinrateOpenings> WinrateOpenings
        {
            get { return winrateOpenings; }
            set
            {
                winrateOpenings = value;
                RaisePropertyChanged(nameof(WinrateOpenings));
            }
        }

        public async override void Init(object initData)
        {
            base.Init(initData);
            await GetWinrates();
            await GetOpeningsWinrates();
        }

        private async Task GetOpeningsWinrates()
        {
            var claims = await authService.GetClaims();
            var userId = Guid.Parse(claims.FirstOrDefault(c => c.Type == "id").Value);
            var games = await gamesService.GetGameListsForUser(userId);

            WinrateOpenings = new ObservableCollection<WinrateOpenings>();

            var mostPlayedOpenings = games.GroupBy(g => g.OpeningId)
              .OrderByDescending(gp => gp.Count())
              .Take(5)
              .Select(a => a.Key);

            for (int i = 0; i < 5; i++)
            {
                if (mostPlayedOpenings.Count() == i)
                {
                    break;
                }
                var tempOpening = await openingsService.GetOpening(mostPlayedOpenings.ToList()[i]);
                var openingGames = games.Where(g => g.OpeningId == tempOpening.Id);
                WinrateOpenings.Add(new WinrateOpenings()
                {
                    Number = i + 1,
                    Name = tempOpening.Name,
                    Winrate = $"{Math.Round(Convert.ToDecimal(games.Where(g => g.Outcome == "Win" && g.OpeningId == tempOpening.Id).Count()) / Convert.ToDecimal(openingGames.Count()) * 100, 2)}%",
                    Drawrate = $"{Math.Round(Convert.ToDecimal(games.Where(g => g.Outcome == "Draw" && g.OpeningId == tempOpening.Id).Count()) / Convert.ToDecimal(openingGames.Count()) * 100, 2)}%",
                    Lossrate = $"{Math.Round(Convert.ToDecimal(games.Where(g => g.Outcome == "Loss" && g.OpeningId == tempOpening.Id).Count()) / Convert.ToDecimal(openingGames.Count()) * 100, 2)}%",
                });
            }
        }

        private async Task GetWinrates()
        {
            var claims = await authService.GetClaims();
            var userId = Guid.Parse(claims.FirstOrDefault(c => c.Type == "id").Value);
            try
            {
                var games = await gamesService.GetGameListsForUser(userId); //Moet nog veranderen!!
                WinCount = new List<Game>(games).Where(g => g.Outcome == "Win").Count();
                DrawCount = new List<Game>(games).Where(g => g.Outcome == "Draw").Count();
                LossCount = new List<Game>(games).Where(g => g.Outcome == "Loss").Count();
                RefreshPiechartData();
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
        }

        private void RefreshPiechartData()
        {
            Data = null;
            Data = new ObservableCollection<Winrate>()
            {
                new Winrate("Win", WinCount),
                new Winrate("Draw", DrawCount),
                new Winrate("Loss", LossCount),
            };
        }

    }
}
