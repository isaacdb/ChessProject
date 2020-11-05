using ChessProject.Board;


namespace ChessProject.Chess
{
    class Tower : Piece
    {
        public Tower(ChessBoard chessBoard, Color color) : base(color, chessBoard)
        {
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[ChessBoard.Lines, ChessBoard.Columns];

            Position pos = new Position(0, 0);

            //acima
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //direita
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            //esquerda
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            return mat;
        }
        private bool CanMove(Position pos)
        {
            Piece p = ChessBoard.PiecePosition(pos);
            return p == null || p.Color != Color;
        }

        public override string ToString()
        {
            return "T";
        }

    }
}