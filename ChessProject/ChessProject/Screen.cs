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
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessBoard.Columns; j++)
                {
                    if (chessBoard.PiecePositon(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        PieceImpress(chessBoard.PiecePositon(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PieceImpress(Piece piec)
        {
            if (piec.Color == Color.Branca)
                Console.Write(piec);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(piec);
                Console.ForegroundColor = aux;
            }
        }
    }
}
