using FluentValidation;
using FreshMvvm;
using Imi.Project.Common;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainTabbedViewModel : FreshBasePageModel
    {
        private readonly IGamesService gamesService;
        private readonly IOpeningsService openingsService;
        private readonly IEventService eventService;
        private readonly IAuthService authService;
        public MainTabbedViewModel(IGamesService gamesService,
            IOpeningsService openingsService,
            IEventService eventService,
            IAuthService authService)
        {
            this.gamesService = gamesService;
            this.openingsService = openingsService;
            this.eventService = eventService;
            this.authService = authService;
        }

        public MainTabbedViewModel(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);
            await RefreshGameLists();
        }
        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            await RefreshGameLists();
            await LoadOpenings();
            await LoadEvents();
            await LoadPages();
        }


        /*
         *      UPLOAD PAGE
         */
        private string outcome;

        public string Outcome
        {
            get { return outcome; }
            set
            {
                outcome = value;
                RaisePropertyChanged(nameof(Outcome));
            }
        }

        private string gameMovesToAdd;

        public string GameMovesToAdd
        {
            get { return gameMovesToAdd; }
            set
            {
                gameMovesToAdd = value;
                RaisePropertyChanged(nameof(GameMovesToAdd));
            }
        }

        private string playedAs;

        public string PlayedAs
        {
            get { return playedAs; }
            set
            {
                playedAs = value;
                RaisePropertyChanged(nameof(PlayedAs));
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }

        private string gameName;

        public string GameName
        {
            get { return gameName; }
            set
            {
                gameName = value;
                RaisePropertyChanged(nameof(GameName));
            }
        }

        public ICommand AddNewGame => new Command(
          async () =>
          {
              GameValidator validator = new GameValidator();
              var claims = await authService.GetClaims();
              var userId = Guid.Parse(claims.FirstOrDefault(c => c.Type == "id").Value);
              var game = new Game()
              {
                  Id = Guid.NewGuid(),
                  Moves = FilterMovesFromString(GameMovesToAdd),
                  DateAdded = DateTime.Now,
                  Name = GameName,
                  UserId = userId, //Moet nog veranderen als identity werkt.
                  Outcome = Outcome,
                  PlayedAs = PlayedAs
              };

              var validationContext = new ValidationContext<Game>(game);
              var validationResult = validator.Validate(validationContext);

              ChessConverter converter = new ChessConverter();

              if (validationResult.IsValid)
              {
                  try
                  {
                      var pgnList = game.Moves.Select(a => a.MovePGN).ToList();

                      if (converter.ValidateMoves(pgnList))
                      {
                          await gamesService.AddGame(game);
                          await RefreshGameLists();
                          ErrorMessage = null;
                          GameName = "";
                          GameMovesToAdd = "";
                          game = await gamesService.GetGame(game.Id);
                          await CoreMethods.PushPageModel<ChessBoardViewModel>(game, false, true);
                      }
                      else
                      {
                          ErrorMessage = "Enter a correct PNG file";
                      }
                  }
                  catch
                  {
                      ErrorMessage = "Enter a correct PNG file";
                  }

              }
              else
              {
                  ErrorMessage = "";
                  foreach (var item in validationResult.Errors)
                  {
                      ErrorMessage += $"- {item.ErrorMessage}\n";
                  }
              }
          }
          );

        private List<GameMove> FilterMovesFromString(string input)
        {
            if (input == null)
            {
                return null;
            }
            List<string> moves = new List<string>();

            input = Regex.Replace(input, @"{[^{}]*}", "");
            input = Regex.Replace(input, @"\[[^{}]*\]", "");
            input = Regex.Replace(input, @"\([^)]*\)", "");
            input = Regex.Replace(input, @"[0-9]*\.", "");
            input = Regex.Replace(input, @"\n", " ");
            input = Regex.Replace(input, @"  *", " ");
            //input = Regex.Replace(input, @" [^ ]* *$", ""); //Removes last word
            input = Regex.Replace(input, @"\r", " ");
            moves = input.Split(' ').ToList();
            moves = moves.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            if (moves.Last() == "1-0" || moves.Last() == "1/2-1/2" || moves.Last() == "0-1")
                moves.Remove(moves.Last());


            return ConvertStringListToMoveList(moves);
        }

        private List<GameMove> ConvertStringListToMoveList(List<string> moves)
        {
            List<GameMove> listMoves = new List<GameMove>() { };
            for (int i = 0; i < moves.Count; i++)
            {
                GameMove gameMove = new GameMove();

                gameMove.Id = Guid.NewGuid();
                gameMove.MovePGN = moves[i];
                gameMove.Turn = i + 1;
                listMoves.Add(gameMove);
            }
            return listMoves;
        }

        public ICommand ClearGameMovesToAdd => new Command(
            () =>
            {
                GameMovesToAdd = "";
            }
        );

        public ICommand PasteClipboardText => new Command(
            async () =>
            {
                if (Clipboard.HasText)
                {
                    GameMovesToAdd = await Clipboard.GetTextAsync();
                }
            }
        );

        /*
         *      GAME LIST PAGE
         */

        private IEnumerable<Game> loadedGames;

        public IEnumerable<Game> LoadedGames
        {
            get { return loadedGames; }
            set
            {
                loadedGames = value;
                RaisePropertyChanged(nameof(LoadedGames));
            }
        }


        private ObservableCollection<Game> games;

        public ObservableCollection<Game> Games
        {
            get { return games; }
            set
            {
                games = value;
                RaisePropertyChanged(nameof(Games));
            }
        }

        private string gamesSearch;

        public string GamesSearch
        {
            get { return gamesSearch; }
            set
            {
                gamesSearch = value;
                RaisePropertyChanged(nameof(GamesSearch));
            }
        }


        public ICommand OpenGameBoard => new Command<Game>(
          async (Game game) =>
          {
              await CoreMethods.PushPageModel<ChessBoardViewModel>(game, false, true);
          }
       );

        private async Task RefreshGameLists()
        {
            var claims = await authService.GetClaims();
            var userId = Guid.Parse(claims.FirstOrDefault(c => c.Type == "id").Value);
            try
            {
                var games = await gamesService.GetGameListsForUser(userId); //Moet nog veranderen!!
                Games = null;
                Games = new ObservableCollection<Game>(games.OrderByDescending(e => e.DateAdded));
                LoadedGames = Games;
                if (GamesSearch != null)
                {
                    FilterGames();
                }
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
        }

        private void FilterGames()
        {
            Games = new ObservableCollection<Game>(LoadedGames);

            Games = new ObservableCollection<Game>(Games.Where(o => o.Name.ToUpper().Contains(GamesSearch.ToUpper())).OrderBy(a => a.Name));
            if (GamesSearch == "" || GamesSearch == null)
            {
                Games = new ObservableCollection<Game>(games.OrderByDescending(e => e.DateAdded));
            }
        }

        public ICommand GameFilter => new Command(
            () =>
            {
                FilterGames();
            }
        );

        /*
         *      OPENINGS PAGE
         */
        IEnumerable<Opening> LoadedOpenings = new List<Opening>() { };


        private ObservableCollection<Opening> openings;

        public ObservableCollection<Opening> Openings
        {
            get { return openings; }
            set
            {
                openings = value;
                RaisePropertyChanged(nameof(Openings));
            }
        }

        private string openingSearch;

        public string OpeningSearch
        {
            get { return openingSearch; }
            set
            {
                openingSearch = value;
                RaisePropertyChanged(nameof(OpeningSearch));
            }
        }

        public ICommand OpenOpeningBoard => new Command<Opening>(
            async (Opening opening) =>
            {
                await CoreMethods.PushPageModel<ChessBoardOpeningViewModel>(opening, false, true);
            }
        );

        private async Task LoadOpenings()
        {
            try
            {
                var openings = await openingsService.GetAllOpenings();
                Openings = null;
                Openings = new ObservableCollection<Opening>(openings.OrderBy(a => a.Name));
                LoadedOpenings = Openings;
                if (OpeningSearch != null)
                {
                    FilterOpening();
                }
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
        }


        private void FilterOpening()
        {
            Openings = new ObservableCollection<Opening>(LoadedOpenings);

            Openings = new ObservableCollection<Opening>(Openings.Where(o => o.Name.ToUpper().Contains(OpeningSearch.ToUpper())).OrderBy(a => a.Name));
            if (OpeningSearch == "")
            {
                Openings = openings;
            }
        }

        public ICommand OpeningFilter => new Command(
            () =>
            {
                FilterOpening();
            }
        );

        /*
         *      EVENTS PAGE
         */

        private ObservableCollection<Event> events;

        public ObservableCollection<Event> Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged(nameof(Events));
            }
        }

        private async Task LoadEvents()
        {
            try
            {
                var events = await eventService.GetEventList();
                Events = null;
                Events = new ObservableCollection<Event>(events.OrderBy(a => a.DateTimeOfEvent));
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
        }

        public ICommand OpenEvent => new Command<Event>(
            async (Event eventItem) =>
            {
                await CoreMethods.PushPageModel<EventsDetailViewModel>(eventItem, false, true);
            }
        );


        //////MORE

        private List<string> pages;

        public List<string> Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                RaisePropertyChanged(nameof(Pages));
            }
        }


        private Task LoadPages()
        {
            Pages = new List<string>() { "Statistics" };
            return Task.CompletedTask;
        }

        public ICommand OpenPage => new Command<string>(
            async (string Page) =>
            {
                switch (Page)
                {
                    case "Statistics":
                        await CoreMethods.PushPageModel<StatisticsViewModel>();

                        break;
                }


            }
        );

    }
}
