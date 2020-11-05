using ChessProject.Board;
using ChessProject.Chess;
using System;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessBoard chessBoard = new ChessBoard(8, 8);

            chessBoard.InsertPiece(new King(chessBoard, Color.Preta), new Position(1, 3));
            chessBoard.InsertPiece(new Tower(chessBoard, Color.Branca), new Position(0, 3));
            chessBoard.InsertPiece(new King(chessBoard, Color.Preta), new Position(7, 7));
            chessBoard.InsertPiece(new Tower(chessBoard, Color.Branca), new Position(1, 6));

            Screen.BoardImpress(chessBoard);
        }
    }
}
