using FreshMvvm;
using Imi.Project.Common;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Imi.Project.Mobile.Domain.Services.Interfaces.NativeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ChessBoardOpeningViewModel : FreshBasePageModel
    {
        private readonly IOpeningsService openingsService;
        private readonly ISoundPlayer soundPlayer;

        public ChessBoardOpeningViewModel(IOpeningsService openingsService,
            ISoundPlayer soundPlayer)
        {
            this.openingsService = openingsService;
            this.soundPlayer = soundPlayer;
        }


        private Opening currentOpening;
        private int move = 0;


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

        private Opening game;

        public Opening Game
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


        public ICommand GoNextMove => new Command(
           () =>
           {
               NextMove();
           }
        );

        public ICommand GoPreviousMove => new Command(
           () =>
           {
               PreviousMove();
           }
        );


        public async override void Init(object initData)
        {
            base.Init(initData);

            currentOpening = initData as Opening;
            Game = await openingsService.GetOpening(currentOpening.Id);
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

        public void MovePiece(int move)
        {
            ChessConverter converter = new ChessConverter();
            char[,] chessBoard = converter.GetStartingBoard();


            for (int i = 0; i < move; i++)
            {
                if (i % 2 == 0)
                {
                    converter.convertPgnMoveToBoard(Game.Moves.FirstOrDefault(m => m.Turn == i).MovePGN, chessBoard, Turn.White);
                }
                else
                {
                    converter.convertPgnMoveToBoard(Game.Moves.FirstOrDefault(m => m.Turn == i).MovePGN, chessBoard, Turn.Black);
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

        public void NextMove()
        {
            if (move < Game.Moves.Count)
            {
                MovePiece(++move);
                if (move != 0)
                {
                    GameTurn = Game.Moves.FirstOrDefault(m => m.Turn == move -1).Turn;
                    ChangeColorTiles(Game.Moves.FirstOrDefault(m => m.Turn == move - 1).MovePath);
                    soundPlayer.PlaySound();
                    GameTurn++;
                }
                else
                {
                    GameTurn = 0;
                }
            }
        }

        public void PreviousMove()
        {
            if (move > 0)
            {
                MovePiece(--move);
                if (move != 0)
                {
                    GameTurn = Game.Moves.FirstOrDefault(m => m.Turn == move - 1).Turn;
                    ChangeColorTiles(Game.Moves.FirstOrDefault(m => m.Turn == move - 1).MovePath);
                    soundPlayer.PlaySound();
                    GameTurn++;
                }
                else
                {
                    GameTurn = 0;
                }
            }
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

        private void ChangeColorTiles(string path)
        {
            SetColors();
            if (path == "O-O")
            {
                if (GameTurn % 2 != 0)
                {
                    colors[60] = Constants.CheckedDarkTileHex;
                    colors[63] = Constants.CheckedLightTileHex;

                    Colors = colors;
                }
                else
                {
                    colors[4] = Constants.CheckedLightTileHex;
                    colors[7] = Constants.CheckedDarkTileHex;
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
                    Colors = colors;
                }
                else
                {
                    colors[0] = Constants.CheckedLightTileHex;
                    colors[4] = Constants.CheckedLightTileHex;
                    Colors = colors;
                }
                return;
            }

            int tile = 0;
            var columnInitialPosition = path.Substring(0, 1);
            var rowInitialPosition = Convert.ToInt32(path.Substring(1, 1));
            switch (columnInitialPosition)
            {
                case "a":
                    tile = ((8 - rowInitialPosition) * 8) + 0;
                    break;
                case "b":
                    tile = ((8 - rowInitialPosition) * 8) + 1;

                    break;
                case "c":
                    tile = ((8 - rowInitialPosition) * 8) + 2;
                    break;
                case "d":
                    tile = ((8 - rowInitialPosition) * 8) + 3;
                    break;       
                case "e":        
                    tile = ((8 - rowInitialPosition) * 8) + 4;
                    break;       
                case "f":        
                    tile = ((8 - rowInitialPosition) * 8) + 5;
                    break;       
                case "g":        
                    tile = ((8 - rowInitialPosition) * 8) + 6;
                    break;       
                case "h":        
                    tile = ((8 - rowInitialPosition) * 8) + 7;
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
            var columnFinalPosition = path.Substring(2, 1);
            var rowFinalPosition = Convert.ToInt32(path.Substring(3, 1));
            switch (columnFinalPosition)
            {
                case "a":
                    tile = ((8 - rowFinalPosition) * 8) + 0;
                    break;
                case "b":
                    tile = ((8 - rowFinalPosition) * 8) + 1;
                                 
                    break;       
                case "c":        
                    tile = ((8 - rowFinalPosition) * 8) + 2;
                    break;      
                case "d":       
                    tile = ((8 - rowFinalPosition) * 8) + 3;
                    break;       
                case "e":        
                    tile = ((8 - rowFinalPosition) * 8) + 4;
                    break;       
                case "f":        
                    tile = ((8 - rowFinalPosition) * 8) + 5;
                    break;       
                case "g":        
                    tile = ((8 - rowFinalPosition) * 8) + 6;
                    break;       
                case "h":        
                    tile = ((8 - rowFinalPosition) * 8) + 7;
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
        }
    }
}
