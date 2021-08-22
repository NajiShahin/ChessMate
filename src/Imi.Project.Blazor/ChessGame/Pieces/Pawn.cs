using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame.Pieces
{
    public class Pawn : Piece
    {
        public bool IsEnPassantable { get; set; } = false;
        public Pawn(Color color, char character) : base(color, character)
        {
        }

        char legalMove = '•';

        public char[,] GetPawnLegalMoves(ChessBoard GameBoard, Pawn pawn)
        {
            char[,] legalMoves = new char[8, 8];

            GetPawnMoves(pawn, GameBoard, legalMoves);
            GetPawnAttacks(pawn, GameBoard, legalMoves);

            return legalMoves;
        }

        public char[,] GetLegalMoves(ChessBoard gameBoard, Pawn pawn)
        {
            char[,] legalMoves = GetPawnLegalMoves(gameBoard, pawn);
            return RemoveMovesThatCauseCheck(pawn, gameBoard, legalMoves);
        }

        private char[,] GetPawnMoves(Pawn pawn, ChessBoard GameBoard, char[,] legalMoves)
        {
            int piecePositionY = GameBoard.GetPositionY(pawn);
            int piecePositionX = GameBoard.GetPositionX(pawn);

            if (pawn.Color == Color.White)
            {
                if (piecePositionY == 6 && GameBoard.GameBoard[4, piecePositionX] == null && GameBoard.GameBoard[5, piecePositionX] == null)
                {
                    legalMoves[4, piecePositionX] = legalMove;
                }

                if (pawn.IsOnBoard(piecePositionY - 1, piecePositionX))
                {
                    if (GameBoard.GameBoard[piecePositionY - 1, piecePositionX] == null)
                    {
                        legalMoves[piecePositionY - 1, piecePositionX] = legalMove;
                    }
                }
            }

            if (pawn.Color == Color.Black)
            {
                if (piecePositionY == 1 && GameBoard.GameBoard[3, piecePositionX] == null && GameBoard.GameBoard[2, piecePositionX] == null)
                {
                    legalMoves[3, piecePositionX] = legalMove;
                }

                if (pawn.IsOnBoard(piecePositionY + 1, piecePositionX))
                {
                    if (GameBoard.GameBoard[piecePositionY + 1, piecePositionX] == null)
                    {
                        legalMoves[piecePositionY + 1, piecePositionX] = legalMove;
                    }
                }
            }

            return legalMoves;
        }

        public void PromotePawn(Pawn pawn, ChessBoard chessBoard)
        {
            int x = chessBoard.GetPositionX(pawn);
            int y = chessBoard.GetPositionY(pawn);

            if (y == 0 || y == 7)
            {
                chessBoard.GameBoard[y, x] = null;
                if (pawn.Color == Color.Black)
                {
                    chessBoard.GameBoard[y, x] = new Queen(pawn.Color, '♛');
                }
                else
                {
                    chessBoard.GameBoard[y, x] = new Queen(pawn.Color, '♕');
                }
            }
        }

        private char[,] GetPawnAttacks(Pawn pawn, ChessBoard GameBoard, char[,] legalMoves)
        {
            int piecePositionY = GameBoard.GetPositionY(pawn);
            int piecePositionX = GameBoard.GetPositionX(pawn);

            int pawnPos = 0;
            if (pawn.Color == Color.Black)
                pawnPos = 1;
            if (pawn.Color == Color.White)
                pawnPos = -1;


            if (pawn.IsOnBoard(piecePositionY + pawnPos, piecePositionX - 1))
            {
                if (GameBoard.GameBoard[piecePositionY + pawnPos, piecePositionX - 1] != null && GameBoard.GameBoard[piecePositionY + pawnPos, piecePositionX - 1]?.Color != pawn.Color)
                {
                    legalMoves[piecePositionY + pawnPos, piecePositionX - 1] = legalMove;
                }
            }
            if (pawn.IsOnBoard(piecePositionY + pawnPos, piecePositionX + 1))
            {
                if (GameBoard.GameBoard[piecePositionY + pawnPos, piecePositionX + 1] != null && GameBoard.GameBoard[piecePositionY + pawnPos, piecePositionX + 1]?.Color != pawn.Color)
                {
                    legalMoves[piecePositionY + pawnPos, piecePositionX + 1] = legalMove;
                }
            }


            if (pawn.IsOnBoard(piecePositionY, piecePositionX + 1))
            {
                if (GameBoard.GameBoard[piecePositionY, piecePositionX + 1] != null && GameBoard.GameBoard[piecePositionY, piecePositionX + 1]?.Color != pawn.Color
                    && GameBoard.GameBoard[piecePositionY, piecePositionX + 1]?.GetType() == typeof(Pawn))
                {
                    Pawn enemyPawn = GameBoard.GameBoard[piecePositionY, piecePositionX + 1] as Pawn;
                    if ((bool)(enemyPawn?.IsEnPassantable) && enemyPawn?.Color != pawn?.Color)
                    {
                        legalMoves[piecePositionY + pawnPos, piecePositionX + 1] = legalMove;
                    }
                }
            }
            if (pawn.IsOnBoard(piecePositionY, piecePositionX - 1))
            {
                if (GameBoard.GameBoard[piecePositionY, piecePositionX - 1] != null && GameBoard.GameBoard[piecePositionY, piecePositionX - 1]?.Color != pawn.Color
                    && GameBoard.GameBoard[piecePositionY, piecePositionX - 1]?.GetType() == typeof(Pawn))
                {
                    Pawn enemyPawn = GameBoard.GameBoard[piecePositionY, piecePositionX - 1] as Pawn;
                    if ((bool)(enemyPawn?.IsEnPassantable) && enemyPawn?.Color != pawn?.Color)
                    {
                        legalMoves[piecePositionY + pawnPos, piecePositionX - 1] = legalMove;
                    }
                }
            }


            return legalMoves;
        }

        public void SetEnPassantEnemiesToFalse(ChessBoard board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.GameBoard[i, j]?.Color != this.Color && board.GameBoard[i, j]?.GetType() == typeof(Pawn))
                    {
                        var pawn = board.GameBoard[i, j] as Pawn;
                        pawn.IsEnPassantable = false;
                    }
                }
            }
        }

        public void EnPassant(ChessBoard board, Pawn pawn)
        {
            int x = board.GetPositionX(pawn);
            int y = board.GetPositionY(pawn);
            if (pawn.Color == Color.Black)
            {
                if (IsOnBoard(y - 1, x))
                {
                    if (board.GameBoard[y - 1, x]?.GetType() == typeof(Pawn))
                    {
                        var pawnBehind = (Pawn)board.GameBoard[y - 1, x];
                        if (pawnBehind.IsEnPassantable == true && pawnBehind?.Color != pawn?.Color)
                            board.GameBoard[y - 1, x] = null;
                    }
                }

            }

            if (pawn.Color == Color.White)
            {
                if (IsOnBoard(y + 1, x))
                {
                    if (board.GameBoard[y + 1, x]?.GetType() == typeof(Pawn))
                    {
                        var pawnBehind = (Pawn)board.GameBoard[y + 1, x];
                        if (pawnBehind.IsEnPassantable == true && pawnBehind?.Color != pawn?.Color)
                            board.GameBoard[y + 1, x] = null;
                    }
                }
            }
        }
    }
}
