using ChessProject.Board;
using ChessProject.Chess;
using Microsoft.Win32.SafeHandles;
using System;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame game = new ChessGame();
                while (!game.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGame(game);

                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPlayerInput().toPosition();
                        game.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = game.ChessBoard.PiecePosition(origin).PossibleMoviments();

                        Console.Clear();
                        Screen.BoardImpress(game.ChessBoard, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadPlayerInput().toPosition();
                        game.ValidateDestinyPosition(origin, destiny);
                        game.PerformsMove(origin, destiny);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
