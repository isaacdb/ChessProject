using ChessProject.Board;
using System.Collections.Generic;

namespace ChessProject.Chess
{
    class ChessGame
    {
        public ChessBoard ChessBoard { get; set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public HashSet<Piece> FreePieces { get;  private set; }
        public HashSet<Piece> CapturedPieces { get; set; }

        public ChessGame()
        {
            ChessBoard = new ChessBoard(8, 8);
            Shift = 1;
            CurrentPlayer = Color.Branca;
            Finished = false;
            FreePieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
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
            if (CapturedPiece != null)
                CapturedPieces.Add(CapturedPiece);
        }
        public HashSet<Piece> PieceCaptureds(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in CapturedPieces)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            return aux;
        }
        public HashSet<Piece> PiecesOnGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in FreePieces)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            aux.ExceptWith(PieceCaptureds(color));
            return aux;

        }
        public void PutNewPiece(char column, int line, Piece piec)
        {
            ChessBoard.InsertPiece(piec, new ChessPosition(column, line).toPosition());

        }
        public void PutPieces()
        {
            PutNewPiece('c',1,new Tower( ChessBoard,Color.Branca));
            PutNewPiece('c',7,new King( ChessBoard,Color.Preta));
        }
    }
}
