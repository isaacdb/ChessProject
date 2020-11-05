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
        public void InsertPiece(Piece piec, Position pos)
        {
            Pieces[pos.Line, pos.Column] = piec;
            piec.Position = pos;
        }
    }
}
