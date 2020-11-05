using ChessProject.Board;
using System;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessBoard chessBoard = new ChessBoard(8, 8);

            Screen.BoardImpress(chessBoard);
        }
    }
}
