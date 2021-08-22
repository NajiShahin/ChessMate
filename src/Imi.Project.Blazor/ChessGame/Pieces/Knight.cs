using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, char character) : base(color, character)
        {
        }
        char legalMove = '•';

        public char[,] GetKnightLegalMoves(ChessBoard GameBoard, Knight knight)
        {
            char[,] legalMoves = new char[8, 8];

            GetLegalMove(knight, GameBoard, legalMoves, 1, 2);
            GetLegalMove(knight, GameBoard, legalMoves, -1, -2);//
            GetLegalMove(knight, GameBoard, legalMoves, 1, -2);
            GetLegalMove(knight, GameBoard, legalMoves, -1, 2);

            GetLegalMove(knight, GameBoard, legalMoves, 2, -1);
            GetLegalMove(knight, GameBoard, legalMoves, -2, -1);//
            GetLegalMove(knight, GameBoard, legalMoves, -2, 1);
            GetLegalMove(knight, GameBoard, legalMoves, 2, 1);


            return legalMoves;
        }
        public char[,] GetLegalMoves(ChessBoard gameBoard, Knight knight)
        {
            char[,] legalMoves = GetKnightLegalMoves(gameBoard, knight);
            return RemoveMovesThatCauseCheck(knight, gameBoard, legalMoves);

        }
        private char[,] GetLegalMove(Knight knight, ChessBoard GameBoard, char[,] legalMoves, int x, int y)
        {
            int piecePositionY = GameBoard.GetPositionY(knight);
            int piecePositionX = GameBoard.GetPositionX(knight);

            if (knight.IsOnBoard(piecePositionY + y, piecePositionX + x))
            {
                if (GameBoard.GameBoard[piecePositionY + y, piecePositionX + x]?.Color != knight.Color)
                {
                    legalMoves[piecePositionY + y, piecePositionX + x] = legalMove;
                }
            }
            return legalMoves;
        }
    }
}
