using ChessProject.Board;
using ChessProject.Chess;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    PieceImpress(chessBoard.PiecePositon(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void BoardImpress(ChessBoard chessBoard, bool[,] possibleMoviments)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < chessBoard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessBoard.Columns; j++)
                {
                    if (possibleMoviments[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PieceImpress(chessBoard.PiecePositon(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadPlayerInput()
        {
            string s = Console.ReadLine();
            ValidateInput(s);
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void ValidateInput(string input)
        {
            if (!input.Length.Equals(2))
                throw new BoardException("Insert a valid position.");

            List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            List<int> numbers = new List<int> { '1', '2', '3', '4', '5', '6', '7', '8' };

            var newletter = letters.FirstOrDefault(l => l.Equals(input[0]));
            if (newletter.Equals('\0'))
                throw new BoardException("Insert a valid position.");

            var newNumb = numbers.FirstOrDefault(n => n.Equals(input[1]));
            if (newNumb.Equals('\0'))
                throw new BoardException("Insert a valid position.");
        }
        public static void PrintGame(ChessGame game)
        {
            BoardImpress(game.ChessBoard);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Shift: " + game.Shift);
            if (!game.Finished)
            {
                Console.WriteLine("Waiting move: " + game.CurrentPlayer);
                if (game.GameInCheck)
                    Console.WriteLine("Check!");
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Winner: " + game.CurrentPlayer);
            }
        }
        public static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintSet(game.PieceCaptureds(Color.Branca));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintSet(game.PieceCaptureds(Color.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }
        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
        public static void PieceImpress(Piece piec)
        {
            if (piec == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
