namespace ChessProject.Board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }
    }
}
