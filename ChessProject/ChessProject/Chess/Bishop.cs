using ChessProject.Board;

namespace ChessProject.Chess
{
    class Bishop:Piece
    {
        public Bishop(ChessBoard chessBoard, Color color) : base(chessBoard, color)
        {
        }
        private bool CanMove(Position pos)
        {
            Piece p = ChessBoard.PiecePosition(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[ChessBoard.Lines, ChessBoard.Columns];

            Position pos = new Position(0, 0);

            //NO
            pos.DefineValues(Position.Line - 1, Position.Column-1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
            }
            //NE
            pos.DefineValues(Position.Line - 1, Position.Column+1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }
            //SO
            pos.DefineValues(Position.Line +1, Position.Column - 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
            pos.DefineValues(pos.Line +1, pos.Column - 1);
            }
            //SE
            pos.DefineValues(Position.Line +1, Position.Column + 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
            pos.DefineValues(pos.Line +1, pos.Column +1);
            }
            return mat;
        }
        public override string ToString()
        {
            return "B";
        }
    }
}
