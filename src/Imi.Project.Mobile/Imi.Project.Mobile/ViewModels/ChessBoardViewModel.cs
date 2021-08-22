using FreshMvvm;
using Imi.Project.Common;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Imi.Project.Mobile.Domain.Services.Interfaces.NativeApi;
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
    public class ChessBoardViewModel : FreshBasePageModel
    {
        private Game currentGame;
        private int move = 0;

        private readonly ISoundPlayer soundPlayer;
        private readonly IGamesService gamesService;
        private readonly IOpeningsService openingsService;

        public ChessBoardViewModel(IGamesService gamesService,
            IOpeningsService openingsService,
            ISoundPlayer soundPlayer)
        {
            this.soundPlayer = soundPlayer;
            this.openingsService = openingsService;
            this.gamesService = gamesService;
        }

        private char[] board = new char[64];

        public char[] Board
        {
            get { return board; }
            set
            {
                board = value;
                RaisePropertyChanged(nameof(Board));
            }
        }

        private Game game;

        public Game Game
        {
            get { return game; }
            set
            {
                game = value;
                RaisePropertyChanged(nameof(Game));
            }
        }

        private string[] colors = new string[64];

        public string[] Colors
        {
            get { return colors; }
            set
            {
                colors = value;
                RaisePropertyChanged(nameof(Colors));
            }
        }

        private string annotation;

        public string Annotation
        {
            get { return annotation; }
            set
            {
                annotation = value;
                RaisePropertyChanged(nameof(Annotation));
            }
        }

        private int gameTurn;

        public int GameTurn
        {
            get { return gameTurn; }
            set
            {
                gameTurn = value;
                RaisePropertyChanged(nameof(GameTurn));
            }
        }

        private Opening opening;

        public Opening Opening
        {
            get { return opening; }
            set
            {
                opening = value;
                RaisePropertyChanged(nameof(Opening));
            }
        }

        private string textAreaVisible;

        public string TextAreaVisible
        {
            get { return textAreaVisible; }
            set
            {
                textAreaVisible = value;
                RaisePropertyChanged(nameof(TextAreaVisible));
            }
        }

        private string annotationIsVisible;

        public string AnnotationIsVisible
        {
            get { return annotationIsVisible; }
            set
            {
                annotationIsVisible = value;
                RaisePropertyChanged(nameof(AnnotationIsVisible));
            }
        }

        public ICommand ChangeEditAnnotation => new Command(
          () =>
          {
              if (TextAreaVisible == "True" || GameTurn == 0)
              {
                  AnnotationIsVisible = "True";
                  TextAreaVisible = "False";
              }
              else
              {
                  AnnotationIsVisible = "False";
                  TextAreaVisible = "True";
              }
          }
          );

        public ICommand PutAnnotation => new Command(
           () =>
           {
               Game.Moves.SingleOrDefault(g => g.Turn == GameTurn).Annotation = Annotation;
               gamesService.UpdateGameMoves(Game);
               AnnotationIsVisible = "True";
               TextAreaVisible = "False";
           }
        );

        public ICommand DeleteGame => new Command(
           async () =>
           {
               var deleteItem = await Application.Current.MainPage.DisplayAlert("Delete game", "Do you want to delete this game?", "Cancel", "ok");
               if (!deleteItem == true)
               {
                   await gamesService.DeleteGame(Game.Id);
                   await Application.Current.MainPage.Navigation.PopAsync();
               }
           }
        );

        public ICommand GoNextMove => new Command(
           async () =>
           {
               await NextMoveAsync();
               AnnotationIsVisible = "True";
               TextAreaVisible = "False";
           }
        );

        public ICommand GoPreviousMove => new Command(
           async () =>
           {
               await PreviousMoveAsync();
               AnnotationIsVisible = "True";
               TextAreaVisible = "False";
           }
        );


        public async override void Init(object initData)
        {
            base.Init(initData);

            currentGame = initData as Game;
            Game = await gamesService.GetGame(currentGame.Id);
            Game.Opening = await openingsService.GetOpening(game.OpeningId);
            Opening = Game.Opening;
            AnnotationIsVisible = "True";
            TextAreaVisible = "False";
            SetColors();
            await InitializeBoard();
        }

        private Task InitializeBoard()
        {
            Board = new char[64]
            {
                 '♜','♞','♝','♛','♚','♝','♞','♜',
                 '♟','♟','♟','♟','♟','♟','♟','♟',
                 ' ',' ',' ',' ',' ',' ',' ',' ',
                 ' ',' ',' ',' ',' ',' ',' ',' ',
                 ' ',' ',' ',' ',' ',' ',' ',' ',
                 ' ',' ',' ',' ',' ',' ',' ',' ',
                 '♙','♙','♙','♙','♙','♙','♙','♙',
                 '♖','♘','♗','♕','♔','♗','♘','♖',
            };
            return Task.FromResult(Board);
        }

        private void SetColors()
        {
            colors = new string[64];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        colors[i * 8 + j] = Constants.LightTileHex;
                        //cdd26a
                    }
                    else
                    {
                        colors[i * 8 + j] = Constants.DarkTileHex;
                        //aaa23a
                    }
                }
            }
            Colors = colors;
        }

        public void MovePiece(int move)
        {
            ChessConverter converter = new ChessConverter();
            char[,] chessBoard = converter.GetStartingBoard();


            for (int i = 0; i < move; i++)
            {
                if (i % 2 == 0)
                {
                    converter.convertPgnMoveToBoard(Game.Moves.FirstOrDefault(m => m.Turn == i + 1).MovePGN, chessBoard, Turn.White);
                }
                else
                {
                    converter.convertPgnMoveToBoard(Game.Moves.FirstOrDefault(m => m.Turn == i + 1).MovePGN, chessBoard, Turn.Black);
                }
            }
            Board = Convert2DChessArrayTo1D(chessBoard);
        }

        private char[] Convert2DChessArrayTo1D(char[,] chessBoard)
        {
            char[] oneDBoard = new char[64];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    oneDBoard[(8 * i) + j] = chessBoard[i, j];
                }
            }
            return oneDBoard;
        }

        public async Task NextMoveAsync()
        {
            if (move < Game.Moves.Count)
            {
                MovePiece(++move);
                if (move != 0)
                {
                    Annotation = Game.Moves.FirstOrDefault(m => m.Turn == move).Annotation;
                    GameTurn = Game.Moves.FirstOrDefault(m => m.Turn == move).Turn;
                    var path = Game.Moves.FirstOrDefault(m => m.Turn == move).MovePath;
                    if (path != null)
                    {
                        ChangeColorTiles(path);
                    }
                    await soundPlayer.PlaySound();
                }
                else
                {
                    Annotation = "";
                    GameTurn = 0;
                }
            }
        }

        public async Task PreviousMoveAsync()
        {
            if (move > 0)
            {
                MovePiece(--move);
                if (move != 0)
                {
                    Annotation = Game.Moves.FirstOrDefault(m => m.Turn == move).Annotation;
                    GameTurn = Game.Moves.FirstOrDefault(m => m.Turn == move).Turn;
                    var path = Game.Moves.FirstOrDefault(m => m.Turn == move).MovePath;
                    if (path != null)
                    {
                        ChangeColorTiles(path);
                    }
                    await soundPlayer.PlaySound();
                }
                else
                {
                    Annotation = "";
                    GameTurn = 0;
                }
            }
        }

        private void ChangeColorTiles(string path)
        {
            SetColors();
            if (path == "O-O")
            {
                if (GameTurn % 2 != 0) //White
                {
                    colors[60] = Constants.CheckedDarkTileHex;
                    colors[63] = Constants.CheckedLightTileHex;
                    if (path.Contains("+") || path.Contains("#"))
                    {
                        Colors[GetKing1DTile(Turn.Black)] = Constants.CheckedTileHex;
                    }
                    Colors = colors;
                }
                else //Black
                {
                    colors[4] = Constants.CheckedLightTileHex;
                    colors[7] = Constants.CheckedDarkTileHex;
                    if (path.Contains("+") || path.Contains("#"))
                    {
                        Colors[GetKing1DTile(Turn.White)] = Constants.CheckedTileHex;
                    }
                    Colors = colors;
                }
                return;
            }
            if (path == "O-O-O")
            {
                if (GameTurn % 2 != 0)
                {
                    colors[60] = Constants.CheckedDarkTileHex;
                    colors[56] = Constants.CheckedDarkTileHex;
                    if (path.Contains("+") || path.Contains("#"))
                    {
                        Colors[GetKing1DTile(Turn.Black)] = Constants.CheckedTileHex;
                    }

                    Colors = colors;
                }
                else
                {
                    colors[0] = Constants.CheckedLightTileHex;
                    colors[4] = Constants.CheckedLightTileHex;
                    if (path.Contains("+") || path.Contains("#"))
                    {
                        Colors[GetKing1DTile(Turn.White)] = Constants.CheckedTileHex;
                    }

                    Colors = colors;
                }
                return;
            }

            int tile = 0;
            switch (path.Substring(0, 1))
            {
                case "a":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 0;
                    break;
                case "b":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 1;

                    break;
                case "c":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 2;
                    break;
                case "d":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 3;
                    break;
                case "e":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 4;
                    break;
                case "f":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 5;
                    break;
                case "g":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 6;
                    break;
                case "h":
                    tile = ((8 - Convert.ToInt32(path.Substring(1, 1))) * 8) + 7;
                    break;
            }
            if (colors[tile] == Constants.LightTileHex)
            {
                colors[tile] = Constants.CheckedLightTileHex;
                Colors = colors;
            }
            else
            {
                colors[tile] = Constants.CheckedDarkTileHex;
            }

            tile = 0;
            switch (path.Substring(2, 1))
            {
                case "a":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 0;
                    break;
                case "b":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 1;

                    break;
                case "c":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 2;
                    break;
                case "d":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 3;
                    break;
                case "e":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 4;
                    break;
                case "f":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 5;
                    break;
                case "g":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 6;
                    break;
                case "h":
                    tile = ((8 - Convert.ToInt32(path.Substring(3, 1))) * 8) + 7;
                    break;
            }
            if (colors[tile] == Constants.LightTileHex)
            {
                colors[tile] = Constants.CheckedLightTileHex;
                Colors = colors;
            }
            else
            {
                colors[tile] = Constants.CheckedDarkTileHex;
                Colors = colors;
            }

            if (GameTurn % 2 != 0) //White
            {
                if (path.Contains("+") || path.Contains("#"))
                {
                    Colors[GetKing1DTile(Turn.Black)] = Constants.CheckedTileHex;
                }
                Colors = colors;
            }
            else //Black
            {
                if (path.Contains("+") || path.Contains("#"))
                {
                    Colors[GetKing1DTile(Turn.White)] = Constants.CheckedTileHex;
                }
                Colors = colors;
            }

        }

        private int GetKing1DTile(Turn color)
        {
            for (int i = 0; i < 64; i++)
            {
                if (Board[i] == '♚' && color == Turn.Black || Board[i] == '♔' && color == Turn.White)
                {
                    return i;
                }
            }
            return 1;
        }
    }
}
