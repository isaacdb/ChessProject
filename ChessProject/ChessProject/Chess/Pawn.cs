using ChessProject.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.Chess
{
    class Pawn:Piece
    {
        public ChessGame Game { get; private set; }

        public Pawn(ChessBoard chessBoard, Color color, ChessGame game) : base(color, chessBoard)
        {
            Game = game;
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

                //#jogada especial EnPassant
                if(Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(ChessBoard.ValidPosition(left) && ExistEnimie(left) && ChessBoard.PiecePosition(left) == Game.VulnerableForEnPassant)
                    {
                        mat[left.Line-1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (ChessBoard.ValidPosition(right) && ExistEnimie(right) && ChessBoard.PiecePosition(right) == Game.VulnerableForEnPassant)
                    {
                        mat[right.Line-1, right.Column] = true;
                    }
                }
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

                //#jogada especial EnPassant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (ChessBoard.ValidPosition(left) && ExistEnimie(left) && ChessBoard.PiecePosition(left) == Game.VulnerableForEnPassant)
                    {
                        mat[left.Line+1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (ChessBoard.ValidPosition(right) && ExistEnimie(right) && ChessBoard.PiecePosition(right) == Game.VulnerableForEnPassant)
                    {
                        mat[right.Line+1, right.Column] = true;
                    }
                }

            }
            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
