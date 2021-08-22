using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame.Pieces
{
    public class Rook : Piece
    {
        public bool CanCastle { get; set; } = true;

        public Rook(Color color, char character) : base(color, character)
        {
        }
        char legalMove = '•';

        public char[,] GetRookLegalMoves(ChessBoard GameBoard, Rook rook)
        {
            char[,] legalMoves = new char[8, 8];

            GetVerticalMoves(rook, GameBoard, legalMoves);
            GetHorizontalMoves(rook, GameBoard, legalMoves);

            return legalMoves;
        }
        public char[,] GetLegalMoves(ChessBoard gameBoard, Rook rook)
        {
            char[,] legalMoves = GetRookLegalMoves(gameBoard, rook);
            return RemoveMovesThatCauseCheck(rook, gameBoard, legalMoves);
        }

        private char[,] GetVerticalMoves(Rook rook, ChessBoard GameBoard, char[,] legalMoves)
        {
            int y = GameBoard.GetPositionY(rook);
            int x = GameBoard.GetPositionX(rook);
            while (y < 7)
            {
                y++;
                if (GameBoard.GameBoard[y, x]?.Color != rook.Color)
                {
                    legalMoves[y, x] = legalMove;
                    if (GameBoard.GameBoard[y, x] != null)
                        break;
                }
                else
                {
                    break;
                }
            }


            y = GameBoard.GetPositionY(rook);
            while (y > 0)
            {
                y--;
                if (GameBoard.GameBoard[y, x]?.Color != rook.Color)
                {
                    legalMoves[y, x] = legalMove;
                    if (GameBoard.GameBoard[y, x] != null)
                        break;
                }
                else
                {
                    break;
                }
            }

            return legalMoves;
        }

        private char[,] GetHorizontalMoves(Rook rook, ChessBoard GameBoard, char[,] legalMoves)
        {
            int y = GameBoard.GetPositionY(rook);
            int x = GameBoard.GetPositionX(rook);
            while (x < 7)
            {
                x++;
                if (GameBoard.GameBoard[y, x]?.Color != rook.Color) //if null or opposite color
                {
                    legalMoves[y, x] = legalMove;
                    if (GameBoard.GameBoard[y, x] != null)
                        break;
                }
                else
                {
                    break;
                }
            }

            x = GameBoard.GetPositionX(rook);
            while (x > 0)
            {
                x--;
                if (GameBoard.GameBoard[y, x]?.Color != rook.Color)
                {
                    legalMoves[y, x] = legalMove;
                    if (GameBoard.GameBoard[y, x] != null)
                        break;
                }
                else
                {
                    break;
                }
            }
            return legalMoves;
        }

        public void HasMoved(Rook rook)
        {
            rook.CanCastle = false;
        }
    }
}
