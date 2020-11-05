using ChessProject.Board;
using System;
namespace ChessProject.Chess
{
    class ChessGame
    {
        public ChessBoard ChessBoard { get; set; }
        public int Shift { get; set; }
        public Color CurrentPlayer { get; set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            ChessBoard = new ChessBoard(8, 8);
            Shift = 1;
            CurrentPlayer = Color.Branca;
            Finished = false;
            PutPieces();
        }
        public void RunMoviment(Position origin, Position destiny)
        {
            Piece p = ChessBoard.RemovePiece(origin);
            p.IncrementQnttMovies();
            Piece CapturedPiece = ChessBoard.RemovePiece(destiny);
            ChessBoard.InsertPiece(p, destiny);
        }
        public void PutPieces()
        {
            ChessBoard.InsertPiece(new Tower(ChessBoard, Color.Branca), new ChessPosition('c', 1).toPosition());
        }
    }
}
