using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Imi.Project.Common
{
    public class ChessConverter
    {
        //https://bit.ly/3sQWHNy

        public char WhitePawn { get; set; }
        public char WhiteRook { get; set; }
        public char WhiteKnight { get; set; }
        public char WhiteBishop { get; set; }
        public char WhiteQueen { get; set; }
        public char WhiteKing { get; set; }
        public char BlackPawn { get; set; }
        public char BlackRook { get; set; }
        public char BlackKnight { get; set; }
        public char BlackBishop { get; set; }
        public char BlackQueen { get; set; }
        public char BlackKing { get; set; }


        public ChessConverter(char whitePawn = '♙', char whiteRook = '♖', char whiteKnight = '♘', char whiteBishop = '♗',
            char whiteQueen = '♕', char whiteKing = '♔', char blackPawn = '♟', char blackRook = '♜', char blackKnight = '♞',
            char blackBishop = '♝', char blackQueen = '♛', char blackKing = '♚')
        {
            this.WhitePawn = whitePawn;
            this.WhiteRook = whiteRook;
            this.WhiteKnight = whiteKnight;
            this.WhiteBishop = whiteBishop;
            this.WhiteQueen = whiteQueen;
            this.WhiteKing = whiteKing;
            this.BlackPawn = blackPawn;
            this.BlackRook = blackRook;
            this.BlackKnight = blackKnight;
            this.BlackBishop = blackBishop;
            this.BlackQueen = blackQueen;
            this.BlackKing = blackKing;
        }

        public char[,] GetStartingBoard()
        {
            return new char[8, 8]
            {
            { BlackRook,BlackKnight,BlackBishop,BlackQueen,BlackKing,BlackBishop,BlackKnight,BlackRook},
                { BlackPawn,BlackPawn,BlackPawn,BlackPawn,BlackPawn,BlackPawn,BlackPawn,BlackPawn},
                { ' ',' ',' ',' ',' ',' ',' ',' '},
                { ' ',' ',' ',' ',' ',' ',' ',' '},
                { ' ',' ',' ',' ',' ',' ',' ',' '},
                { ' ',' ',' ',' ',' ',' ',' ',' '},
                { WhitePawn,WhitePawn,WhitePawn,WhitePawn,WhitePawn,WhitePawn,WhitePawn,WhitePawn},
                { WhiteRook,WhiteKnight,WhiteBishop,WhiteQueen,WhiteKing,WhiteBishop,WhiteKnight,WhiteRook},
            };
        }

        public string GetBeginAndFinishPositionOfLastMove(string pgnMove, char[,] chessBoard, Turn turn)
        {
            string longPGN = GetLongPGN(pgnMove, chessBoard, turn);


            if (longPGN.Substring(0, 1) == "R" || longPGN.Substring(0, 1) == "N" || longPGN.Substring(0, 1) == "B" ||
                longPGN.Substring(0, 1) == "Q" || longPGN.Substring(0, 1) == "K")
            {
                return longPGN.Substring(1);
            }

            return longPGN;
        }


        public string GetLongPGN(string pgnMove, char[,] chessBoard, Turn turn)
        {
            bool hasCheck = false;
            bool hasMate = false;

            if (pgnMove.Contains('+'))
            {
                hasCheck = true;
                pgnMove = Regex.Replace(pgnMove, "[+]", string.Empty);
            }
            if (pgnMove.Contains('#'))
            {
                hasMate = true;
                pgnMove = Regex.Replace(pgnMove, "#", string.Empty);
            }


            if (pgnMove.Substring(0, 1) == "O")
            {
                return pgnMove;
            }

            char[,] newBoard = GetCloneBoard(chessBoard);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    newBoard = GetCloneBoard(chessBoard);
                    convertPgnMoveToBoard(pgnMove, newBoard, turn);
                    string piece = "";
                    if (chessBoard[i, j] != ' ' && newBoard[i, j] == ' ')
                    {
                        if (pgnMove.Substring(0, 1) == "R" || pgnMove.Substring(0, 1) == "N" || pgnMove.Substring(0, 1) == "B" ||
                            pgnMove.Substring(0, 1) == "Q" || pgnMove.Substring(0, 1) == "K")
                        {
                            piece = pgnMove.Substring(0, 1);
                            if (pgnMove.Length == 3)
                            {
                                pgnMove = pgnMove.Substring(1);
                            }
                            else if (pgnMove.Length == 4)
                            {
                                pgnMove = pgnMove.Substring(2);
                            }
                            else if (pgnMove.Length == 5)
                            {
                                pgnMove = pgnMove.Substring(3);
                            }
                        }
                        if (hasMate)
                            pgnMove += "#";

                        if (hasCheck)
                            pgnMove += "+";

                        if (pgnMove.Contains('x'))
                        {
                            pgnMove = pgnMove.Substring(pgnMove.IndexOf('x') + 1);
                        }

                        switch (j)
                        {
                            case 0:
                                return piece + "a" + (8 - i) + pgnMove;
                            case 1:
                                return piece + "b" + (8 - i) + pgnMove;
                            case 2:
                                return piece + "c" + (8 - i) + pgnMove;
                            case 3:
                                return piece + "d" + (8 - i) + pgnMove;
                            case 4:
                                return piece + "e" + (8 - i) + pgnMove;
                            case 5:
                                return piece + "f" + (8 - i) + pgnMove;
                            case 6:
                                return piece + "g" + (8 - i) + pgnMove;
                            case 7:
                                return piece + "h" + (8 - i) + pgnMove;
                            default:
                                break;
                        }
                    }
                }
            }
            return "";
        }

        private char[,] GetCloneBoard(char[,] chessBoard)
        {
            char[,] board = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = chessBoard[i, j];
                }
            }
            return board;
        }


        public string GetFenString(char[,] GameBoard)
        {
            string fenString = "";
            int emptyRows = 0;
            for (int i = 0; i < 8; i++)
            {
                emptyRows = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j] == ' ')
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

                        if (GameBoard[i, j] == BlackPawn)
                        {
                            emptyRows = 0;
                            charToAdd = "p";
                        }
                        else if (GameBoard[i, j] == BlackRook)
                        {
                            emptyRows = 0;
                            charToAdd = "r";
                        }
                        else if (GameBoard[i, j] == BlackKnight)
                        {
                            emptyRows = 0;
                            charToAdd = "n";
                        }
                        else if (GameBoard[i, j] == BlackBishop)
                        {
                            emptyRows = 0;
                            charToAdd = "b";
                        }
                        else if (GameBoard[i, j] == BlackQueen)
                        {
                            emptyRows = 0;
                            charToAdd = "q";
                        }
                        else if (GameBoard[i, j] == BlackKing)
                        {
                            emptyRows = 0;
                            charToAdd = "k";
                        }
                        else if (GameBoard[i, j] == WhitePawn)
                        {
                            emptyRows = 0;
                            charToAdd = "P";
                        }
                        else if (GameBoard[i, j] == WhiteRook)
                        {
                            emptyRows = 0;
                            charToAdd = "R";
                        }
                        else if (GameBoard[i, j] == WhiteKnight)
                        {
                            emptyRows = 0;
                            charToAdd = "N";
                        }
                        else if (GameBoard[i, j] == WhiteBishop)
                        {
                            emptyRows = 0;
                            charToAdd = "B";
                        }
                        else if (GameBoard[i, j] == WhiteQueen)
                        {
                            emptyRows = 0;
                            charToAdd = "Q";
                        }
                        else if (GameBoard[i, j] == WhiteKing)
                        {
                            emptyRows = 0;
                            charToAdd = "K";
                        }
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

        public bool ValidateMoves(List<string> pgnMoves)
        {
            char[,] chessBoard = GetStartingBoard();
            for (int i = 0; i < pgnMoves.Count; i++)
            {
                try
                {
                    if (i % 2 == 0)
                    {
                        convertPgnMoveToBoard(pgnMoves[i], chessBoard, Turn.White);
                    }
                    else
                    {
                        convertPgnMoveToBoard(pgnMoves[i], chessBoard, Turn.Black);
                    }
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            return true;

        }

        public void convertPgnMoveToBoard(string pgnMove, char[,] chessBoard, Turn turn)
        {
            pgnMove = Regex.Replace(pgnMove, "#", string.Empty);
            pgnMove = Regex.Replace(pgnMove, "[+]", string.Empty);
            switch (pgnMove.Substring(0, 1))
            {
                case "N":
                    knightMoves(pgnMove, chessBoard, turn);
                    break;
                case "B":
                    bishopMoves(pgnMove, chessBoard, turn);
                    break;
                case "R":
                    rookMoves(pgnMove, chessBoard, turn);
                    break;
                case "Q":
                    queenMoves(pgnMove, chessBoard, turn);
                    break;
                case "K":
                    kingMoves(pgnMove, chessBoard, turn);
                    break;
                case "O":
                        Castle(pgnMove, chessBoard, turn);
                    break;
                default:
                    pawnMoves(pgnMove, chessBoard, turn);
                    break;
            }
        } 

        private void Castle(string pgnMove, char[,] chessBoard, Turn turn)
        {
            //KingsSideCastle
            if (pgnMove == "O-O")
            {
                if (turn == Turn.White)
                {
                    chessBoard[7, 7] = ' ';
                    chessBoard[7, 4] = ' '; 
                    chessBoard[7, 6] = WhiteKing;
                    chessBoard[7, 5] = WhiteRook;
                }
                else
                {
                    chessBoard[0, 7] = ' ';
                    chessBoard[0, 4] = ' ';
                    chessBoard[0, 6] = BlackKing;
                    chessBoard[0, 5] = BlackRook;
                }
            }
            //QueensSideCastle
            else
            {
                if (turn == Turn.White) 
                {
                    chessBoard[7, 0] = ' ';
                    chessBoard[7, 4] = ' ';
                    chessBoard[7, 2] = WhiteKing;
                    chessBoard[7, 3] = WhiteRook;
                }
                else
                {
                    chessBoard[0, 0] = ' ';
                    chessBoard[0, 4] = ' ';
                    chessBoard[0, 2] = BlackKing;
                    chessBoard[0, 3] = BlackRook;
                }
            }
        }
        public void pawnMoves(string pgnMove, char[,] chessBoard, Turn turn)
        {
            char pawn = WhitePawn;
            if (turn == Turn.Black)
            {
                pawn = BlackPawn;
            }
            int fileX, fileY;

            switch (pgnMove.Length)
            {
                case 2:
                    fileX = getFilePosition(pgnMove[0]);
                    fileY = 8 - Convert.ToInt32(pgnMove.Substring(1));
                    removeMovingPawn(fileX, fileY, chessBoard, turn);
                    chessBoard[fileY, fileX] = pawn;
                    break;

                case 4:
                    if (!pgnMove.Contains("="))
                    {
                        pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
                        fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1)));
                        fileY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1));
                        removeAttackingPawn(getFilePosition(pgnMove[0]), fileX, fileY, chessBoard, turn);
                        chessBoard[fileY, fileX] = pawn;
                    }
                    else
                    {
                        fileX = getFilePosition(pgnMove[0]);
                        fileY = 8 - Convert.ToInt32(pgnMove.Substring(1, 1));
                        removeMovingPawn(fileX, fileY, chessBoard, turn);
                        pawn = promotePawn(pgnMove, turn);
                        chessBoard[fileY, fileX] = pawn;
                    }
                    break;

                case 6:
                    pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
                    fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1)));
                    fileY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1));
                    removeAttackingPawn(getFilePosition(pgnMove[0]), fileX, fileY, chessBoard, turn);
                    pawn = promotePawn(pgnMove, turn);
                    chessBoard[fileY, fileX] = pawn;
                    break;
            }
        }

        private void removeMovingPawn(int fileX, int fileY, char[,] chessBoard, Turn turn)
        {
            char pawn = WhitePawn;
            if (turn == Turn.Black)
            {
                pawn = BlackPawn;
                if (chessBoard[fileY - 1, fileX] == pawn)
                {
                    chessBoard[fileY - 1, fileX] = ' ';
                }
                else if (fileY - 2 >= 0)
                {
                    if (chessBoard[fileY - 2, fileX] == pawn)
                    {
                        chessBoard[fileY - 2, fileX] = ' ';
                    }
                }
            }
            else
            {
                if (chessBoard[fileY + 1, fileX] == pawn)
                {
                    chessBoard[fileY + 1, fileX] = ' ';
                }
                else if (fileY + 2 <= 8)
                {
                    if (chessBoard[fileY + 2, fileX] == pawn)
                    {
                        chessBoard[fileY + 2, fileX] = ' ';
                    }
                }
            }
        }

        private void removeAttackingPawn(int initialX, int fileX, int fileY, char[,] chessBoard, Turn turn)
        {

            char pawn = WhitePawn;
            if (turn == Turn.Black)
            {
                pawn = BlackPawn;
                if (chessBoard[fileY - 1, initialX] == pawn && chessBoard[fileY, fileX] != ' ')
                {
                    chessBoard[fileY - 1, initialX] = ' ';
                }
                else if (chessBoard[fileY - 1, initialX] == pawn && chessBoard[fileY, fileX] == ' ' && fileY == 5)
                {
                    chessBoard[fileY - 1, initialX] = ' ';

                    chessBoard[fileY - 1, fileX] = ' ';

                }
            }
            else
            {
                if (chessBoard[fileY + 1, initialX] == pawn && chessBoard[fileY, fileX] != ' ')
                {
                    chessBoard[fileY + 1, initialX] = ' ';
                }
                else if (chessBoard[fileY + 1, initialX] == pawn && chessBoard[fileY, fileX] == ' ' && fileY == 2)
                {
                    chessBoard[fileY + 1, initialX] = ' ';
                    chessBoard[fileY + 1, fileX] = ' ';

                }
            }
        }
        private char promotePawn(string pgnMove, Turn turn)
        {
            pgnMove = Regex.Replace(pgnMove, "=", string.Empty);
            List<char> pieces = new List<char> { WhiteRook, WhiteKnight, WhiteBishop, WhiteQueen};
            if (turn == Turn.Black)
            {
                pieces = new List<char> { BlackRook, BlackKnight, BlackBishop, BlackQueen};
            }
            switch (pgnMove.Last())
            {
                case 'R':
                    return pieces[0];
                case 'N':
                    return pieces[1];
                case 'B':
                    return pieces[2];
                case 'Q':
                    return pieces[3];
            }
            //Gebeurt bij een correcte pgn nooit!
            return ' ';
        }

        private void kingMoves(string pgnMove, char[,] chessBoard, Turn turn)
        {
            char king = WhiteKing;
            if (turn == Turn.Black)
            {
                king = BlackKing;
            }
            pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
            int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1)));
            int fileY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1));
            checkKingPosition(fileX, fileY, chessBoard, turn);
            chessBoard[fileY, fileX] = king;
        }

        private void checkKingPosition(int fileX, int fileY, char[,] chessBoard, Turn turn)
        {
            removeKing(chessBoard, turn, fileY, fileX, 1, 1);
            removeKing(chessBoard, turn, fileY, fileX, -1, 1);
            removeKing(chessBoard, turn, fileY, fileX, 0, +1);
            removeKing(chessBoard, turn, fileY, fileX, 1, -1);
            removeKing(chessBoard, turn, fileY, fileX, 0, -1);
            removeKing(chessBoard, turn, fileY, fileX, -1, -1);
            removeKing(chessBoard, turn, fileY, fileX, 1, 0);
            removeKing(chessBoard, turn, fileY, fileX, -1, 0);
            
        }

        private void removeKing(char[,] chessBoard, Turn turn,int fileY, int fileX, int previousY, int previousX)
        {
            char king = WhiteKing;
            if (turn == Turn.Black)
            {
                king = BlackKing;
            }
            if (IsOnBoard(fileX + previousX, fileY + previousY))
            {
                if (chessBoard[fileY + previousY, fileX + previousX] == king)
                {
                    chessBoard[fileY + previousY, fileX + previousX] = ' ';
                }
            }
        }



        private void knightMoves(string pgnMove, char[,] chessBoard, Turn turn)
        {
            char knight = WhiteKnight;
            if (turn == Turn.Black)
            {
                knight = BlackKnight;
            }
            pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
            if (pgnMove.Length == 3)
            {
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(1,1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(2,1));
                checkKnightPosition(fileX, fileY, chessBoard, turn);
                chessBoard[fileY, fileX] = knight;
            }
            else if (pgnMove.Length == 4)
            {
                pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(2, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(3, 1));
                checkKnightPosition(fileX, fileY, chessBoard, turn, pgnMove.Substring(1,1)) ;
                chessBoard[fileY, fileX] = knight;
            }
            else
            {
                pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(3, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(4, 1));
                chessBoard[fileY, fileX] = knight;
                int originalX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1))); ;
                int originalY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1)); ;
                chessBoard[originalY, originalX] = ' ';
            }
        }

        private void checkKnightPosition(int fileX, int fileY, char[,] chessBoard, Turn turn, string initial = "")
        {
            if (fileY <= 5 && fileX <= 6)
            {
                removeKnight(fileX, fileY, chessBoard, turn, 2, +1, initial);
            }
            if (fileY <= 5 && fileX >= 1)
            {
                removeKnight(fileX, fileY, chessBoard, turn, 2, -1, initial);
            }
            if (fileY >= 2 && fileX <= 6)
            {
                removeKnight(fileX, fileY, chessBoard, turn, -2, +1, initial);
            }
            if (fileY >= 2 && fileX >= 1)
            {
                removeKnight(fileX, fileY, chessBoard, turn, -2, -1, initial);
            }
            if (fileY <= 6 && fileX <= 5)
            {
                removeKnight(fileX, fileY, chessBoard, turn, 1, 2, initial);
            }
            if (fileY <= 6 && fileX >= 2)
            {
                removeKnight(fileX, fileY, chessBoard, turn, 1, -2, initial);
            }
            if (fileY >= 1 && fileX <= 5)
            {
                removeKnight(fileX, fileY, chessBoard, turn, -1, 2, initial);
            }
            if (fileY >= 1 && fileX >= 2)
            {
                removeKnight(fileX, fileY, chessBoard, turn, -1, -2, initial);
            }
        }

        private void removeKnight(int fileX, int fileY, char[,] chessBoard, Turn turn, int previousY, int previousX, string initial = "")
        {
            char knight = WhiteKnight;
            if (turn == Turn.Black)
            {
                knight = BlackKnight;
            }
            if (chessBoard[fileY + previousY, fileX + previousX] == knight)
            {
                if (initial == "")
                {
                    chessBoard[fileY + previousY, fileX + previousX] = ' ';
                }
                else if (int.TryParse(initial, out _))
                {
                    if (chessBoard[fileY + previousY, fileX + previousX] == knight && 7 - (fileY + previousY) == Convert.ToInt32(initial) - 1)
                    {
                        chessBoard[fileY + previousY, fileX + previousX] = ' ';
                    }
                }
                else
                {
                    var a = getFilePosition(Convert.ToChar(initial));
                    if (chessBoard[fileY + previousY, fileX + previousX] == knight && fileX + previousX == a)
                    {
                        chessBoard[fileY + previousY, fileX + previousX] = ' ';
                    }
                }
            }
        }


        private void bishopMoves(string pgnMove, char[,] chessBoard, Turn turn)
        {
            char bishop = BlackBishop;
            if (turn == Turn.White)
            {
                bishop = WhiteBishop;
            }
            pgnMove = Regex.Replace(pgnMove, "x", string.Empty);

            if (pgnMove.Length == 3)
            {
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1));
                removeDiagonal(fileX, fileY, chessBoard, turn, WhiteBishop, BlackBishop);
                chessBoard[fileY, fileX] = bishop;
            }
            else if (pgnMove.Length == 4)
            {
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(2, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(3, 1));
                removeDiagonal(fileX, fileY, chessBoard, turn, WhiteBishop, BlackBishop, pgnMove.Substring(1, 1));
                chessBoard[fileY, fileX] = bishop;
            }
            else
            {
                pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(3, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(4, 1));
                chessBoard[fileY, fileX] = bishop;
                int originalX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1))); ;
                int originalY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1)); ;
                chessBoard[originalY, originalX] = ' ';
            }
        }

        private void removeDiagonal(int fileX, int fileY, char[,] chessBoard, Turn turn, char whitePiece, char blackPiece, string initial = "")
        {
            List<char> pieces = new List<char> { BlackKing, BlackQueen, BlackRook, BlackBishop, BlackKnight, BlackPawn,
                WhiteKing, WhiteQueen, WhiteRook, WhiteBishop, WhiteKnight, WhitePawn};
            char bishop = whitePiece;
            if (turn == Turn.Black)
            {
                bishop = blackPiece;
            }

            int i = 0;
            if (fileX + fileY <= 7)
            {
                while (i != fileX + fileY + 1)
                {
                    if (chessBoard[fileX + fileY - i, i] == bishop)
                    {
                        bool isBlocked = false;
                        if (i < fileX)
                        {
                            isBlocked = false;

                            for (int j = i +1; j  < fileX; j++)
                            {
                                if (chessBoard[fileX + fileY - j, j] == pieces[0]
                                    || chessBoard[fileX + fileY - j, j] == pieces[1]
                                    || chessBoard[fileX + fileY - j, j] == pieces[2]
                                    || chessBoard[fileX + fileY - j, j] == pieces[3]
                                    || chessBoard[fileX + fileY - j, j] == pieces[4]
                                    || chessBoard[fileX + fileY - j, j] == pieces[5]
                                    || chessBoard[fileX + fileY - j, j] == pieces[6]
                                    || chessBoard[fileX + fileY - j, j] == pieces[7]
                                    || chessBoard[fileX + fileY - j, j] == pieces[8]
                                    || chessBoard[fileX + fileY - j, j] == pieces[9]
                                    || chessBoard[fileX + fileY - j, j] == pieces[10]
                                    || chessBoard[fileX + fileY - j, j] == pieces[11])
                                {
                                    isBlocked = true;
                                }
                            }
                        }
                        else
                        {
                            isBlocked = false;
                            for (int j = i - 1; j > fileX; j--)
                            {
                                //Change values inside square brackets
                                if (chessBoard[fileX + fileY - j, j] == pieces[0]
                                    || chessBoard[fileX + fileY - j, j] == pieces[1]
                                    || chessBoard[fileX + fileY - j, j] == pieces[2]
                                    || chessBoard[fileX + fileY - j, j] == pieces[3]
                                    || chessBoard[fileX + fileY - j, j] == pieces[4]
                                    || chessBoard[fileX + fileY - j, j] == pieces[5]
                                    || chessBoard[fileX + fileY - j, j] == pieces[6]
                                    || chessBoard[fileX + fileY - j, j] == pieces[7]
                                    || chessBoard[fileX + fileY - j, j] == pieces[8]
                                    || chessBoard[fileX + fileY - j, j] == pieces[9]
                                    || chessBoard[fileX + fileY - j, j] == pieces[10]
                                    || chessBoard[fileX + fileY - j, j] == pieces[11])
                                {
                                    isBlocked = true;
                                }
                            }
                        }
                        if (!isBlocked && initial == "")
                        {

                            chessBoard[fileX + fileY - i, i] = ' ';
                            return;
                        }
                        else if (int.TryParse(initial, out _) && initial != "")
                        {
                            if (chessBoard[8 - Convert.ToInt16(initial), i] == bishop)
                            {
                                chessBoard[8 - Convert.ToInt16(initial), i] = ' ';
                                return;
                            }
                        }
                        else if(initial != "")
                        {
                            var a = getFilePosition(Convert.ToChar(initial));
                            if (chessBoard[fileX + fileY - i, i] == bishop && i == a)
                            {
                                chessBoard[fileX + fileY - i, a] = ' ';
                                return;
                            }
                        }
                        
                    }
                    i++;
                }
            }
            i = 0;
            if (fileX + fileY > 7)
            {
                int bottomX = 7, bottomY = 0;
                bottomY = fileX + fileY - 7;

                while (i !=  bottomX - (bottomY - 1))
                {
                    if (chessBoard[7 - i, fileX + fileY - 7 + i] == bishop)
                    {
                        bool isBlocked = false;

                        if (i < fileX)
                        {
                            isBlocked = false;
                            for (int j = i +1; j < 7 - fileY; j++)
                            {
                                if (fileX + fileY - 7 + j <= 7)
                                {
                                    
                                    if (chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[0]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[1]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[2]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[3]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[4]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[5]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[6]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[7]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[8]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[9]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[10]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[11])
                                    {
                                        isBlocked = true;
                                    }
                                    
                                }
                            }
                        }
                        else
                        {
                            isBlocked = false;
                            for (int j = i -1; j > fileX - 1; j--)
                            {
                                if (chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[0]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[1]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[2]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[3]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[4]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[5]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[6]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[7]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[8]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[9]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[10]
                                    || chessBoard[7 - j, fileX + fileY - 7 + j] == pieces[11])
                                {
                                    isBlocked = true;
                                }
                            }
                        }

                        if (!isBlocked && initial == "")
                        {
                            chessBoard[7 - i, fileX + fileY - 7 + i] = ' ';
                            return;
                        }
                        else if (int.TryParse(initial, out _) && initial != "")
                        {
                            if (chessBoard[7 - i, fileX + fileY - 7 + i] == bishop && 7 - i == 8 - Convert.ToInt16(initial))
                            {
                                chessBoard[7 - i, fileX + fileY - 7 + i] = ' ';
                                return;
                            }
                        }
                        else if (initial != "")
                        {
                            var a = getFilePosition(Convert.ToChar(initial));
                            if (chessBoard[7 - i, fileX + fileY - 7 + i] == bishop && fileX + fileY - 7 + i == a)
                            {
                                chessBoard[7 - i, fileX + fileY - 7 + i] = ' ';
                                return;
                            }
                        }
                    }
                    i++;
                }
            }
            i = 0;
            if (fileY - fileX >= 0)
            {
                while (i != 8 - (fileY - fileX))
                {
                    if (chessBoard[fileY - fileX + i, i] == bishop)
                    {
                        bool isBlocked = false;
                        if (i < fileX)
                        {
                            for (int j = i + 1; j < fileX; j++)
                            {
                                if (chessBoard[fileY - fileX + j, j] == pieces[0]
                                    || chessBoard[fileY - fileX + j, j] == pieces[1]
                                    || chessBoard[fileY - fileX + j, j] == pieces[2]
                                    || chessBoard[fileY - fileX + j, j] == pieces[3]
                                    || chessBoard[fileY - fileX + j, j] == pieces[4]
                                    || chessBoard[fileY - fileX + j, j] == pieces[5]
                                    || chessBoard[fileY - fileX + j, j] == pieces[6]
                                    || chessBoard[fileY - fileX + j, j] == pieces[7]
                                    || chessBoard[fileY - fileX + j, j] == pieces[8]
                                    || chessBoard[fileY - fileX + j, j] == pieces[9]
                                    || chessBoard[fileY - fileX + j, j] == pieces[10]
                                    || chessBoard[fileY - fileX + j, j] == pieces[11])
                                {
                                    isBlocked = true;
                                }
                            }
                        }
                        else
                        {
                            for (int j = i; j > fileX + 1; j--)
                            {
                                //Change values inside square brackets
                                if (chessBoard[fileY - fileX + j - 1, j - 1] == pieces[0]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[1]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[2]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[3]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[4]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[5]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[6]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[7]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[8]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[9]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[10]
                                    || chessBoard[fileY - fileX + j - 1, j - 1] == pieces[11])
                                {
                                    isBlocked = true;
                                }
                            }
                        }
                        if (!isBlocked && initial == "")
                        {
                            chessBoard[fileY - fileX + i, i] = ' ';
                            return;
                        }
                        else if (initial != "" && int.TryParse(initial, out _))
                        {
                            if (chessBoard[fileY - fileX + i, i] == bishop && 8 - Convert.ToInt32(initial) == fileY - fileX + i)
                            {
                                chessBoard[fileY - fileX + i, i] = ' ';
                                return;
                            }
                        }
                        else if(initial != "")
                        {
                            var a = getFilePosition(Convert.ToChar(initial));
                            if (chessBoard[fileY - fileX + i, i] == bishop && i == a)
                            {
                                chessBoard[fileY - fileX + i, i] = ' ';
                                return;
                            }
                        }
                        
                    }
                    i++;
                }
            }
            i = 0;
            if (fileY - fileX < 0)
            {
                while (i != 8 - (fileX - fileY))
                {
                    if (chessBoard[i, fileX - fileY + i] == bishop)
                    {
                        bool isBlocked = false;
                        ////Check isBlocked
                        if (i < fileX)
                        {
                            for (int j = i + 1; j < fileY; j++)
                            {
                                if (fileX - fileY + j <= 7)
                                {
                                    if (chessBoard[j, fileX - fileY + j] == pieces[0]
                                    || chessBoard[j, fileX - fileY + j] == pieces[1]
                                    || chessBoard[j, fileX - fileY + j] == pieces[2]
                                    || chessBoard[j, fileX - fileY + j] == pieces[3]
                                    || chessBoard[j, fileX - fileY + j] == pieces[4]
                                    || chessBoard[j, fileX - fileY + j] == pieces[5]
                                    || chessBoard[j, fileX - fileY + j] == pieces[6]
                                    || chessBoard[j, fileX - fileY + j] == pieces[7]
                                    || chessBoard[j, fileX - fileY + j] == pieces[8]
                                    || chessBoard[j, fileX - fileY + j] == pieces[9]
                                    || chessBoard[j, fileX - fileY + j] == pieces[10]
                                    || chessBoard[j, fileX - fileY + j] == pieces[11])
                                    {
                                        isBlocked = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = i; j + 1> fileX + 1; j--)
                            {
                                //Change values inside square brackets
                                if (chessBoard[fileY - fileX + j, j] == pieces[0]
                                    || chessBoard[fileY - fileX + j, j] == pieces[1]
                                    || chessBoard[fileY - fileX + j, j] == pieces[2]
                                    || chessBoard[fileY - fileX + j, j] == pieces[3]
                                    || chessBoard[fileY - fileX + j, j] == pieces[4]
                                    || chessBoard[fileY - fileX + j, j] == pieces[5]
                                    || chessBoard[fileY - fileX + j, j] == pieces[6]
                                    || chessBoard[fileY - fileX + j, j] == pieces[7]
                                    || chessBoard[fileY - fileX + j, j] == pieces[8]
                                    || chessBoard[fileY - fileX + j, j] == pieces[9]
                                    || chessBoard[fileY - fileX + j, j] == pieces[10]
                                    || chessBoard[fileY - fileX + j, j] == pieces[11])
                                {
                                    isBlocked = true;
                                }
                            }
                        }

                        if (!isBlocked && initial == "")
                        {
                            chessBoard[i, fileX - fileY + i] = ' ';
                            return;
                        }
                        else if (int.TryParse(initial, out _) && initial != "")
                        {
                            if (chessBoard[i, fileX - fileY + i] == bishop && i == 8 - Convert.ToInt16(initial))
                            {
                                chessBoard[i, fileX - fileY + i] = ' ';
                                return;
                            }
                        }
                        else if (initial != "")
                        {
                            var a = getFilePosition(Convert.ToChar(initial));
                            if (chessBoard[i, fileX - fileY + i] == bishop && fileX - fileY + i == a)
                            {
                                chessBoard[i, fileX - fileY + i] = ' ';
                                return;
                            }
                        }
                    }
                    i++;
                }
            }
        }


        private void rookMoves(string pgnMove, char[,] chessBoard, Turn turn)
        {
            char rook = BlackRook;
            if (turn == Turn.White)
            {
                rook = WhiteRook;
            }
            pgnMove = Regex.Replace(pgnMove, "x", string.Empty);

            if (pgnMove.Length == 3)
            {
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1));
                removeHorizontal(fileX, fileY, chessBoard, turn, WhiteRook, BlackRook);
                chessBoard[fileY, fileX] = rook;
            }
            else if (pgnMove.Length == 4)
            {
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(2, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(3, 1));
                removeHorizontal(fileX, fileY, chessBoard, turn, WhiteRook, BlackRook, pgnMove.Substring(1, 1));
                chessBoard[fileY, fileX] = rook;
            }
            else
            {
                pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(3, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(4, 1));
                chessBoard[fileY, fileX] = rook;
                int originalX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1))); ;
                int originalY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1)); ;
                chessBoard[originalY, originalX] = ' ';
            }
        }

        private void removeHorizontal(int fileX, int fileY, char[,] chessBoard, Turn turn, char whitePiece, char blackPiece, string initial = "")
        {
            char piece = whitePiece;
            if (turn == Turn.Black)
            {
                piece = blackPiece;
            }

            for (int i = 0; i < 8; i++)
            {

                if (chessBoard[fileY, i] == piece)
                {
                    bool isBlocked = false;
                    isBlocked = checkIfBlockedX(chessBoard, fileX, fileY, i);
                    if (!isBlocked && initial == "")
                    {
                        chessBoard[fileY, i] = ' ';
                        return;
                    }
                    if (initial != "")
                    {
                        if (int.TryParse(initial, out _))
                        {
                            if (chessBoard[fileY, 8 - Convert.ToInt32(initial)] == piece)
                            {
                                chessBoard[fileY,8 - Convert.ToInt32(initial)] = ' ';
                                return;
                            }
                        }
                        else
                        {
                            var a = getFilePosition(Convert.ToChar(initial));
                            if (chessBoard[fileY, a] == piece)// && fileX == a)
                            {
                                chessBoard[fileY, a] = ' ';
                                return;
                            }
                        } 
                    }
                }
                if (chessBoard[i, fileX] == piece)
                {
                    bool isBlocked = false;

                    isBlocked = checkIfBlockedY(chessBoard, fileX, fileY, i);
                    if (!isBlocked && initial == "")
                    {
                        chessBoard[i, fileX] = ' ';
                        return;
                    }
                    if (initial != "")
                    {
                        if (int.TryParse(initial, out _))
                        {
                            if (chessBoard[8 - Convert.ToInt32(initial), fileX] == piece)
                            {                                       
                                chessBoard[8 - Convert.ToInt32(initial), fileX] = ' ';
                                return;
                            }
                        }
                        else
                        {
                            var a = getFilePosition(Convert.ToChar(initial));
                            if (chessBoard[i, a] == piece)
                            {
                                chessBoard[i, a] = ' ';
                                return;
                            }
                        }
                    }
                }
            }
        }
        private bool checkIfBlockedX(char[,] chessBoard, int fileX, int fileY, int counter)
        {
            List<char> pieces = new List<char> { BlackKing, BlackQueen, BlackRook, BlackBishop, BlackKnight, BlackPawn,
                WhiteKing, WhiteQueen, WhiteRook, WhiteBishop, WhiteKnight, WhitePawn};

            if (counter < fileX)
            {
                for (int j = counter + 1; j < fileX; j++)
                {
                    if (chessBoard[fileY, j] == pieces[0]
                        || chessBoard[fileY, j] == pieces[1]
                        || chessBoard[fileY, j] == pieces[2]
                        || chessBoard[fileY, j] == pieces[3]
                        || chessBoard[fileY, j] == pieces[4]
                        || chessBoard[fileY, j] == pieces[5]
                        || chessBoard[fileY, j] == pieces[6]
                        || chessBoard[fileY, j] == pieces[7]
                        || chessBoard[fileY, j] == pieces[8]
                        || chessBoard[fileY, j] == pieces[9]
                        || chessBoard[fileY, j] == pieces[10]
                        || chessBoard[fileY, j] == pieces[11])
                    {
                        return true;
                    }
                }
            }
            if (counter > fileX)
            {
                for (int j = counter - 1; j > fileX; j--)
                {
                    if (chessBoard[fileY, j] == pieces[0]
                        || chessBoard[fileY, j] == pieces[1]
                        || chessBoard[fileY, j] == pieces[2]
                        || chessBoard[fileY, j] == pieces[3]
                        || chessBoard[fileY, j] == pieces[4]
                        || chessBoard[fileY, j] == pieces[5]
                        || chessBoard[fileY, j] == pieces[6]
                        || chessBoard[fileY, j] == pieces[7]
                        || chessBoard[fileY, j] == pieces[8]
                        || chessBoard[fileY, j] == pieces[9]
                        || chessBoard[fileY, j] == pieces[10]
                        || chessBoard[fileY, j] == pieces[11])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool checkIfBlockedY(char[,] chessBoard, int fileX, int fileY, int counter)
        {
            List<char> pieces = new List<char> { BlackKing, BlackQueen, BlackRook, BlackBishop, BlackKnight, BlackPawn,
                WhiteKing, WhiteQueen, WhiteRook, WhiteBishop, WhiteKnight, WhitePawn};

            if (counter < fileY)
            {
                for (int j= counter + 1; j < fileY; j++)
                {
                    if (chessBoard[j, fileX] == pieces[0]
                        || chessBoard[j, fileX] == pieces[1]
                        || chessBoard[j, fileX] == pieces[2]
                        || chessBoard[j, fileX] == pieces[3]
                        || chessBoard[j, fileX] == pieces[4]
                        || chessBoard[j, fileX] == pieces[5]
                        || chessBoard[j, fileX] == pieces[6]
                        || chessBoard[j, fileX] == pieces[7]
                        || chessBoard[j, fileX] == pieces[8]
                        || chessBoard[j, fileX] == pieces[9]
                        || chessBoard[j, fileX] == pieces[10]
                        || chessBoard[j, fileX] == pieces[11])
                    {
                        return true;
                    }
                }
            }
            if (counter > fileY)
            {
                for (int j = counter - 1; j > fileY; j--)
                {
                    if (chessBoard[j, fileX] == pieces[0]
                        || chessBoard[j, fileX] == pieces[1]
                        || chessBoard[j, fileX] == pieces[2]
                        || chessBoard[j, fileX] == pieces[3]
                        || chessBoard[j, fileX] == pieces[4]
                        || chessBoard[j, fileX] == pieces[5]
                        || chessBoard[j, fileX] == pieces[6]
                        || chessBoard[j, fileX] == pieces[7]
                        || chessBoard[j, fileX] == pieces[8]
                        || chessBoard[j, fileX] == pieces[9]
                        || chessBoard[j, fileX] == pieces[10]
                        || chessBoard[j, fileX] == pieces[11])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void queenMoves(string pgnMove, char[,] chessBoard, Turn turn)
        {
            char queen;
            if (turn == Turn.White)
            {
                queen = WhiteQueen;
            }
            else
            {
                queen = BlackQueen;
            }
            pgnMove = Regex.Replace(pgnMove, "x", string.Empty);

            if (pgnMove.Length == 3)
            {
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1));
                removeHorizontal(fileX, fileY, chessBoard, turn, WhiteQueen, BlackQueen);
                removeDiagonal(fileX, fileY, chessBoard, turn, WhiteQueen, BlackQueen);
                chessBoard[fileY, fileX] = queen;
            }
            else if (pgnMove.Length == 4)
            {
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(2, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(3, 1));
                removeDiagonal(fileX, fileY, chessBoard, turn, WhiteQueen, BlackQueen, pgnMove.Substring(1, 1));
                removeHorizontal(fileX, fileY, chessBoard, turn, WhiteQueen, BlackQueen, pgnMove.Substring(1, 1));
                chessBoard[fileY, fileX] = queen;
            }
            else
            {
                pgnMove = Regex.Replace(pgnMove, "x", string.Empty);
                int fileX = getFilePosition(Convert.ToChar(pgnMove.Substring(3, 1)));
                int fileY = 8 - Convert.ToInt32(pgnMove.Substring(4, 1));
                chessBoard[fileY, fileX] = queen;
                int originalX = getFilePosition(Convert.ToChar(pgnMove.Substring(1, 1))); ;
                int originalY = 8 - Convert.ToInt32(pgnMove.Substring(2, 1)); ;
                chessBoard[originalY, originalX] = ' ';
            }
        }

        public int getFilePosition(char character)
        {
            int fileX = 0;
            switch (character)
            {
                case 'b':
                    fileX = 1;
                    break;
                case 'c':
                    fileX = 2;
                    break;
                case 'd':
                    fileX = 3;
                    break;
                case 'e':
                    fileX = 4;
                    break;
                case 'f':
                    fileX = 5;
                    break;
                case 'g':
                    fileX = 6;
                    break;
                case 'h':
                    fileX = 7;
                    break;
            }
            return fileX;
        }

        private bool IsOnBoard(int x, int y)
        {
            if (x <= 7 && x >= 0 && y <= 7 && y >= 0)

                return true;
            return false;
        }
    }
}
