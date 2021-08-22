using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color, char character) : base(color, character)
        {
        }
        char legalMove = '•';

        public char[,] GetBishopLegalMoves(ChessBoard GameBoard, Bishop bishop)
        {
            char[,] legalMoves = new char[8, 8];

            GetDiagonals(bishop, GameBoard, legalMoves);

            return legalMoves;
        }

        public char[,] GetLegalMoves(ChessBoard gameBoard, Bishop bishop)
        {
            char[,] legalMoves = GetBishopLegalMoves(gameBoard, bishop);
            return RemoveMovesThatCauseCheck(bishop, gameBoard, legalMoves);

        }

        private char[,] GetDiagonals(Bishop bishop, ChessBoard GameBoard, char[,] legalMoves)
        {
            GetDiagonal(bishop, GameBoard, legalMoves, -1, -1);
            GetDiagonal(bishop, GameBoard, legalMoves, 1, -1);
            GetDiagonal(bishop, GameBoard, legalMoves, -1, 1);
            GetDiagonal(bishop, GameBoard, legalMoves, 1, 1);

            return legalMoves;
        }
        private char[,] GetDiagonal(Bishop bishop, ChessBoard GameBoard, char[,] legalMoves, int xtDiagonal, int yDiagonal)
        {
            int y = GameBoard.GetPositionY(bishop);
            int x = GameBoard.GetPositionX(bishop);

            for (int i = 0; i < 8; i++)
            {
                y += yDiagonal;
                x += xtDiagonal;
                if (bishop.IsOnBoard(y, x))
                {
                    if (GameBoard.GameBoard[y, x] == null)
                    {
                        legalMoves[y, x] = legalMove;
                    }
                    else if (GameBoard.GameBoard[y, x]?.Color != bishop.Color)
                    {
                        legalMoves[y, x] = legalMove;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }


            return legalMoves;
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
    }
}
