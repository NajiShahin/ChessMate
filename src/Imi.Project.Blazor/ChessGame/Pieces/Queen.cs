using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, char character) : base(color, character)
        {
        }
        char legalMove = '•';

        public char[,] GetQueenLegalMoves(ChessBoard GameBoard, Queen queen)
        {
            char[,] legalMoves = new char[8, 8];

            GetVerticalMoves(queen, GameBoard, legalMoves);
            GetHorizontalMoves(queen, GameBoard, legalMoves);
            GetDiagonals(queen, GameBoard, legalMoves);

            return legalMoves;
        }

        public char[,] GetLegalMoves(ChessBoard gameBoard, Queen queen)
        {
            char[,] legalMoves = GetQueenLegalMoves(gameBoard, queen);
            return RemoveMovesThatCauseCheck(queen, gameBoard, legalMoves);
        }

        private char[,] GetDiagonals(Queen bishop, ChessBoard GameBoard, char[,] legalMoves)
        {
            GetDiagonal(bishop, GameBoard, legalMoves, -1, -1);
            GetDiagonal(bishop, GameBoard, legalMoves, 1, -1);
            GetDiagonal(bishop, GameBoard, legalMoves, -1, 1);
            GetDiagonal(bishop, GameBoard, legalMoves, 1, 1);

            return legalMoves;
        }
        private char[,] GetDiagonal(Queen bishop, ChessBoard GameBoard, char[,] legalMoves, int xtDiagonal, int yDiagonal)
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

        private char[,] GetVerticalMoves(Queen rook, ChessBoard GameBoard, char[,] legalMoves)
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

        private char[,] GetHorizontalMoves(Queen rook, ChessBoard GameBoard, char[,] legalMoves)
        {
            int x = GameBoard.GetPositionX(rook);
            int y = GameBoard.GetPositionY(rook);
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
