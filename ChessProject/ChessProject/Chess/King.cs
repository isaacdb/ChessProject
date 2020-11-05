using ChessProject.Board;


namespace ChessProject.Chess
{
    class King:Piece
    {
        public King(ChessBoard chessBoard, Color color) : base(color, chessBoard)
        {
        }

        public override string ToString()
        {
            return "K";
        }

    }
}
