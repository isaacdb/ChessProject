using ChessProject.Board;


namespace ChessProject.Chess
{
    class Tower : Piece
    {
        public Tower(ChessBoard chessBoard, Color color) : base(color, chessBoard)
        {
        }

        public override string ToString()
        {
            return "T";
        }

    }
}