using ChessProject.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.Chess
{
    class Pawn:Piece
    {
        public Pawn(ChessBoard chessBoard, Color color) : base(color, chessBoard)
        {
        }
        private bool CanMove(Position pos)
        {
            Piece p = ChessBoard.PiecePosition(pos);
            return p == null || p.Color != Color;
        }
        private bool ExistEnimie(Position pos)
        {
            Piece p = ChessBoard.PiecePosition(pos);
            return p != null && p.Color != Color;
        }
        private bool Free(Position pos)
        {
            return ChessBoard.PiecePosition(pos) == null;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[ChessBoard.Lines, ChessBoard.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.Branca)
            {

                pos.DefineValues(Position.Line - 1, Position.Column);
                if (ChessBoard.ValidPosition(pos) && Free(pos))
                    mat[pos.Line, pos.Column] = true;
                pos.DefineValues(Position.Line - 2, Position.Column);
                if (ChessBoard.ValidPosition(pos) && Free(pos) && QnttMovies == 0)
                    mat[pos.Line, pos.Column] = true;
                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (ChessBoard.ValidPosition(pos) && ExistEnimie(pos))
                    mat[pos.Line, pos.Column] = true;
                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (ChessBoard.ValidPosition(pos) && ExistEnimie(pos))
                    mat[pos.Line, pos.Column] = true;
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (ChessBoard.ValidPosition(pos) && Free(pos))
                    mat[pos.Line, pos.Column] = true;
                pos.DefineValues(Position.Line + 2, Position.Column);
                if (ChessBoard.ValidPosition(pos) && Free(pos) && QnttMovies == 0)
                    mat[pos.Line, pos.Column] = true;
                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (ChessBoard.ValidPosition(pos) && ExistEnimie(pos))
                    mat[pos.Line, pos.Column] = true;
                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (ChessBoard.ValidPosition(pos) && ExistEnimie(pos))
                    mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
