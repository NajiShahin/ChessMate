using Imi.Project.Blazor.ChessGame.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame.Pieces.Base
{
    public abstract class Piece
    {
        public Color Color { get; set; }
        public Char Charachter { get; set; }

        public Piece(Color color, char character)
        {
            this.Color = color;
            this.Charachter = character;
        }
        char legalMove = '•';

        public char[,] GetLegalMoves(ChessBoard GameBoard, Piece piece)
        {
            char[,] legalMoves = new char[8, 8];


            if (piece?.GetType() == typeof(Pawn))
            {
                Pawn pawn = piece as Pawn;
                return pawn.GetLegalMoves(GameBoard, pawn);
            }
            if (piece?.GetType() == typeof(Rook))
            {
                Rook rook = piece as Rook;
                return rook.GetLegalMoves(GameBoard, rook);
            }
            if (piece?.GetType() == typeof(Knight))
            {
                Knight knight = piece as Knight;
                return knight.GetLegalMoves(GameBoard, knight);
            }
            if (piece?.GetType() == typeof(Bishop))
            {
                Bishop bishop = piece as Bishop;
                return bishop.GetLegalMoves(GameBoard, bishop);
            }
            if (piece?.GetType() == typeof(Queen))
            {
                Queen queen = piece as Queen;
                return queen.GetLegalMoves(GameBoard, queen);
            }
            if (piece?.GetType() == typeof(King))
            {
                King king = piece as King;
                return king.GetLegalMoves(GameBoard, king);
            }
            return legalMoves;
        }
        public bool IsOnBoard(int futureY, int futureX)
        {
            if (futureX <= 7 && futureX >= 0 && futureY <= 7 && futureY >= 0)
            {
                return true;
            }
            return false;
        }

        public bool HasLegalMoves(char[,] legalMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (legalMoves[i, j] == legalMove)
                        return true;
                }
            }
            return false;
        }

        public char[,] RemoveMovesThatCauseCheck(Piece piece, ChessBoard board, char[,] legalMoves)
        {
            ChessBoard newBoard = new ChessBoard();
            newBoard.GameBoard = board.MakeClone(board);
            int x = board.GetPositionX(piece);
            int y = board.GetPositionY(piece);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (legalMoves[i,j] == legalMove)
                    {
                        newBoard.GameBoard = board.MakeClone(board);

                        newBoard.MakeMove(x,y,j,i, newBoard);
                        if (piece.Color == Color.White && newBoard.IsWhiteChecked())
                        {
                            legalMoves[i, j] = char.MinValue;
                        }
                        if (piece.Color == Color.Black && newBoard.isBlackChecked())
                        {
                            legalMoves[i, j] = char.MinValue;
                        }
                    }
                }
            }
            return legalMoves;
        }
    }
}
