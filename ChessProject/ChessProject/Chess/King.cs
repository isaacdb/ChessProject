using ChessProject.Board;


namespace ChessProject.Chess
{
    class King:Piece
    {
        public King(ChessBoard chessBoard, Color color) : base(color, chessBoard)
        {
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[ChessBoard.Lines, ChessBoard.Columns];

            Position pos = new Position(0, 0);

            //acima
            pos.DefineValues(Position.Line - 1, Position.Column);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //esquerda
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //direita
            pos.DefineValues(Position.Line, Position.Column-1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //nordeste
            pos.DefineValues(Position.Line - 1, Position.Column-1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //noroeste
            pos.DefineValues(Position.Line - 1, Position.Column+1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //sudeste
            pos.DefineValues(Position.Line + 1, Position.Column-1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //sudoeste
            pos.DefineValues(Position.Line + 1, Position.Column+1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
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
            return "K";
        }

    }
}
