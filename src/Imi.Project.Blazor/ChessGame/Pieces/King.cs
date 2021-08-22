using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame.Pieces
{
    public class King : Piece
    {
        public bool CanCastle { get; set; } = true;
        public King(Color color, char character) : base(color, character)
        {
        }
        char legalMove = '•';

        public bool IsChecked(King king, ChessBoard GameBoard)
        {
            if (KnightCheck(king, GameBoard) || BishopCheck(king, GameBoard) || RookCheck(king, GameBoard) || PawnCheck(king,GameBoard))
                return true;
         
            return false;
        }

        public bool isCheckMated(King king, ChessBoard gameBoard)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(Pawn))
                    {
                        var pawn = (Pawn)gameBoard.GameBoard[i, j];
                        if (HasLegalMoves(pawn.GetLegalMoves(gameBoard, pawn)) && gameBoard.GameBoard[i, j]?.Color == king.Color)
                        {
                            return false;
                        }
                    }
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(Rook))
                    {
                        var rook = (Rook)gameBoard.GameBoard[i, j];
                        if (HasLegalMoves(rook.GetLegalMoves(gameBoard, rook)) && gameBoard.GameBoard[i, j]?.Color == king.Color)
                        {
                            return false;
                        }
                    }
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(Knight))
                    {
                        var knight = (Knight)gameBoard.GameBoard[i, j];
                        if (HasLegalMoves(knight.GetLegalMoves(gameBoard, knight)) && gameBoard.GameBoard[i, j]?.Color == king.Color)
                        {
                            return false;
                        }
                    }
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(Bishop))
                    {
                        var bishop = (Bishop)gameBoard.GameBoard[i, j];
                        if (HasLegalMoves(bishop.GetLegalMoves(gameBoard, bishop)) && gameBoard.GameBoard[i, j]?.Color == king.Color)
                        {
                            return false;
                        }
                    }
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(Queen))
                    {
                        var queen = (Queen)gameBoard.GameBoard[i, j];
                        if (HasLegalMoves(queen.GetLegalMoves(gameBoard, queen)) && gameBoard.GameBoard[i, j]?.Color == king.Color)
                        {
                            return false;
                        }
                    }
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(King))
                    {
                        var yourKing = (King)gameBoard.GameBoard[i, j];
                        if (HasLegalMoves(yourKing.GetLegalMoves(gameBoard, yourKing)) && gameBoard.GameBoard[i, j]?.Color == king.Color)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool KnightCheck(King king, ChessBoard GameBoard)
        {
            int x = GameBoard.GetPositionX(king);
            int y = GameBoard.GetPositionY(king);
            ChessBoard newBoard = new ChessBoard();

            Knight knight = new Knight(king.Color, ' ');

            newBoard.GameBoard = new Piece[8, 8];
            newBoard.GameBoard[y, x] = knight;
            char[,] legalMoves = new char[8, 8];
            legalMoves = knight.GetKnightLegalMoves(newBoard, knight);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (legalMoves[i, j] == legalMove && GameBoard.GameBoard[i, j]?.GetType() == typeof(Knight) && GameBoard.GameBoard[i, j]?.Color != king.Color)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private bool BishopCheck(King king, ChessBoard GameBoard)
        {
            int x = GameBoard.GetPositionX(king);
            int y = GameBoard.GetPositionY(king);
            ChessBoard newBoard = new ChessBoard();

            Bishop bishop = new Bishop(king.Color, ' ');

            newBoard.GameBoard = GameBoard.MakeClone(GameBoard);
            newBoard.GameBoard[y, x] = bishop;
            char[,] legalMoves = new char[8, 8];
            legalMoves = bishop.GetBishopLegalMoves(newBoard, bishop);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (legalMoves[i, j] == legalMove && GameBoard.GameBoard[i, j]?.GetType() == typeof(Bishop) && GameBoard.GameBoard[i, j]?.Color != king.Color
                        || legalMoves[i, j] == legalMove && GameBoard.GameBoard[i, j]?.GetType() == typeof(Queen) && GameBoard.GameBoard[i, j]?.Color != king.Color)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool RookCheck(King king, ChessBoard GameBoard)
        {
            int x = GameBoard.GetPositionX(king);
            int y = GameBoard.GetPositionY(king);
            ChessBoard newBoard = new ChessBoard();

            Rook rook = new Rook(king.Color, ' ');

            newBoard.GameBoard = GameBoard.MakeClone(GameBoard);
            newBoard.GameBoard[y, x] = rook;
            char[,] legalMoves = new char[8, 8];
            legalMoves = rook.GetRookLegalMoves(newBoard, rook);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (legalMoves[i, j] == legalMove && GameBoard.GameBoard[i, j]?.GetType() == typeof(Rook) && GameBoard.GameBoard[i, j]?.Color != king.Color
                        || legalMoves[i, j] == legalMove && GameBoard.GameBoard[i, j]?.GetType() == typeof(Queen) && GameBoard.GameBoard[i, j]?.Color != king.Color)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool PawnCheck(King king, ChessBoard GameBoard)
        {
            int x = GameBoard.GetPositionX(king);
            int y = GameBoard.GetPositionY(king);
            ChessBoard newBoard = new ChessBoard();

            Pawn pawn = new Pawn(king.Color, ' ');
            if (king.Color == Color.White)
            {
                if (y - 1 >= 0 && y - 1 <= 7 && x + 1 >= 0 && x + 1 <= 7)
                    if (GameBoard.GameBoard[y - 1, x + 1]?.GetType() == typeof(Pawn) && GameBoard.GameBoard[y - 1, x + 1].Color == Color.Black)
                        return true;

                if (y - 1 >= 0 && y - 1 <= 7 && x - 1 >= 0 && x - 1 <= 7)
                    if (GameBoard.GameBoard[y - 1, x - 1]?.GetType() == typeof(Pawn) && GameBoard.GameBoard[y - 1, x - 1].Color == Color.Black)
                        return true;
            }

            if (king.Color == Color.Black)
            {
                if (y + 1 >= 0 && y + 1 <= 7 && x + 1 >= 0 && x + 1 <= 7)
                    if (GameBoard.GameBoard[y + 1, x + 1]?.GetType() == typeof(Pawn) && GameBoard.GameBoard[y + 1, x + 1].Color == Color.White)
                        return true;

                if (y + 1 >= 0 && y + 1 <= 7 && x - 1 >= 0 && x - 1 <= 7)
                    if (GameBoard.GameBoard[y + 1, x - 1]?.GetType() == typeof(Pawn) && GameBoard.GameBoard[y + 1, x - 1].Color == Color.White)
                        return true;
            }


            return false;
        }

        private char[,] GetKingLegalMoves(ChessBoard GameBoard, King king)
        {
            char[,] legalMoves = new char[8, 8];

            GetLegalMove(king, GameBoard, legalMoves, 0, 1);
            GetLegalMove(king, GameBoard, legalMoves, 0, -1);
            GetLegalMove(king, GameBoard, legalMoves, 1, 0);
            GetLegalMove(king, GameBoard, legalMoves, -1, 0);
            GetLegalMove(king, GameBoard, legalMoves, 1, -1);
            GetLegalMove(king, GameBoard, legalMoves, -1, 1);
            GetLegalMove(king, GameBoard, legalMoves, 1, 1);
            GetLegalMove(king, GameBoard, legalMoves, -1, -1);
            GetLegalCastlingMoves(king, GameBoard, legalMoves);
            IsChecked(king, GameBoard);


            return legalMoves;
        }

        private char[,] GetLegalCastlingMoves(King king, ChessBoard gameBoard, char[,] legalMoves)
        {
            int y = gameBoard.GetPositionY(king);

            Color oppositeColor = Color.White;
            if (king.Color == Color.White)
                oppositeColor = Color.Black;
            char[,] attackingTiles = gameBoard.GetAllAttackingTiles(oppositeColor);
            if (king.CanCastle)
            {
                if (gameBoard.GameBoard[y, 0]?.GetType() == typeof(Rook))
                {
                    var rook = (Rook)gameBoard.GameBoard[y, 0];
                    if (rook.CanCastle 
                        && gameBoard.GameBoard[y, 1] == null
                        && gameBoard.GameBoard[y, 2] == null 
                        && gameBoard.GameBoard[y, 3] == null
                        && attackingTiles[y, 1] != legalMove
                        && attackingTiles[y, 2] != legalMove
                        && attackingTiles[y, 3] != legalMove)
                    {
                        legalMoves[y, 2] = legalMove;
                    }
                }
                if (gameBoard.GameBoard[y, 7]?.GetType() == typeof(Rook))
                {
                    var rook = (Rook)gameBoard.GameBoard[y, 7];
                    if (rook.CanCastle 
                        && gameBoard.GameBoard[y, 5] == null 
                        && gameBoard.GameBoard[y, 6] == null
                        && attackingTiles[y, 5] != legalMove
                        && attackingTiles[y, 6] != legalMove)
                    {
                        legalMoves[y, 6] = legalMove;
                    }
                }
            }
            return legalMoves;
        }

        public void Castle(King king, ChessBoard gameBoard, int x)
        {
            int y = gameBoard.GetPositionY(king);

            if (king.CanCastle && x == 2 && y == 0 || king.CanCastle && x == 2 && y == 7)
            {
                gameBoard.GameBoard[y, 3] = gameBoard.GameBoard[y, 0];
                gameBoard.GameBoard[y, 0] = null;
            }

            if (king.CanCastle && x == 6 && y == 0 || king.CanCastle && x == 2 && y == 7)
            {
                gameBoard.GameBoard[y, 5] = gameBoard.GameBoard[y, 7];
                gameBoard.GameBoard[y, 7] = null;
            }
        }

        public char[,] GetLegalMoves(ChessBoard gameBoard, King king)
        {
            char[,] legalMoves = GetKingLegalMoves(gameBoard, king);
            return RemoveMovesThatCauseCheck(king, gameBoard, legalMoves);
            
        }

        private bool IsTooCloseToEnemyKing(King king, int futureY, int futureX,ChessBoard gameBoard)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (IsOnBoard(futureY + i, futureX + j))
                    {
                        if (gameBoard.GameBoard[futureY + i, futureX + j]?.Color != king.Color && gameBoard.GameBoard[futureY + i, futureX + j]?.GetType() == typeof(King))
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        public char[,] GetLegalMove(King king, ChessBoard GameBoard, char[,] legalMoves, int x, int y)
        {
            int piecePositionY = GameBoard.GetPositionY(king);
            int piecePositionX = GameBoard.GetPositionX(king);

            if (king.IsOnBoard(piecePositionY + y, piecePositionX + x))
            {
                if (GameBoard.GameBoard[piecePositionY + y, piecePositionX + x]?.Color != king.Color && !IsTooCloseToEnemyKing(king, piecePositionY + y, piecePositionX + x, GameBoard))
                {
                    legalMoves[piecePositionY + y, piecePositionX + x] = legalMove;
                }
            }
            return legalMoves;
        }

        public void HasMoved(King king)
        {
            king.CanCastle = false;
        }
    }
}
