using ChessProject.Board;
using System;
namespace ChessProject.Chess
{
    class ChessGame
    {
        public ChessBoard ChessBoard { get; set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            ChessBoard = new ChessBoard(8, 8);
            Shift = 1;
            CurrentPlayer = Color.Branca;
            Finished = false;
            PutPieces();
        }
        public void PerformsMove(Position origin, Position destiny)
        {
            RunMoviment(origin, destiny);
            Shift++;
            ChangePlayer();

        }
        public void ValidateOriginPosition(Position pos)
        {
            if(ChessBoard.PiecePosition(pos) == null)
            {
                throw new BoardException("Dont have piece in the chosed position");
            }
            if (CurrentPlayer != ChessBoard.PiecePosition(pos).Color)
            {
                throw new BoardException("The origin piece chosed is'nt your");
            }
            if (!ChessBoard.PiecePosition(pos).ExistPossibleMovies())
            {
                throw new BoardException("Dont have possible moviments for piece chosed");
            }
        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!ChessBoard.PiecePosition(origin).CanMoveFor(destiny))
                throw new BoardException("Chose a valid position for destiny!");
        }
        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Branca)
                CurrentPlayer = Color.Preta;
            else
                CurrentPlayer = Color.Branca;
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
            ChessBoard.InsertPiece(new King(ChessBoard, Color.Preta), new ChessPosition('c', 8).toPosition());
        }
    }
}
