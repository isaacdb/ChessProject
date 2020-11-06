using ChessProject.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.Chess
{
    class Horse:Piece
    {
        public Horse(ChessBoard chessBoard, Color color) : base(color, chessBoard)
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

            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;
            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;
            pos.DefineValues(Position.Line - 2, Position.Column +1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;
            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;
            pos.DefineValues(Position.Line + 2, Position.Column + 1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;
            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;
            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            return mat;
        }
        public override string ToString()
        {
            return "H";
        }
    }
}
