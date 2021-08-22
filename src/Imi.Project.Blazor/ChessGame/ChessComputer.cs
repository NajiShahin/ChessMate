using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame
{
    public class ChessComputer
    {
        char legalMove = '•';
        /*
        public int Evaluate(ChessBoard board, Color color)
        {
            int evaluateVal = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.GameBoard[i, j]?.GetType() == typeof(Pawn))
                    {
                        if (board.GameBoard[i, j]?.Color == color)
                        {
                            evaluateVal += 10;
                        }
                        else
                        {
                            evaluateVal -= 10;
                        }
                    }
                    if (board.GameBoard[i, j]?.GetType() == typeof(Rook))
                    {
                        if (board.GameBoard[i, j]?.Color == color)
                        {
                            evaluateVal += 50;
                        }
                        else
                        {
                            evaluateVal -= 50;
                        }
                    }
                    if (board.GameBoard[i, j]?.GetType() == typeof(Knight))
                    {
                        if (board.GameBoard[i, j]?.Color == color)
                        {
                            evaluateVal += 30;
                        }
                        else
                        {
                            evaluateVal -= 30;
                        }
                    }
                    if (board.GameBoard[i, j]?.GetType() == typeof(Bishop))
                    {
                        if (board.GameBoard[i, j]?.Color == color)
                        {
                            evaluateVal += 30;
                        }
                        else
                        {
                            evaluateVal -= 30;
                        }
                    }
                    if (board.GameBoard[i, j]?.GetType() == typeof(Queen))
                    {
                        if (board.GameBoard[i, j]?.Color == color)
                        {
                            evaluateVal += 90;
                        }
                        else
                        {
                            evaluateVal -= 90;
                        }
                    }

                }
            }
            return evaluateVal;
        }
        */
        private void MakeRandomMove(ChessBoard board, Color color)
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.GameBoard[i, j]?.Color == color)
                    {
                        pieces.Add(board.GameBoard[i, j]);
                    }
                }
            }

            Random rnd = new Random();

            int amountOfLegalMoves = 0;
            Piece randomPiece = new Pawn(color,' ');
            int counter = 0;
            while (amountOfLegalMoves == 0)
            {
                int r = rnd.Next(pieces.Count);

                randomPiece = pieces[r];

                amountOfLegalMoves = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (randomPiece.GetLegalMoves(board, randomPiece)[i, j] == legalMove)
                        {
                            amountOfLegalMoves++;
                        }
                    }
                }
                counter++;
                if (counter==100)
                {
                    break;
                }
            }

            int randomMove = rnd.Next(amountOfLegalMoves);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (randomPiece.GetLegalMoves(board, randomPiece)[i, j] == legalMove)
                    {
                        randomMove--;
                        if (randomMove == -1)
                        {
                            //First value is X
                            //Second value is Y
                            //Third value is future X
                            //forth value is future Y

                            int x = board.GetPositionX(randomPiece);
                            int y = board.GetPositionY(randomPiece);
                            board.MakeMove(x, y, j, i, board);
                        }
                    }
                }
            }

        }

        public void MakeMove(ChessBoard board, Color color)
        {
            ChessBoard newBoard = new ChessBoard();
            newBoard.GameBoard = board.MakeClone(board);

            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (newBoard.GameBoard[i, j]?.Color == color)
                    {
                        pieces.Add(newBoard.GameBoard[i, j]);
                    }
                }
            }

            foreach (var piece in pieces)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        var a = piece.GetLegalMoves(newBoard, piece);
                        if (piece.GetLegalMoves(newBoard,piece)[i,j] == legalMove)
                        {
                            if (color == Color.White)
                            {
                                int x = newBoard.GetPositionX(piece);
                                int y = newBoard.GetPositionY(piece);
                                newBoard.MakeMove(x, y, j, i, newBoard);
                                if (newBoard.isBlackCheckMated())
                                {
                                    board.MakeMove(x, y, j, i, board);
                                    return;
                                }
                                else
                                {
                                    newBoard.MakeMove(j, i, x, y, newBoard);
                                }
                            }
                            else if (color == Color.Black)
                            {
                                int x = newBoard.GetPositionX(piece);
                                int y = newBoard.GetPositionY(piece);
                                newBoard.MakeMove(x, y, j, i, newBoard);
                                if (newBoard.IsWhiteCheckMated())
                                {
                                    board.MakeMove(x, y, j, i, board);
                                    return;
                                }
                                else
                                {
                                    newBoard.MakeMove(j, i, x, y, newBoard);
                                }
                            }
                        }
                    }
                }
            }

            MakeRandomMove(board, color);
        }
    }
}
