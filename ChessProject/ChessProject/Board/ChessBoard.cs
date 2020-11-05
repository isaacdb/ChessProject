namespace ChessProject.Board
{
    class ChessBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; private set; }

        public ChessBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }
        public Piece PiecePositon(int line, int column)
        {
            return Pieces[line, column];
        }
        public Piece PiecePosition(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }
        public bool ExistPiece(Position pos)
        {
            ValidadePosition(pos);
            return PiecePosition(pos) != null;
        }
        public void InsertPiece(Piece piec, Position pos)
        {
            if (ExistPiece(pos))
                throw new BoardException("Piece exist on this position");
            Pieces[pos.Line, pos.Column] = piec;
            piec.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
                return false;
            else
                return true;
        }
         public void ValidadePosition(Position pos)
        {
            if (!ValidPosition(pos))
                throw new BoardException("invalid Positon!");
        }
    }
}
