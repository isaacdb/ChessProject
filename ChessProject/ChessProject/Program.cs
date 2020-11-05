using ChessProject.Board;
using ChessProject.Chess;
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
                    Console.Clear();
                    Screen.BoardImpress(game.ChessBoard);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadPlayerInput().toPosition();

                    bool[,] possiblePositions = game.ChessBoard.PiecePosition(origin).PossibleMoviments();

                    Console.Clear();
                    Screen.BoardImpress(game.ChessBoard, possiblePositions);
                    
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadPlayerInput().toPosition();

                    game.RunMoviment(origin, destiny);

                }
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
