using Imi.Project.Blazor.ChessGame;
using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages.Base
{
    public class ChessGameBase: ComponentBase
    {
        //@inject IJSRuntime Js
        [Inject]
        private IJSRuntime Js { get; set; }




        public EventCallback OnPieceClick { get; set; }

        Turn turn = Turn.White;

        private char legalMove = '•';

        public char[,] chessBoard;

        public string[,] chessBoardImages = new string[8, 8];

        private int lastPressedX;
        private int lastPressedY;

        public string winner;

        private string fenString;

        private IEnumerable<OpeningItem> openings = new List<OpeningItem>() { };

        public string opening;

        public string[,] tileColors = new string[8, 8];

        ChessBoard board = new ChessBoard();

        public ElementReference Audio { get; set; }


        protected async override void OnInitialized()
        {
            base.OnInitialized();
            GetStartBoard();
            openings = await board.InitializeOpenings();
        }

        public void MakeMove()
        {
            if (board.isBlackCheckMated() || board.IsWhiteCheckMated())
            {

            }
            else
            {
                ChessComputer chessComputer = new ChessComputer();

                Color color = Color.White;

                if (turn.ToString() != color.ToString())
                {
                    color = Color.Black;
                }

                //If there is a mate in one that move will happen otherwise random move
                chessComputer.MakeMove(board, color);

                if (turn == Turn.White)
                {
                    turn = Turn.Black;
                }
                else
                {
                    turn = Turn.White;
                }
                Js.InvokeVoidAsync("playAudio", Audio);

                chessBoard = board.GetBoardCharacters();
                ConvertCharToStringImage(chessBoard);

                fenString = board.GetFenString(board.GameBoard);
                ShowChecked();
                showDraw();

            }

        }


        public void GetStartBoard()
        {
            board.InitializeBoard();
            turn = Turn.White;
            winner = "";
            opening = "";
            chessBoard = board.GetBoardCharacters();
            SetTileColors();
            ConvertCharToStringImage(chessBoard);
        }

        private void SetTileColors()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((j + i) % 2 == 0)
                    {
                        tileColors[i, j] = "light";
                    }
                    else
                    {
                        tileColors[i, j] = "dark";
                    }
                }
            }
        }

        private void showDraw()
        {
            if (!board.isBlackChecked() && !board.IsWhiteChecked())
            {
                if (turn == Turn.White)
                {
                    if (board.IsDraw(Turn.Black))
                    {
                        winner = "Stalemate";
                    }
                }
                else
                {
                    if (board.IsDraw(Turn.White))
                    {
                        winner = "Stalemate";
                    }
                }
                
            }
        }

        private void ShowChecked()
        {
            SetTileColors();
            if (board.isBlackChecked())
            {
                int y = board.GetPositionY(board.GetBlackKing(board));
                int x = board.GetPositionX(board.GetBlackKing(board));
                tileColors[y, x] = "check";
                if (board.isBlackCheckMated())
                {
                    winner = "Black got checkmated";
                }
            }
            else if (board.IsWhiteChecked())
            {
                int y = board.GetPositionY(board.GetWhiteKing(board));
                int x = board.GetPositionX(board.GetWhiteKing(board));
                tileColors[y, x] = "check";
                if (board.IsWhiteCheckMated())
                {
                    winner = "White got checkmated";
                }
            }
        }

        private void ConvertCharToStringImage(char[,] charArray)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (charArray[i, j])
                    {
                        case '•':
                            chessBoardImages[i, j] = "Images/LegalMove.png";
                            break;
                        case '♔':
                            chessBoardImages[i, j] = "Images/WhiteKing.png";
                            break;
                        case '♕':
                            chessBoardImages[i, j] = "Images/WhiteQueen.png";
                            break;
                        case '♖':
                            chessBoardImages[i, j] = "Images/WhiteRook.png";
                            break;
                        case '♗':
                            chessBoardImages[i, j] = "Images/WhiteBishop.png";
                            break;
                        case '♘':
                            chessBoardImages[i, j] = "Images/WhiteKnight.png";
                            break;
                        case '♙':
                            chessBoardImages[i, j] = "Images/WhitePawn.png";
                            break;
                        default:
                            chessBoardImages[i, j] = "Images/Empty.png";
                            break;
                        case '♚':
                            chessBoardImages[i, j] = "Images/BlackKing.png";
                            break;
                        case '♛':
                            chessBoardImages[i, j] = "Images/BlackQueen.png";
                            break;
                        case '♜':
                            chessBoardImages[i, j] = "Images/BlackRook.png";
                            break;
                        case '♝':
                            chessBoardImages[i, j] = "Images/BlackBishop.png";
                            break;
                        case '♞':
                            chessBoardImages[i, j] = "Images/BlackKnight.png";
                            break;
                        case '♟':
                            chessBoardImages[i, j] = "Images/BlackPawn.png";
                            break;
                    }
                }
            }

        }

        public char[,] MakeMove(int positionX, int positionY)
        {
            if (board.GameBoard[positionY, positionX] == null && chessBoard[positionY, positionX] != legalMove)
            {
                chessBoard = board.GetBoardCharacters();
                ConvertCharToStringImage(chessBoard);
                return new char[,] { };
            }
            if (chessBoard[positionY, positionX] == legalMove)
            {
                board.MakeMove(lastPressedX, lastPressedY, positionX, positionY, board);

                Js.InvokeVoidAsync("playAudio", Audio);

                chessBoard = board.GetBoardCharacters();
                ConvertCharToStringImage(chessBoard);

                fenString = board.GetFenString(board.GameBoard);
                ShowChecked();
                showDraw();

                if (board.GetOpeningAsync(openings) != "")
                {
                    opening = board.GetOpeningAsync(openings);
                }
                if (turn == Turn.White)
                {
                    turn = Turn.Black;
                }
                else
                {
                    turn = Turn.White;
                }
            }
            else
            {
                chessBoard = board.GetBoardCharacters();
                ConvertCharToStringImage(chessBoard);

                lastPressedX = positionX;
                lastPressedY = positionY;
                GetLegalMoves(positionX, positionY);
            }
            ConvertCharToStringImage(chessBoard);
            return new char[,] { };
        }

        private char[,] GetLegalMoves(int positionX, int positionY)
        {
            var piece = board.GameBoard[positionY, positionX];

            if (piece.Color.ToString() != turn.ToString())
            {
                return new char[,] { };
            }
            var legalMoves = piece.GetLegalMoves(board, piece);
            ShowLegalMoves(legalMoves);
            return piece.GetLegalMoves(board, piece);
        }



        private void ShowLegalMoves(char[,] legalMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (legalMoves[i, j] == legalMove)
                    {
                        chessBoard[i, j] = legalMoves[i, j];
                    }
                }
            }
        }



    }
}
