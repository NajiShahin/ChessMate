using Imi.Project.Blazor.ChessGame.enums;
using Imi.Project.Blazor.ChessGame.Pieces;
using Imi.Project.Blazor.ChessGame.Pieces.Base;
using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services.Api;
using Imi.Project.Blazor.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.ChessGame
{
    public class ChessBoard
    {

        public Piece[,] GameBoard { get; set; }
        public Turn Turn { get; set; }
        char legalMove = '•';

        public Piece[,] InitializeBoard()
        {
            Piece[,] board = new Piece[8, 8]
            {
                { new Rook(Color.Black, '♜'),new Knight(Color.Black, '♞'),new Bishop(Color.Black, '♝'),new Queen(Color.Black, '♛'),new King(Color.Black, '♚'),new Bishop(Color.Black, '♝'),new Knight(Color.Black, '♞'),new Rook(Color.Black, '♜')},
                { new Pawn(Color.Black,'♟'),new Pawn(Color.Black,'♟'),new Pawn(Color.Black,'♟'),new Pawn(Color.Black,'♟'),new Pawn(Color.Black,'♟'),new Pawn(Color.Black,'♟'),new Pawn(Color.Black,'♟'),new Pawn(Color.Black,'♟')},
                { null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null},
                { new Pawn(Color.White,'♙'),new Pawn(Color.White,'♙'),new Pawn(Color.White,'♙'),new Pawn(Color.White,'♙'),new Pawn(Color.White,'♙'),new Pawn(Color.White,'♙'),new Pawn(Color.White,'♙'),new Pawn(Color.White,'♙')},
                { new Rook(Color.White, '♖'),new Knight(Color.White, '♘'),new Bishop(Color.White, '♗'),new Queen(Color.White, '♕'),new King(Color.White, '♔'),new Bishop(Color.White, '♗'),new Knight(Color.White, '♘'),new Rook(Color.White, '♖')},
            };
            GameBoard = board;
            return GameBoard;
        }

        public void MakeMove(int initialX, int initialY, int futureX, int futureY, ChessBoard board)
        {
            var piece = GameBoard[initialY, initialX];
            GameBoard[futureY, futureX] = piece;
            GameBoard[initialY, initialX] = null;

            //Enables en passant and pawn promotion
            //////////////////////////////////////////
            piece = board.GameBoard[futureY, futureX];

            if (piece?.GetType() == typeof(Pawn))
            {
                var pawn = piece as Pawn;
                pawn.EnPassant(board, pawn);
                pawn.SetEnPassantEnemiesToFalse(board);
                if (piece.Color == Color.White && initialY == 6 && futureY == 4)
                {
                    pawn.IsEnPassantable = true;
                }
                if (piece.Color == Color.Black && initialY == 1 && futureY == 3)
                {
                    pawn.IsEnPassantable = true;
                }
                pawn.PromotePawn(pawn, board);
            }
            //////////////////////////////////////////

            //Enables castling
            //////////////////////////////////////////
            var castlingPiece = board.GameBoard[futureY, futureX];


            if (piece?.GetType() == typeof(King))
            {
                var king = piece as King;
                king.Castle(king, this, futureX);
                king.HasMoved(king);
            }

            if (piece?.GetType() == typeof(Rook))
            {
                var rook = piece as Rook;
                rook.HasMoved(rook);
            }
            //////////////////////////////////////////

        }

        public Piece[,] MakeClone(ChessBoard board)
        {
            Piece[,] newBoard = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.GameBoard[i, j]?.GetType() == typeof(Pawn))
                    {
                        newBoard[i, j] = new Pawn(board.GameBoard[i, j].Color, board.GameBoard[i, j].Charachter);
                    }
                    else if (board.GameBoard[i, j]?.GetType() == typeof(Rook))
                    {
                        newBoard[i, j] = new Rook(board.GameBoard[i, j].Color, board.GameBoard[i, j].Charachter);
                    }
                    else if (board.GameBoard[i, j]?.GetType() == typeof(Knight))
                    {
                        newBoard[i, j] = new Knight(board.GameBoard[i, j].Color, board.GameBoard[i, j].Charachter);
                    }
                    else if (board.GameBoard[i, j]?.GetType() == typeof(Bishop))
                    {
                        newBoard[i, j] = new Bishop(board.GameBoard[i, j].Color, board.GameBoard[i, j].Charachter);
                    }
                    else if (board.GameBoard[i, j]?.GetType() == typeof(Queen))
                    {
                        newBoard[i, j] = new Queen(board.GameBoard[i, j].Color, board.GameBoard[i, j].Charachter);
                    }
                    else if (board.GameBoard[i, j]?.GetType() == typeof(King))
                    {
                        newBoard[i, j] = new King(board.GameBoard[i, j].Color, board.GameBoard[i, j].Charachter);
                    }

                }
            }
            return newBoard;
        }

        public async Task<IEnumerable<OpeningItem>> InitializeOpenings()
        {
            HttpClient _httpClient = new HttpClient();
            AuthService _authService = new AuthService(_httpClient);

            var token = await _authService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            await Task.CompletedTask;


            string baseUrl = "https://localhost:5001/api/openings";

            return JsonConvert.DeserializeObject<IEnumerable<OpeningItem>>(await _httpClient.GetAsync(baseUrl).Result.Content.ReadAsStringAsync());
        }

        public string GetOpeningAsync(IEnumerable<OpeningItem> openings)
        {
            if (openings == null)
                return "";

            foreach (var opening in openings)
            {
                if (opening.FenString == GetFenString(GameBoard))
                {
                    return opening.Name;
                }
            }
            return "";
        }

        public string GetFenString(Piece[,] GameBoard)
        {
            string fenString = "";
            int emptyRows = 0;
            for (int i = 0; i < 8; i++)
            {
                emptyRows = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j] == null)
                    {
                        emptyRows++;
                        if (j == 7)
                        {
                            fenString += emptyRows.ToString();
                        }
                    }
                    else
                    {
                        string charToAdd = "";
                        if (emptyRows != 0)
                        {
                            fenString += emptyRows.ToString();
                        }

                        if (GameBoard[i, j].GetType() == typeof(Pawn))
                        {
                            emptyRows = 0;
                            charToAdd = "p";
                        }
                        else if (GameBoard[i, j].GetType() == typeof(Rook))
                        {
                            emptyRows = 0;
                            charToAdd = "r";
                        }
                        else if (GameBoard[i, j].GetType() == typeof(Knight))
                        {
                            emptyRows = 0;
                            charToAdd = "n";
                        }
                        else if (GameBoard[i, j].GetType() == typeof(Bishop))
                        {
                            emptyRows = 0;
                            charToAdd = "b";
                        }
                        else if (GameBoard[i, j].GetType() == typeof(Queen))
                        {
                            emptyRows = 0;
                            charToAdd = "q";
                        }
                        else if (GameBoard[i, j].GetType() == typeof(King))
                        {
                            emptyRows = 0;
                            charToAdd = "k";
                        }
                        if (GameBoard[i, j]?.Color == Color.White)
                            fenString += charToAdd.ToUpper();
                        else
                            fenString += charToAdd;
                    }
                }
                if (i != 7)
                {
                    fenString += "/";
                }
            }
            return fenString;
        }


        public bool IsDraw(Turn turn)
        {
            int piecesWithNoMoves = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j]?.Color.ToString() == turn.ToString())
                    {
                        if (GameBoard[i, j].HasLegalMoves(GameBoard[i, j].GetLegalMoves(this, GameBoard[i, j])))
                        {
                            piecesWithNoMoves++;
                        }
                    }
                }
            }
            if (piecesWithNoMoves == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsWhiteCheckMated()
        {
            var whiteKing = GetWhiteKing(this);
            return whiteKing.isCheckMated(whiteKing, this);
        }

        public bool isBlackCheckMated()
        {
            return GetBlackKing(this).isCheckMated(GetBlackKing(this), this);
        }

        public bool IsWhiteChecked()
        {
            var whiteKing = GetWhiteKing(this);
            return whiteKing.IsChecked(whiteKing, this);
        }

        public bool isBlackChecked()
        {
            return GetBlackKing(this).IsChecked(GetBlackKing(this), this);
        }

        public King GetWhiteKing(ChessBoard gameBoard)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(King) && gameBoard.GameBoard[i, j]?.Color == Color.White)
                    {
                        return gameBoard.GameBoard[i, j] as King;
                    }
                }
            }
            return new King(Color.White, ' ');
        }

        public King GetBlackKing(ChessBoard gameBoard)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gameBoard.GameBoard[i, j]?.GetType() == typeof(King) && gameBoard.GameBoard[i, j]?.Color == Color.Black)
                    {
                        return gameBoard.GameBoard[i, j] as King;
                    }
                }
            }
            return new King(Color.Black, ' ');
        }


        public char[,] GetBoardCharacters()
        {
            char[,] board = new char[8, 8];
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (GameBoard[i, j] != null)
                    {
                        board[i, j] = GameBoard[i, j].Charachter;
                    }
                    else
                    {
                        board[i, j] = ' ';
                    }
                }
            }
            return board;
        }

        public int GetPositionX(Piece piece)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j] == piece)
                    {
                        return j;
                    }
                }
            }
            return 0;
        }


        public int GetPositionY(Piece piece)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j] == piece)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        //Gets all attacking tiles from given color
        public char[,] GetAllAttackingTiles(Color color)
        {
            char[,] attackTiles = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j]?.Color == color && GameBoard[i, j]?.GetType() != typeof(King))
                    {
                        AddLegalMoves(attackTiles, GameBoard[i, j].GetLegalMoves(this, GameBoard[i, j]));
                    }
                    if (GameBoard[i, j]?.Color == color && GameBoard[i, j]?.GetType() == typeof(King))
                    {
                        //Zonder dit zal je in een oneindige loop komen door de castling method
                        King king = GameBoard[i, j] as King;
                        king.GetLegalMove(king, this, attackTiles, 0, 1);
                        king.GetLegalMove(king, this, attackTiles, 0, -1);
                        king.GetLegalMove(king, this, attackTiles, 1, 0);
                        king.GetLegalMove(king, this, attackTiles, -1, 0);
                        king.GetLegalMove(king, this, attackTiles, 1, -1);
                        king.GetLegalMove(king, this, attackTiles, -1, 1);
                        king.GetLegalMove(king, this, attackTiles, 1, 1);
                        king.GetLegalMove(king, this, attackTiles, -1, -1);
                    }
                }
            }

            return attackTiles;
        }

        private char[,] AddLegalMoves(char[,] newArray, char[,] arrayToAdd)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (arrayToAdd[i, j] == legalMove)
                    {
                        newArray[i, j] = arrayToAdd[i, j];
                    }
                }
            }
            return newArray;
        }
    }
}
