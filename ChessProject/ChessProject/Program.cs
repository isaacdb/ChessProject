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

                    Console.Write("Origem: ");
                    Position origin = Screen.ReadPlayerInput().toPosition();

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
