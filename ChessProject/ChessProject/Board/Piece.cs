namespace ChessProject.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QnttMovies { get; protected set; }
        public ChessBoard ChessBoard { get; protected set; }

        public Piece(Color color, ChessBoard chessBoard)
        {
            //  Position = null;
            Color = color;
            ChessBoard = chessBoard;
        }
        public void IncrementQnttMovies()
        {
            QnttMovies++;
        }
        public bool ExistPossibleMovies()
        {
            bool[,] mat = PossibleMoviments();
            for (int i = 0; i < ChessBoard.Lines; i++)
            {
                for (int j = 0; j < ChessBoard.Columns; j++)
                {
                    if (mat[i, j])
                        return true;


                }
            }
            return false;

        }
        public bool CanMoveFor(Position pos)
        {
            return PossibleMoviments()[pos.Line, pos.Column];
        }



        public abstract bool[,] PossibleMoviments();
    }
}

