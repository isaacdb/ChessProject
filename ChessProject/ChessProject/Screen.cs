using ChessProject.Board;
using System;

namespace ChessProject
{
    class Screen
    {
        public static void BoardImpress(ChessBoard chessBoard)
        {
            for (int i = 0; i < chessBoard.Lines; i++)
            {
                for (int j = 0; j < chessBoard.Columns; j++)
                {
                    if (chessBoard.PiecePositon(i, j) == null)
                        Console.Write("- ");
                    else
                        Console.Write(chessBoard.PiecePositon(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
