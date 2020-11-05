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
        public abstract bool[,] PossibleMoviments();
    }
}
